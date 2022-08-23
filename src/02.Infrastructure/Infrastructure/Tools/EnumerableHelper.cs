namespace Infrastructure.Tools;

public static class EnumerableHelper
{
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        using var enumerator = source.GetEnumerator();
        while (enumerator.MoveNext()) action(enumerator.Current);
    }

    public static void ForEach<T>(this IEnumerable<T> source,
        Action<T, int> action)
    {
        using var enumerator = source.GetEnumerator();
        var index = 0;
        while (enumerator.MoveNext())
        {
            action(enumerator.Current, index);
            ++index;
        }
    }

    public static IEnumerable<T> Exclude<T>(this IEnumerable<T> source, T item)
    {
        using var enumerator = source.GetEnumerator();
        while (enumerator.MoveNext())
            if (Equals(enumerator.Current, item) == false)
                yield return enumerator.Current;
    }

    public static bool SetEquals<T>(this IEnumerable<T> source,
        IEnumerable<T> second)
    {
        return new HashSet<T>(source).SetEquals(second);
    }

    public static bool IsEnumerable(Type type)
    {
        return IsEnumerable(type, out _);
    }

    public static bool IsEnumerable(Type type, out Type? underlyingType)
    {
        underlyingType = type.IsInterface && type.IsGenericType &&
                         type.GetGenericTypeDefinition() ==
                         typeof(IEnumerable<>)
            ? type.GetGenericArguments()[0]
            : type.GetInterfaces().FirstOrDefault(IsEnumerable)
                ?.GetGenericArguments()[0];
        return underlyingType != null;
    }
}