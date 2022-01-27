using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Antlr4.Runtime.Tree;
using Tetl;
using Tetl.Content;

namespace Tetl;

public class TetlVisitor : TetlBaseVisitor<object?>
{
    private Dictionary<string, object?> Variables { get; } = new();

    public TetlVisitor()
    {
        Variables["E"] = Math.E;
        Variables["pi"] = Math.PI;

        Variables["Out"] = new Func<object?[], object?>(Out);
        Variables["OutNewLine"] = new Func<object?[], object?>(OutNewLine);
    }

    private object? Out(object?[] args)
    {
        foreach (var arg in args)
        {
            Console.Write(arg);
        }

        return null;
    }

    private object? OutNewLine(object?[] args)
    {
        foreach (var arg in args)
        {
            Console.WriteLine(arg);
        }

        return null;
    }

    public override object? VisitFunctionCall(TetlParser.FunctionCallContext context)
    {
        var name = context.IDENTIFIER().GetText();
        var args = context.expression().Select(Visit).ToArray();

        if (!Variables.ContainsKey(name))
        {
            throw new TetlFunctionNotDefinedException()
            {
                ErrorMessage = $"Function is not defined!",
                Function = $"name: {name}"
            };
        }

        if (Variables[name] is not Func<object?[], object?> func)
        {
            throw new TetlFunctionNotDefinedException()
            {
                ErrorMessage = $"Function is not defined!",
                Function = $"name: {name}"
            };
        }

        return func(args);
    }

    public override object? VisitAssignment(TetlParser.AssignmentContext context)
    {
        var varName = context.IDENTIFIER().GetText();
        var value = Visit(context.expression());

        Variables[varName] = value;

        return null;
    }

    public override object? VisitIdentifierExpression(TetlParser.IdentifierExpressionContext context)
    {
        var varName = context.IDENTIFIER().GetText();
        if (!Variables.ContainsKey(varName))
        {
            throw new TetlVariableNotDefinedException()
            {
                ErrorMessage = $"Variable is not defined!",
                Variable = $"variable: {varName}",
            };
        }

        return Variables[varName];
    }

    public override object? VisitConstant(TetlParser.ConstantContext context)
    {
        if (context.INTEGER() is { } i)
        {
            return int.Parse(i.GetText());
        }

        if (context.FLOAT() is { } f)
        {
            return float.Parse(f.GetText(), CultureInfo.InvariantCulture);
        }

        if (context.STRING() is { } s)
        {
            return s.GetText()[1..^1];
        }

        if (context.BOOL() is { } b)
        {
            return b.GetText() == "true";
        }

        if (context.NULL() is { })
        {
            return null;
        }

        return new NotImplementedException();
    }

    public override object? VisitAdditiveExpression(TetlParser.AdditiveExpressionContext context)
    {
        var left = Visit(context.expression(0));
        var right = Visit(context.expression(1));

        var op = context.addOp().GetText();
        return op switch
        {
            "+" => Add(left, right),
            "-" => Subtract(left, right),
            _ => throw new NotImplementedException("Invalid operation!")
        };
    }

    #region Addition

    private object? Add(object? left, object? right)
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

    private object? Subtract(object? left, object? right)
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
                ErrorMessage = "Cannot subtract null value!",
                Left = $"{nameof(left)}: {left}",
                Right = $"{nameof(right)}: {right}"
            };
        }
        else
        {
            throw new TetlInvalidAdditionException()
            {
                ErrorMessage = $"Cannot subtract values of types {left?.GetType()} and {right?.GetType()}",
                Left = $"{nameof(left)}: {left}",
                Right = $"{nameof(right)}: {right}"
            };
        }
    }

    #endregion

    public override object? VisitMultiplicativeExpression(TetlParser.MultiplicativeExpressionContext context)
    {
        var left = Visit(context.expression(0));
        var right = Visit(context.expression(1));

        var op = context.multOp().GetText();
        return op switch
        {
            "*" => Multiplication(left, right),
            "/" => Division(left, right),
            "%" => Modulus(left, right),
            _ => throw new NotImplementedException("Invalid operation!")
        };
    }

    #region Multiplication

    private object? Multiplication(object? left, object? right)
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

    private object? Division(object? left, object? right)
    {
        if (left is int l && right is int r)
        {
            return (float) l / (float) r;
        }

        if (left is float lf && right is float rf)
        {
            return (float) lf / (float) rf;
        }

        if (left is int lInt && right is float rFloat)
        {
            return (int) lInt / (float) rFloat;
        }

        if (left is float lFloat && right is int rInt)
        {
            return (float) lFloat / (int) rInt;
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
    private object? Modulus(object? left, object? right)
    {
        if (left is int l && right is int r)
        {
            return (float) l % (float) r;
        }

        if (left is float lf && right is float rf)
        {
            return (float) lf % (float) rf;
        }

        if (left is int lInt && right is float rFloat)
        {
            return (int) lInt % (float) rFloat;
        }

        if (left is float lFloat && right is int rInt)
        {
            return (float) lFloat % (int) rInt;
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
    

    public override object? VisitWhileBlock(TetlParser.WhileBlockContext context)
    {
        Func<object?, bool> condition = context.WHILE().GetText() == "while" ? IsTrue : IsFalse;

        if (condition(Visit(context.expression())))
        {
            do
            {
                Visit(context.block());
            } while (condition(Visit(context.expression())));
        }
        else
        {
            Visit(context.block());
        }

        return null;
    }

    public override object? VisitComparisonExpression(TetlParser.ComparisonExpressionContext context)
    {
        var left = Visit(context.expression(0));
        var right = Visit(context.expression(1));

        var op = context.compareOp().GetText();

        return op switch
        {
            "==" => IsEquals(left, right),
            "!=" => NotEquals(left, right),
            ">" => GreaterThan(left, right),
            "<" => LessThan(left, right),
            ">=" => GreaterThanOrEqual(left, right),
            "<=" => LessThenOrEqual(left, right),
            _ => throw new NotImplementedException()
        };
    }

    private bool IsEquals(object? left, object? right)
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

    private bool NotEquals(object? left, object? right)
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

    private bool LessThan(object? left, object? right)
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

    private bool GreaterThan(object? left, object? right)
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

    private bool GreaterThanOrEqual(object? left, object? right)
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

    private bool LessThenOrEqual(object? left, object? right)
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

    private bool IsTrue(object? value)
    {
        if (value is bool b)
        {
            return b;
        }

        throw new TetlValueIsNotBooleanException()
        {
            ErrorMessage = "Value is not boolean!",
            Variable = $"variable: {nameof(value)}",
            Value = $"value: {value}"
        };
    }

    public bool IsFalse(object? value) => !IsTrue(value);
}