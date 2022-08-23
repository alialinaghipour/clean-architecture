using Microsoft.AspNetCore.Identity;

namespace WebMvc.Infrastructure.PersianTranslate;

public class IdentityErrorPersian : IdentityErrorDescriber
{
    public override IdentityError DuplicateEmail(string email)
    {
        return new()
        {
            Code = nameof(DuplicateEmail),
            Description = $"'{email}' ایمیل وارد شده ، تکراری است"
        };
    }

    public override IdentityError InvalidEmail(string email)
    {
        return new()
        {
            Code = nameof(InvalidEmail),
            Description = $"این ایمیل '{email}' ،معتبر نیست"
        };
    }

    public override IdentityError DuplicateRoleName(string role)
    {
        return new()
        {
            Code = nameof(DuplicateRoleName),
            Description = $"'{role}' نقش وارد شده ، تکراری است"
        };
    }

    public override IdentityError InvalidRoleName(string role)
    {
        return new()
        {
            Code = nameof(InvalidRoleName),
            Description = $"این نقش '{role}' ،معتبر نیست"
        };
    }

    public override IdentityError UserNotInRole(string role)
    {
        return new()
        {
            Code = nameof(UserNotInRole),
            Description = $"کاربر در این نقش '{role}'، نیست"
        };
    }

    public override IdentityError UserAlreadyInRole(string role)
    {
        return new()
        {
            Code = nameof(UserAlreadyInRole),
            Description = $"کاربر قبلا این نقش '{role}'، را داشت"
        };
    }

    public override IdentityError DuplicateUserName(string userName)
    {
        return new()
        {
            Code = nameof(DuplicateRoleName),
            Description = $"'{userName}' نام کاربری وارد شده ، تکراری است"
        };
    }

    public override IdentityError InvalidUserName(string userName)
    {
        return new()
        {
            Code = nameof(InvalidUserName),
            Description = $"این کاربر '{userName}' ،معتبر نیست"
        };
    }


    public override IdentityError UserAlreadyHasPassword()
    {
        return new()
        {
            Code = nameof(UserAlreadyHasPassword),
            Description = "کاربر قبلا کلمه ی عبور داشت"
        };
    }

    public override IdentityError PasswordTooShort(int length)
    {
        return new()
        {
            Code = nameof(PasswordTooShort),
            Description =
                $"تعداد کاراکتر های کلمه ی عبور باید بیشتر از '{length}' باشد"
        };
    }
}