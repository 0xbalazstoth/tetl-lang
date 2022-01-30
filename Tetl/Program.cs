using System;
using System.IO;
using Antlr4.Runtime;
using Tetl.Content;
using Tetl;

var fileName = @"C:\Users\rpgix\RiderProjects\Tetl\Tetl\Tests\test_array.tetl";
var fileContents = File.ReadAllText(fileName);
var inputStream = new AntlrInputStream(fileContents);
var tetlLexer = new TetlLexer(inputStream);
var commonTokenStream = new CommonTokenStream(tetlLexer);
var tetlParser = new TetlParser(commonTokenStream);
var tetlContext = tetlParser.program();
var visitor = new TetlVisitor();

static void ProcessInformation(object? message, ConsoleColor color = ConsoleColor.White)
{
    Console.ForegroundColor = color;
    Console.WriteLine(message);
    Console.ResetColor();
}

try
{
    visitor.Visit(tetlContext);
}
catch (TetlCannotCompareValuesException e)
{
    ProcessInformation($"\n[EXCEPTION]: {e.GetType().Name}", ConsoleColor.Yellow);
    ProcessInformation($"[INFO]: {e.Left}, {e.Right}", ConsoleColor.DarkYellow);
    ProcessInformation($"[ERROR]: {e.ErrorMessage}\n", ConsoleColor.DarkRed);
}
catch (TetlFunctionNotDefinedException e)
{
    ProcessInformation($"\n[EXCEPTION]: {e.GetType().Name}", ConsoleColor.Yellow);
    ProcessInformation($"[INFO]: {e.Function}", ConsoleColor.DarkYellow);
    ProcessInformation($"[ERROR]: {e.ErrorMessage}\n", ConsoleColor.DarkRed);
}
catch (TetlVariableNotDefinedException e)
{
    ProcessInformation($"\n[EXCEPTION]: {e.GetType().Name}", ConsoleColor.Yellow);
    ProcessInformation($"[INFO]: {e.Variable}", ConsoleColor.DarkYellow);
    ProcessInformation($"[ERROR]: {e.ErrorMessage}\n", ConsoleColor.DarkRed);
}
catch (TetlValueIsNotBooleanException e)
{
    ProcessInformation($"\n[EXCEPTION]: {e.GetType().Name}", ConsoleColor.Yellow);
    ProcessInformation($"[INFO]: {e.Variable}", ConsoleColor.DarkYellow);
    ProcessInformation($"[ERROR]: {e.ErrorMessage}\n", ConsoleColor.DarkRed);
}
catch (TetlInvalidAdditionException e)
{
    ProcessInformation($"\n[EXCEPTION]: {e.GetType().Name}", ConsoleColor.Yellow);
    ProcessInformation($"[INFO]: {e.Left}, {e.Right}", ConsoleColor.DarkYellow);
    ProcessInformation($"[ERROR]: {e.ErrorMessage}\n", ConsoleColor.DarkRed);
}
catch (TetlInvalidSubtractException e)
{
    ProcessInformation($"\n[EXCEPTION]: {e.GetType().Name}", ConsoleColor.Yellow);
    ProcessInformation($"[INFO]: {e.Left}, {e.Right}", ConsoleColor.DarkYellow);
    ProcessInformation($"[ERROR]: {e.ErrorMessage}\n", ConsoleColor.DarkRed);
}
catch (TetlInvalidMultiplicationException e)
{
    ProcessInformation($"\n[EXCEPTION]: {e.GetType().Name}", ConsoleColor.Yellow);
    ProcessInformation($"[INFO]: {e.Left}, {e.Right}", ConsoleColor.DarkYellow);
    ProcessInformation($"[ERROR]: {e.ErrorMessage}\n", ConsoleColor.DarkRed);
}
catch (TetlInvalidDivisionException e)
{
    ProcessInformation($"\n[EXCEPTION]: {e.GetType().Name}", ConsoleColor.Yellow);
    ProcessInformation($"[INFO]: {e.Left}, {e.Right}", ConsoleColor.DarkYellow);
    ProcessInformation($"[ERROR]: {e.ErrorMessage}\n", ConsoleColor.DarkRed);
}
catch (TetlInvalidModulusException e)
{
    ProcessInformation($"\n[EXCEPTION]: {e.GetType().Name}", ConsoleColor.Yellow);
    ProcessInformation($"[INFO]: {e.Left}, {e.Right}", ConsoleColor.DarkYellow);
    ProcessInformation($"[ERROR]: {e.ErrorMessage}\n", ConsoleColor.DarkRed);
}
catch (TetlValueCannotBeNullException e)
{
    ProcessInformation($"\n[EXCEPTION]: {e.GetType().Name}", ConsoleColor.Yellow);
    ProcessInformation($"[ERROR]: {e.ErrorMessage}\n", ConsoleColor.DarkRed);
}
catch (TetlIndexWasOutsideTheException e)
{
    ProcessInformation($"\n[EXCEPTION]: {e.GetType().Name}", ConsoleColor.Yellow);
    ProcessInformation($"[INFO]: {e.Index}", ConsoleColor.DarkYellow);
    ProcessInformation($"[ERROR]: {e.ErrorMessage}\n", ConsoleColor.DarkRed);
}
catch (TetlFunctionNotAvailableForThisTypeException e)
{
    ProcessInformation($"\n[EXCEPTION]: {e.GetType().Name}", ConsoleColor.Yellow);
    ProcessInformation($"[INFO]: {e.Value}", ConsoleColor.DarkYellow);
    ProcessInformation($"[ERROR]: {e.ErrorMessage}\n", ConsoleColor.DarkRed);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}