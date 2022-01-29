namespace Tetl;

public class AdditiveExpressions
{
    #region Addition

    public object? Add(object? left, object? right)
    {
        if (left is int l && right is int r)
        {
            return l + r;
        }

        if (left is float lf && right is float rf)
        {
            return lf + rf;
        }

        if (left is int lInt && right is float rFloat)
        {
            return lInt + rFloat;
        }

        if (left is float lFloat && right is int rInt)
        {
            return lFloat + rInt;
        }

        if (left is string || right is string)
        {
            return $"{left}{right}";
        }

        if (left?.GetType() == null && right?.GetType() == null)
        {
            throw new TetlInvalidAdditionException()
            {
                ErrorMessage = "Both values are null!",
                Left = $"{nameof(left)}: {left}",
                Right = $"{nameof(right)}: {right}"
            };
        }
        else if ((left?.GetType() == null && right?.GetType() != null) ||
                 (left?.GetType() != null && right?.GetType() == null))
        {
            throw new TetlInvalidAdditionException()
            {
                ErrorMessage = "Cannot add null value!",
                Left = $"{nameof(left)}: {left}",
                Right = $"{nameof(right)}: {right}"
            };
        }
        else
        {
            throw new TetlInvalidAdditionException()
            {
                ErrorMessage = $"Cannot add values of types {left?.GetType()} and {right?.GetType()}",
                Left = $"{nameof(left)}: {left}",
                Right = $"{nameof(right)}: {right}"
            };
        }
    }

    #endregion
    
    #region Subtract

    public object? Subtract(object? left, object? right)
    {
        if (left is int l && right is int r)
        {
            return l - r;
        }

        if (left is float lf && right is float rf)
        {
            return lf - rf;
        }

        if (left is int lInt && right is float rFloat)
        {
            return lInt - rFloat;
        }

        if (left is float lFloat && right is int rInt)
        {
            return lFloat - rInt;
        }

        if (left?.GetType() == null && right?.GetType() == null)
        {
            throw new TetlInvalidSubtractException()
            {
                ErrorMessage = "Both values are null!",
                Left = $"{nameof(left)}: {left}",
                Right = $"{nameof(right)}: {right}"
            };
        }
        else if ((left?.GetType() == null && right?.GetType() != null) ||
                 (left?.GetType() != null && right?.GetType() == null))
        {
            throw new TetlInvalidSubtractException()
            {
                ErrorMessage = "Cannot subtract null value!",
                Left = $"{nameof(left)}: {left}",
                Right = $"{nameof(right)}: {right}"
            };
        }
        else
        {
            throw new TetlInvalidSubtractException()
            {
                ErrorMessage = $"Cannot subtract values of types {left?.GetType()} and {right?.GetType()}",
                Left = $"{nameof(left)}: {left}",
                Right = $"{nameof(right)}: {right}"
            };
        }
    }

    #endregion
}