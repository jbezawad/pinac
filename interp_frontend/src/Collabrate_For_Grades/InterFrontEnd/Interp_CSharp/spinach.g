
grammar spinach;

options {
  language = 'CSharp';
  output=AST;
} 

@parser::header {
using System.Collections.Generic;
}

@lexer::header {
using System.Collections.Generic;
}

/*
 * Parser Rules
 */
program returns [List<Element> ret]
@init {
  retval.ret = new List<Element>();
}
  : (expr {retval.ret.Add($expr.ret); } )+;
  
expr returns [Element ret]
  :expr1{retval.ret = $expr1.ret;}| parallelfor{retval.ret = $parallelfor.ret;}
;

expr1 returns [Element ret]
  : assignment {retval.ret = $assignment.ret;}
  | scalarvardec { retval.ret = $scalarvardec.ret;}
  | vectorvardec { retval.ret = $vectorvardec.ret;}
  | matrixvardec { retval.ret = $matrixvardec.ret;}
  | deletionofvar { retval.ret = $deletionofvar.ret;}
  | structdec {retval.ret = $structdec.ret;}
  | structobjdec { retval.ret = $structobjdec.ret;}
  | print { retval.ret = $print.ret; }
  | ifelse{retval.ret = $ifelse.ret;}
  | functioncall{retval.ret=$functioncall.ret;}
  | equality{retval.ret = $equality.ret;}
  | nonequality{retval.ret = $nonequality.ret;}
  | forstatement{retval.ret = $forstatement.ret;}
  | functiondefination{retval.ret = $functiondefination.ret;}
  | functionreturn{retval.ret =$functionreturn.ret;}
  | plotfunctions{retval.ret = $plotfunctions.ret;};

var_int_or_double_literal returns [Element ret]
  :  (variable { retval.ret = $variable.ret; } 
  |   int_literal {retval.ret = $int_literal.ret; }
  |   double_literal {retval.ret = $double_literal.ret;});

variable returns [VariableElement ret]
@init {
  retval.ret = new VariableElement();
}
  : VARIABLE { retval.ret.setText($VARIABLE.text); };

int_literal returns [IntegerElement ret]
@init {
  retval.ret = new IntegerElement();
}
  : INT_LITERAL { retval.ret.setText($INT_LITERAL.text); };

double_literal returns [DoubleElement ret]
@init {
	retval.ret = new DoubleElement();
	}
	: el1=DOUBLE_LITERAL {retval.ret.setText($el1.text);};

matrixvardec returns [MatrixVariableDeclaration ret]
@init {
	retval.ret = new MatrixVariableDeclaration();
	}
	:('Matrix' '<' VARTYPE { retval.ret.setType($VARTYPE.text);}'>' '['el1=int_literal { retval.ret.setRow($el1.ret);}']'
	'[' el2=int_literal { retval.ret.setColumn($el2.ret);}']'
	 (el3= variable { retval.ret.setVar($el3.ret);})
	 ASSIGNMENT
	 '['((el4=int_literal {retval.ret.addValue($el4.ret);}|el5=double_literal {retval.ret.addValue($el5.ret);})
	 (','el6=int_literal {retval.ret.addValue($el6.ret);}|','el7=double_literal {retval.ret.addValue($el7.ret);})*)']'){retval.ret.setValue();}
	 END_OF_STATEMENT;

vectorvardec returns [VectorVariableDeclaration ret]
@init {
	retval.ret = new VectorVariableDeclaration();
	}
	:('Vector' '<' VARTYPE { retval.ret.setType($VARTYPE.text);}'>' '['el1=int_literal {retval.ret.setRange($el1.ret);}']'
	 el2=variable {retval.ret.setText($el2.ret);} 
	 ASSIGNMENT 
	 '['((el3=int_literal {retval.ret.addValue($el3.ret);}|el4=double_literal {retval.ret.addValue($el4.ret);})
	 (','el5=int_literal {retval.ret.addValue($el5.ret);}|','el6=double_literal {retval.ret.addValue($el6.ret);})*)']'){retval.ret.setValue();}
	 END_OF_STATEMENT;

assignment returns [AssignmentOperationElement ret]
@init {
  retval.ret = new AssignmentOperationElement();
}
  : (variable {retval.ret.setLhs($variable.ret); }
    | structassign {retval.ret.setLhs($structassign.ret);})
    ASSIGNMENT 
    (var_int_or_double_literal {retval.ret.setRhs($var_int_or_double_literal.ret); } 
    | addition {retval.ret.setRhs($addition.ret); }
    ) END_OF_STATEMENT;

addition returns [AdditionOperationElement ret]
@init {
  retval.ret = new AdditionOperationElement();
}
  : el1=var_int_or_double_literal { retval.ret.setLhs($el1.ret); } 
    '+' 
    el2= var_int_or_double_literal { retval.ret.setRhs($el2.ret); };
    
    
 
structdec returns [StructDeclaration ret]
@init {
retval.ret = new StructDeclaration();
}
: ('Struct' variable { retval.ret.setName($variable.ret);}
'{' (el1=scalarvardec { retval.ret.setVarType($el1.ret);})+
'}')END_OF_STATEMENT; 

scalarvardec returns [ScalarVariableDeclaration ret]
@init {
	retval.ret = new ScalarVariableDeclaration();
	}	
	:((VARTYPE { retval.ret.setType($VARTYPE.text);}
	| STRINGTYPE { retval.ret.setType($STRINGTYPE.text);}) 
	variable { retval.ret.setVar($variable.ret);})END_OF_STATEMENT;
 
structobjdec returns [StructObjectDeclaration ret]
@init {
retval.ret = new StructObjectDeclaration();
}
: (el1=variable { retval.ret.setStructName($el1.ret);}
 el2=variable { retval.ret.setObjName($el2.ret);})
 END_OF_STATEMENT;
 
structassign returns [StructAssignDeclaration ret]
@init {
retval.ret = new StructAssignDeclaration();
}
:(el1=variable {retval.ret.setName($el1.ret);}'.'el2=variable {retval.ret.setObj($el2.ret);});

deletionofvar returns [DeleteVariable ret]
@init {
retval.ret = new DeleteVariable();
}
:('delete' el1=variable { retval.ret.setVar($el1.ret);})END_OF_STATEMENT;

print returns [PrintOperationElement ret]
@init {
  retval.ret = new PrintOperationElement();
}
  : 'print' var_int_or_double_literal {retval.ret.setChildElement($var_int_or_double_literal.ret); }
    END_OF_STATEMENT; 
    

parallelfor returns [ParallelForElement ret]
@init {
  retval.ret = new ParallelForElement();
}: 'parallelfor' r11 = range{retval.ret.RANGE = $range.ret;} LEFTPARANTHESIS  ((e11=expr1{retval.ret.ADDCODE =$e11.ret;})+(('SYNC'{retval.ret.syncfunction();} END_OF_STATEMENT)|{retval.ret.syncfunction();}))+ RIGHTPARANTHESIS
;

range returns[RangeElement ret]
@init{
  retval.ret= new RangeElement();
}:LEFTBRACE e11 = variable{retval.ret.RANGEVARIABLE = $e11.ret;} POINT e12 = int_literal{retval.ret.STARTINGRANGE = $e12.ret;} 'to' e13= int_literal{retval.ret.ENDINGRANGE = $e13.ret;} RIGHTBRACE;

//bodyloop returns [list<Element> ret]
//@init{
//   retval.ret = new List<Element>();
//}
//: (expr1{retval.ret.Add($expr1.ret);})+ ('SYNC'{retval.ret.syncfunction();} END_OF_STATEMENT)?;

ifelse returns [IfStatementElement ret]
@init{
   retval.ret = new IfStatementElement();
}
:('if' LEFTBRACE (equality{retval.ret.CONDITION = $equality.ret;}|nonequality{retval.ret.CONDITION = $nonequality.ret;}) RIGHTBRACE LEFTPARANTHESIS ((e11 = program{retval.ret.IFCODE = $e11.ret;})|)RIGHTPARANTHESIS)('else'  LEFTPARANTHESIS ((e12 =  program{retval.ret.ELSECODE = $e12.ret;})|) RIGHTPARANTHESIS)? ;

forstatement returns [ForStatementElement ret]
@init{
   retval.ret = new ForStatementElement();
}:'for'  r11=range{retval.ret.RANGE = $r11.ret;} LEFTPARANTHESIS (e11=expr1{retval.ret.ADDCODE =$e11.ret;})+ RIGHTPARANTHESIS;

   //vinit tasks
   functioncall returns [FunctionCallElement ret]
 @init{ retval.ret = new FunctionCallElement();
 }
  :variable{retval.ret.setfunctioncallname($variable.ret);}
  '('(el1=var_int_or_double_literal{retval.ret.setparameters($el1.ret);} (',' el2=var_int_or_double_literal{retval.ret.setparameters($el2.ret);})*)? ')'
  END_OF_STATEMENT
;
 
 
equality returns [EqualityOperationElement ret]
 
@init {
  retval.ret = new EqualityOperationElement();
}
 
: variable {retval.ret.setequalityLhs($variable.ret); }
     EQUALITYEXPRESSION
        var_int_or_double_literal {retval.ret.setequalityRhs($var_int_or_double_literal.ret); } 
     ;
    
    
nonequality returns [NonEqualityOperationElement ret]
 
@init {
  retval.ret = new NonEqualityOperationElement();
}
 
: variable {retval.ret.setnonequalityLhs($variable.ret); }
     NONEQUALITYEXPRESSION
   var_int_or_double_literal {retval.ret.setnonequalityRhs($var_int_or_double_literal.ret); } 
     ;    

//In the function body according to this design it will return only one of the expression to function definition class. we need a list of all the valid SPINACH code inside the function body.
//program will return the list of all the valid spinach code but that will include everything including parallelfor. if we need to support everything in a function then use that else use the bodyloop function.
functiondefination returns [FunctionElement ret]

@init{
retval.ret = new FunctionElement();
}
: (VARTYPE{retval.ret.setreturntype($VARTYPE.text);}
  variable {retval.ret.setfunctionname($variable.ret);}
  '('
 ((e11= functiondeclaration{retval.ret.setArguments($e11.ret);}(',' e12 =functiondeclaration{retval.ret.setArguments($e12.ret);})*)?)
 ')'
'{' (assignment{retval.ret.setBody($assignment.ret);}|functioncall{retval.ret.setBody($functioncall.ret);}| scalarvardec { retval.ret.setBody($scalarvardec.ret);}
  | vectorvardec { retval.ret.setBody($vectorvardec.ret);}
  | matrixvardec { retval.ret.setBody($matrixvardec.ret);}
  | deletionofvar { retval.ret.setBody($deletionofvar.ret);} | print { retval.ret.setBody($print.ret); }
  | ifelse{retval.ret.setBody($ifelse.ret);}| functionreturn{retval.ret.setBody($functionreturn.ret);})+
'}')|'void'{retval.ret.setreturntype("void");}
  variable {retval.ret.setfunctionname($variable.ret);}
  '('
 ((e11 = functiondeclaration{retval.ret.setArguments($e11.ret);}(',' e12=functiondeclaration{retval.ret.setArguments($e12.ret);})*)?)
 ')'
'{' (assignment{retval.ret.setBody($assignment.ret);}|functioncall{retval.ret.setBody($functioncall.ret);}| scalarvardec { retval.ret.setBody($scalarvardec.ret);}
  | vectorvardec { retval.ret.setBody($vectorvardec.ret);}
  | matrixvardec { retval.ret.setBody($matrixvardec.ret);}
  | deletionofvar { retval.ret.setBody($deletionofvar.ret);} | print { retval.ret.setBody($print.ret); }
  | ifelse{retval.ret.setBody($ifelse.ret);}| functionreturn{retval.ret.setBody($functionreturn.ret);})+
'}'
;
functiondeclaration returns [DeclarationElement ret]
 @init { retval.ret = new DeclarationElement();
}
:((VARTYPE{retval.ret.settype($VARTYPE.text);})  variable{retval.ret.setvariable($variable.ret); })
;

functionreturn returns [ReturnElement ret]
@init{
retval.ret = new ReturnElement();
}
:'return' (var_int_or_double_literal{retval.ret.setreturnvariable($var_int_or_double_literal.ret);}) END_OF_STATEMENT
;


//END OF VINIT TASKS
 
 
plotfunctions returns [PlotFunctionElement ret]
@init { retval.ret = new PlotFunctionElement();
}
: ('subPlot'{retval.ret.setPlotFunction("subPlot");} '('
(el1 = int_literal {retval.ret.setRow($el1.ret);}) ','
(el2 = int_literal {retval.ret.setColumn($el2.ret);}) ','
(vl1 = variable {retval.ret.setData($vl1.ret);}) ','
((el3 = int_literal{retval.ret.setMode($el3.ret);})',')?
(vl2 =variable {retval.ret.setTitle($vl2.ret);})','
(el4 = int_literal{retval.ret.setPlotType($el4.ret);})
')'END_OF_STATEMENT)
| ('plot'{retval.ret.setPlotFunction("plot");} '('
(vl1= variable {retval.ret.setData($vl1.ret);}) ','
((el1 = int_literal{retval.ret.setMode($el1.ret);})',')?
(vl2= variable {retval.ret.setTitle($vl2.ret);})','
(el2 =int_literal{retval.ret.setPlotType($el2.ret);})
')'END_OF_STATEMENT)
| ('resetPlot''('')'{retval.ret.setPlotFunction("resetPlot");}END_OF_STATEMENT)
| ('setPlotAxis'{retval.ret.setPlotFunction("setPlotAxis");}'('
(ell2 =int_literal{retval.ret.setXFact($ell2.ret);})','
((ell3=int_literal{retval.ret.setYFact($ell3.ret);})',')
((el4=int_literal{retval.ret.setZFact($el4.ret);}))
')'END_OF_STATEMENT)
|('setPlotAxis'{retval.ret.setPlotFunction("setPlotAxis");}'('
(ell2 =int_literal{retval.ret.setXFact($ell2.ret);})','
((ell3=int_literal{retval.ret.setYFact($ell3.ret);}))
')'END_OF_STATEMENT)
|('setPlotAxis'{retval.ret.setPlotFunction("setPlotAxis");}'('
(ell2 =int_literal{retval.ret.setXFact($ell2.ret);})
')'END_OF_STATEMENT)
| ('setAxisTitle'{retval.ret.setPlotFunction("setAxisTitle");}'('
(vl1= variable{retval.ret.setXTitle($vl1.ret);})','
((vl2 =variable{retval.ret.setYTitle($vl2.ret);})',')
((vl3 =variable{retval.ret.setZTitle($vl3.ret);}))
')'END_OF_STATEMENT)
| ('setAxisTitle'{retval.ret.setPlotFunction("setAxisTitle");}'('
(vl1= variable{retval.ret.setXTitle($vl1.ret);})','
((vl2 =variable{retval.ret.setYTitle($vl2.ret);}))
')'END_OF_STATEMENT)
|('setAxisTitle'{retval.ret.setPlotFunction("setAxisTitle");}'('
(vl1= variable{retval.ret.setXTitle($vl1.ret);})
')'END_OF_STATEMENT)
|('setScaleMode''('{retval.ret.setPlotFunction("setScaleMode");}
SCALEMODE {retval.ret.setScaleMode($SCALEMODE.Text);}
')'
END_OF_STATEMENT)
;
/*
 * Lexer Rules
 */
 
END_OF_STATEMENT: ';';
SCALEMODE: 'log' | 'linear' ;
VARTYPE	: 'int' | 'double';
STRINGTYPE : 'string';	
DOT	:'.';
ASSIGNMENT: '=';
PLUS: '+';
MULTIPLY:'*';
VARIABLE: ('a'..'z' | 'A'..'Z' )+;
INT_LITERAL: ('0'..'9')+;
DOUBLE_LITERAL:(INT_LITERAL DOT INT_LITERAL);	
WHITESPACE : (' ' | '\t' | '\n' | '\r' )+ {$channel = HIDDEN; } ;
LEFTBRACE :'(';
RIGHTBRACE:')';
LEFTPARANTHESIS:'{';
RIGHTPARANTHESIS:'}';
POINT: '->';
EQUALITYEXPRESSION: '==';
NONEQUALITYEXPRESSION: '!='; 