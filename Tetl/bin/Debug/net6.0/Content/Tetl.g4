grammar Tetl;

program: line* EOF;

line: statement | ifBlock | whileBlock | forBlock;

statement: (assignment|functionCall) ';';

ifBlock: IF '(' expression ')' block (ELSE elseIfBlock)?;
elseIfBlock: block | ifBlock;

whileBlock: WHILE '(' expression ')' block;
forBlock: FOR '(' assignment ';' expression ')' block;

block: '{' line* '}';

assignment: IDENTIFIER '=' expression;

functionCall: IDENTIFIER '(' (expression (',' expression)*)? ')';
arrayInit: '[' expression (',' expression)* ']';
indexVariable: varName=IDENTIFIER '[' at=IDENTIFIER ']';
indexInteger: varName=IDENTIFIER '[' at=INTEGER ']';
nExpression: '!' expression;

expression
	: constant								#constantExpression
	| IDENTIFIER							#identifierExpression
	| functionCall							#functionCallExpression
	| '(' expression ')'					#parenthesizedExpression
	| nExpression				            #notExpression
	| arrayInit                             #arrayExpression
	| indexVariable                         #indexVariableExpression
	| indexInteger                          #indexIntegerExpression
	| expression multOp expression			#multiplicativeExpression
	| expression addOp expression			#additiveExpression
	| expression compareOp expression		#comparisonExpression
	| expression boolOp expression			#booleanExpression
	;

multOp: '*' | '/' | '%';
addOp: '+' | '-';
compareOp: '==' | '!=' | '>' | '<' | '>=' | '<=';
boolOp: BOOL_OPERATOR;

BOOL_OPERATOR: '&&' | 'and' | '||' | 'or';

constant: INTEGER | FLOAT | STRING | BOOL | NULL;

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
COMMENT: '>*' .*? '*<' -> skip;
LINE_COMMENT: '>>' ~[\r\n]* -> skip;
LINE_BREAK: '\n';
WS: [ \t\r\n]+ -> skip;
IDENTIFIER: [a-zA-Z_][a-zA-Z0-9_]*;