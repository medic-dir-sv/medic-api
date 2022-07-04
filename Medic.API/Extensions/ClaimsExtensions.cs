using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Medic.API.Extensions;

public static class ClaimsExtensions
{
    public static string GetEmail(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.FindFirstValue("Email");
    
    public static string GetRole(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.FindFirstValue("Role");
}