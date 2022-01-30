grammar Tetl;

// Lines
program: line* EOF;
line: statement | ifElseBlock | whileBlock | forBlock;

// Statement
statement: (assignment|functionCall|dotFields) ';';

// Blocks
ifElseBlock: IF '(' expression ')' block (ELSE elseIfBlock)?;
elseIfBlock: block | ifElseBlock;
whileBlock: WHILE '(' expression ')' block;
forBlock: FOR '(' assignment ';' expression ')' block;
block: '{' line* '}';

// Assignment
assignment: IDENTIFIER '=' expression;

// Function call
functionCall: IDENTIFIER '(' (expression (',' expression)*)? ')';

// Declarations, main rules
arrayInit: '[' expression (',' expression)* ']';
indexVariable: varName=IDENTIFIER '[' at=IDENTIFIER ']' | varName=IDENTIFIER '.At' '(' at=IDENTIFIER ')';
indexInteger: varName=IDENTIFIER '[' at=INTEGER ']' | varName=IDENTIFIER '.At' '(' at=INTEGER ')';
variableLength: varName=IDENTIFIER LENGTH;
variableAtLength: indexInteger LENGTH;
variableAtIdentifierLength: indexVariable LENGTH;
dotFields: varName=IDENTIFIER ('.' dotFunction=functionCall)*;

// Negate
nExpression: '!' expression;

// Expression
expression
	: constant								#constantExpression
	| IDENTIFIER							#identifierExpression
	| functionCall							#functionCallExpression
	| '(' expression ')'					#parenthesizedExpression
	| nExpression				            #notExpression
	| arrayInit                             #arrayExpression
	| indexVariable                         #indexVariableExpression
	| indexInteger                          #indexIntegerExpression
	| variableLength                        #variableLengthExpression
	| variableAtLength                      #variableAtLengthExpression
	| variableAtIdentifierLength            #variableAtIdentifierLengthExpression
	| expression multOp expression			#multiplicativeExpression
	| expression addOp expression			#additiveExpression
	| expression compareOp expression		#comparisonExpression
	| expression boolOp expression			#booleanExpression
	;

// Operators
multOp: '*' | '/' | '%';
addOp: '+' | '-';
compareOp: '==' | '!=' | '>' | '<' | '>=' | '<=';
boolOp: BOOL_OPERATOR;
BOOL_OPERATOR: '&&' | 'and' | '||' | 'or';

// Constants
constant: INTEGER | FLOAT | STRING | BOOL | NULL;
LENGTH: '.Length()';
INTEGER: [0-9]+;
FLOAT: [0-9]+ '.' [0-9]+;
STRING: ('"' ~'"'* '"') | ('\'' ~'\''* '\'');
BOOL: 'true' | 'false';
NULL: 'null';
FOR: 'for';
IN: 'in';
FOREACH: 'foreach';
DO: 'do';
WHILE: 'while' | 'until';
IF: 'if';
ELSE: 'else';

// Other regex, skips
COMMENT: '>*' .*? '*<' -> skip;
LINE_COMMENT: '>>' ~[\r\n]* -> skip;
LINE_BREAK: '\n';
WS: [ \t\r\n]+ -> skip;

// Identifier
IDENTIFIER: [a-zA-Z_][a-zA-Z0-9_]*;