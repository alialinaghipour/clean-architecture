using System.ComponentModel.DataAnnotations;

namespace WebMvc.Infrastructure.PersianTranslate.DataAnnotatoins;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
    AllowMultiple = false)]
public class EmailAddressPersian: RequiredAttribute
{
    public override string FormatErrorMessage(string name)
    {
        return "ایمیل وارد شده معتبر نمی باشد";
    }
}