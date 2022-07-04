using Npgsql;

namespace Medic.API.Extensions;

public static class StringExtensions
{
    public static string BuildConnectionStringFromUri(this string conn)
    {
        var dbUri = new Uri(conn);
        var userInfo = dbUri.UserInfo.Split(':');

        var builder = new NpgsqlConnectionStringBuilder
        {
            Host = dbUri.Host,
            Port = dbUri.Port,
            Username = userInfo[0],
            Password = userInfo[1],
            Database = dbUri.LocalPath.TrimStart('/'),
        };

        return builder.ToString();
    }
}