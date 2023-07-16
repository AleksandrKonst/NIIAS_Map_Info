using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace RZDMap.Services.Token;

public interface IJwtTokenGenerator
{
    string GenerateToken(IdentityUser user, IList<string> roles, IList<Claim> claims);
}