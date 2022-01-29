namespace Tetl;

public class MultiplicativeExpressions
{
    #region Multiplication

    public object? Multiplication(object? left, object? right)
    {
        if (left is int l && right is int r)
        {
            return l * r;
        }

        if (left is float lf && right is float rf)
        {
            return lf * rf;
        }

        if (left is int lInt && right is float rFloat)
        {
            return lInt * rFloat;
        }

        if (left is float lFloat && right is int rInt)
        {
            return lFloat * rInt;
        }

        if (left?.GetType() == null && right?.GetType() == null)
        {
            throw new TetlInvalidMultiplicationException()
            {
                ErrorMessage = "Both values are null!",
                Left = $"{nameof(left)}: {left}",
                Right = $"{nameof(right)}: {right}"
            };
        }
        else if ((left?.GetType() == null && right?.GetType() != null) ||
                 (left?.GetType() != null && right?.GetType() == null))
        {
            throw new TetlInvalidMultiplicationException()
            {
                ErrorMessage = "Cannot multiplicate null value!",
                Left = $"{nameof(left)}: {left}",
                Right = $"{nameof(right)}: {right}"
            };
        }
        else
        {
            throw new TetlInvalidMultiplicationException()
            {
                ErrorMessage = $"Cannot multiplicate values of types {left?.GetType()} and {right?.GetType()}",
                Left = $"{nameof(left)}: {left}",
                Right = $"{nameof(right)}: {right}"
            };
        }
    }

    #endregion

    #region Division

    public object? Division(object? left, object? right)
    {
        if (left is int l && right is int r)
        {
            return (float)l / (float)r;
        }

        if (left is float lf && right is float rf)
        {
            return (float)lf / (float)rf;
        }

        if (left is int lInt && right is float rFloat)
        {
            return (int)lInt / (float)rFloat;
        }

        if (left is float lFloat && right is int rInt)
        {
            return (float)lFloat / (int)rInt;
        }

        if (left?.GetType() == null && right?.GetType() == null)
        {
            throw new TetlInvalidDivisionException()
            {
                ErrorMessage = "Both values are null!",
                Left = $"{nameof(left)}: {left}",
                Right = $"{nameof(right)}: {right}"
            };
        }
        else if ((left?.GetType() == null && right?.GetType() != null) ||
                 (left?.GetType() != null && right?.GetType() == null))
        {
            throw new TetlInvalidDivisionException()
            {
                ErrorMessage = "Cannot divide null value!",
                Left = $"{nameof(left)}: {left}",
                Right = $"{nameof(right)}: {right}"
            };
        }
        else
        {
            throw new TetlInvalidDivisionException()
            {
                ErrorMessage = $"Cannot divide values of types {left?.GetType()} and {right?.GetType()}",
                Left = $"{nameof(left)}: {left}",
                Right = $"{nameof(right)}: {right}"
            };
        }
    }

    #endregion

    #region Modulus

    public object? Modulus(object? left, object? right)
    {
        if (left is int l && right is int r)
        {
            return (float)l % (float)r;
        }

        if (left is float lf && right is float rf)
        {
            return (float)lf % (float)rf;
        }

        if (left is int lInt && right is float rFloat)
        {
            return (int)lInt % (float)rFloat;
        }

        if (left is float lFloat && right is int rInt)
        {
            return (float)lFloat % (int)rInt;
        }

        if (left?.GetType() == null && right?.GetType() == null)
        {
            throw new TetlInvalidModulusException()
            {
                ErrorMessage = "Both values are null!",
                Left = $"{nameof(left)}: {left}",
                Right = $"{nameof(right)}: {right}"
            };
        }
        else if ((left?.GetType() == null && right?.GetType() != null) ||
                 (left?.GetType() != null && right?.GetType() == null))
        {
            throw new TetlInvalidModulusException()
            {
                ErrorMessage = "Cannot divide null value!",
                Left = $"{nameof(left)}: {left}",
                Right = $"{nameof(right)}: {right}"
            };
        }
        else
        {
            throw new TetlInvalidModulusException()
            {
                ErrorMessage = $"Cannot divide values of types {left?.GetType()} and {right?.GetType()}",
                Left = $"{nameof(left)}: {left}",
                Right = $"{nameof(right)}: {right}"
            };
        }
    }

    #endregion
}