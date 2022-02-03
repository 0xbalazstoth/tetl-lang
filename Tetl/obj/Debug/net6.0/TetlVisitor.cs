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
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="TetlParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public interface ITetlVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by the <c>constantExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConstantExpression([NotNull] TetlParser.ConstantExpressionContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>arrayExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArrayExpression([NotNull] TetlParser.ArrayExpressionContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>indexVariableExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIndexVariableExpression([NotNull] TetlParser.IndexVariableExpressionContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>additiveExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAdditiveExpression([NotNull] TetlParser.AdditiveExpressionContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>indexIntegerExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIndexIntegerExpression([NotNull] TetlParser.IndexIntegerExpressionContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>identifierExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdentifierExpression([NotNull] TetlParser.IdentifierExpressionContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>notExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNotExpression([NotNull] TetlParser.NotExpressionContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>comparisonExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitComparisonExpression([NotNull] TetlParser.ComparisonExpressionContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>multiplicativeExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMultiplicativeExpression([NotNull] TetlParser.MultiplicativeExpressionContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>booleanExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBooleanExpression([NotNull] TetlParser.BooleanExpressionContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>variableAtIdentifierLengthExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVariableAtIdentifierLengthExpression([NotNull] TetlParser.VariableAtIdentifierLengthExpressionContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>parenthesizedExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParenthesizedExpression([NotNull] TetlParser.ParenthesizedExpressionContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>indexExpressionExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIndexExpressionExpression([NotNull] TetlParser.IndexExpressionExpressionContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>functionCallExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionCallExpression([NotNull] TetlParser.FunctionCallExpressionContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>variableLengthExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVariableLengthExpression([NotNull] TetlParser.VariableLengthExpressionContext context);

	/// <summary>
	/// Visit a parse tree produced by the <c>variableAtLengthExpression</c>
	/// labeled alternative in <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVariableAtLengthExpression([NotNull] TetlParser.VariableAtLengthExpressionContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="TetlParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProgram([NotNull] TetlParser.ProgramContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="TetlParser.line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLine([NotNull] TetlParser.LineContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="TetlParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatement([NotNull] TetlParser.StatementContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="TetlParser.ifElseBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfElseBlock([NotNull] TetlParser.IfElseBlockContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="TetlParser.elseIfBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElseIfBlock([NotNull] TetlParser.ElseIfBlockContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="TetlParser.whileBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhileBlock([NotNull] TetlParser.WhileBlockContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="TetlParser.forBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitForBlock([NotNull] TetlParser.ForBlockContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="TetlParser.forEachBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitForEachBlock([NotNull] TetlParser.ForEachBlockContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="TetlParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBlock([NotNull] TetlParser.BlockContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="TetlParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignment([NotNull] TetlParser.AssignmentContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="TetlParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionCall([NotNull] TetlParser.FunctionCallContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="TetlParser.arrayInit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArrayInit([NotNull] TetlParser.ArrayInitContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="TetlParser.indexVariable"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIndexVariable([NotNull] TetlParser.IndexVariableContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="TetlParser.indexInteger"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIndexInteger([NotNull] TetlParser.IndexIntegerContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="TetlParser.indexExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIndexExpression([NotNull] TetlParser.IndexExpressionContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="TetlParser.variableLength"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVariableLength([NotNull] TetlParser.VariableLengthContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="TetlParser.variableAtLength"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVariableAtLength([NotNull] TetlParser.VariableAtLengthContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="TetlParser.variableAtIdentifierLength"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVariableAtIdentifierLength([NotNull] TetlParser.VariableAtIdentifierLengthContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="TetlParser.dotFields"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDotFields([NotNull] TetlParser.DotFieldsContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="TetlParser.nExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNExpression([NotNull] TetlParser.NExpressionContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="TetlParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression([NotNull] TetlParser.ExpressionContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="TetlParser.multOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMultOp([NotNull] TetlParser.MultOpContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="TetlParser.addOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAddOp([NotNull] TetlParser.AddOpContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="TetlParser.compareOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCompareOp([NotNull] TetlParser.CompareOpContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="TetlParser.boolOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBoolOp([NotNull] TetlParser.BoolOpContext context);

	/// <summary>
	/// Visit a parse tree produced by <see cref="TetlParser.constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConstant([NotNull] TetlParser.ConstantContext context);
}
} // namespace Tetl.Content
