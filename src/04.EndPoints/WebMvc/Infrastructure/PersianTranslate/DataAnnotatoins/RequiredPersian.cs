using System.ComponentModel.DataAnnotations;

namespace WebMvc.Infrastructure.PersianTranslate.DataAnnotatoins;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field |
                AttributeTargets.Parameter)]
public class RequiredPersian : RequiredAttribute
{
    public override string FormatErrorMessage(string name)
    {
        return $"وارد کردن '{name}'،الزامی است";
    }
}