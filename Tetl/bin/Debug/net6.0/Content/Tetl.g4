grammar Tetl;

program: line* EOF;

line: statement | ifBlock | whileBlock;

statement: (assignment|functionCall) ';';

ifBlock: IF '(' expression ')' block (ELSE elseIfBlock)?;
elseIfBlock: block | ifBlock;

whileBlock: WHILE '(' expression ')' block;

block: '{' line* '}';

WHILE: 'while' | 'until';

array: '[' ( expression ( ',' expression )* )? ']';

IF: 'if';
ELSE: 'else';

assignment: IDENTIFIER '=' expression;

functionCall: IDENTIFIER '(' (expression (',' expression)*)? ')';

expression
	: constant								#constantExpression
	| IDENTIFIER							#identifierExpression
	| functionCall							#functionCallExpression
	| '(' expression ')'					#parenthesizedExpression
	| '!' expression						#notExpression
	| expression multOp expression			#multiplicativeExpression
	| expression addOp expression			#additiveExpression
	| expression compareOp expression		#comparisonExpression
	| expression boolOp expression			#booleanExpression
	;

multOp: '*' | '/' | '%';
addOp: '+' | '-';
compareOp: '==' | '!=' | '>' | '<' | '>=' | '<=';
boolOp: BOOL_OPERATOR;

BOOL_OPERATOR: '&&' | '||';

constant: INTEGER | FLOAT | STRING | BOOL | NULL;

INTEGER: [0-9]+;
FLOAT: [0-9]+ '.' [0-9]+;
STRING: ('"' ~'"'* '"') | ('\'' ~'\''* '\'');
BOOL: 'true' | 'false';
NULL: 'null';

COMMENT: '>*' .*? '*<' -> skip;

LINE_COMMENT: '>>' ~[\r\n]* -> skip;
LINE_BREAK: '\n';
WS: [ \t\r\n]+ -> skip;
IDENTIFIER: [a-zA-Z_][a-zA-Z0-9_]*;