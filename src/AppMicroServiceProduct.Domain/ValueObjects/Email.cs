using System.Text.RegularExpressions;

namespace AppMicroServiceProduct.Domain.ValueObjects;

public class Email : BaseValueObject<Email>
{
    public string Value { get; private set; } = null!;
    public static Email FromString(string value) => new(value);
    private Email()
    {

    }

    public Email(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException("وارد کردن مقدار آدرس ایمیل الزامیست");
        }
        
        if (!new Regex("Regexes.Email").IsMatch(value))
        {
            throw new InvalidDataException("فرمت آدرس ایمیل معتبر نمی باشد");
        }

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
