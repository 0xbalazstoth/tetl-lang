using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Antlr4.Runtime.Tree;
using Tetl;
using Tetl.Content;

namespace Tetl;

public class TetlVisitor : TetlBaseVisitor<object?>
{
    private Dictionary<string, object?> Variables { get; } = new();

    public TetlVisitor()
    {
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

    #region Array

    public override object? VisitArrayInit(TetlParser.ArrayInitContext context)
    {
        List<object?> values = new List<object?>();
        foreach (TetlParser.ExpressionContext value in context.expression())
        {
            values.Add(Visit(value));
        }

        return values;
    }

    #endregion

    #region Variable length

    public override object? VisitVariableLength(TetlParser.VariableLengthContext context)
    {
        var varName = context.varName.Text;

        if (Variables.ContainsKey(varName))
        {
            var variable = Variables.GetValueOrDefault(varName);

            if (variable != null)
            {
                if (variable.GetType().IsGenericType && variable is IEnumerable)
                {
                    var elements = variable as List<object?>;
                    if (elements != null)
                    {
                        return elements.Count;
                    }
                }
                else if (variable is string)
                {
                    var str = variable as string;
                    if (str != null)
                    {
                        return str.Length;
                    }
                }
            }
        }
        else
        {
            throw new TetlVariableNotDefinedException()
            {
                ErrorMessage = $"Variable is not defined!",
                Variable = $"variable: {varName}",
            };
        }

        throw new TetlValueCannotBeNullException()
        {
            ErrorMessage = "Value is null!",
        };
    }

    public override object? VisitVariableAtLength(TetlParser.VariableAtLengthContext context)
    {
        var varName = context.indexInteger().varName.Text;
        var index = Convert.ToInt32(context.indexInteger().at.Text);

        if (Variables.ContainsKey(varName))
        {
            var variable = Variables.GetValueOrDefault(varName);

            if (variable != null)
            {
                if (variable.GetType().IsGenericType && variable is IEnumerable)
                {
                    var elements = variable as List<object?>;
                    if (elements != null)
                    {
                        return elements[index]?.ToString()!.Length;
                    }
                }
            }
        }
        else
        {
            throw new TetlVariableNotDefinedException()
            {
                ErrorMessage = $"Variable is not defined!",
                Variable = $"variable: {varName}",
            };
        }

        throw new TetlValueCannotBeNullException()
        {
            ErrorMessage = "Value is null!",
        };
    }

    public override object? VisitVariableAtIdentifierLength(TetlParser.VariableAtIdentifierLengthContext context)
    {
        var varName = context.indexVariable().varName.Text;
        var indexVariableName = context.indexVariable().at.Text;
        var indexVariableValue = Convert.ToInt32(Variables.GetValueOrDefault(indexVariableName));

        if (Variables.ContainsKey(varName))
        {
            var variable = Variables.GetValueOrDefault(varName);

            if (variable != null)
            {
                if (variable.GetType().IsGenericType && variable is IEnumerable)
                {
                    var elements = variable as List<object?>;
                    if (elements != null)
                    {
                        return elements[indexVariableValue]?.ToString()!.Length;
                    }
                }
            }
        }
        else
        {
            throw new TetlVariableNotDefinedException()
            {
                ErrorMessage = $"Variable is not defined!",
                Variable = $"variable: {varName}",
            };
        }

        throw new TetlValueCannotBeNullException()
        {
            ErrorMessage = "Value is null!",
        };
    }

    #endregion

    #region Indexing

    public override object? VisitIndexVariable(TetlParser.IndexVariableContext context)
    {
        var varName = context.varName.Text;
        var indexVariableName = context.at.Text;
        var indexVariableValue = Convert.ToInt32(Variables.GetValueOrDefault(indexVariableName));

        if (Variables.ContainsKey(varName))
        {
            var variable = Variables.GetValueOrDefault(varName);

            if (variable != null)
            {
                if (variable.GetType().IsGenericType && variable is IEnumerable)
                {
                    var elements = variable as List<object?>;

                    if (indexVariableValue < elements?.Count)
                    {
                        var element = elements?[indexVariableValue];
                        return element;
                    }
                    else
                    {
                        throw new TetlIndexWasOutsideTheException()
                        {
                            ErrorMessage = "Index was outside the bound!",
                            Index = $"index: {indexVariableValue}"
                        };
                    }
                }
                else if (variable is string)
                {
                    var str = variable as string;
                    if (str != null)
                    {
                        if (indexVariableValue < str.Length)
                        {
                            return str[indexVariableValue];
                        }
                        else
                        {
                            throw new TetlIndexWasOutsideTheException()
                            {
                                ErrorMessage = "Index was outside the bound!",
                                Index = $"index: {indexVariableValue}"
                            };
                        }
                    }
                }
            }
        }
        else
        {
            throw new TetlVariableNotDefinedException()
            {
                ErrorMessage = $"Variable is not defined!",
                Variable = $"variable: {varName}",
            };
        }
        
        throw new TetlValueCannotBeNullException()
        {
            ErrorMessage = "Value is null!",
        };
    }

    public override object? VisitIndexInteger(TetlParser.IndexIntegerContext context)
    {
        var varName = context.varName.Text;
        int indexINTEGER = Convert.ToInt32(context.INTEGER().GetText());

        if (Variables.ContainsKey(varName))
        {
            var variable = Variables.GetValueOrDefault(varName);

            if (variable != null)
            {
                if (variable.GetType().IsGenericType && variable is IEnumerable)
                {
                    var elements = variable as List<object?>;

                    if (indexINTEGER < elements?.Count)
                    {
                        var element = elements?[indexINTEGER];
                        return element;
                    }
                    else
                    {
                        throw new TetlIndexWasOutsideTheException()
                        {
                            ErrorMessage = "Index was outside the bound!",
                            Index = $"index: {indexINTEGER}"
                        };
                    }
                }
                else if (variable is string)
                {
                    var str = variable as string;
                    if (str != null)
                    {
                        if (indexINTEGER < str.Length)
                        {
                            return str[indexINTEGER];
                        }
                        else
                        {
                            throw new TetlIndexWasOutsideTheException()
                            {
                                ErrorMessage = "Index was outside the bound!",
                                Index = $"index: {indexINTEGER}"
                            };
                        }
                    }
                }
            }
        }
        else
        {
            throw new TetlVariableNotDefinedException()
            {
                ErrorMessage = $"Variable is not defined!",
                Variable = $"variable: {varName}",
            };
        }

        throw new TetlValueCannotBeNullException()
        {
            ErrorMessage = "Value is null!",
        };
    }

    #endregion

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

        var additiveExpressions = new AdditiveExpressions();

        return op switch
        {
            "+" => additiveExpressions.Add(left, right),
            "-" => additiveExpressions.Subtract(left, right),
            _ => throw new NotImplementedException("Invalid operation!")
        };
    }

    public override object? VisitMultiplicativeExpression(TetlParser.MultiplicativeExpressionContext context)
    {
        var left = Visit(context.expression(0));
        var right = Visit(context.expression(1));

        var op = context.multOp().GetText();

        var multiplicativeExpressions = new MultiplicativeExpressions();

        return op switch
        {
            "*" => multiplicativeExpressions.Multiplication(left, right),
            "/" => multiplicativeExpressions.Division(left, right),
            "%" => multiplicativeExpressions.Modulus(left, right),
            _ => throw new NotImplementedException("Invalid operation!")
        };
    }

    #region While loop

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

    #endregion

    #region For loop

    public override object? VisitForBlock(TetlParser.ForBlockContext context)
    {
        Func<object?, bool> condition = context.FOR().GetText() == "for" ? IsTrue : IsFalse;
        var varName = context.assignment().IDENTIFIER().GetText();
        var value = Visit(context.assignment().expression());
        Variables[varName] = value;

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

    #endregion

    #region Conditions

    // public override object? VisitIfBlock(TetlParser.IfBlockContext context)
    // {
    //     string conditionText = context.IF().GetText();
    //     Func<object?, bool> condition = conditionText == "if" ? IsTrue : IsFalse;
    //     if (condition(Visit(context.expression())))
    //     {
    //         Visit(context.block());
    //     }
    //
    //     return null;
    // }
    public override object? VisitIfElseBlock(TetlParser.IfElseBlockContext context)
    {
        string conditionIFText = context.IF().GetText();
        bool isElseBlockGiven = false;

        try
        {
            string conditionELSEText = context.ELSE().GetText();
            isElseBlockGiven = true;
        }
        catch (NullReferenceException)
        {
            isElseBlockGiven = false;
        }
        
        Func<object?, bool> condition = conditionIFText == "if" ? IsTrue : IsFalse;
        if (conditionIFText != null && isElseBlockGiven) // if, else if, else
        {
            if (condition(Visit(context.expression())))
            {
                Visit(context.block());
            }
            else
            {
                Visit(context.elseIfBlock());
            }
        }
        else if (conditionIFText != null && !isElseBlockGiven) // if
        {
            if (condition(Visit(context.expression())))
            {
                Visit(context.block());
            }
        }

        return null;
    }

    #endregion

    #region Negate

    public override object? VisitNotExpression(TetlParser.NotExpressionContext context)
    {
        object? value = Visit(context.nExpression());
        return !(value as bool?);
    }

    #endregion

    #region Boolean and, or

    public override object? VisitBooleanExpression(TetlParser.BooleanExpressionContext context)
    {
        var left = Visit(context.expression(0));
        var right = Visit(context.expression(1));
        var op = context.boolOp().GetText();

        var booleanExpressions = new BooleanExpressions();

        return op switch
        {
            "and" => booleanExpressions.AndOperator(left, right),
            "&&" => booleanExpressions.AndOperator(left, right),
            "||" => booleanExpressions.OrOperator(left, right),
            "or" => booleanExpressions.OrOperator(left, right),
            _ => throw new NotImplementedException()
        };
    }

    #endregion

    public override object? VisitComparisonExpression(TetlParser.ComparisonExpressionContext context)
    {
        var left = Visit(context.expression(0));
        var right = Visit(context.expression(1));

        var op = context.compareOp().GetText();

        var comparisonExpressions = new ComparisonExpressions();

        return op switch
        {
            "==" => comparisonExpressions.IsEquals(left, right),
            "!=" => comparisonExpressions.NotEquals(left, right),
            ">" => comparisonExpressions.GreaterThan(left, right),
            "<" => comparisonExpressions.LessThan(left, right),
            ">=" => comparisonExpressions.GreaterThanOrEqual(left, right),
            "<=" => comparisonExpressions.LessThenOrEqual(left, right),
            _ => throw new NotImplementedException()
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