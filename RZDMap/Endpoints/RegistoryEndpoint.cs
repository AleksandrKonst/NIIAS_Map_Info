using Microsoft.AspNetCore.Identity;

namespace RZDMap.Endpoints;

public class RegistoryEndpoint
{
    public class RegisterForm
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
    public static async Task<IResult> Handler(RegisterForm form, UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
    {
        if (form.Password != form.ConfirmPassword)
        {
            return Results.BadRequest();
        }

        var user = new IdentityUser() { UserName = form.Username };
        var CreateUserResult = await userManager.CreateAsync(user, form.Password);
        if (!CreateUserResult.Succeeded)
        {
            return Results.BadRequest();
        }
        
        await signInManager.SignInAsync(user, true);
        return Results.Ok();
    }
}