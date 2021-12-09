using System;

namespace API;

public class Env
{
    public class TokenExpirationTime
    {
        public static TimeSpan OneDay = TimeSpan.FromDays(1);
        public static TimeSpan SevenDays = TimeSpan.FromDays(7);
    }
        
    public class IdentityClaims
    {
        public const string ID = "id";
        public const string ROLES = "role";
    }
        
    public class Roles
    {
        public const string USER = "User";
        public const string ADMIN = "Admin";
        public const string ALL = "User, Admin";
    }
}