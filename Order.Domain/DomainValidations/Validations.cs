using Ardalis.GuardClauses;

namespace Order.Domain.DomainValidations;

public static class Validations
{
    public static void StringLengthLessThanOrEqualTo(string value, int length)
    {
        if ((value?.Length ?? 0) > length)
            throw new ArgumentException($"String {value} length is longer than {length}");
    }

    public static void StringLengthEqualTo(string value, int length)
    {
        if ((value?.Length ?? 0) != length)
            throw new ArgumentException($"String {value} length is not equal as {length}");
    }

    public static void NumberNotNegativeOrEqualTo0(decimal? value)
    {
        if (value is <= 0) throw new ArgumentException($"{value} is a negative number or 0");
    }

    public static void NotNull<T>(T obj)
    {
        Guard.Against.Null(obj, nameof(obj));
    }

    public static void NotNullOrEmpty(string value)
    {
        Guard.Against.NullOrEmpty(value, nameof(value));
    }
}