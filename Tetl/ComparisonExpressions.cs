namespace Tetl;

public class ComparisonExpressions
{
    public bool IsEquals(object? left, object? right)
    {
        if (left is int l && right is int r)
        {
            return l == r;
        }

        if (left is float lf && right is float rf)
        {
            return lf == rf;
        }

        if (left is int lInt && right is float rFloat)
        {
            return lInt == rFloat;
        }

        if (left is float lFloat && right is int rInt)
        {
            return lFloat == rInt;
        }

        if (left is string lString && right is string rString)
        {
            return lString == rString;
        }

        if (left is bool lBool && right is bool rBool)
        {
            return lBool == rBool;
        }

        throw new TetlCannotCompareValuesException()
        {
            ErrorMessage = $"Cannot compare values of {left?.GetType()} and {right?.GetType()}!",
            Left = $"{nameof(left)}: {left}",
            Right = $"{nameof(right)}: {right}"
        };
    }

    public bool NotEquals(object? left, object? right)
    {
        if (left is int l && right is int r)
        {
            return l != r;
        }

        if (left is float lf && right is float rf)
        {
            return lf != rf;
        }

        if (left is int lInt && right is float rFloat)
        {
            return lInt != rFloat;
        }

        if (left is float lFloat && right is int rInt)
        {
            return lFloat != rInt;
        }

        if (left is string lString && right is string rString)
        {
            return lString != rString;
        }

        if (left is bool lBool && right is bool rBool)
        {
            return lBool != rBool;
        }

        throw new TetlCannotCompareValuesException()
        {
            ErrorMessage = $"Cannot compare values of {left?.GetType()} and {right?.GetType()}!",
            Left = $"{nameof(left)}: {left}",
            Right = $"{nameof(right)}: {right}"
        };
    }

    public bool LessThan(object? left, object? right)
    {
        if (left is int l && right is int r)
        {
            return l < r;
        }

        if (left is float lf && right is float rf)
        {
            return lf < rf;
        }

        if (left is int lInt && right is float rFloat)
        {
            return lInt < rFloat;
        }

        if (left is float lFloat && right is int rInt)
        {
            return lFloat < rInt;
        }

        throw new TetlCannotCompareValuesException()
        {
            ErrorMessage = $"Cannot compare values of {left?.GetType()} and {right?.GetType()}!",
            Left = $"{nameof(left)}: {left}",
            Right = $"{nameof(right)}: {right}"
        };
    }

    public bool GreaterThan(object? left, object? right)
    {
        if (left is int l && right is int r)
        {
            return l > r;
        }

        if (left is float lf && right is float rf)
        {
            return lf > rf;
        }

        if (left is int lInt && right is float rFloat)
        {
            return lInt > rFloat;
        }

        if (left is float lFloat && right is int rInt)
        {
            return lFloat > rInt;
        }

        throw new TetlCannotCompareValuesException()
        {
            ErrorMessage = $"Cannot compare values of {left?.GetType()} and {right?.GetType()}!",
            Left = $"{nameof(left)}: {left}",
            Right = $"{nameof(right)}: {right}"
        };
    }

    public bool GreaterThanOrEqual(object? left, object? right)
    {
        if (left is int l && right is int r)
        {
            return l >= r;
        }

        if (left is float lf && right is float rf)
        {
            return lf >= rf;
        }

        if (left is int lInt && right is float rFloat)
        {
            return lInt >= rFloat;
        }

        if (left is float lFloat && right is int rInt)
        {
            return lFloat >= rInt;
        }

        throw new TetlCannotCompareValuesException()
        {
            ErrorMessage = $"Cannot compare values of {left?.GetType()} and {right?.GetType()}!",
            Left = $"{nameof(left)}: {left}",
            Right = $"{nameof(right)}: {right}"
        };
    }

    public bool LessThenOrEqual(object? left, object? right)
    {
        if (left is int l && right is int r)
        {
            return l <= r;
        }

        if (left is float lf && right is float rf)
        {
            return lf <= rf;
        }

        if (left is int lInt && right is float rFloat)
        {
            return lInt <= rFloat;
        }

        if (left is float lFloat && right is int rInt)
        {
            return lFloat <= rInt;
        }

        throw new TetlCannotCompareValuesException()
        {
            ErrorMessage = $"Cannot compare values of {left?.GetType()} and {right?.GetType()}!",
            Left = $"{nameof(left)}: {left}",
            Right = $"{nameof(right)}: {right}"
        };
    }
}