grammar Lab1;


/*
 * Parser Rules
 */

compileUnit : expression EOF;

expression :
	LPAREN expression RPAREN #ParenthesizedExpr
	|expression EXPONENT expression #ExponentialExpr
    |expression operatorToken=(MULTIPLY | DIVIDE) expression #MultiplicativeExpr
	//|SUBSTRACT LPAREN expression RPAREN #UnminExpr
	| MAX LPAREN left = expression ',' right = expression RPAREN #Max
	| MIN LPAREN left = expression ',' right = expression RPAREN #Min
	| 'mmin' LPAREN paramlist = arglist RPAREN #Mmax
	| 'mmax' LPAREN paramlist = arglist RPAREN #Mmin
	|expression operatorToken=(ADD | SUBTRACT) expression #AdditiveExpr
	|NUMBER #NumberExpr
	|IDENTIFIER #IdentifierExpr
	; 
arglist: expression (',' expression)+;
/*
 * Lexer Rules
 */

NUMBER : INT (',' INT)?; 
IDENTIFIER : [A-Z]+([0-9]+);

INT : ('0'..'9')+;


EXPONENT : '^';
MULTIPLY : '*';
DIVIDE : '/';
MAX : 'max';
MIN : 'min';
SUBTRACT : '-';
ADD : '+';
LPAREN : '(';
RPAREN : ')';
DESP : ',';


WS : [ \t\r\n] -> channel(HIDDEN);
