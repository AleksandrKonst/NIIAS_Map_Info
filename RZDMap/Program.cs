using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RZDMap.Data;
using RZDMap.Services;
using RZDMap.Services.Email;
using RZDMap.Services.Token;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GeoNiiasContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("TicketContext")));
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(opt => 
    {
        {
            opt.Password.RequireDigit = false;
            opt.Password.RequireLowercase = false;
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequireUppercase = false;
            opt.Password.RequiredLength = 4;
            opt.User.RequireUniqueEmail = true;
            opt.SignIn.RequireConfirmedEmail = true;
        }
    })
    .AddEntityFrameworkStores<GeoNiiasContext>().AddDefaultTokenProviders();

builder.Services.AddAuthentication(cfg =>
{
    cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:Key"])),
        ValidIssuer = builder.Configuration["Token:Issuer"],
        ValidateIssuer = true,
        ValidateAudience = false,
    };
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ManagerDevelopers", md =>
    {
        md.RequireClaim("JobTitle", "Developer");
        md.RequireRole("Manager");
    });
    options.AddPolicy("AdminDevelopers", ad =>
    {
        ad.RequireClaim("JobTitle", "Developer");
        ad.RequireRole("Administrator");
    });
});

builder.Services.AddControllers();
builder.Services.AddApiVersioning();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHealthChecks();

builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddTransient<IStationService, StationService>();
builder.Services.AddTransient<IMapLineService, MapLineService>();
builder.Services.AddSingleton<IEmailSender, EmailSender>();

builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp/dist";
});

var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();

#pragma warning disable ASP0014
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks("/health");
});
#pragma warning restore ASP0014

if (!app.Environment.IsDevelopment())
{
    app.UseSpaStaticFiles();
}
app.UseSpa(spa =>
{
    spa.Options.SourcePath = "ClientApp";
 
    if (app.Environment.IsDevelopment())
    {
        spa.UseAngularCliServer(npmScript: "start");
    }
});

app.Run();