namespace MyAsbo.Service.Helpers;

public static class PasswordHelper
{
    private const int WorkFactor = 12;

    public static string Hash(string password)
    => BCrypt.Net.BCrypt.HashPassword(password, WorkFactor);

    public static bool Verify(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
        

}
