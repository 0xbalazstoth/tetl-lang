namespace Tetl;

public class BooleanExpressions
{
    #region And operator

    public object? AndOperator(object? left, object? right)
    {
        if (left as bool? == true)
        {
            if (right as bool? == true)
            {
                return true;
            }
        }

        return false;
    }

    #endregion

    #region Or operator

    public object? OrOperator(object? left, object? right)
    {
        if (left as bool? == true)
        {
            return true;
        }

        if (right as bool? == true)
        {
            return true;
        }

        return false;
    }

    #endregion
}