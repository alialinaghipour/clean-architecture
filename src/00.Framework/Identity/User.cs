namespace Identity;

public class User : IdentityUser<string>
{
}

public class Role : IdentityRole<string>
{
}

public class UserRole : IdentityUserRole<string>
{
}

public class UserClaim : IdentityUserClaim<string>
{
}

public class UserLogin : IdentityUserLogin<string>
{
}

public class RoleClaim : IdentityRoleClaim<string>
{
}

public class UserToken : IdentityUserToken<string>
{
}