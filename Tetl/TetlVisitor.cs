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

    public override object? VisitDotFields(TetlParser.DotFieldsContext context)
    {
        var varName = context.varName.Text;
        var dotFunctionName = context.dotFunction.IDENTIFIER().GetText();
        var dotFunctionParameters = context.dotFunction.expression().Select(Visit).ToArray();

        switch (dotFunctionName)
        {
            case "Add":
                ArrayAddItem(varName, dotFunctionParameters);
                break;
            case "Remove":
                ArrayRemoveItem(varName, dotFunctionParameters);
                break;
            case "Reverse":
                ArrayReverse(varName);
                break;
            default:
                throw new NotImplementedException();
        }

        return null;
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
        var startIndex = context.start.StartIndex;
        var stopIndex = context.stop.StopIndex;

        if ((stopIndex - startIndex) <= 1)
        {
            return values;
        }
        else
        {
            foreach (TetlParser.ExpressionContext value in context.expression())
            {
                values.Add(Visit(value));
            }

            return values;
        }
    }

    private void ArrayAddItem(string varName, object?[] dotFunctionParameters)
    {
        if (Variables.ContainsKey(varName))
        {
            var variable = Variables.GetValueOrDefault(varName);

            if (variable != null)
            {
                if (variable.GetType().IsGenericType && variable is IEnumerable)
                {
                    var elements = variable as List<object?>;
                    elements?.Add(dotFunctionParameters[0]);
                }
                else
                {
                    throw new TetlFunctionNotAvailableForThisTypeException()
                    {
                        ErrorMessage = "You can't use Add function for this type!",
                        Value = variable.GetType()
                    };
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
    }
    
    private void ArrayRemoveItem(string varName, object?[] dotFunctionParameters)
    {
        if (Variables.ContainsKey(varName))
        {
            var variable = Variables.GetValueOrDefault(varName);

            if (variable != null)
            {
                if (variable.GetType().IsGenericType && variable is IEnumerable)
                {
                    var elements = variable as List<object?>;
                    elements?.Remove(dotFunctionParameters[0]);
                }
                else
                {
                    throw new TetlFunctionNotAvailableForThisTypeException()
                    {
                        ErrorMessage = "You can't use Remove function for this type!",
                        Value = variable.GetType()
                    };
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
    }
    
    private void ArrayReverse(string varName)
    {
        if (Variables.ContainsKey(varName))
        {
            var variable = Variables.GetValueOrDefault(varName);

            if (variable != null)
            {
                if (variable.GetType().IsGenericType && variable is IEnumerable)
                {
                    var elements = variable as List<object?>;
                    elements?.Reverse();
                    Variables[varName] = elements;
                }
                else
                {
                    throw new TetlFunctionNotAvailableForThisTypeException()
                    {
                        ErrorMessage = "You can't use Reverse function for this type!",
                        Value = variable.GetType()
                    };
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

    #region Update value at index

    public override object? VisitAtUpdateValue(TetlParser.AtUpdateValueContext context)
    {
        var varName = context.varName.Text;
        var parameter = Visit(context.at);

        if (parameter != null)
        {
            if (Variables.ContainsKey(varName))
            {
                int index = Convert.ToInt32(parameter);
                var variable = Variables.GetValueOrDefault(varName);

                if (variable != null)
                {
                    if (variable.GetType().IsGenericType && variable is IEnumerable)
                    {
                        var elements = variable as List<object?>;
            
                        if (index < elements?.Count)
                        {
                            var value = Visit(context.value);
                            elements[index] = value;
                        }
                        else
                        {
                            throw new TetlIndexOutOfRangeException()
                            {
                                ErrorMessage = "Index was outside the bound!",
                                Index = $"index: {index}"
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

        return null;
    }

    #endregion
    
    #region Indexing

    public override object? VisitIndexExpression(TetlParser.IndexExpressionContext context)
    {
        var varName = context.varName.Text;
        var parameter = Visit(context.at);

        if (parameter != null)
        {
            if (Variables.ContainsKey(varName))
            {
                int index = Convert.ToInt32(parameter);
                
                var variable = Variables.GetValueOrDefault(varName);
            
                if (variable != null)
                {
                    if (variable.GetType().IsGenericType && variable is IEnumerable)
                    {
                        var elements = variable as List<object?>;
            
                        if (index < elements?.Count)
                        {
                            var element = elements?[index];
                            return element;
                        }
                        else
                        {
                            throw new TetlIndexOutOfRangeException()
                            {
                                ErrorMessage = "Index was outside the bound!",
                                Index = $"index: {index}"
                            };
                        }
                    }
                    else if (variable is string)
                    {
                        var str = variable as string;
                        if (str != null)
                        {
                            if (index < str.Length)
                            {
                                return str[index];
                            }
                            else
                            {
                                throw new TetlIndexOutOfRangeException()
                                {
                                    ErrorMessage = "Index was outside the bound!",
                                    Index = $"index: {index}"
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
        }
        else
        {
            throw new ArgumentException("Invalid index value given!");
        }

        throw new TetlValueCannotBeNullException()
        {
            ErrorMessage = "Value is null!",
        };
    }

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
                        throw new TetlIndexOutOfRangeException()
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
                            throw new TetlIndexOutOfRangeException()
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
                        throw new TetlIndexOutOfRangeException()
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
                            throw new TetlIndexOutOfRangeException()
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

    #region Identifiers
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
    #endregion

    #region Constants
    public override object? VisitConstant(TetlParser.ConstantContext context)
    {
        if (context.INTEGER() is { } i)
        {
            return int.Parse(i.GetText(), CultureInfo.InvariantCulture);
        }

        if (context.FLOAT() is { } f)
        {
            return float.Parse(f.GetText(), CultureInfo.InvariantCulture);
        }

        if (context.STRING() is { } s)
        {
            return s.GetText()[1..^1];
        }

        if (context.CHAR() is { } c)
        {
            var startIndex = context.start.StartIndex;
            var stopIndex = context.stop.StopIndex;

            if ((stopIndex - startIndex) == 2)
            {
                return c.GetText()[1..^1];
            }
            else
            {
                throw new TetlInvalidCharacterDeclarationException()
                {
                    ErrorMessage = "Invalid character declaration!",
                    Value = "Too many characters!"
                };
            }            
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
    #endregion

    #region Arithmetic operators
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
    #endregion

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
    
    #region Foreach loop

    public override object? VisitForEachBlock(TetlParser.ForEachBlockContext context)
    {
        Func<object?, bool> condition = context.FOREACH().GetText() == "foreach" ? IsTrue : IsFalse;
        var expression = Visit(context.expression());
        var collection = expression as List<object?>;
        Variables[context.varName.Text] = null;

        if (collection != null)
        {
            foreach (var element in collection)
            {
                Variables[context.varName.Text] = element;
                Visit(context.block());
            }
        }

        return null;
    }

    #endregion

    #region Conditions

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

    #region Comparison
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
    #endregion

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