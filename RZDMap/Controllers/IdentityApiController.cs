using System.Security.Claims;
using System.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RZDMap.DTO.ViewModels;
using RZDMap.Services.Email;
using RZDMap.Services.Token;

namespace RZDMap.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/identity")]
public class IdentityApiController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IJwtTokenGenerator _jwtToken;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _config;
    private readonly IEmailSender _emailSender;

    public IdentityApiController(UserManager<IdentityUser> userManager, 
        SignInManager<IdentityUser> signInManager, 
        IJwtTokenGenerator jwtToken,
        RoleManager<IdentityRole> roleManager,
        IConfiguration config,
        IEmailSender emailSender)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtToken = jwtToken;
        _roleManager = roleManager;
        _config = config;
        _emailSender = emailSender;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginModel model)
    {
        var userFromDb = await _userManager.FindByNameAsync(model.Username);

        if (userFromDb == null)
        {
            return BadRequest();
        }

        var result = await _signInManager.CheckPasswordSignInAsync(userFromDb, model.Password, false);


        if (!result.Succeeded)
        {
            return BadRequest();
        }
        
        var roles = await _userManager.GetRolesAsync(userFromDb);
        
        IList<Claim> claims = await _userManager.GetClaimsAsync(userFromDb);
        return Ok(new
        {
            result = result,
            username = userFromDb.UserName,
            email = userFromDb.Email,
            token = _jwtToken.GenerateToken(userFromDb, roles, claims)
        });
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        if (!(await _roleManager.RoleExistsAsync(model.Role)))
        {
            await _roleManager.CreateAsync(new IdentityRole(model.Role));
        }
        
        var userToCreate = new IdentityUser
        {
            Email = model.Email,
            UserName = model.Username
        };
        
        var result = await _userManager.CreateAsync(userToCreate, model.Password);

        if (result.Succeeded)
        {
            var userFromDb = await _userManager.FindByNameAsync(userToCreate.UserName);
            
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(userFromDb);
            var uriBuilder = new UriBuilder(_config["ReturnPaths:ConfirmEmail"]);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["token"] = token;
            query["userid"] = userFromDb.Id;
            uriBuilder.Query = query.ToString();
            var urlString = uriBuilder.ToString();
            var senderEmail = _config["ReturnPaths:SenderEmail"];
            await _emailSender.SendEmailAsync(senderEmail, userFromDb.Email, "Confirm your email address", urlString);
            
            await _userManager.AddToRoleAsync(userFromDb, model.Role);
            
            var claim = new Claim("JobTitle", model.JobTitle);

            await _userManager.AddClaimAsync(userFromDb, claim);
            
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpPost]
    [Route("confirmemail")]
    public async Task<IActionResult> ConfirmEmail(ConfirmEmailViewModel model)
    {

        var user = await _userManager.FindByIdAsync(model.UserId);

        var result = await _userManager.ConfirmEmailAsync(user, model.Token);

        if (result.Succeeded)
        {
            return Ok();
        }
        return BadRequest();
    }
}