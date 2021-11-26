namespace Moksnes.CurrencyConverter.Shared;


public static class WellKnownCurrencies
{
    public static Currency SEK => new Currency(nameof(SEK));
    public static Currency EUR => new Currency(nameof(EUR));
}

public class Currency : IEquatable<Currency>
{
    public string Value { get; }

    public Currency(string value)
    {
        if (!IsValid(value))
            throw new ArgumentException("Not a valid currency", nameof(value));
        Value = value.ToUpper();
    }

    public static bool IsValid(string value)
    {
        // Some sort of simple validation.
        return value.Length == 3;
    }


    public bool Equals(Currency? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Currency) obj);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(Currency? left, Currency? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Currency? left, Currency? right)
    {
        return !Equals(left, right);
    }
}