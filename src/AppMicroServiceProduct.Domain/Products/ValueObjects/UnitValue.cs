namespace AppMicroServiceProduct.Domain.Products.ValueObjects;

public abstract class UnitValue<T> : BaseValueObject<UnitValue<T>>
{
    public virtual required T Value { get; set; }
    public short Unit { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value!;
        yield return Unit;
    }
}
public class IntUnitValue : UnitValue<int> { }
public class FloatUnitValue : UnitValue<double> { }

public class IntNullableUnitValue : UnitValue<int?> { }
public class FloatNullableUnitValue : UnitValue<double?> { }
