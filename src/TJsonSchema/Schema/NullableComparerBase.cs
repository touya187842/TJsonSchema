using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TJsonSchema.Schema;

public abstract class NullableComparerBase<T> : IEqualityComparer<T?>
{
    public bool Equals(T? x, T? y)
    {
        if (x is null && y is null)
        {
            return true;
        }

        if (x is null ^ y is null)
        {
            return false;
        }

        return NotNullEquals(x!, y!);
    }

    protected abstract bool NotNullEquals([DisallowNull] T x, [DisallowNull] T y);

    public abstract int GetHashCode([DisallowNull] T obj);
}