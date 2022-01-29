using System;
using System.IO;
using Antlr4.Runtime;
using Tetl.Content;
using Tetl;

var fileName = @"C:\Users\rpgix\RiderProjects\Tetl\Tetl\Tests\test_variable_length.tetl";
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
    ProcessInformation($"[EXCEPTION]: {e.GetType().Name}", ConsoleColor.Yellow);
    ProcessInformation($"[INFO]: {e.Left}, {e.Right}", ConsoleColor.DarkYellow);
    ProcessInformation($"[ERROR]: {e.ErrorMessage}", ConsoleColor.DarkRed);
}
catch (TetlFunctionNotDefinedException e)
{
    ProcessInformation($"[EXCEPTION]: {e.GetType().Name}", ConsoleColor.Yellow);
    ProcessInformation($"[INFO]: {e.Function}", ConsoleColor.DarkYellow);
    ProcessInformation($"[ERROR]: {e.ErrorMessage}", ConsoleColor.DarkRed);
}
catch (TetlVariableNotDefinedException e)
{
    ProcessInformation($"[EXCEPTION]: {e.GetType().Name}", ConsoleColor.Yellow);
    ProcessInformation($"[INFO]: {e.Variable}", ConsoleColor.DarkYellow);
    ProcessInformation($"[ERROR]: {e.ErrorMessage}", ConsoleColor.DarkRed);
}
catch (TetlValueIsNotBooleanException e)
{
    ProcessInformation($"[EXCEPTION]: {e.GetType().Name}", ConsoleColor.Yellow);
    ProcessInformation($"[INFO]: {e.Variable}", ConsoleColor.DarkYellow);
    ProcessInformation($"[ERROR]: {e.ErrorMessage}", ConsoleColor.DarkRed);
}
catch (TetlInvalidAdditionException e)
{
    ProcessInformation($"[EXCEPTION]: {e.GetType().Name}", ConsoleColor.Yellow);
    ProcessInformation($"[INFO]: {e.Left}, {e.Right}", ConsoleColor.DarkYellow);
    ProcessInformation($"[ERROR]: {e.ErrorMessage}", ConsoleColor.DarkRed);
}
catch (TetlInvalidSubtractException e)
{
    ProcessInformation($"[EXCEPTION]: {e.GetType().Name}", ConsoleColor.Yellow);
    ProcessInformation($"[INFO]: {e.Left}, {e.Right}", ConsoleColor.DarkYellow);
    ProcessInformation($"[ERROR]: {e.ErrorMessage}", ConsoleColor.DarkRed);
}
catch (TetlInvalidMultiplicationException e)
{
    ProcessInformation($"[EXCEPTION]: {e.GetType().Name}", ConsoleColor.Yellow);
    ProcessInformation($"[INFO]: {e.Left}, {e.Right}", ConsoleColor.DarkYellow);
    ProcessInformation($"[ERROR]: {e.ErrorMessage}", ConsoleColor.DarkRed);
}
catch (TetlInvalidDivisionException e)
{
    ProcessInformation($"[EXCEPTION]: {e.GetType().Name}", ConsoleColor.Yellow);
    ProcessInformation($"[INFO]: {e.Left}, {e.Right}", ConsoleColor.DarkYellow);
    ProcessInformation($"[ERROR]: {e.ErrorMessage}", ConsoleColor.DarkRed);
}
catch (TetlInvalidModulusException e)
{
    ProcessInformation($"[EXCEPTION]: {e.GetType().Name}", ConsoleColor.Yellow);
    ProcessInformation($"[INFO]: {e.Left}, {e.Right}", ConsoleColor.DarkYellow);
    ProcessInformation($"[ERROR]: {e.ErrorMessage}", ConsoleColor.DarkRed);
}
catch (TetlValueCannotBeNullException e)
{
    ProcessInformation($"[EXCEPTION]: {e.GetType().Name}", ConsoleColor.Yellow);
    ProcessInformation($"[ERROR]: {e.ErrorMessage}", ConsoleColor.DarkRed);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}