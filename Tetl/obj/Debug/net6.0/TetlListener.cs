//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\rpgix\RiderProjects\Tetl\Tetl\Content\Tetl.g4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Tetl.Content {
using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="TetlParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public interface ITetlListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by the <c>constantExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConstantExpression([NotNull] TetlParser.ConstantExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>constantExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConstantExpression([NotNull] TetlParser.ConstantExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>arrayExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArrayExpression([NotNull] TetlParser.ArrayExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>arrayExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArrayExpression([NotNull] TetlParser.ArrayExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>indexVariableExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIndexVariableExpression([NotNull] TetlParser.IndexVariableExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>indexVariableExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIndexVariableExpression([NotNull] TetlParser.IndexVariableExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>additiveExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAdditiveExpression([NotNull] TetlParser.AdditiveExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>additiveExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAdditiveExpression([NotNull] TetlParser.AdditiveExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>indexIntegerExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIndexIntegerExpression([NotNull] TetlParser.IndexIntegerExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>indexIntegerExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIndexIntegerExpression([NotNull] TetlParser.IndexIntegerExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>identifierExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdentifierExpression([NotNull] TetlParser.IdentifierExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>identifierExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdentifierExpression([NotNull] TetlParser.IdentifierExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>notExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNotExpression([NotNull] TetlParser.NotExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>notExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNotExpression([NotNull] TetlParser.NotExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>comparisonExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterComparisonExpression([NotNull] TetlParser.ComparisonExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>comparisonExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitComparisonExpression([NotNull] TetlParser.ComparisonExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>multiplicativeExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMultiplicativeExpression([NotNull] TetlParser.MultiplicativeExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>multiplicativeExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMultiplicativeExpression([NotNull] TetlParser.MultiplicativeExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>booleanExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBooleanExpression([NotNull] TetlParser.BooleanExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>booleanExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBooleanExpression([NotNull] TetlParser.BooleanExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>variableAtIdentifierLengthExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVariableAtIdentifierLengthExpression([NotNull] TetlParser.VariableAtIdentifierLengthExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>variableAtIdentifierLengthExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVariableAtIdentifierLengthExpression([NotNull] TetlParser.VariableAtIdentifierLengthExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>parenthesizedExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParenthesizedExpression([NotNull] TetlParser.ParenthesizedExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>parenthesizedExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParenthesizedExpression([NotNull] TetlParser.ParenthesizedExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>indexExpressionExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIndexExpressionExpression([NotNull] TetlParser.IndexExpressionExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>indexExpressionExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIndexExpressionExpression([NotNull] TetlParser.IndexExpressionExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>functionCallExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctionCallExpression([NotNull] TetlParser.FunctionCallExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>functionCallExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctionCallExpression([NotNull] TetlParser.FunctionCallExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>variableLengthExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVariableLengthExpression([NotNull] TetlParser.VariableLengthExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>variableLengthExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVariableLengthExpression([NotNull] TetlParser.VariableLengthExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by the <c>variableAtLengthExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVariableAtLengthExpression([NotNull] TetlParser.VariableAtLengthExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>variableAtLengthExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVariableAtLengthExpression([NotNull] TetlParser.VariableAtLengthExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="TetlParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProgram([NotNull] TetlParser.ProgramContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="TetlParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProgram([NotNull] TetlParser.ProgramContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="TetlParser.line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLine([NotNull] TetlParser.LineContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="TetlParser.line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLine([NotNull] TetlParser.LineContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="TetlParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatement([NotNull] TetlParser.StatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="TetlParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatement([NotNull] TetlParser.StatementContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="TetlParser.ifElseBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIfElseBlock([NotNull] TetlParser.IfElseBlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="TetlParser.ifElseBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIfElseBlock([NotNull] TetlParser.IfElseBlockContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="TetlParser.elseIfBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterElseIfBlock([NotNull] TetlParser.ElseIfBlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="TetlParser.elseIfBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitElseIfBlock([NotNull] TetlParser.ElseIfBlockContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="TetlParser.whileBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWhileBlock([NotNull] TetlParser.WhileBlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="TetlParser.whileBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWhileBlock([NotNull] TetlParser.WhileBlockContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="TetlParser.forBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterForBlock([NotNull] TetlParser.ForBlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="TetlParser.forBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitForBlock([NotNull] TetlParser.ForBlockContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="TetlParser.forEachBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterForEachBlock([NotNull] TetlParser.ForEachBlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="TetlParser.forEachBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitForEachBlock([NotNull] TetlParser.ForEachBlockContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="TetlParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBlock([NotNull] TetlParser.BlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="TetlParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBlock([NotNull] TetlParser.BlockContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="TetlParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignment([NotNull] TetlParser.AssignmentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="TetlParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignment([NotNull] TetlParser.AssignmentContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="TetlParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctionCall([NotNull] TetlParser.FunctionCallContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="TetlParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctionCall([NotNull] TetlParser.FunctionCallContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="TetlParser.arrayInit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArrayInit([NotNull] TetlParser.ArrayInitContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="TetlParser.arrayInit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArrayInit([NotNull] TetlParser.ArrayInitContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="TetlParser.indexVariable"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIndexVariable([NotNull] TetlParser.IndexVariableContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="TetlParser.indexVariable"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIndexVariable([NotNull] TetlParser.IndexVariableContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="TetlParser.indexInteger"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIndexInteger([NotNull] TetlParser.IndexIntegerContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="TetlParser.indexInteger"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIndexInteger([NotNull] TetlParser.IndexIntegerContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="TetlParser.indexExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIndexExpression([NotNull] TetlParser.IndexExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="TetlParser.indexExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIndexExpression([NotNull] TetlParser.IndexExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="TetlParser.variableLength"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVariableLength([NotNull] TetlParser.VariableLengthContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="TetlParser.variableLength"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVariableLength([NotNull] TetlParser.VariableLengthContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="TetlParser.variableAtLength"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVariableAtLength([NotNull] TetlParser.VariableAtLengthContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="TetlParser.variableAtLength"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVariableAtLength([NotNull] TetlParser.VariableAtLengthContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="TetlParser.variableAtIdentifierLength"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVariableAtIdentifierLength([NotNull] TetlParser.VariableAtIdentifierLengthContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="TetlParser.variableAtIdentifierLength"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVariableAtIdentifierLength([NotNull] TetlParser.VariableAtIdentifierLengthContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="TetlParser.atUpdateValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAtUpdateValue([NotNull] TetlParser.AtUpdateValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="TetlParser.atUpdateValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAtUpdateValue([NotNull] TetlParser.AtUpdateValueContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="TetlParser.dotFields"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDotFields([NotNull] TetlParser.DotFieldsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="TetlParser.dotFields"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDotFields([NotNull] TetlParser.DotFieldsContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="TetlParser.nExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNExpression([NotNull] TetlParser.NExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="TetlParser.nExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNExpression([NotNull] TetlParser.NExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpression([NotNull] TetlParser.ExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpression([NotNull] TetlParser.ExpressionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="TetlParser.multOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMultOp([NotNull] TetlParser.MultOpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="TetlParser.multOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMultOp([NotNull] TetlParser.MultOpContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="TetlParser.addOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAddOp([NotNull] TetlParser.AddOpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="TetlParser.addOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAddOp([NotNull] TetlParser.AddOpContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="TetlParser.compareOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCompareOp([NotNull] TetlParser.CompareOpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="TetlParser.compareOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCompareOp([NotNull] TetlParser.CompareOpContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="TetlParser.boolOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBoolOp([NotNull] TetlParser.BoolOpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="TetlParser.boolOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBoolOp([NotNull] TetlParser.BoolOpContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="TetlParser.constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConstant([NotNull] TetlParser.ConstantContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="TetlParser.constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConstant([NotNull] TetlParser.ConstantContext context);
}
} // namespace Tetl.Content
