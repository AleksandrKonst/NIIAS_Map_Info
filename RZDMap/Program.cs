using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using RZDMap.Endpoints;
using RZDMapRailwaysApi.Data;
using RZDMapRailwaysApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GeoNiiasContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("TicketContext")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => 
    {
        if (builder.Environment.IsDevelopment())
        {
            options.User.RequireUniqueEmail = false;
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 6;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
        }
    })
    .AddEntityFrameworkStores<GeoNiiasContext>()
    .AddDefaultTokenProviders();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
builder.Services.AddApiVersioning();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthorization();
builder.Services.AddTransient<IStationService, StationService>();
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp/dist";
});

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
#pragma warning disable ASP0014
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers().RequireAuthorization();
    endpoints.MapGet("/api/user", UserEndpoint.Handler);
    endpoints.MapPost("/api/login", LoginEndpoint.Handler);
    endpoints.MapPost("/api/registry", RegistoryEndpoint.Handler);
    endpoints.MapGet("/api/logout", LogoutEndpoint.Handler).RequireAuthorization();
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