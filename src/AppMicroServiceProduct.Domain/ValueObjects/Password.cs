namespace AppMicroServiceProduct.Domain.ValueObjects;

public class Password : BaseValueObject<Password>
{
    public string Value { get; private set; } = null!;
    public static Password FromString(string value) => new(value);
    private Password()
    {

    }
    public Password(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentNullException("وارد کردن مقدار کلمه عبور الزامیست");
        //if (!new Regex(Regexes.ComplexPassword).IsMatch(value))
        //    throw new InvalidDataException("کلمه عبور می بایست شامل حداقل یک حروف بزرگ، یک حروف کوچک، یک کارکتر خاص و یک عدد باشد");

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
