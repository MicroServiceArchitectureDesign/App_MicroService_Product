namespace AppMicroServiceProduct.Domain.Products.Enums;

public record Units : BaseEnumeration<Units>
{
    public new short Value { get; set; }

    private Units(short value, string displayName)
        : base(value, displayName)
    {
        Value = value;
    }

    public static Units G = new(1, "گِرَم");
    public static Units Kg = new(2, "کیلو گِرَم");
    public static Units Cm = new(3, "سانتی متر");
    public static Units Mm = new(4, "میلی متر");

    public static List<Units> Weights()
    {
        return new List<Units>() { G, Kg };
    }
    
    public static  List<Units> Distance()
    {
        return new List<Units>() { Cm, Mm };
    }
    
}