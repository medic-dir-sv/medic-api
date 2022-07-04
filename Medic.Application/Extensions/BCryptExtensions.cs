namespace Medic.Services.Extensions;

public static class BCryptExtensions
{
    public static string HashPassword(this string toHash)
    {
        return BCrypt.Net.BCrypt.HashPassword(toHash);
    }

    public static bool VerifyPassword(this string toVerify, string hashed)
    {
        return BCrypt.Net.BCrypt.Verify(toVerify, hashed);
    }
}