// $ANTLR 3.1.3 Mar 18, 2009 10:09:25 spinach.g 2009-11-26 01:19:36


using System.Collections.Generic;


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;



using Antlr.Runtime.Tree;

public class spinachParser : Parser 
{
    public static readonly string[] tokenNames = new string[] 
	{
        "<invalid>", 
		"<EOR>", 
		"<DOWN>", 
		"<UP>", 
		"VARIABLE", 
		"INT_LITERAL", 
		"DOUBLE_LITERAL", 
		"VARTYPE", 
		"ASSIGNMENT", 
		"END_OF_STATEMENT", 
		"STRINGTYPE", 
		"LEFTBRACE", 
		"POINT", 
		"RIGHTBRACE", 
		"LEFTPARANTHESIS", 
		"RIGHTPARANTHESIS", 
		"SCALEMODE", 
		"PLUS", 
		"MULTIPLY", 
		"DOT", 
		"WHITESPACE", 
		"EQUALITYEXPRESSION", 
		"NONEQUALITYEXPRESSION", 
		"LESSTHANEXPRESSION", 
		"LESSTHANEQUALTOEXPRESSION", 
		"GREATERTHANEXPRESSION", 
		"GREATERTHANEQUALTOEXPRESSION", 
		"'matrix'", 
		"'['", 
		"']'", 
		"','", 
		"'vector'", 
		"'-'", 
		"'struct'", 
		"'delete'", 
		"'print'", 
		"'parallelfor'", 
		"'to'", 
		"'SYNC'", 
		"'if'", 
		"'else'", 
		"'for'", 
		"'void'", 
		"'DOT'", 
		"'T'", 
		"'return'", 
		"'subPlot'", 
		"'1D'", 
		"'2D'", 
		"'3D'", 
		"'plot'", 
		"'resetPlot'", 
		"'setPlotAxis'", 
		"'setAxisTitle'", 
		"'setScaleMode('", 
		"'//'", 
		"'setScaleMode'", 
		"'\"'", 
		"'&'", 
		"':'", 
		"'^'", 
		"'$'", 
		"'#'", 
		"'@'", 
		"'!'", 
		"'?'", 
		"'/'"
    };

    public const int T__66 = 66;
    public const int T__29 = 29;
    public const int T__64 = 64;
    public const int T__28 = 28;
    public const int T__65 = 65;
    public const int T__27 = 27;
    public const int T__62 = 62;
    public const int T__63 = 63;
    public const int POINT = 12;
    public const int EQUALITYEXPRESSION = 21;
    public const int DOUBLE_LITERAL = 6;
    public const int T__61 = 61;
    public const int EOF = -1;
    public const int T__60 = 60;
    public const int NONEQUALITYEXPRESSION = 22;
    public const int T__55 = 55;
    public const int T__56 = 56;
    public const int T__57 = 57;
    public const int T__58 = 58;
    public const int T__51 = 51;
    public const int LEFTBRACE = 11;
    public const int T__52 = 52;
    public const int T__53 = 53;
    public const int LESSTHANEQUALTOEXPRESSION = 24;
    public const int T__54 = 54;
    public const int MULTIPLY = 18;
    public const int T__59 = 59;
    public const int PLUS = 17;
    public const int RIGHTBRACE = 13;
    public const int LESSTHANEXPRESSION = 23;
    public const int DOT = 19;
    public const int T__50 = 50;
    public const int END_OF_STATEMENT = 9;
    public const int RIGHTPARANTHESIS = 15;
    public const int GREATERTHANEQUALTOEXPRESSION = 26;
    public const int T__42 = 42;
    public const int T__43 = 43;
    public const int SCALEMODE = 16;
    public const int T__40 = 40;
    public const int INT_LITERAL = 5;
    public const int T__41 = 41;
    public const int T__46 = 46;
    public const int T__47 = 47;
    public const int T__44 = 44;
    public const int T__45 = 45;
    public const int T__48 = 48;
    public const int T__49 = 49;
    public const int WHITESPACE = 20;
    public const int GREATERTHANEXPRESSION = 25;
    public const int VARTYPE = 7;
    public const int T__30 = 30;
    public const int T__31 = 31;
    public const int T__32 = 32;
    public const int T__33 = 33;
    public const int T__34 = 34;
    public const int VARIABLE = 4;
    public const int T__35 = 35;
    public const int T__36 = 36;
    public const int T__37 = 37;
    public const int T__38 = 38;
    public const int T__39 = 39;
    public const int STRINGTYPE = 10;
    public const int LEFTPARANTHESIS = 14;
    public const int ASSIGNMENT = 8;

    // delegates
    // delegators



        public spinachParser(ITokenStream input)
    		: this(input, new RecognizerSharedState()) {
        }

        public spinachParser(ITokenStream input, RecognizerSharedState state)
    		: base(input, state) {
            InitializeCyclicDFAs();

             
       }
        
    protected ITreeAdaptor adaptor = new CommonTreeAdaptor();

    public ITreeAdaptor TreeAdaptor
    {
        get { return this.adaptor; }
        set {
    	this.adaptor = value;
    	}
    }

    override public string[] TokenNames {
		get { return spinachParser.tokenNames; }
    }

    override public string GrammarFileName {
		get { return "spinach.g"; }
    }


    public class program_return : ParserRuleReturnScope
    {
        public List<Element> ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "program"
    // spinach.g:24:1: program returns [List<Element> ret] : ( ( expr | comment )+ EOF ) ;
    public spinachParser.program_return program() // throws RecognitionException [1]
    {   
        spinachParser.program_return retval = new spinachParser.program_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken EOF3 = null;
        spinachParser.expr_return expr1 = null;

        spinachParser.comment_return comment2 = null;


        object EOF3_tree=null;


          retval.ret = new List<Element>();

        try 
    	{
            // spinach.g:28:3: ( ( ( expr | comment )+ EOF ) )
            // spinach.g:28:5: ( ( expr | comment )+ EOF )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// spinach.g:28:5: ( ( expr | comment )+ EOF )
            	// spinach.g:28:6: ( expr | comment )+ EOF
            	{
            		// spinach.g:28:6: ( expr | comment )+
            		int cnt1 = 0;
            		do 
            		{
            		    int alt1 = 3;
            		    int LA1_0 = input.LA(1);

            		    if ( (LA1_0 == VARIABLE || LA1_0 == VARTYPE || LA1_0 == STRINGTYPE || LA1_0 == 27 || LA1_0 == 31 || (LA1_0 >= 33 && LA1_0 <= 36) || LA1_0 == 39 || (LA1_0 >= 41 && LA1_0 <= 42) || LA1_0 == 46 || (LA1_0 >= 50 && LA1_0 <= 54)) )
            		    {
            		        alt1 = 1;
            		    }
            		    else if ( (LA1_0 == 55) )
            		    {
            		        alt1 = 2;
            		    }


            		    switch (alt1) 
            			{
            				case 1 :
            				    // spinach.g:28:7: expr
            				    {
            				    	PushFollow(FOLLOW_expr_in_program70);
            				    	expr1 = expr();
            				    	state.followingStackPointer--;

            				    	adaptor.AddChild(root_0, expr1.Tree);
            				    	retval.ret.Add(((expr1 != null) ? expr1.ret : null)); 

            				    }
            				    break;
            				case 2 :
            				    // spinach.g:28:44: comment
            				    {
            				    	PushFollow(FOLLOW_comment_in_program76);
            				    	comment2 = comment();
            				    	state.followingStackPointer--;

            				    	adaptor.AddChild(root_0, comment2.Tree);
            				    	retval.ret.Add(((comment2 != null) ? comment2.ret : null));

            				    }
            				    break;

            				default:
            				    if ( cnt1 >= 1 ) goto loop1;
            			            EarlyExitException eee1 =
            			                new EarlyExitException(1, input);
            			            throw eee1;
            		    }
            		    cnt1++;
            		} while (true);

            		loop1:
            			;	// Stops C# compiler whining that label 'loop1' has no statements

            		EOF3=(IToken)Match(input,EOF,FOLLOW_EOF_in_program82); 
            			EOF3_tree = (object)adaptor.Create(EOF3);
            			adaptor.AddChild(root_0, EOF3_tree);


            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "program"

    public class expr_return : ParserRuleReturnScope
    {
        public Element ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "expr"
    // spinach.g:32:1: expr returns [Element ret] : ( expr1 | parallelfor | structdec | functiondefination );
    public spinachParser.expr_return expr() // throws RecognitionException [1]
    {   
        spinachParser.expr_return retval = new spinachParser.expr_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        spinachParser.expr1_return expr14 = null;

        spinachParser.parallelfor_return parallelfor5 = null;

        spinachParser.structdec_return structdec6 = null;

        spinachParser.functiondefination_return functiondefination7 = null;



        try 
    	{
            // spinach.g:33:3: ( expr1 | parallelfor | structdec | functiondefination )
            int alt2 = 4;
            switch ( input.LA(1) ) 
            {
            case VARIABLE:
            case STRINGTYPE:
            case 27:
            case 31:
            case 34:
            case 35:
            case 39:
            case 41:
            case 46:
            case 50:
            case 51:
            case 52:
            case 53:
            case 54:
            	{
                alt2 = 1;
                }
                break;
            case VARTYPE:
            	{
                int LA2_2 = input.LA(2);

                if ( (LA2_2 == VARIABLE) )
                {
                    int LA2_6 = input.LA(3);

                    if ( (LA2_6 == END_OF_STATEMENT) )
                    {
                        alt2 = 1;
                    }
                    else if ( (LA2_6 == LEFTBRACE) )
                    {
                        alt2 = 4;
                    }
                    else 
                    {
                        NoViableAltException nvae_d2s6 =
                            new NoViableAltException("", 2, 6, input);

                        throw nvae_d2s6;
                    }
                }
                else 
                {
                    NoViableAltException nvae_d2s2 =
                        new NoViableAltException("", 2, 2, input);

                    throw nvae_d2s2;
                }
                }
                break;
            case 36:
            	{
                alt2 = 2;
                }
                break;
            case 33:
            	{
                alt2 = 3;
                }
                break;
            case 42:
            	{
                alt2 = 4;
                }
                break;
            	default:
            	    NoViableAltException nvae_d2s0 =
            	        new NoViableAltException("", 2, 0, input);

            	    throw nvae_d2s0;
            }

            switch (alt2) 
            {
                case 1 :
                    // spinach.g:33:4: expr1
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_expr1_in_expr105);
                    	expr14 = expr1();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, expr14.Tree);
                    	retval.ret = ((expr14 != null) ? expr14.ret : null);

                    }
                    break;
                case 2 :
                    // spinach.g:33:37: parallelfor
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_parallelfor_in_expr109);
                    	parallelfor5 = parallelfor();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, parallelfor5.Tree);
                    	retval.ret = ((parallelfor5 != null) ? parallelfor5.ret : null);

                    }
                    break;
                case 3 :
                    // spinach.g:33:82: structdec
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_structdec_in_expr113);
                    	structdec6 = structdec();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, structdec6.Tree);
                    	retval.ret = ((structdec6 != null) ? structdec6.ret : null);

                    }
                    break;
                case 4 :
                    // spinach.g:34:8: functiondefination
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_functiondefination_in_expr124);
                    	functiondefination7 = functiondefination();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, functiondefination7.Tree);
                    	retval.ret = ((functiondefination7 != null) ? functiondefination7.ret : null);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "expr"

    public class expr1_return : ParserRuleReturnScope
    {
        public Element ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "expr1"
    // spinach.g:37:1: expr1 returns [Element ret] : ( forexpr | print );
    public spinachParser.expr1_return expr1() // throws RecognitionException [1]
    {   
        spinachParser.expr1_return retval = new spinachParser.expr1_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        spinachParser.forexpr_return forexpr8 = null;

        spinachParser.print_return print9 = null;



        try 
    	{
            // spinach.g:38:4: ( forexpr | print )
            int alt3 = 2;
            int LA3_0 = input.LA(1);

            if ( (LA3_0 == VARIABLE || LA3_0 == VARTYPE || LA3_0 == STRINGTYPE || LA3_0 == 27 || LA3_0 == 31 || LA3_0 == 34 || LA3_0 == 39 || LA3_0 == 41 || LA3_0 == 46 || (LA3_0 >= 50 && LA3_0 <= 54)) )
            {
                alt3 = 1;
            }
            else if ( (LA3_0 == 35) )
            {
                alt3 = 2;
            }
            else 
            {
                NoViableAltException nvae_d3s0 =
                    new NoViableAltException("", 3, 0, input);

                throw nvae_d3s0;
            }
            switch (alt3) 
            {
                case 1 :
                    // spinach.g:38:5: forexpr
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_forexpr_in_expr1140);
                    	forexpr8 = forexpr();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, forexpr8.Tree);
                    	retval.ret = ((forexpr8 != null) ? forexpr8.ret : null);

                    }
                    break;
                case 2 :
                    // spinach.g:39:10: print
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_print_in_expr1152);
                    	print9 = print();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, print9.Tree);
                    	 retval.ret = ((print9 != null) ? print9.ret : null); 

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "expr1"

    public class forexpr_return : ParserRuleReturnScope
    {
        public Element ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "forexpr"
    // spinach.g:43:1: forexpr returns [Element ret] : ( expr2 | matrixvardec | plotfunctions | functioncall | vectorvardec );
    public spinachParser.forexpr_return forexpr() // throws RecognitionException [1]
    {   
        spinachParser.forexpr_return retval = new spinachParser.forexpr_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        spinachParser.expr2_return expr210 = null;

        spinachParser.matrixvardec_return matrixvardec11 = null;

        spinachParser.plotfunctions_return plotfunctions12 = null;

        spinachParser.functioncall_return functioncall13 = null;

        spinachParser.vectorvardec_return vectorvardec14 = null;



        try 
    	{
            // spinach.g:44:1: ( expr2 | matrixvardec | plotfunctions | functioncall | vectorvardec )
            int alt4 = 5;
            switch ( input.LA(1) ) 
            {
            case VARIABLE:
            	{
                int LA4_1 = input.LA(2);

                if ( (LA4_1 == VARIABLE || LA4_1 == ASSIGNMENT || LA4_1 == DOT || LA4_1 == 28) )
                {
                    alt4 = 1;
                }
                else if ( (LA4_1 == LEFTBRACE) )
                {
                    alt4 = 4;
                }
                else 
                {
                    NoViableAltException nvae_d4s1 =
                        new NoViableAltException("", 4, 1, input);

                    throw nvae_d4s1;
                }
                }
                break;
            case VARTYPE:
            case STRINGTYPE:
            case 34:
            case 39:
            case 41:
            	{
                alt4 = 1;
                }
                break;
            case 27:
            	{
                alt4 = 2;
                }
                break;
            case 46:
            case 50:
            case 51:
            case 52:
            case 53:
            case 54:
            	{
                alt4 = 3;
                }
                break;
            case 31:
            	{
                alt4 = 5;
                }
                break;
            	default:
            	    NoViableAltException nvae_d4s0 =
            	        new NoViableAltException("", 4, 0, input);

            	    throw nvae_d4s0;
            }

            switch (alt4) 
            {
                case 1 :
                    // spinach.g:45:7: expr2
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_expr2_in_forexpr185);
                    	expr210 = expr2();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, expr210.Tree);
                    	retval.ret = ((expr210 != null) ? expr210.ret : null);

                    }
                    break;
                case 2 :
                    // spinach.g:46:7: matrixvardec
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_matrixvardec_in_forexpr194);
                    	matrixvardec11 = matrixvardec();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, matrixvardec11.Tree);
                    	 retval.ret = ((matrixvardec11 != null) ? matrixvardec11.ret : null);

                    }
                    break;
                case 3 :
                    // spinach.g:47:7: plotfunctions
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_plotfunctions_in_forexpr204);
                    	plotfunctions12 = plotfunctions();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, plotfunctions12.Tree);
                    	retval.ret = ((plotfunctions12 != null) ? plotfunctions12.ret : null);

                    }
                    break;
                case 4 :
                    // spinach.g:48:7: functioncall
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_functioncall_in_forexpr213);
                    	functioncall13 = functioncall();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, functioncall13.Tree);
                    	retval.ret=((functioncall13 != null) ? functioncall13.ret : null);

                    }
                    break;
                case 5 :
                    // spinach.g:49:7: vectorvardec
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_vectorvardec_in_forexpr222);
                    	vectorvardec14 = vectorvardec();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, vectorvardec14.Tree);
                    	 retval.ret = ((vectorvardec14 != null) ? vectorvardec14.ret : null);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "forexpr"

    public class expr2_return : ParserRuleReturnScope
    {
        public Element ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "expr2"
    // spinach.g:52:1: expr2 returns [Element ret] : (el1= assignment | el4= ifelse | el5= forstatement | e12= scalarvardec | e13= deletionofvar | structobjdec ) ;
    public spinachParser.expr2_return expr2() // throws RecognitionException [1]
    {   
        spinachParser.expr2_return retval = new spinachParser.expr2_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        spinachParser.assignment_return el1 = null;

        spinachParser.ifelse_return el4 = null;

        spinachParser.forstatement_return el5 = null;

        spinachParser.scalarvardec_return e12 = null;

        spinachParser.deletionofvar_return e13 = null;

        spinachParser.structobjdec_return structobjdec15 = null;



        try 
    	{
            // spinach.g:53:1: ( (el1= assignment | el4= ifelse | el5= forstatement | e12= scalarvardec | e13= deletionofvar | structobjdec ) )
            // spinach.g:53:4: (el1= assignment | el4= ifelse | el5= forstatement | e12= scalarvardec | e13= deletionofvar | structobjdec )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// spinach.g:53:4: (el1= assignment | el4= ifelse | el5= forstatement | e12= scalarvardec | e13= deletionofvar | structobjdec )
            	int alt5 = 6;
            	switch ( input.LA(1) ) 
            	{
            	case VARIABLE:
            		{
            	    int LA5_1 = input.LA(2);

            	    if ( (LA5_1 == ASSIGNMENT || LA5_1 == DOT || LA5_1 == 28) )
            	    {
            	        alt5 = 1;
            	    }
            	    else if ( (LA5_1 == VARIABLE) )
            	    {
            	        alt5 = 6;
            	    }
            	    else 
            	    {
            	        NoViableAltException nvae_d5s1 =
            	            new NoViableAltException("", 5, 1, input);

            	        throw nvae_d5s1;
            	    }
            	    }
            	    break;
            	case 39:
            		{
            	    alt5 = 2;
            	    }
            	    break;
            	case 41:
            		{
            	    alt5 = 3;
            	    }
            	    break;
            	case VARTYPE:
            	case STRINGTYPE:
            		{
            	    alt5 = 4;
            	    }
            	    break;
            	case 34:
            		{
            	    alt5 = 5;
            	    }
            	    break;
            		default:
            		    NoViableAltException nvae_d5s0 =
            		        new NoViableAltException("", 5, 0, input);

            		    throw nvae_d5s0;
            	}

            	switch (alt5) 
            	{
            	    case 1 :
            	        // spinach.g:53:5: el1= assignment
            	        {
            	        	PushFollow(FOLLOW_assignment_in_expr2242);
            	        	el1 = assignment();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, el1.Tree);
            	        	retval.ret = ((el1 != null) ? el1.ret : null);

            	        }
            	        break;
            	    case 2 :
            	        // spinach.g:54:5: el4= ifelse
            	        {
            	        	PushFollow(FOLLOW_ifelse_in_expr2252);
            	        	el4 = ifelse();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, el4.Tree);
            	        	retval.ret = ((el4 != null) ? el4.ret : null);

            	        }
            	        break;
            	    case 3 :
            	        // spinach.g:55:5: el5= forstatement
            	        {
            	        	PushFollow(FOLLOW_forstatement_in_expr2262);
            	        	el5 = forstatement();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, el5.Tree);
            	        	retval.ret = ((el5 != null) ? el5.ret : null);

            	        }
            	        break;
            	    case 4 :
            	        // spinach.g:57:5: e12= scalarvardec
            	        {
            	        	PushFollow(FOLLOW_scalarvardec_in_expr2274);
            	        	e12 = scalarvardec();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, e12.Tree);
            	        	 retval.ret = ((e12 != null) ? e12.ret : null);

            	        }
            	        break;
            	    case 5 :
            	        // spinach.g:58:5: e13= deletionofvar
            	        {
            	        	PushFollow(FOLLOW_deletionofvar_in_expr2286);
            	        	e13 = deletionofvar();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, e13.Tree);
            	        	retval.ret = ((e13 != null) ? e13.ret : null);

            	        }
            	        break;
            	    case 6 :
            	        // spinach.g:59:5: structobjdec
            	        {
            	        	PushFollow(FOLLOW_structobjdec_in_expr2293);
            	        	structobjdec15 = structobjdec();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, structobjdec15.Tree);
            	        	 retval.ret = ((structobjdec15 != null) ? structobjdec15.ret : null);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "expr2"

    public class var_int_or_double_literal_return : ParserRuleReturnScope
    {
        public Element ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "var_int_or_double_literal"
    // spinach.g:63:1: var_int_or_double_literal returns [Element ret] : ( int_literal | double_literal | varorstruct ) ;
    public spinachParser.var_int_or_double_literal_return var_int_or_double_literal() // throws RecognitionException [1]
    {   
        spinachParser.var_int_or_double_literal_return retval = new spinachParser.var_int_or_double_literal_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        spinachParser.int_literal_return int_literal16 = null;

        spinachParser.double_literal_return double_literal17 = null;

        spinachParser.varorstruct_return varorstruct18 = null;



        try 
    	{
            // spinach.g:64:3: ( ( int_literal | double_literal | varorstruct ) )
            // spinach.g:64:7: ( int_literal | double_literal | varorstruct )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// spinach.g:64:7: ( int_literal | double_literal | varorstruct )
            	int alt6 = 3;
            	switch ( input.LA(1) ) 
            	{
            	case INT_LITERAL:
            		{
            	    alt6 = 1;
            	    }
            	    break;
            	case DOUBLE_LITERAL:
            		{
            	    alt6 = 2;
            	    }
            	    break;
            	case VARIABLE:
            		{
            	    alt6 = 3;
            	    }
            	    break;
            		default:
            		    NoViableAltException nvae_d6s0 =
            		        new NoViableAltException("", 6, 0, input);

            		    throw nvae_d6s0;
            	}

            	switch (alt6) 
            	{
            	    case 1 :
            	        // spinach.g:64:8: int_literal
            	        {
            	        	PushFollow(FOLLOW_int_literal_in_var_int_or_double_literal318);
            	        	int_literal16 = int_literal();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, int_literal16.Tree);
            	        	retval.ret = ((int_literal16 != null) ? int_literal16.ret : null); 

            	        }
            	        break;
            	    case 2 :
            	        // spinach.g:65:7: double_literal
            	        {
            	        	PushFollow(FOLLOW_double_literal_in_var_int_or_double_literal328);
            	        	double_literal17 = double_literal();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, double_literal17.Tree);
            	        	retval.ret = ((double_literal17 != null) ? double_literal17.ret : null);

            	        }
            	        break;
            	    case 3 :
            	        // spinach.g:66:5: varorstruct
            	        {
            	        	PushFollow(FOLLOW_varorstruct_in_var_int_or_double_literal336);
            	        	varorstruct18 = varorstruct();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, varorstruct18.Tree);
            	        	retval.ret = ((varorstruct18 != null) ? varorstruct18.ret : null);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "var_int_or_double_literal"

    public class varorstruct_return : ParserRuleReturnScope
    {
        public Element ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "varorstruct"
    // spinach.g:68:1: varorstruct returns [Element ret] : ( variable | matrixelem | vectorelem | structassign ) ;
    public spinachParser.varorstruct_return varorstruct() // throws RecognitionException [1]
    {   
        spinachParser.varorstruct_return retval = new spinachParser.varorstruct_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        spinachParser.variable_return variable19 = null;

        spinachParser.matrixelem_return matrixelem20 = null;

        spinachParser.vectorelem_return vectorelem21 = null;

        spinachParser.structassign_return structassign22 = null;



        try 
    	{
            // spinach.g:69:1: ( ( variable | matrixelem | vectorelem | structassign ) )
            // spinach.g:69:3: ( variable | matrixelem | vectorelem | structassign )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// spinach.g:69:3: ( variable | matrixelem | vectorelem | structassign )
            	int alt7 = 4;
            	alt7 = dfa7.Predict(input);
            	switch (alt7) 
            	{
            	    case 1 :
            	        // spinach.g:69:4: variable
            	        {
            	        	PushFollow(FOLLOW_variable_in_varorstruct351);
            	        	variable19 = variable();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, variable19.Tree);
            	        	retval.ret = ((variable19 != null) ? variable19.ret : null);

            	        }
            	        break;
            	    case 2 :
            	        // spinach.g:70:2: matrixelem
            	        {
            	        	PushFollow(FOLLOW_matrixelem_in_varorstruct355);
            	        	matrixelem20 = matrixelem();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, matrixelem20.Tree);
            	        	retval.ret=((matrixelem20 != null) ? matrixelem20.ret : null);

            	        }
            	        break;
            	    case 3 :
            	        // spinach.g:71:2: vectorelem
            	        {
            	        	PushFollow(FOLLOW_vectorelem_in_varorstruct359);
            	        	vectorelem21 = vectorelem();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, vectorelem21.Tree);
            	        	retval.ret=((vectorelem21 != null) ? vectorelem21.ret : null);

            	        }
            	        break;
            	    case 4 :
            	        // spinach.g:72:2: structassign
            	        {
            	        	PushFollow(FOLLOW_structassign_in_varorstruct365);
            	        	structassign22 = structassign();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, structassign22.Tree);
            	        	retval.ret = ((structassign22 != null) ? structassign22.ret : null);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "varorstruct"

    public class variable_return : ParserRuleReturnScope
    {
        public VariableElement ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "variable"
    // spinach.g:75:1: variable returns [VariableElement ret] : VARIABLE ;
    public spinachParser.variable_return variable() // throws RecognitionException [1]
    {   
        spinachParser.variable_return retval = new spinachParser.variable_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken VARIABLE23 = null;

        object VARIABLE23_tree=null;


          retval.ret = new VariableElement();

        try 
    	{
            // spinach.g:79:3: ( VARIABLE )
            // spinach.g:79:5: VARIABLE
            {
            	root_0 = (object)adaptor.GetNilNode();

            	VARIABLE23=(IToken)Match(input,VARIABLE,FOLLOW_VARIABLE_in_variable387); 
            		VARIABLE23_tree = (object)adaptor.Create(VARIABLE23);
            		adaptor.AddChild(root_0, VARIABLE23_tree);

            	 retval.ret.setText(((VARIABLE23 != null) ? VARIABLE23.Text : null)); 

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "variable"

    public class int_literal_return : ParserRuleReturnScope
    {
        public IntegerElement ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "int_literal"
    // spinach.g:81:1: int_literal returns [IntegerElement ret] : INT_LITERAL ;
    public spinachParser.int_literal_return int_literal() // throws RecognitionException [1]
    {   
        spinachParser.int_literal_return retval = new spinachParser.int_literal_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken INT_LITERAL24 = null;

        object INT_LITERAL24_tree=null;


          retval.ret = new IntegerElement();

        try 
    	{
            // spinach.g:85:3: ( INT_LITERAL )
            // spinach.g:85:5: INT_LITERAL
            {
            	root_0 = (object)adaptor.GetNilNode();

            	INT_LITERAL24=(IToken)Match(input,INT_LITERAL,FOLLOW_INT_LITERAL_in_int_literal408); 
            		INT_LITERAL24_tree = (object)adaptor.Create(INT_LITERAL24);
            		adaptor.AddChild(root_0, INT_LITERAL24_tree);

            	 retval.ret.setText(((INT_LITERAL24 != null) ? INT_LITERAL24.Text : null)); 

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "int_literal"

    public class double_literal_return : ParserRuleReturnScope
    {
        public DoubleElement ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "double_literal"
    // spinach.g:87:1: double_literal returns [DoubleElement ret] : el1= DOUBLE_LITERAL ;
    public spinachParser.double_literal_return double_literal() // throws RecognitionException [1]
    {   
        spinachParser.double_literal_return retval = new spinachParser.double_literal_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken el1 = null;

        object el1_tree=null;


        	retval.ret = new DoubleElement();
        	
        try 
    	{
            // spinach.g:91:2: (el1= DOUBLE_LITERAL )
            // spinach.g:91:4: el1= DOUBLE_LITERAL
            {
            	root_0 = (object)adaptor.GetNilNode();

            	el1=(IToken)Match(input,DOUBLE_LITERAL,FOLLOW_DOUBLE_LITERAL_in_double_literal430); 
            		el1_tree = (object)adaptor.Create(el1);
            		adaptor.AddChild(root_0, el1_tree);

            	retval.ret.setText(((el1 != null) ? el1.Text : null));

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "double_literal"

    public class matrixvardec_return : ParserRuleReturnScope
    {
        public MatrixVariableDeclaration ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "matrixvardec"
    // spinach.g:95:1: matrixvardec returns [MatrixVariableDeclaration ret] : ( 'matrix' '<' (el0= VARTYPE '>' '[' el1= int_literal ']' '[' el2= int_literal ']' (el3= variable ) ASSIGNMENT ( ( '[' ']' ) | ( '[' (el7= int_literal ( ',' el5= int_literal )* ) ']' ) | ( '[' el4= double_literal ( ',' el6= double_literal )* ) ']' ) ) ) END_OF_STATEMENT ;
    public spinachParser.matrixvardec_return matrixvardec() // throws RecognitionException [1]
    {   
        spinachParser.matrixvardec_return retval = new spinachParser.matrixvardec_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken el0 = null;
        IToken string_literal25 = null;
        IToken char_literal26 = null;
        IToken char_literal27 = null;
        IToken char_literal28 = null;
        IToken char_literal29 = null;
        IToken char_literal30 = null;
        IToken char_literal31 = null;
        IToken ASSIGNMENT32 = null;
        IToken char_literal33 = null;
        IToken char_literal34 = null;
        IToken char_literal35 = null;
        IToken char_literal36 = null;
        IToken char_literal37 = null;
        IToken char_literal38 = null;
        IToken char_literal39 = null;
        IToken char_literal40 = null;
        IToken END_OF_STATEMENT41 = null;
        spinachParser.int_literal_return el1 = null;

        spinachParser.int_literal_return el2 = null;

        spinachParser.variable_return el3 = null;

        spinachParser.int_literal_return el7 = null;

        spinachParser.int_literal_return el5 = null;

        spinachParser.double_literal_return el4 = null;

        spinachParser.double_literal_return el6 = null;


        object el0_tree=null;
        object string_literal25_tree=null;
        object char_literal26_tree=null;
        object char_literal27_tree=null;
        object char_literal28_tree=null;
        object char_literal29_tree=null;
        object char_literal30_tree=null;
        object char_literal31_tree=null;
        object ASSIGNMENT32_tree=null;
        object char_literal33_tree=null;
        object char_literal34_tree=null;
        object char_literal35_tree=null;
        object char_literal36_tree=null;
        object char_literal37_tree=null;
        object char_literal38_tree=null;
        object char_literal39_tree=null;
        object char_literal40_tree=null;
        object END_OF_STATEMENT41_tree=null;


        	retval.ret = new MatrixVariableDeclaration();
        	
        try 
    	{
            // spinach.g:99:2: ( ( 'matrix' '<' (el0= VARTYPE '>' '[' el1= int_literal ']' '[' el2= int_literal ']' (el3= variable ) ASSIGNMENT ( ( '[' ']' ) | ( '[' (el7= int_literal ( ',' el5= int_literal )* ) ']' ) | ( '[' el4= double_literal ( ',' el6= double_literal )* ) ']' ) ) ) END_OF_STATEMENT )
            // spinach.g:99:3: ( 'matrix' '<' (el0= VARTYPE '>' '[' el1= int_literal ']' '[' el2= int_literal ']' (el3= variable ) ASSIGNMENT ( ( '[' ']' ) | ( '[' (el7= int_literal ( ',' el5= int_literal )* ) ']' ) | ( '[' el4= double_literal ( ',' el6= double_literal )* ) ']' ) ) ) END_OF_STATEMENT
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// spinach.g:99:3: ( 'matrix' '<' (el0= VARTYPE '>' '[' el1= int_literal ']' '[' el2= int_literal ']' (el3= variable ) ASSIGNMENT ( ( '[' ']' ) | ( '[' (el7= int_literal ( ',' el5= int_literal )* ) ']' ) | ( '[' el4= double_literal ( ',' el6= double_literal )* ) ']' ) ) )
            	// spinach.g:99:4: 'matrix' '<' (el0= VARTYPE '>' '[' el1= int_literal ']' '[' el2= int_literal ']' (el3= variable ) ASSIGNMENT ( ( '[' ']' ) | ( '[' (el7= int_literal ( ',' el5= int_literal )* ) ']' ) | ( '[' el4= double_literal ( ',' el6= double_literal )* ) ']' ) )
            	{
            		string_literal25=(IToken)Match(input,27,FOLLOW_27_in_matrixvardec452); 
            			string_literal25_tree = (object)adaptor.Create(string_literal25);
            			adaptor.AddChild(root_0, string_literal25_tree);

            		char_literal26=(IToken)Match(input,LESSTHANEXPRESSION,FOLLOW_LESSTHANEXPRESSION_in_matrixvardec454); 
            			char_literal26_tree = (object)adaptor.Create(char_literal26);
            			adaptor.AddChild(root_0, char_literal26_tree);

            		// spinach.g:100:2: (el0= VARTYPE '>' '[' el1= int_literal ']' '[' el2= int_literal ']' (el3= variable ) ASSIGNMENT ( ( '[' ']' ) | ( '[' (el7= int_literal ( ',' el5= int_literal )* ) ']' ) | ( '[' el4= double_literal ( ',' el6= double_literal )* ) ']' ) )
            		// spinach.g:100:3: el0= VARTYPE '>' '[' el1= int_literal ']' '[' el2= int_literal ']' (el3= variable ) ASSIGNMENT ( ( '[' ']' ) | ( '[' (el7= int_literal ( ',' el5= int_literal )* ) ']' ) | ( '[' el4= double_literal ( ',' el6= double_literal )* ) ']' )
            		{
            			el0=(IToken)Match(input,VARTYPE,FOLLOW_VARTYPE_in_matrixvardec461); 
            				el0_tree = (object)adaptor.Create(el0);
            				adaptor.AddChild(root_0, el0_tree);

            			 retval.ret.setType(((el0 != null) ? el0.Text : null));
            			char_literal27=(IToken)Match(input,GREATERTHANEXPRESSION,FOLLOW_GREATERTHANEXPRESSION_in_matrixvardec463); 
            				char_literal27_tree = (object)adaptor.Create(char_literal27);
            				adaptor.AddChild(root_0, char_literal27_tree);

            			char_literal28=(IToken)Match(input,28,FOLLOW_28_in_matrixvardec465); 
            				char_literal28_tree = (object)adaptor.Create(char_literal28);
            				adaptor.AddChild(root_0, char_literal28_tree);

            			PushFollow(FOLLOW_int_literal_in_matrixvardec468);
            			el1 = int_literal();
            			state.followingStackPointer--;

            			adaptor.AddChild(root_0, el1.Tree);
            			 retval.ret.setRow(((el1 != null) ? el1.ret : null));
            			char_literal29=(IToken)Match(input,29,FOLLOW_29_in_matrixvardec471); 
            				char_literal29_tree = (object)adaptor.Create(char_literal29);
            				adaptor.AddChild(root_0, char_literal29_tree);

            			char_literal30=(IToken)Match(input,28,FOLLOW_28_in_matrixvardec474); 
            				char_literal30_tree = (object)adaptor.Create(char_literal30);
            				adaptor.AddChild(root_0, char_literal30_tree);

            			PushFollow(FOLLOW_int_literal_in_matrixvardec478);
            			el2 = int_literal();
            			state.followingStackPointer--;

            			adaptor.AddChild(root_0, el2.Tree);
            			 retval.ret.setColumn(((el2 != null) ? el2.ret : null));
            			char_literal31=(IToken)Match(input,29,FOLLOW_29_in_matrixvardec481); 
            				char_literal31_tree = (object)adaptor.Create(char_literal31);
            				adaptor.AddChild(root_0, char_literal31_tree);

            			// spinach.g:102:3: (el3= variable )
            			// spinach.g:102:4: el3= variable
            			{
            				PushFollow(FOLLOW_variable_in_matrixvardec489);
            				el3 = variable();
            				state.followingStackPointer--;

            				adaptor.AddChild(root_0, el3.Tree);
            				 retval.ret.setVar(((el3 != null) ? el3.ret : null));

            			}

            			ASSIGNMENT32=(IToken)Match(input,ASSIGNMENT,FOLLOW_ASSIGNMENT_in_matrixvardec496); 
            				ASSIGNMENT32_tree = (object)adaptor.Create(ASSIGNMENT32);
            				adaptor.AddChild(root_0, ASSIGNMENT32_tree);

            			// spinach.g:104:3: ( ( '[' ']' ) | ( '[' (el7= int_literal ( ',' el5= int_literal )* ) ']' ) | ( '[' el4= double_literal ( ',' el6= double_literal )* ) ']' )
            			int alt10 = 3;
            			int LA10_0 = input.LA(1);

            			if ( (LA10_0 == 28) )
            			{
            			    switch ( input.LA(2) ) 
            			    {
            			    case 29:
            			    	{
            			        alt10 = 1;
            			        }
            			        break;
            			    case DOUBLE_LITERAL:
            			    	{
            			        alt10 = 3;
            			        }
            			        break;
            			    case INT_LITERAL:
            			    	{
            			        alt10 = 2;
            			        }
            			        break;
            			    	default:
            			    	    NoViableAltException nvae_d10s1 =
            			    	        new NoViableAltException("", 10, 1, input);

            			    	    throw nvae_d10s1;
            			    }

            			}
            			else 
            			{
            			    NoViableAltException nvae_d10s0 =
            			        new NoViableAltException("", 10, 0, input);

            			    throw nvae_d10s0;
            			}
            			switch (alt10) 
            			{
            			    case 1 :
            			        // spinach.g:104:4: ( '[' ']' )
            			        {
            			        	// spinach.g:104:4: ( '[' ']' )
            			        	// spinach.g:104:5: '[' ']'
            			        	{
            			        		char_literal33=(IToken)Match(input,28,FOLLOW_28_in_matrixvardec502); 
            			        			char_literal33_tree = (object)adaptor.Create(char_literal33);
            			        			adaptor.AddChild(root_0, char_literal33_tree);

            			        		char_literal34=(IToken)Match(input,29,FOLLOW_29_in_matrixvardec503); 
            			        			char_literal34_tree = (object)adaptor.Create(char_literal34);
            			        			adaptor.AddChild(root_0, char_literal34_tree);


            			        	}


            			        }
            			        break;
            			    case 2 :
            			        // spinach.g:105:3: ( '[' (el7= int_literal ( ',' el5= int_literal )* ) ']' )
            			        {
            			        	// spinach.g:105:3: ( '[' (el7= int_literal ( ',' el5= int_literal )* ) ']' )
            			        	// spinach.g:105:4: '[' (el7= int_literal ( ',' el5= int_literal )* ) ']'
            			        	{
            			        		char_literal35=(IToken)Match(input,28,FOLLOW_28_in_matrixvardec510); 
            			        			char_literal35_tree = (object)adaptor.Create(char_literal35);
            			        			adaptor.AddChild(root_0, char_literal35_tree);

            			        		// spinach.g:105:7: (el7= int_literal ( ',' el5= int_literal )* )
            			        		// spinach.g:105:8: el7= int_literal ( ',' el5= int_literal )*
            			        		{
            			        			PushFollow(FOLLOW_int_literal_in_matrixvardec514);
            			        			el7 = int_literal();
            			        			state.followingStackPointer--;

            			        			adaptor.AddChild(root_0, el7.Tree);
            			        			retval.ret.addValue(((el7 != null) ? el7.ret : null));
            			        			// spinach.g:105:57: ( ',' el5= int_literal )*
            			        			do 
            			        			{
            			        			    int alt8 = 2;
            			        			    int LA8_0 = input.LA(1);

            			        			    if ( (LA8_0 == 30) )
            			        			    {
            			        			        alt8 = 1;
            			        			    }


            			        			    switch (alt8) 
            			        				{
            			        					case 1 :
            			        					    // spinach.g:105:58: ',' el5= int_literal
            			        					    {
            			        					    	char_literal36=(IToken)Match(input,30,FOLLOW_30_in_matrixvardec519); 
            			        					    		char_literal36_tree = (object)adaptor.Create(char_literal36);
            			        					    		adaptor.AddChild(root_0, char_literal36_tree);

            			        					    	PushFollow(FOLLOW_int_literal_in_matrixvardec522);
            			        					    	el5 = int_literal();
            			        					    	state.followingStackPointer--;

            			        					    	adaptor.AddChild(root_0, el5.Tree);
            			        					    	retval.ret.addValue(((el5 != null) ? el5.ret : null));

            			        					    }
            			        					    break;

            			        					default:
            			        					    goto loop8;
            			        			    }
            			        			} while (true);

            			        			loop8:
            			        				;	// Stops C# compiler whining that label 'loop8' has no statements


            			        		}

            			        		char_literal37=(IToken)Match(input,29,FOLLOW_29_in_matrixvardec528); 
            			        			char_literal37_tree = (object)adaptor.Create(char_literal37);
            			        			adaptor.AddChild(root_0, char_literal37_tree);


            			        	}


            			        }
            			        break;
            			    case 3 :
            			        // spinach.g:106:4: ( '[' el4= double_literal ( ',' el6= double_literal )* ) ']'
            			        {
            			        	// spinach.g:106:4: ( '[' el4= double_literal ( ',' el6= double_literal )* )
            			        	// spinach.g:106:5: '[' el4= double_literal ( ',' el6= double_literal )*
            			        	{
            			        		char_literal38=(IToken)Match(input,28,FOLLOW_28_in_matrixvardec535); 
            			        			char_literal38_tree = (object)adaptor.Create(char_literal38);
            			        			adaptor.AddChild(root_0, char_literal38_tree);

            			        		PushFollow(FOLLOW_double_literal_in_matrixvardec538);
            			        		el4 = double_literal();
            			        		state.followingStackPointer--;

            			        		adaptor.AddChild(root_0, el4.Tree);
            			        		retval.ret.addValue(((el4 != null) ? el4.ret : null));
            			        		// spinach.g:106:59: ( ',' el6= double_literal )*
            			        		do 
            			        		{
            			        		    int alt9 = 2;
            			        		    int LA9_0 = input.LA(1);

            			        		    if ( (LA9_0 == 30) )
            			        		    {
            			        		        alt9 = 1;
            			        		    }


            			        		    switch (alt9) 
            			        			{
            			        				case 1 :
            			        				    // spinach.g:106:60: ',' el6= double_literal
            			        				    {
            			        				    	char_literal39=(IToken)Match(input,30,FOLLOW_30_in_matrixvardec542); 
            			        				    		char_literal39_tree = (object)adaptor.Create(char_literal39);
            			        				    		adaptor.AddChild(root_0, char_literal39_tree);

            			        				    	PushFollow(FOLLOW_double_literal_in_matrixvardec545);
            			        				    	el6 = double_literal();
            			        				    	state.followingStackPointer--;

            			        				    	adaptor.AddChild(root_0, el6.Tree);
            			        				    	retval.ret.addValue(((el6 != null) ? el6.ret : null));

            			        				    }
            			        				    break;

            			        				default:
            			        				    goto loop9;
            			        		    }
            			        		} while (true);

            			        		loop9:
            			        			;	// Stops C# compiler whining that label 'loop9' has no statements


            			        	}

            			        	char_literal40=(IToken)Match(input,29,FOLLOW_29_in_matrixvardec551); 
            			        		char_literal40_tree = (object)adaptor.Create(char_literal40);
            			        		adaptor.AddChild(root_0, char_literal40_tree);


            			        }
            			        break;

            			}


            		}

            		retval.ret.setValue();

            	}

            	END_OF_STATEMENT41=(IToken)Match(input,END_OF_STATEMENT,FOLLOW_END_OF_STATEMENT_in_matrixvardec562); 
            		END_OF_STATEMENT41_tree = (object)adaptor.Create(END_OF_STATEMENT41);
            		adaptor.AddChild(root_0, END_OF_STATEMENT41_tree);


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "matrixvardec"

    public class vectorvardec_return : ParserRuleReturnScope
    {
        public VectorVariableDeclaration ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "vectorvardec"
    // spinach.g:110:1: vectorvardec returns [VectorVariableDeclaration ret] : ( 'vector' '<' VARTYPE '>' '[' el1= int_literal ']' el2= variable ASSIGNMENT ( ( '[' ']' ) | ( '[' el3= int_literal ( ',' el5= int_literal )* ']' ) | ( '[' el4= double_literal ( ',' el6= double_literal )* ) ']' ) ) END_OF_STATEMENT ;
    public spinachParser.vectorvardec_return vectorvardec() // throws RecognitionException [1]
    {   
        spinachParser.vectorvardec_return retval = new spinachParser.vectorvardec_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken string_literal42 = null;
        IToken char_literal43 = null;
        IToken VARTYPE44 = null;
        IToken char_literal45 = null;
        IToken char_literal46 = null;
        IToken char_literal47 = null;
        IToken ASSIGNMENT48 = null;
        IToken char_literal49 = null;
        IToken char_literal50 = null;
        IToken char_literal51 = null;
        IToken char_literal52 = null;
        IToken char_literal53 = null;
        IToken char_literal54 = null;
        IToken char_literal55 = null;
        IToken char_literal56 = null;
        IToken END_OF_STATEMENT57 = null;
        spinachParser.int_literal_return el1 = null;

        spinachParser.variable_return el2 = null;

        spinachParser.int_literal_return el3 = null;

        spinachParser.int_literal_return el5 = null;

        spinachParser.double_literal_return el4 = null;

        spinachParser.double_literal_return el6 = null;


        object string_literal42_tree=null;
        object char_literal43_tree=null;
        object VARTYPE44_tree=null;
        object char_literal45_tree=null;
        object char_literal46_tree=null;
        object char_literal47_tree=null;
        object ASSIGNMENT48_tree=null;
        object char_literal49_tree=null;
        object char_literal50_tree=null;
        object char_literal51_tree=null;
        object char_literal52_tree=null;
        object char_literal53_tree=null;
        object char_literal54_tree=null;
        object char_literal55_tree=null;
        object char_literal56_tree=null;
        object END_OF_STATEMENT57_tree=null;


        	retval.ret = new VectorVariableDeclaration();
        	
        try 
    	{
            // spinach.g:114:2: ( ( 'vector' '<' VARTYPE '>' '[' el1= int_literal ']' el2= variable ASSIGNMENT ( ( '[' ']' ) | ( '[' el3= int_literal ( ',' el5= int_literal )* ']' ) | ( '[' el4= double_literal ( ',' el6= double_literal )* ) ']' ) ) END_OF_STATEMENT )
            // spinach.g:114:3: ( 'vector' '<' VARTYPE '>' '[' el1= int_literal ']' el2= variable ASSIGNMENT ( ( '[' ']' ) | ( '[' el3= int_literal ( ',' el5= int_literal )* ']' ) | ( '[' el4= double_literal ( ',' el6= double_literal )* ) ']' ) ) END_OF_STATEMENT
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// spinach.g:114:3: ( 'vector' '<' VARTYPE '>' '[' el1= int_literal ']' el2= variable ASSIGNMENT ( ( '[' ']' ) | ( '[' el3= int_literal ( ',' el5= int_literal )* ']' ) | ( '[' el4= double_literal ( ',' el6= double_literal )* ) ']' ) )
            	// spinach.g:114:4: 'vector' '<' VARTYPE '>' '[' el1= int_literal ']' el2= variable ASSIGNMENT ( ( '[' ']' ) | ( '[' el3= int_literal ( ',' el5= int_literal )* ']' ) | ( '[' el4= double_literal ( ',' el6= double_literal )* ) ']' )
            	{
            		string_literal42=(IToken)Match(input,31,FOLLOW_31_in_vectorvardec580); 
            			string_literal42_tree = (object)adaptor.Create(string_literal42);
            			adaptor.AddChild(root_0, string_literal42_tree);

            		char_literal43=(IToken)Match(input,LESSTHANEXPRESSION,FOLLOW_LESSTHANEXPRESSION_in_vectorvardec582); 
            			char_literal43_tree = (object)adaptor.Create(char_literal43);
            			adaptor.AddChild(root_0, char_literal43_tree);

            		VARTYPE44=(IToken)Match(input,VARTYPE,FOLLOW_VARTYPE_in_vectorvardec584); 
            			VARTYPE44_tree = (object)adaptor.Create(VARTYPE44);
            			adaptor.AddChild(root_0, VARTYPE44_tree);

            		 retval.ret.setType(((VARTYPE44 != null) ? VARTYPE44.Text : null));
            		char_literal45=(IToken)Match(input,GREATERTHANEXPRESSION,FOLLOW_GREATERTHANEXPRESSION_in_vectorvardec587); 
            			char_literal45_tree = (object)adaptor.Create(char_literal45);
            			adaptor.AddChild(root_0, char_literal45_tree);

            		char_literal46=(IToken)Match(input,28,FOLLOW_28_in_vectorvardec589); 
            			char_literal46_tree = (object)adaptor.Create(char_literal46);
            			adaptor.AddChild(root_0, char_literal46_tree);

            		PushFollow(FOLLOW_int_literal_in_vectorvardec592);
            		el1 = int_literal();
            		state.followingStackPointer--;

            		adaptor.AddChild(root_0, el1.Tree);
            		retval.ret.setRange(((el1 != null) ? el1.ret : null));
            		char_literal47=(IToken)Match(input,29,FOLLOW_29_in_vectorvardec595); 
            			char_literal47_tree = (object)adaptor.Create(char_literal47);
            			adaptor.AddChild(root_0, char_literal47_tree);

            		PushFollow(FOLLOW_variable_in_vectorvardec601);
            		el2 = variable();
            		state.followingStackPointer--;

            		adaptor.AddChild(root_0, el2.Tree);
            		retval.ret.setText(((el2 != null) ? el2.ret : null));
            		ASSIGNMENT48=(IToken)Match(input,ASSIGNMENT,FOLLOW_ASSIGNMENT_in_vectorvardec608); 
            			ASSIGNMENT48_tree = (object)adaptor.Create(ASSIGNMENT48);
            			adaptor.AddChild(root_0, ASSIGNMENT48_tree);

            		// spinach.g:117:3: ( ( '[' ']' ) | ( '[' el3= int_literal ( ',' el5= int_literal )* ']' ) | ( '[' el4= double_literal ( ',' el6= double_literal )* ) ']' )
            		int alt13 = 3;
            		int LA13_0 = input.LA(1);

            		if ( (LA13_0 == 28) )
            		{
            		    switch ( input.LA(2) ) 
            		    {
            		    case 29:
            		    	{
            		        alt13 = 1;
            		        }
            		        break;
            		    case DOUBLE_LITERAL:
            		    	{
            		        alt13 = 3;
            		        }
            		        break;
            		    case INT_LITERAL:
            		    	{
            		        alt13 = 2;
            		        }
            		        break;
            		    	default:
            		    	    NoViableAltException nvae_d13s1 =
            		    	        new NoViableAltException("", 13, 1, input);

            		    	    throw nvae_d13s1;
            		    }

            		}
            		else 
            		{
            		    NoViableAltException nvae_d13s0 =
            		        new NoViableAltException("", 13, 0, input);

            		    throw nvae_d13s0;
            		}
            		switch (alt13) 
            		{
            		    case 1 :
            		        // spinach.g:117:4: ( '[' ']' )
            		        {
            		        	// spinach.g:117:4: ( '[' ']' )
            		        	// spinach.g:117:5: '[' ']'
            		        	{
            		        		char_literal49=(IToken)Match(input,28,FOLLOW_28_in_vectorvardec615); 
            		        			char_literal49_tree = (object)adaptor.Create(char_literal49);
            		        			adaptor.AddChild(root_0, char_literal49_tree);

            		        		char_literal50=(IToken)Match(input,29,FOLLOW_29_in_vectorvardec616); 
            		        			char_literal50_tree = (object)adaptor.Create(char_literal50);
            		        			adaptor.AddChild(root_0, char_literal50_tree);


            		        	}


            		        }
            		        break;
            		    case 2 :
            		        // spinach.g:118:3: ( '[' el3= int_literal ( ',' el5= int_literal )* ']' )
            		        {
            		        	// spinach.g:118:3: ( '[' el3= int_literal ( ',' el5= int_literal )* ']' )
            		        	// spinach.g:118:4: '[' el3= int_literal ( ',' el5= int_literal )* ']'
            		        	{
            		        		char_literal51=(IToken)Match(input,28,FOLLOW_28_in_vectorvardec623); 
            		        			char_literal51_tree = (object)adaptor.Create(char_literal51);
            		        			adaptor.AddChild(root_0, char_literal51_tree);

            		        		PushFollow(FOLLOW_int_literal_in_vectorvardec626);
            		        		el3 = int_literal();
            		        		state.followingStackPointer--;

            		        		adaptor.AddChild(root_0, el3.Tree);
            		        		retval.ret.addValue(((el3 != null) ? el3.ret : null));
            		        		// spinach.g:118:56: ( ',' el5= int_literal )*
            		        		do 
            		        		{
            		        		    int alt11 = 2;
            		        		    int LA11_0 = input.LA(1);

            		        		    if ( (LA11_0 == 30) )
            		        		    {
            		        		        alt11 = 1;
            		        		    }


            		        		    switch (alt11) 
            		        			{
            		        				case 1 :
            		        				    // spinach.g:118:57: ',' el5= int_literal
            		        				    {
            		        				    	char_literal52=(IToken)Match(input,30,FOLLOW_30_in_vectorvardec631); 
            		        				    		char_literal52_tree = (object)adaptor.Create(char_literal52);
            		        				    		adaptor.AddChild(root_0, char_literal52_tree);

            		        				    	PushFollow(FOLLOW_int_literal_in_vectorvardec634);
            		        				    	el5 = int_literal();
            		        				    	state.followingStackPointer--;

            		        				    	adaptor.AddChild(root_0, el5.Tree);
            		        				    	retval.ret.addValue(((el5 != null) ? el5.ret : null));

            		        				    }
            		        				    break;

            		        				default:
            		        				    goto loop11;
            		        		    }
            		        		} while (true);

            		        		loop11:
            		        			;	// Stops C# compiler whining that label 'loop11' has no statements

            		        		char_literal53=(IToken)Match(input,29,FOLLOW_29_in_vectorvardec639); 
            		        			char_literal53_tree = (object)adaptor.Create(char_literal53);
            		        			adaptor.AddChild(root_0, char_literal53_tree);


            		        	}


            		        }
            		        break;
            		    case 3 :
            		        // spinach.g:119:3: ( '[' el4= double_literal ( ',' el6= double_literal )* ) ']'
            		        {
            		        	// spinach.g:119:3: ( '[' el4= double_literal ( ',' el6= double_literal )* )
            		        	// spinach.g:119:4: '[' el4= double_literal ( ',' el6= double_literal )*
            		        	{
            		        		char_literal54=(IToken)Match(input,28,FOLLOW_28_in_vectorvardec646); 
            		        			char_literal54_tree = (object)adaptor.Create(char_literal54);
            		        			adaptor.AddChild(root_0, char_literal54_tree);

            		        		PushFollow(FOLLOW_double_literal_in_vectorvardec649);
            		        		el4 = double_literal();
            		        		state.followingStackPointer--;

            		        		adaptor.AddChild(root_0, el4.Tree);
            		        		retval.ret.addValue(((el4 != null) ? el4.ret : null));
            		        		// spinach.g:120:3: ( ',' el6= double_literal )*
            		        		do 
            		        		{
            		        		    int alt12 = 2;
            		        		    int LA12_0 = input.LA(1);

            		        		    if ( (LA12_0 == 30) )
            		        		    {
            		        		        alt12 = 1;
            		        		    }


            		        		    switch (alt12) 
            		        			{
            		        				case 1 :
            		        				    // spinach.g:120:4: ',' el6= double_literal
            		        				    {
            		        				    	char_literal55=(IToken)Match(input,30,FOLLOW_30_in_vectorvardec656); 
            		        				    		char_literal55_tree = (object)adaptor.Create(char_literal55);
            		        				    		adaptor.AddChild(root_0, char_literal55_tree);

            		        				    	PushFollow(FOLLOW_double_literal_in_vectorvardec659);
            		        				    	el6 = double_literal();
            		        				    	state.followingStackPointer--;

            		        				    	adaptor.AddChild(root_0, el6.Tree);
            		        				    	retval.ret.addValue(((el6 != null) ? el6.ret : null));

            		        				    }
            		        				    break;

            		        				default:
            		        				    goto loop12;
            		        		    }
            		        		} while (true);

            		        		loop12:
            		        			;	// Stops C# compiler whining that label 'loop12' has no statements


            		        	}

            		        	char_literal56=(IToken)Match(input,29,FOLLOW_29_in_vectorvardec665); 
            		        		char_literal56_tree = (object)adaptor.Create(char_literal56);
            		        		adaptor.AddChild(root_0, char_literal56_tree);


            		        }
            		        break;

            		}

            		retval.ret.setValue();

            	}

            	END_OF_STATEMENT57=(IToken)Match(input,END_OF_STATEMENT,FOLLOW_END_OF_STATEMENT_in_vectorvardec672); 
            		END_OF_STATEMENT57_tree = (object)adaptor.Create(END_OF_STATEMENT57);
            		adaptor.AddChild(root_0, END_OF_STATEMENT57_tree);


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "vectorvardec"

    public class matrixelem_return : ParserRuleReturnScope
    {
        public MatrixElement ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "matrixelem"
    // spinach.g:123:1: matrixelem returns [MatrixElement ret] : (el1= variable '[' (el2= int_literal | el4= variable ) ']' '[' (el3= int_literal | el5= variable ) ']' ) ;
    public spinachParser.matrixelem_return matrixelem() // throws RecognitionException [1]
    {   
        spinachParser.matrixelem_return retval = new spinachParser.matrixelem_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken char_literal58 = null;
        IToken char_literal59 = null;
        IToken char_literal60 = null;
        IToken char_literal61 = null;
        spinachParser.variable_return el1 = null;

        spinachParser.int_literal_return el2 = null;

        spinachParser.variable_return el4 = null;

        spinachParser.int_literal_return el3 = null;

        spinachParser.variable_return el5 = null;


        object char_literal58_tree=null;
        object char_literal59_tree=null;
        object char_literal60_tree=null;
        object char_literal61_tree=null;


         retval.ret = new MatrixElement();
         
        try 
    	{
            // spinach.g:127:2: ( (el1= variable '[' (el2= int_literal | el4= variable ) ']' '[' (el3= int_literal | el5= variable ) ']' ) )
            // spinach.g:127:3: (el1= variable '[' (el2= int_literal | el4= variable ) ']' '[' (el3= int_literal | el5= variable ) ']' )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// spinach.g:127:3: (el1= variable '[' (el2= int_literal | el4= variable ) ']' '[' (el3= int_literal | el5= variable ) ']' )
            	// spinach.g:127:4: el1= variable '[' (el2= int_literal | el4= variable ) ']' '[' (el3= int_literal | el5= variable ) ']'
            	{
            		PushFollow(FOLLOW_variable_in_matrixelem692);
            		el1 = variable();
            		state.followingStackPointer--;

            		adaptor.AddChild(root_0, el1.Tree);
            		retval.ret.setVar(((el1 != null) ? el1.ret : null));
            		char_literal58=(IToken)Match(input,28,FOLLOW_28_in_matrixelem698); 
            			char_literal58_tree = (object)adaptor.Create(char_literal58);
            			adaptor.AddChild(root_0, char_literal58_tree);

            		// spinach.g:128:6: (el2= int_literal | el4= variable )
            		int alt14 = 2;
            		int LA14_0 = input.LA(1);

            		if ( (LA14_0 == INT_LITERAL) )
            		{
            		    alt14 = 1;
            		}
            		else if ( (LA14_0 == VARIABLE) )
            		{
            		    alt14 = 2;
            		}
            		else 
            		{
            		    NoViableAltException nvae_d14s0 =
            		        new NoViableAltException("", 14, 0, input);

            		    throw nvae_d14s0;
            		}
            		switch (alt14) 
            		{
            		    case 1 :
            		        // spinach.g:128:7: el2= int_literal
            		        {
            		        	PushFollow(FOLLOW_int_literal_in_matrixelem702);
            		        	el2 = int_literal();
            		        	state.followingStackPointer--;

            		        	adaptor.AddChild(root_0, el2.Tree);
            		        	retval.ret.setRow(((el2 != null) ? el2.ret : null));

            		        }
            		        break;
            		    case 2 :
            		        // spinach.g:128:53: el4= variable
            		        {
            		        	PushFollow(FOLLOW_variable_in_matrixelem707);
            		        	el4 = variable();
            		        	state.followingStackPointer--;

            		        	adaptor.AddChild(root_0, el4.Tree);
            		        	retval.ret.setRow(((el4 != null) ? el4.ret : null));

            		        }
            		        break;

            		}

            		char_literal59=(IToken)Match(input,29,FOLLOW_29_in_matrixelem710); 
            			char_literal59_tree = (object)adaptor.Create(char_literal59);
            			adaptor.AddChild(root_0, char_literal59_tree);

            		char_literal60=(IToken)Match(input,28,FOLLOW_28_in_matrixelem713); 
            			char_literal60_tree = (object)adaptor.Create(char_literal60);
            			adaptor.AddChild(root_0, char_literal60_tree);

            		// spinach.g:129:5: (el3= int_literal | el5= variable )
            		int alt15 = 2;
            		int LA15_0 = input.LA(1);

            		if ( (LA15_0 == INT_LITERAL) )
            		{
            		    alt15 = 1;
            		}
            		else if ( (LA15_0 == VARIABLE) )
            		{
            		    alt15 = 2;
            		}
            		else 
            		{
            		    NoViableAltException nvae_d15s0 =
            		        new NoViableAltException("", 15, 0, input);

            		    throw nvae_d15s0;
            		}
            		switch (alt15) 
            		{
            		    case 1 :
            		        // spinach.g:129:6: el3= int_literal
            		        {
            		        	PushFollow(FOLLOW_int_literal_in_matrixelem717);
            		        	el3 = int_literal();
            		        	state.followingStackPointer--;

            		        	adaptor.AddChild(root_0, el3.Tree);
            		        	retval.ret.setColumn(((el3 != null) ? el3.ret : null));

            		        }
            		        break;
            		    case 2 :
            		        // spinach.g:129:55: el5= variable
            		        {
            		        	PushFollow(FOLLOW_variable_in_matrixelem722);
            		        	el5 = variable();
            		        	state.followingStackPointer--;

            		        	adaptor.AddChild(root_0, el5.Tree);
            		        	retval.ret.setColumn(((el5 != null) ? el5.ret : null));

            		        }
            		        break;

            		}

            		char_literal61=(IToken)Match(input,29,FOLLOW_29_in_matrixelem725); 
            			char_literal61_tree = (object)adaptor.Create(char_literal61);
            			adaptor.AddChild(root_0, char_literal61_tree);


            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "matrixelem"

    public class vectorelem_return : ParserRuleReturnScope
    {
        public VectorElement ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "vectorelem"
    // spinach.g:131:1: vectorelem returns [VectorElement ret] : (el1= variable '[' (el2= int_literal | el3= variable ) ']' ) ;
    public spinachParser.vectorelem_return vectorelem() // throws RecognitionException [1]
    {   
        spinachParser.vectorelem_return retval = new spinachParser.vectorelem_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken char_literal62 = null;
        IToken char_literal63 = null;
        spinachParser.variable_return el1 = null;

        spinachParser.int_literal_return el2 = null;

        spinachParser.variable_return el3 = null;


        object char_literal62_tree=null;
        object char_literal63_tree=null;


         retval.ret = new VectorElement();
         
        try 
    	{
            // spinach.g:135:2: ( (el1= variable '[' (el2= int_literal | el3= variable ) ']' ) )
            // spinach.g:135:3: (el1= variable '[' (el2= int_literal | el3= variable ) ']' )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// spinach.g:135:3: (el1= variable '[' (el2= int_literal | el3= variable ) ']' )
            	// spinach.g:135:4: el1= variable '[' (el2= int_literal | el3= variable ) ']'
            	{
            		PushFollow(FOLLOW_variable_in_vectorelem747);
            		el1 = variable();
            		state.followingStackPointer--;

            		adaptor.AddChild(root_0, el1.Tree);
            		retval.ret.setVar(((el1 != null) ? el1.ret : null));
            		char_literal62=(IToken)Match(input,28,FOLLOW_28_in_vectorelem753); 
            			char_literal62_tree = (object)adaptor.Create(char_literal62);
            			adaptor.AddChild(root_0, char_literal62_tree);

            		// spinach.g:136:6: (el2= int_literal | el3= variable )
            		int alt16 = 2;
            		int LA16_0 = input.LA(1);

            		if ( (LA16_0 == INT_LITERAL) )
            		{
            		    alt16 = 1;
            		}
            		else if ( (LA16_0 == VARIABLE) )
            		{
            		    alt16 = 2;
            		}
            		else 
            		{
            		    NoViableAltException nvae_d16s0 =
            		        new NoViableAltException("", 16, 0, input);

            		    throw nvae_d16s0;
            		}
            		switch (alt16) 
            		{
            		    case 1 :
            		        // spinach.g:136:7: el2= int_literal
            		        {
            		        	PushFollow(FOLLOW_int_literal_in_vectorelem757);
            		        	el2 = int_literal();
            		        	state.followingStackPointer--;

            		        	adaptor.AddChild(root_0, el2.Tree);
            		        	retval.ret.setRange(((el2 != null) ? el2.ret : null));

            		        }
            		        break;
            		    case 2 :
            		        // spinach.g:136:56: el3= variable
            		        {
            		        	PushFollow(FOLLOW_variable_in_vectorelem763);
            		        	el3 = variable();
            		        	state.followingStackPointer--;

            		        	adaptor.AddChild(root_0, el3.Tree);
            		        	retval.ret.setRange(((el3 != null) ? el3.ret : null));

            		        }
            		        break;

            		}

            		char_literal63=(IToken)Match(input,29,FOLLOW_29_in_vectorelem766); 
            			char_literal63_tree = (object)adaptor.Create(char_literal63);
            			adaptor.AddChild(root_0, char_literal63_tree);


            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "vectorelem"

    public class assignment_return : ParserRuleReturnScope
    {
        public AssignmentOperationElement ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "assignment"
    // spinach.g:138:1: assignment returns [AssignmentOperationElement ret] : ( ( variable | structassign | e12= vectorelem | e11= matrixelem ) ASSIGNMENT ( ( subtractive_exp | dotproduct | matrixtranspose | string_literal ) END_OF_STATEMENT | functioncall ) ) ;
    public spinachParser.assignment_return assignment() // throws RecognitionException [1]
    {   
        spinachParser.assignment_return retval = new spinachParser.assignment_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken ASSIGNMENT66 = null;
        IToken END_OF_STATEMENT71 = null;
        spinachParser.vectorelem_return e12 = null;

        spinachParser.matrixelem_return e11 = null;

        spinachParser.variable_return variable64 = null;

        spinachParser.structassign_return structassign65 = null;

        spinachParser.subtractive_exp_return subtractive_exp67 = null;

        spinachParser.dotproduct_return dotproduct68 = null;

        spinachParser.matrixtranspose_return matrixtranspose69 = null;

        spinachParser.string_literal_return string_literal70 = null;

        spinachParser.functioncall_return functioncall72 = null;


        object ASSIGNMENT66_tree=null;
        object END_OF_STATEMENT71_tree=null;


          retval.ret = new AssignmentOperationElement();

        try 
    	{
            // spinach.g:142:3: ( ( ( variable | structassign | e12= vectorelem | e11= matrixelem ) ASSIGNMENT ( ( subtractive_exp | dotproduct | matrixtranspose | string_literal ) END_OF_STATEMENT | functioncall ) ) )
            // spinach.g:142:5: ( ( variable | structassign | e12= vectorelem | e11= matrixelem ) ASSIGNMENT ( ( subtractive_exp | dotproduct | matrixtranspose | string_literal ) END_OF_STATEMENT | functioncall ) )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// spinach.g:142:5: ( ( variable | structassign | e12= vectorelem | e11= matrixelem ) ASSIGNMENT ( ( subtractive_exp | dotproduct | matrixtranspose | string_literal ) END_OF_STATEMENT | functioncall ) )
            	// spinach.g:142:6: ( variable | structassign | e12= vectorelem | e11= matrixelem ) ASSIGNMENT ( ( subtractive_exp | dotproduct | matrixtranspose | string_literal ) END_OF_STATEMENT | functioncall )
            	{
            		// spinach.g:142:6: ( variable | structassign | e12= vectorelem | e11= matrixelem )
            		int alt17 = 4;
            		alt17 = dfa17.Predict(input);
            		switch (alt17) 
            		{
            		    case 1 :
            		        // spinach.g:142:7: variable
            		        {
            		        	PushFollow(FOLLOW_variable_in_assignment789);
            		        	variable64 = variable();
            		        	state.followingStackPointer--;

            		        	adaptor.AddChild(root_0, variable64.Tree);
            		        	retval.ret.setLhs(((variable64 != null) ? variable64.ret : null)); 

            		        }
            		        break;
            		    case 2 :
            		        // spinach.g:143:7: structassign
            		        {
            		        	PushFollow(FOLLOW_structassign_in_assignment799);
            		        	structassign65 = structassign();
            		        	state.followingStackPointer--;

            		        	adaptor.AddChild(root_0, structassign65.Tree);
            		        	retval.ret.setLhs(((structassign65 != null) ? structassign65.ret : null));

            		        }
            		        break;
            		    case 3 :
            		        // spinach.g:144:6: e12= vectorelem
            		        {
            		        	PushFollow(FOLLOW_vectorelem_in_assignment811);
            		        	e12 = vectorelem();
            		        	state.followingStackPointer--;

            		        	adaptor.AddChild(root_0, e12.Tree);
            		        	retval.ret.setLhs(((e12 != null) ? e12.ret : null));

            		        }
            		        break;
            		    case 4 :
            		        // spinach.g:145:7: e11= matrixelem
            		        {
            		        	PushFollow(FOLLOW_matrixelem_in_assignment824);
            		        	e11 = matrixelem();
            		        	state.followingStackPointer--;

            		        	adaptor.AddChild(root_0, e11.Tree);
            		        	retval.ret.setLhs(((e11 != null) ? e11.ret : null));

            		        }
            		        break;

            		}

            		ASSIGNMENT66=(IToken)Match(input,ASSIGNMENT,FOLLOW_ASSIGNMENT_in_assignment832); 
            			ASSIGNMENT66_tree = (object)adaptor.Create(ASSIGNMENT66);
            			adaptor.AddChild(root_0, ASSIGNMENT66_tree);

            		// spinach.g:147:5: ( ( subtractive_exp | dotproduct | matrixtranspose | string_literal ) END_OF_STATEMENT | functioncall )
            		int alt19 = 2;
            		int LA19_0 = input.LA(1);

            		if ( ((LA19_0 >= INT_LITERAL && LA19_0 <= DOUBLE_LITERAL) || LA19_0 == LEFTBRACE || LA19_0 == 44 || LA19_0 == 57) )
            		{
            		    alt19 = 1;
            		}
            		else if ( (LA19_0 == VARIABLE) )
            		{
            		    int LA19_2 = input.LA(2);

            		    if ( (LA19_2 == END_OF_STATEMENT || (LA19_2 >= PLUS && LA19_2 <= DOT) || LA19_2 == 28 || LA19_2 == 32 || LA19_2 == 43) )
            		    {
            		        alt19 = 1;
            		    }
            		    else if ( (LA19_2 == LEFTBRACE) )
            		    {
            		        alt19 = 2;
            		    }
            		    else 
            		    {
            		        NoViableAltException nvae_d19s2 =
            		            new NoViableAltException("", 19, 2, input);

            		        throw nvae_d19s2;
            		    }
            		}
            		else 
            		{
            		    NoViableAltException nvae_d19s0 =
            		        new NoViableAltException("", 19, 0, input);

            		    throw nvae_d19s0;
            		}
            		switch (alt19) 
            		{
            		    case 1 :
            		        // spinach.g:147:6: ( subtractive_exp | dotproduct | matrixtranspose | string_literal ) END_OF_STATEMENT
            		        {
            		        	// spinach.g:147:6: ( subtractive_exp | dotproduct | matrixtranspose | string_literal )
            		        	int alt18 = 4;
            		        	switch ( input.LA(1) ) 
            		        	{
            		        	case INT_LITERAL:
            		        	case DOUBLE_LITERAL:
            		        	case LEFTBRACE:
            		        		{
            		        	    alt18 = 1;
            		        	    }
            		        	    break;
            		        	case VARIABLE:
            		        		{
            		        	    int LA18_2 = input.LA(2);

            		        	    if ( (LA18_2 == END_OF_STATEMENT || (LA18_2 >= PLUS && LA18_2 <= DOT) || LA18_2 == 28 || LA18_2 == 32) )
            		        	    {
            		        	        alt18 = 1;
            		        	    }
            		        	    else if ( (LA18_2 == 43) )
            		        	    {
            		        	        alt18 = 2;
            		        	    }
            		        	    else 
            		        	    {
            		        	        NoViableAltException nvae_d18s2 =
            		        	            new NoViableAltException("", 18, 2, input);

            		        	        throw nvae_d18s2;
            		        	    }
            		        	    }
            		        	    break;
            		        	case 44:
            		        		{
            		        	    alt18 = 3;
            		        	    }
            		        	    break;
            		        	case 57:
            		        		{
            		        	    alt18 = 4;
            		        	    }
            		        	    break;
            		        		default:
            		        		    NoViableAltException nvae_d18s0 =
            		        		        new NoViableAltException("", 18, 0, input);

            		        		    throw nvae_d18s0;
            		        	}

            		        	switch (alt18) 
            		        	{
            		        	    case 1 :
            		        	        // spinach.g:147:8: subtractive_exp
            		        	        {
            		        	        	PushFollow(FOLLOW_subtractive_exp_in_assignment842);
            		        	        	subtractive_exp67 = subtractive_exp();
            		        	        	state.followingStackPointer--;

            		        	        	adaptor.AddChild(root_0, subtractive_exp67.Tree);
            		        	        	retval.ret.setRhs(((subtractive_exp67 != null) ? subtractive_exp67.ret : null));

            		        	        }
            		        	        break;
            		        	    case 2 :
            		        	        // spinach.g:147:67: dotproduct
            		        	        {
            		        	        	PushFollow(FOLLOW_dotproduct_in_assignment846);
            		        	        	dotproduct68 = dotproduct();
            		        	        	state.followingStackPointer--;

            		        	        	adaptor.AddChild(root_0, dotproduct68.Tree);
            		        	        	retval.ret.setRhs(((dotproduct68 != null) ? dotproduct68.ret : null));

            		        	        }
            		        	        break;
            		        	    case 3 :
            		        	        // spinach.g:148:7: matrixtranspose
            		        	        {
            		        	        	PushFollow(FOLLOW_matrixtranspose_in_assignment855);
            		        	        	matrixtranspose69 = matrixtranspose();
            		        	        	state.followingStackPointer--;

            		        	        	adaptor.AddChild(root_0, matrixtranspose69.Tree);
            		        	        	retval.ret.setRhs(((matrixtranspose69 != null) ? matrixtranspose69.ret : null));

            		        	        }
            		        	        break;
            		        	    case 4 :
            		        	        // spinach.g:148:66: string_literal
            		        	        {
            		        	        	PushFollow(FOLLOW_string_literal_in_assignment859);
            		        	        	string_literal70 = string_literal();
            		        	        	state.followingStackPointer--;

            		        	        	adaptor.AddChild(root_0, string_literal70.Tree);
            		        	        	retval.ret.setRhs(((string_literal70 != null) ? string_literal70.ret : null));

            		        	        }
            		        	        break;

            		        	}

            		        	END_OF_STATEMENT71=(IToken)Match(input,END_OF_STATEMENT,FOLLOW_END_OF_STATEMENT_in_assignment867); 
            		        		END_OF_STATEMENT71_tree = (object)adaptor.Create(END_OF_STATEMENT71);
            		        		adaptor.AddChild(root_0, END_OF_STATEMENT71_tree);


            		        }
            		        break;
            		    case 2 :
            		        // spinach.g:150:7: functioncall
            		        {
            		        	PushFollow(FOLLOW_functioncall_in_assignment875);
            		        	functioncall72 = functioncall();
            		        	state.followingStackPointer--;

            		        	adaptor.AddChild(root_0, functioncall72.Tree);
            		        	retval.ret.setRhs(((functioncall72 != null) ? functioncall72.ret : null));

            		        }
            		        break;

            		}


            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "assignment"

    public class additive_expression_return : ParserRuleReturnScope
    {
        public AdditiveElement ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "additive_expression"
    // spinach.g:153:1: additive_expression returns [AdditiveElement ret] : ( (e11= multiplicative_expression ) ( '+' e12= additive_expression )* ) ;
    public spinachParser.additive_expression_return additive_expression() // throws RecognitionException [1]
    {   
        spinachParser.additive_expression_return retval = new spinachParser.additive_expression_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken char_literal73 = null;
        spinachParser.multiplicative_expression_return e11 = null;

        spinachParser.additive_expression_return e12 = null;


        object char_literal73_tree=null;


        	retval.ret = new AdditiveElement();

        try 
    	{
            // spinach.g:157:2: ( ( (e11= multiplicative_expression ) ( '+' e12= additive_expression )* ) )
            // spinach.g:157:4: ( (e11= multiplicative_expression ) ( '+' e12= additive_expression )* )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// spinach.g:157:4: ( (e11= multiplicative_expression ) ( '+' e12= additive_expression )* )
            	// spinach.g:157:5: (e11= multiplicative_expression ) ( '+' e12= additive_expression )*
            	{
            		// spinach.g:157:5: (e11= multiplicative_expression )
            		// spinach.g:157:6: e11= multiplicative_expression
            		{
            			PushFollow(FOLLOW_multiplicative_expression_in_additive_expression906);
            			e11 = multiplicative_expression();
            			state.followingStackPointer--;

            			adaptor.AddChild(root_0, e11.Tree);
            			retval.ret.setLhs(((e11 != null) ? e11.ret : null));

            		}

            		// spinach.g:157:69: ( '+' e12= additive_expression )*
            		do 
            		{
            		    int alt20 = 2;
            		    int LA20_0 = input.LA(1);

            		    if ( (LA20_0 == PLUS) )
            		    {
            		        alt20 = 1;
            		    }


            		    switch (alt20) 
            			{
            				case 1 :
            				    // spinach.g:157:70: '+' e12= additive_expression
            				    {
            				    	char_literal73=(IToken)Match(input,PLUS,FOLLOW_PLUS_in_additive_expression911); 
            				    		char_literal73_tree = (object)adaptor.Create(char_literal73);
            				    		adaptor.AddChild(root_0, char_literal73_tree);

            				    	PushFollow(FOLLOW_additive_expression_in_additive_expression917);
            				    	e12 = additive_expression();
            				    	state.followingStackPointer--;

            				    	adaptor.AddChild(root_0, e12.Tree);
            				    	retval.ret.setRhs(((e12 != null) ? e12.ret : null));

            				    }
            				    break;

            				default:
            				    goto loop20;
            		    }
            		} while (true);

            		loop20:
            			;	// Stops C# compiler whining that label 'loop20' has no statements


            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "additive_expression"

    public class multiplicative_expression_return : ParserRuleReturnScope
    {
        public MultiplicationElement ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "multiplicative_expression"
    // spinach.g:160:1: multiplicative_expression returns [MultiplicationElement ret] : (e11= var_int_or_double_literal | e12= bracket_exp ) ( '*' el5= multiplicative_expression )* ;
    public spinachParser.multiplicative_expression_return multiplicative_expression() // throws RecognitionException [1]
    {   
        spinachParser.multiplicative_expression_return retval = new spinachParser.multiplicative_expression_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken char_literal74 = null;
        spinachParser.var_int_or_double_literal_return e11 = null;

        spinachParser.bracket_exp_return e12 = null;

        spinachParser.multiplicative_expression_return el5 = null;


        object char_literal74_tree=null;


        	retval.ret = new MultiplicationElement();

        try 
    	{
            // spinach.g:164:2: ( (e11= var_int_or_double_literal | e12= bracket_exp ) ( '*' el5= multiplicative_expression )* )
            // spinach.g:164:4: (e11= var_int_or_double_literal | e12= bracket_exp ) ( '*' el5= multiplicative_expression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// spinach.g:164:4: (e11= var_int_or_double_literal | e12= bracket_exp )
            	int alt21 = 2;
            	int LA21_0 = input.LA(1);

            	if ( ((LA21_0 >= VARIABLE && LA21_0 <= DOUBLE_LITERAL)) )
            	{
            	    alt21 = 1;
            	}
            	else if ( (LA21_0 == LEFTBRACE) )
            	{
            	    alt21 = 2;
            	}
            	else 
            	{
            	    NoViableAltException nvae_d21s0 =
            	        new NoViableAltException("", 21, 0, input);

            	    throw nvae_d21s0;
            	}
            	switch (alt21) 
            	{
            	    case 1 :
            	        // spinach.g:164:5: e11= var_int_or_double_literal
            	        {
            	        	PushFollow(FOLLOW_var_int_or_double_literal_in_multiplicative_expression945);
            	        	e11 = var_int_or_double_literal();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, e11.Tree);
            	        	retval.ret.setLhs(((e11 != null) ? e11.ret : null));

            	        }
            	        break;
            	    case 2 :
            	        // spinach.g:165:7: e12= bracket_exp
            	        {
            	        	PushFollow(FOLLOW_bracket_exp_in_multiplicative_expression957);
            	        	e12 = bracket_exp();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, e12.Tree);
            	        	retval.ret.setLhs(((e12 != null) ? e12.ret : null));

            	        }
            	        break;

            	}

            	// spinach.g:169:5: ( '*' el5= multiplicative_expression )*
            	do 
            	{
            	    int alt22 = 2;
            	    int LA22_0 = input.LA(1);

            	    if ( (LA22_0 == MULTIPLY) )
            	    {
            	        alt22 = 1;
            	    }


            	    switch (alt22) 
            		{
            			case 1 :
            			    // spinach.g:169:6: '*' el5= multiplicative_expression
            			    {
            			    	char_literal74=(IToken)Match(input,MULTIPLY,FOLLOW_MULTIPLY_in_multiplicative_expression981); 
            			    		char_literal74_tree = (object)adaptor.Create(char_literal74);
            			    		adaptor.AddChild(root_0, char_literal74_tree);

            			    	PushFollow(FOLLOW_multiplicative_expression_in_multiplicative_expression991);
            			    	el5 = multiplicative_expression();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, el5.Tree);
            			    	retval.ret.setRhs(el5.ret);

            			    }
            			    break;

            			default:
            			    goto loop22;
            	    }
            	} while (true);

            	loop22:
            		;	// Stops C# compiler whining that label 'loop22' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "multiplicative_expression"

    public class bracket_exp_return : ParserRuleReturnScope
    {
        public BracketElement ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "bracket_exp"
    // spinach.g:176:1: bracket_exp returns [BracketElement ret] : '(' subtractive_exp ')' ;
    public spinachParser.bracket_exp_return bracket_exp() // throws RecognitionException [1]
    {   
        spinachParser.bracket_exp_return retval = new spinachParser.bracket_exp_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken char_literal75 = null;
        IToken char_literal77 = null;
        spinachParser.subtractive_exp_return subtractive_exp76 = null;


        object char_literal75_tree=null;
        object char_literal77_tree=null;


        	retval.ret = new BracketElement();

        try 
    	{
            // spinach.g:180:1: ( '(' subtractive_exp ')' )
            // spinach.g:180:3: '(' subtractive_exp ')'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	char_literal75=(IToken)Match(input,LEFTBRACE,FOLLOW_LEFTBRACE_in_bracket_exp1037); 
            		char_literal75_tree = (object)adaptor.Create(char_literal75);
            		adaptor.AddChild(root_0, char_literal75_tree);

            	PushFollow(FOLLOW_subtractive_exp_in_bracket_exp1038);
            	subtractive_exp76 = subtractive_exp();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, subtractive_exp76.Tree);
            	retval.ret.setbracketexpression(((subtractive_exp76 != null) ? subtractive_exp76.ret : null));
            	char_literal77=(IToken)Match(input,RIGHTBRACE,FOLLOW_RIGHTBRACE_in_bracket_exp1040); 
            		char_literal77_tree = (object)adaptor.Create(char_literal77);
            		adaptor.AddChild(root_0, char_literal77_tree);


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "bracket_exp"

    public class subtractive_exp_return : ParserRuleReturnScope
    {
        public SubtractionElement ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "subtractive_exp"
    // spinach.g:186:1: subtractive_exp returns [SubtractionElement ret] : (e11= additive_expression ( '-' e12= subtractive_exp )* ) ;
    public spinachParser.subtractive_exp_return subtractive_exp() // throws RecognitionException [1]
    {   
        spinachParser.subtractive_exp_return retval = new spinachParser.subtractive_exp_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken char_literal78 = null;
        spinachParser.additive_expression_return e11 = null;

        spinachParser.subtractive_exp_return e12 = null;


        object char_literal78_tree=null;


        	retval.ret = new SubtractionElement();

        try 
    	{
            // spinach.g:190:1: ( (e11= additive_expression ( '-' e12= subtractive_exp )* ) )
            // spinach.g:190:6: (e11= additive_expression ( '-' e12= subtractive_exp )* )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// spinach.g:190:6: (e11= additive_expression ( '-' e12= subtractive_exp )* )
            	// spinach.g:190:7: e11= additive_expression ( '-' e12= subtractive_exp )*
            	{
            		PushFollow(FOLLOW_additive_expression_in_subtractive_exp1069);
            		e11 = additive_expression();
            		state.followingStackPointer--;

            		adaptor.AddChild(root_0, e11.Tree);
            		retval.ret.setLhs(((e11 != null) ? e11.ret : null));
            		// spinach.g:190:64: ( '-' e12= subtractive_exp )*
            		do 
            		{
            		    int alt23 = 2;
            		    int LA23_0 = input.LA(1);

            		    if ( (LA23_0 == 32) )
            		    {
            		        alt23 = 1;
            		    }


            		    switch (alt23) 
            			{
            				case 1 :
            				    // spinach.g:190:65: '-' e12= subtractive_exp
            				    {
            				    	char_literal78=(IToken)Match(input,32,FOLLOW_32_in_subtractive_exp1074); 
            				    		char_literal78_tree = (object)adaptor.Create(char_literal78);
            				    		adaptor.AddChild(root_0, char_literal78_tree);

            				    	PushFollow(FOLLOW_subtractive_exp_in_subtractive_exp1080);
            				    	e12 = subtractive_exp();
            				    	state.followingStackPointer--;

            				    	adaptor.AddChild(root_0, e12.Tree);
            				    	retval.ret.setRhs(((e12 != null) ? e12.ret : null));

            				    }
            				    break;

            				default:
            				    goto loop23;
            		    }
            		} while (true);

            		loop23:
            			;	// Stops C# compiler whining that label 'loop23' has no statements


            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "subtractive_exp"

    public class structdec_return : ParserRuleReturnScope
    {
        public StructDeclaration ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "structdec"
    // spinach.g:194:1: structdec returns [StructDeclaration ret] : ( 'struct' variable ( ( '{' '}' ) | '{' (el1= scalarvardec )+ '}' ) ) END_OF_STATEMENT ;
    public spinachParser.structdec_return structdec() // throws RecognitionException [1]
    {   
        spinachParser.structdec_return retval = new spinachParser.structdec_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken string_literal79 = null;
        IToken char_literal81 = null;
        IToken char_literal82 = null;
        IToken char_literal83 = null;
        IToken char_literal84 = null;
        IToken END_OF_STATEMENT85 = null;
        spinachParser.scalarvardec_return el1 = null;

        spinachParser.variable_return variable80 = null;


        object string_literal79_tree=null;
        object char_literal81_tree=null;
        object char_literal82_tree=null;
        object char_literal83_tree=null;
        object char_literal84_tree=null;
        object END_OF_STATEMENT85_tree=null;


        retval.ret = new StructDeclaration();

        try 
    	{
            // spinach.g:198:1: ( ( 'struct' variable ( ( '{' '}' ) | '{' (el1= scalarvardec )+ '}' ) ) END_OF_STATEMENT )
            // spinach.g:198:3: ( 'struct' variable ( ( '{' '}' ) | '{' (el1= scalarvardec )+ '}' ) ) END_OF_STATEMENT
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// spinach.g:198:3: ( 'struct' variable ( ( '{' '}' ) | '{' (el1= scalarvardec )+ '}' ) )
            	// spinach.g:198:4: 'struct' variable ( ( '{' '}' ) | '{' (el1= scalarvardec )+ '}' )
            	{
            		string_literal79=(IToken)Match(input,33,FOLLOW_33_in_structdec1110); 
            			string_literal79_tree = (object)adaptor.Create(string_literal79);
            			adaptor.AddChild(root_0, string_literal79_tree);

            		PushFollow(FOLLOW_variable_in_structdec1112);
            		variable80 = variable();
            		state.followingStackPointer--;

            		adaptor.AddChild(root_0, variable80.Tree);
            		 retval.ret.setName(((variable80 != null) ? variable80.ret : null));
            		// spinach.g:199:1: ( ( '{' '}' ) | '{' (el1= scalarvardec )+ '}' )
            		int alt25 = 2;
            		int LA25_0 = input.LA(1);

            		if ( (LA25_0 == LEFTPARANTHESIS) )
            		{
            		    int LA25_1 = input.LA(2);

            		    if ( (LA25_1 == RIGHTPARANTHESIS) )
            		    {
            		        alt25 = 1;
            		    }
            		    else if ( (LA25_1 == VARTYPE || LA25_1 == STRINGTYPE) )
            		    {
            		        alt25 = 2;
            		    }
            		    else 
            		    {
            		        NoViableAltException nvae_d25s1 =
            		            new NoViableAltException("", 25, 1, input);

            		        throw nvae_d25s1;
            		    }
            		}
            		else 
            		{
            		    NoViableAltException nvae_d25s0 =
            		        new NoViableAltException("", 25, 0, input);

            		    throw nvae_d25s0;
            		}
            		switch (alt25) 
            		{
            		    case 1 :
            		        // spinach.g:199:2: ( '{' '}' )
            		        {
            		        	// spinach.g:199:2: ( '{' '}' )
            		        	// spinach.g:199:3: '{' '}'
            		        	{
            		        		char_literal81=(IToken)Match(input,LEFTPARANTHESIS,FOLLOW_LEFTPARANTHESIS_in_structdec1118); 
            		        			char_literal81_tree = (object)adaptor.Create(char_literal81);
            		        			adaptor.AddChild(root_0, char_literal81_tree);

            		        		char_literal82=(IToken)Match(input,RIGHTPARANTHESIS,FOLLOW_RIGHTPARANTHESIS_in_structdec1119); 
            		        			char_literal82_tree = (object)adaptor.Create(char_literal82);
            		        			adaptor.AddChild(root_0, char_literal82_tree);


            		        	}


            		        }
            		        break;
            		    case 2 :
            		        // spinach.g:200:1: '{' (el1= scalarvardec )+ '}'
            		        {
            		        	char_literal83=(IToken)Match(input,LEFTPARANTHESIS,FOLLOW_LEFTPARANTHESIS_in_structdec1123); 
            		        		char_literal83_tree = (object)adaptor.Create(char_literal83);
            		        		adaptor.AddChild(root_0, char_literal83_tree);

            		        	// spinach.g:200:5: (el1= scalarvardec )+
            		        	int cnt24 = 0;
            		        	do 
            		        	{
            		        	    int alt24 = 2;
            		        	    int LA24_0 = input.LA(1);

            		        	    if ( (LA24_0 == VARTYPE || LA24_0 == STRINGTYPE) )
            		        	    {
            		        	        alt24 = 1;
            		        	    }


            		        	    switch (alt24) 
            		        		{
            		        			case 1 :
            		        			    // spinach.g:200:6: el1= scalarvardec
            		        			    {
            		        			    	PushFollow(FOLLOW_scalarvardec_in_structdec1128);
            		        			    	el1 = scalarvardec();
            		        			    	state.followingStackPointer--;

            		        			    	adaptor.AddChild(root_0, el1.Tree);
            		        			    	 retval.ret.setVarType(((el1 != null) ? el1.ret : null));

            		        			    }
            		        			    break;

            		        			default:
            		        			    if ( cnt24 >= 1 ) goto loop24;
            		        		            EarlyExitException eee24 =
            		        		                new EarlyExitException(24, input);
            		        		            throw eee24;
            		        	    }
            		        	    cnt24++;
            		        	} while (true);

            		        	loop24:
            		        		;	// Stops C# compiler whining that label 'loop24' has no statements

            		        	char_literal84=(IToken)Match(input,RIGHTPARANTHESIS,FOLLOW_RIGHTPARANTHESIS_in_structdec1133); 
            		        		char_literal84_tree = (object)adaptor.Create(char_literal84);
            		        		adaptor.AddChild(root_0, char_literal84_tree);


            		        }
            		        break;

            		}

            		retval.ret.setVar();

            	}

            	END_OF_STATEMENT85=(IToken)Match(input,END_OF_STATEMENT,FOLLOW_END_OF_STATEMENT_in_structdec1138); 
            		END_OF_STATEMENT85_tree = (object)adaptor.Create(END_OF_STATEMENT85);
            		adaptor.AddChild(root_0, END_OF_STATEMENT85_tree);


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "structdec"

    public class scalarvardec_return : ParserRuleReturnScope
    {
        public ScalarVariableDeclaration ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "scalarvardec"
    // spinach.g:203:1: scalarvardec returns [ScalarVariableDeclaration ret] : ( ( VARTYPE | STRINGTYPE ) variable ) END_OF_STATEMENT ;
    public spinachParser.scalarvardec_return scalarvardec() // throws RecognitionException [1]
    {   
        spinachParser.scalarvardec_return retval = new spinachParser.scalarvardec_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken VARTYPE86 = null;
        IToken STRINGTYPE87 = null;
        IToken END_OF_STATEMENT89 = null;
        spinachParser.variable_return variable88 = null;


        object VARTYPE86_tree=null;
        object STRINGTYPE87_tree=null;
        object END_OF_STATEMENT89_tree=null;


        	retval.ret = new ScalarVariableDeclaration();
        	
        try 
    	{
            // spinach.g:207:2: ( ( ( VARTYPE | STRINGTYPE ) variable ) END_OF_STATEMENT )
            // spinach.g:207:3: ( ( VARTYPE | STRINGTYPE ) variable ) END_OF_STATEMENT
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// spinach.g:207:3: ( ( VARTYPE | STRINGTYPE ) variable )
            	// spinach.g:207:4: ( VARTYPE | STRINGTYPE ) variable
            	{
            		// spinach.g:207:4: ( VARTYPE | STRINGTYPE )
            		int alt26 = 2;
            		int LA26_0 = input.LA(1);

            		if ( (LA26_0 == VARTYPE) )
            		{
            		    alt26 = 1;
            		}
            		else if ( (LA26_0 == STRINGTYPE) )
            		{
            		    alt26 = 2;
            		}
            		else 
            		{
            		    NoViableAltException nvae_d26s0 =
            		        new NoViableAltException("", 26, 0, input);

            		    throw nvae_d26s0;
            		}
            		switch (alt26) 
            		{
            		    case 1 :
            		        // spinach.g:207:5: VARTYPE
            		        {
            		        	VARTYPE86=(IToken)Match(input,VARTYPE,FOLLOW_VARTYPE_in_scalarvardec1159); 
            		        		VARTYPE86_tree = (object)adaptor.Create(VARTYPE86);
            		        		adaptor.AddChild(root_0, VARTYPE86_tree);

            		        	 retval.ret.setType(((VARTYPE86 != null) ? VARTYPE86.Text : null));

            		        }
            		        break;
            		    case 2 :
            		        // spinach.g:208:4: STRINGTYPE
            		        {
            		        	STRINGTYPE87=(IToken)Match(input,STRINGTYPE,FOLLOW_STRINGTYPE_in_scalarvardec1166); 
            		        		STRINGTYPE87_tree = (object)adaptor.Create(STRINGTYPE87);
            		        		adaptor.AddChild(root_0, STRINGTYPE87_tree);

            		        	 retval.ret.setType(((STRINGTYPE87 != null) ? STRINGTYPE87.Text : null));

            		        }
            		        break;

            		}

            		PushFollow(FOLLOW_variable_in_scalarvardec1173);
            		variable88 = variable();
            		state.followingStackPointer--;

            		adaptor.AddChild(root_0, variable88.Tree);
            		 retval.ret.setVar(((variable88 != null) ? variable88.ret : null));

            	}

            	END_OF_STATEMENT89=(IToken)Match(input,END_OF_STATEMENT,FOLLOW_END_OF_STATEMENT_in_scalarvardec1177); 
            		END_OF_STATEMENT89_tree = (object)adaptor.Create(END_OF_STATEMENT89);
            		adaptor.AddChild(root_0, END_OF_STATEMENT89_tree);


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "scalarvardec"

    public class structobjdec_return : ParserRuleReturnScope
    {
        public StructObjectDeclaration ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "structobjdec"
    // spinach.g:212:1: structobjdec returns [StructObjectDeclaration ret] : (el1= variable el2= variable ) END_OF_STATEMENT ;
    public spinachParser.structobjdec_return structobjdec() // throws RecognitionException [1]
    {   
        spinachParser.structobjdec_return retval = new spinachParser.structobjdec_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken END_OF_STATEMENT90 = null;
        spinachParser.variable_return el1 = null;

        spinachParser.variable_return el2 = null;


        object END_OF_STATEMENT90_tree=null;


        retval.ret = new StructObjectDeclaration();

        try 
    	{
            // spinach.g:216:1: ( (el1= variable el2= variable ) END_OF_STATEMENT )
            // spinach.g:216:3: (el1= variable el2= variable ) END_OF_STATEMENT
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// spinach.g:216:3: (el1= variable el2= variable )
            	// spinach.g:216:4: el1= variable el2= variable
            	{
            		PushFollow(FOLLOW_variable_in_structobjdec1199);
            		el1 = variable();
            		state.followingStackPointer--;

            		adaptor.AddChild(root_0, el1.Tree);
            		 retval.ret.setStructName(((el1 != null) ? el1.ret : null));
            		PushFollow(FOLLOW_variable_in_structobjdec1206);
            		el2 = variable();
            		state.followingStackPointer--;

            		adaptor.AddChild(root_0, el2.Tree);
            		 retval.ret.setObjName(((el2 != null) ? el2.ret : null));

            	}

            	END_OF_STATEMENT90=(IToken)Match(input,END_OF_STATEMENT,FOLLOW_END_OF_STATEMENT_in_structobjdec1212); 
            		END_OF_STATEMENT90_tree = (object)adaptor.Create(END_OF_STATEMENT90);
            		adaptor.AddChild(root_0, END_OF_STATEMENT90_tree);


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "structobjdec"

    public class structassign_return : ParserRuleReturnScope
    {
        public StructAssignDeclaration ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "structassign"
    // spinach.g:219:2: structassign returns [StructAssignDeclaration ret] : (el1= variable '.' el2= variable ) ;
    public spinachParser.structassign_return structassign() // throws RecognitionException [1]
    {   
        spinachParser.structassign_return retval = new spinachParser.structassign_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken char_literal91 = null;
        spinachParser.variable_return el1 = null;

        spinachParser.variable_return el2 = null;


        object char_literal91_tree=null;


        retval.ret = new StructAssignDeclaration();

        try 
    	{
            // spinach.g:223:1: ( (el1= variable '.' el2= variable ) )
            // spinach.g:223:2: (el1= variable '.' el2= variable )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// spinach.g:223:2: (el1= variable '.' el2= variable )
            	// spinach.g:223:3: el1= variable '.' el2= variable
            	{
            		PushFollow(FOLLOW_variable_in_structassign1231);
            		el1 = variable();
            		state.followingStackPointer--;

            		adaptor.AddChild(root_0, el1.Tree);
            		retval.ret.setObjName(((el1 != null) ? el1.ret : null));
            		char_literal91=(IToken)Match(input,DOT,FOLLOW_DOT_in_structassign1234); 
            			char_literal91_tree = (object)adaptor.Create(char_literal91);
            			adaptor.AddChild(root_0, char_literal91_tree);

            		PushFollow(FOLLOW_variable_in_structassign1237);
            		el2 = variable();
            		state.followingStackPointer--;

            		adaptor.AddChild(root_0, el2.Tree);
            		retval.ret.setDataMember(((el2 != null) ? el2.ret : null));

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "structassign"

    public class deletionofvar_return : ParserRuleReturnScope
    {
        public DeleteVariable ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "deletionofvar"
    // spinach.g:226:1: deletionofvar returns [DeleteVariable ret] : ( 'delete' el1= variable ) END_OF_STATEMENT ;
    public spinachParser.deletionofvar_return deletionofvar() // throws RecognitionException [1]
    {   
        spinachParser.deletionofvar_return retval = new spinachParser.deletionofvar_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken string_literal92 = null;
        IToken END_OF_STATEMENT93 = null;
        spinachParser.variable_return el1 = null;


        object string_literal92_tree=null;
        object END_OF_STATEMENT93_tree=null;


        retval.ret = new DeleteVariable();

        try 
    	{
            // spinach.g:230:1: ( ( 'delete' el1= variable ) END_OF_STATEMENT )
            // spinach.g:230:2: ( 'delete' el1= variable ) END_OF_STATEMENT
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// spinach.g:230:2: ( 'delete' el1= variable )
            	// spinach.g:230:3: 'delete' el1= variable
            	{
            		string_literal92=(IToken)Match(input,34,FOLLOW_34_in_deletionofvar1258); 
            			string_literal92_tree = (object)adaptor.Create(string_literal92);
            			adaptor.AddChild(root_0, string_literal92_tree);

            		PushFollow(FOLLOW_variable_in_deletionofvar1262);
            		el1 = variable();
            		state.followingStackPointer--;

            		adaptor.AddChild(root_0, el1.Tree);
            		 retval.ret.setVar(((el1 != null) ? el1.ret : null));

            	}

            	END_OF_STATEMENT93=(IToken)Match(input,END_OF_STATEMENT,FOLLOW_END_OF_STATEMENT_in_deletionofvar1266); 
            		END_OF_STATEMENT93_tree = (object)adaptor.Create(END_OF_STATEMENT93);
            		adaptor.AddChild(root_0, END_OF_STATEMENT93_tree);


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "deletionofvar"

    public class print_return : ParserRuleReturnScope
    {
        public PrintOperationElement ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "print"
    // spinach.g:232:1: print returns [PrintOperationElement ret] : 'print' ( varorstruct | string_literal ) END_OF_STATEMENT ;
    public spinachParser.print_return print() // throws RecognitionException [1]
    {   
        spinachParser.print_return retval = new spinachParser.print_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken string_literal94 = null;
        IToken END_OF_STATEMENT97 = null;
        spinachParser.varorstruct_return varorstruct95 = null;

        spinachParser.string_literal_return string_literal96 = null;


        object string_literal94_tree=null;
        object END_OF_STATEMENT97_tree=null;


          retval.ret = new PrintOperationElement();

        try 
    	{
            // spinach.g:236:3: ( 'print' ( varorstruct | string_literal ) END_OF_STATEMENT )
            // spinach.g:236:5: 'print' ( varorstruct | string_literal ) END_OF_STATEMENT
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal94=(IToken)Match(input,35,FOLLOW_35_in_print1285); 
            		string_literal94_tree = (object)adaptor.Create(string_literal94);
            		adaptor.AddChild(root_0, string_literal94_tree);

            	// spinach.g:236:13: ( varorstruct | string_literal )
            	int alt27 = 2;
            	int LA27_0 = input.LA(1);

            	if ( (LA27_0 == VARIABLE) )
            	{
            	    alt27 = 1;
            	}
            	else if ( (LA27_0 == 57) )
            	{
            	    alt27 = 2;
            	}
            	else 
            	{
            	    NoViableAltException nvae_d27s0 =
            	        new NoViableAltException("", 27, 0, input);

            	    throw nvae_d27s0;
            	}
            	switch (alt27) 
            	{
            	    case 1 :
            	        // spinach.g:236:14: varorstruct
            	        {
            	        	PushFollow(FOLLOW_varorstruct_in_print1288);
            	        	varorstruct95 = varorstruct();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, varorstruct95.Tree);
            	        	retval.ret.setChildElement(((varorstruct95 != null) ? varorstruct95.ret : null)); 

            	        }
            	        break;
            	    case 2 :
            	        // spinach.g:237:6: string_literal
            	        {
            	        	PushFollow(FOLLOW_string_literal_in_print1297);
            	        	string_literal96 = string_literal();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, string_literal96.Tree);
            	        	retval.ret.setChildElement(((string_literal96 != null) ? string_literal96.ret : null));

            	        }
            	        break;

            	}

            	END_OF_STATEMENT97=(IToken)Match(input,END_OF_STATEMENT,FOLLOW_END_OF_STATEMENT_in_print1322); 
            		END_OF_STATEMENT97_tree = (object)adaptor.Create(END_OF_STATEMENT97);
            		adaptor.AddChild(root_0, END_OF_STATEMENT97_tree);


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "print"

    public class parallelfor_return : ParserRuleReturnScope
    {
        public ParallelForElement ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "parallelfor"
    // spinach.g:244:1: parallelfor returns [ParallelForElement ret] : 'parallelfor' LEFTBRACE r11= variable POINT r12= int_literal 'to' r13= int_literal RIGHTBRACE LEFTPARANTHESIS ( (e11= expr2 )+ ( ( 'SYNC' END_OF_STATEMENT ) | ) )+ RIGHTPARANTHESIS ;
    public spinachParser.parallelfor_return parallelfor() // throws RecognitionException [1]
    {   
        spinachParser.parallelfor_return retval = new spinachParser.parallelfor_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken string_literal98 = null;
        IToken LEFTBRACE99 = null;
        IToken POINT100 = null;
        IToken string_literal101 = null;
        IToken RIGHTBRACE102 = null;
        IToken LEFTPARANTHESIS103 = null;
        IToken string_literal104 = null;
        IToken END_OF_STATEMENT105 = null;
        IToken RIGHTPARANTHESIS106 = null;
        spinachParser.variable_return r11 = null;

        spinachParser.int_literal_return r12 = null;

        spinachParser.int_literal_return r13 = null;

        spinachParser.expr2_return e11 = null;


        object string_literal98_tree=null;
        object LEFTBRACE99_tree=null;
        object POINT100_tree=null;
        object string_literal101_tree=null;
        object RIGHTBRACE102_tree=null;
        object LEFTPARANTHESIS103_tree=null;
        object string_literal104_tree=null;
        object END_OF_STATEMENT105_tree=null;
        object RIGHTPARANTHESIS106_tree=null;


          retval.ret = new ParallelForElement();

        try 
    	{
            // spinach.g:247:2: ( 'parallelfor' LEFTBRACE r11= variable POINT r12= int_literal 'to' r13= int_literal RIGHTBRACE LEFTPARANTHESIS ( (e11= expr2 )+ ( ( 'SYNC' END_OF_STATEMENT ) | ) )+ RIGHTPARANTHESIS )
            // spinach.g:247:4: 'parallelfor' LEFTBRACE r11= variable POINT r12= int_literal 'to' r13= int_literal RIGHTBRACE LEFTPARANTHESIS ( (e11= expr2 )+ ( ( 'SYNC' END_OF_STATEMENT ) | ) )+ RIGHTPARANTHESIS
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal98=(IToken)Match(input,36,FOLLOW_36_in_parallelfor1344); 
            		string_literal98_tree = (object)adaptor.Create(string_literal98);
            		adaptor.AddChild(root_0, string_literal98_tree);

            	LEFTBRACE99=(IToken)Match(input,LEFTBRACE,FOLLOW_LEFTBRACE_in_parallelfor1345); 
            		LEFTBRACE99_tree = (object)adaptor.Create(LEFTBRACE99);
            		adaptor.AddChild(root_0, LEFTBRACE99_tree);

            	PushFollow(FOLLOW_variable_in_parallelfor1351);
            	r11 = variable();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, r11.Tree);
            	retval.ret.RANGEVARIABLE = ((r11 != null) ? r11.ret : null);
            	POINT100=(IToken)Match(input,POINT,FOLLOW_POINT_in_parallelfor1354); 
            		POINT100_tree = (object)adaptor.Create(POINT100);
            		adaptor.AddChild(root_0, POINT100_tree);

            	PushFollow(FOLLOW_int_literal_in_parallelfor1360);
            	r12 = int_literal();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, r12.Tree);
            	retval.ret.STARTINGRANGE = ((r12 != null) ? r12.ret : null);
            	string_literal101=(IToken)Match(input,37,FOLLOW_37_in_parallelfor1363); 
            		string_literal101_tree = (object)adaptor.Create(string_literal101);
            		adaptor.AddChild(root_0, string_literal101_tree);

            	PushFollow(FOLLOW_int_literal_in_parallelfor1368);
            	r13 = int_literal();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, r13.Tree);
            	retval.ret.ENDINGRANGE = ((r13 != null) ? r13.ret : null);
            	RIGHTBRACE102=(IToken)Match(input,RIGHTBRACE,FOLLOW_RIGHTBRACE_in_parallelfor1371); 
            		RIGHTBRACE102_tree = (object)adaptor.Create(RIGHTBRACE102);
            		adaptor.AddChild(root_0, RIGHTBRACE102_tree);

            	LEFTPARANTHESIS103=(IToken)Match(input,LEFTPARANTHESIS,FOLLOW_LEFTPARANTHESIS_in_parallelfor1373); 
            		LEFTPARANTHESIS103_tree = (object)adaptor.Create(LEFTPARANTHESIS103);
            		adaptor.AddChild(root_0, LEFTPARANTHESIS103_tree);

            	// spinach.g:247:228: ( (e11= expr2 )+ ( ( 'SYNC' END_OF_STATEMENT ) | ) )+
            	int cnt30 = 0;
            	do 
            	{
            	    int alt30 = 2;
            	    int LA30_0 = input.LA(1);

            	    if ( (LA30_0 == VARIABLE || LA30_0 == VARTYPE || LA30_0 == STRINGTYPE || LA30_0 == 34 || LA30_0 == 39 || LA30_0 == 41) )
            	    {
            	        alt30 = 1;
            	    }


            	    switch (alt30) 
            		{
            			case 1 :
            			    // spinach.g:247:229: (e11= expr2 )+ ( ( 'SYNC' END_OF_STATEMENT ) | )
            			    {
            			    	// spinach.g:247:229: (e11= expr2 )+
            			    	int cnt28 = 0;
            			    	do 
            			    	{
            			    	    int alt28 = 2;
            			    	    switch ( input.LA(1) ) 
            			    	    {
            			    	    case VARIABLE:
            			    	    	{
            			    	        alt28 = 1;
            			    	        }
            			    	        break;
            			    	    case 39:
            			    	    	{
            			    	        alt28 = 1;
            			    	        }
            			    	        break;
            			    	    case 41:
            			    	    	{
            			    	        alt28 = 1;
            			    	        }
            			    	        break;
            			    	    case VARTYPE:
            			    	    	{
            			    	        alt28 = 1;
            			    	        }
            			    	        break;
            			    	    case STRINGTYPE:
            			    	    	{
            			    	        alt28 = 1;
            			    	        }
            			    	        break;
            			    	    case 34:
            			    	    	{
            			    	        alt28 = 1;
            			    	        }
            			    	        break;

            			    	    }

            			    	    switch (alt28) 
            			    		{
            			    			case 1 :
            			    			    // spinach.g:247:230: e11= expr2
            			    			    {
            			    			    	PushFollow(FOLLOW_expr2_in_parallelfor1380);
            			    			    	e11 = expr2();
            			    			    	state.followingStackPointer--;

            			    			    	adaptor.AddChild(root_0, e11.Tree);
            			    			    	retval.ret.ADDCODE =((e11 != null) ? e11.ret : null);

            			    			    }
            			    			    break;

            			    			default:
            			    			    if ( cnt28 >= 1 ) goto loop28;
            			    		            EarlyExitException eee28 =
            			    		                new EarlyExitException(28, input);
            			    		            throw eee28;
            			    	    }
            			    	    cnt28++;
            			    	} while (true);

            			    	loop28:
            			    		;	// Stops C# compiler whining that label 'loop28' has no statements

            			    	// spinach.g:247:272: ( ( 'SYNC' END_OF_STATEMENT ) | )
            			    	int alt29 = 2;
            			    	int LA29_0 = input.LA(1);

            			    	if ( (LA29_0 == 38) )
            			    	{
            			    	    alt29 = 1;
            			    	}
            			    	else if ( (LA29_0 == VARIABLE || LA29_0 == VARTYPE || LA29_0 == STRINGTYPE || LA29_0 == RIGHTPARANTHESIS || LA29_0 == 34 || LA29_0 == 39 || LA29_0 == 41) )
            			    	{
            			    	    alt29 = 2;
            			    	}
            			    	else 
            			    	{
            			    	    NoViableAltException nvae_d29s0 =
            			    	        new NoViableAltException("", 29, 0, input);

            			    	    throw nvae_d29s0;
            			    	}
            			    	switch (alt29) 
            			    	{
            			    	    case 1 :
            			    	        // spinach.g:247:273: ( 'SYNC' END_OF_STATEMENT )
            			    	        {
            			    	        	// spinach.g:247:273: ( 'SYNC' END_OF_STATEMENT )
            			    	        	// spinach.g:247:274: 'SYNC' END_OF_STATEMENT
            			    	        	{
            			    	        		string_literal104=(IToken)Match(input,38,FOLLOW_38_in_parallelfor1386); 
            			    	        			string_literal104_tree = (object)adaptor.Create(string_literal104);
            			    	        			adaptor.AddChild(root_0, string_literal104_tree);

            			    	        		retval.ret.syncfunction();
            			    	        		END_OF_STATEMENT105=(IToken)Match(input,END_OF_STATEMENT,FOLLOW_END_OF_STATEMENT_in_parallelfor1389); 
            			    	        			END_OF_STATEMENT105_tree = (object)adaptor.Create(END_OF_STATEMENT105);
            			    	        			adaptor.AddChild(root_0, END_OF_STATEMENT105_tree);


            			    	        	}


            			    	        }
            			    	        break;
            			    	    case 2 :
            			    	        // spinach.g:247:327: 
            			    	        {
            			    	        	retval.ret.syncfunction();

            			    	        }
            			    	        break;

            			    	}


            			    }
            			    break;

            			default:
            			    if ( cnt30 >= 1 ) goto loop30;
            		            EarlyExitException eee30 =
            		                new EarlyExitException(30, input);
            		            throw eee30;
            	    }
            	    cnt30++;
            	} while (true);

            	loop30:
            		;	// Stops C# compiler whining that label 'loop30' has no statements

            	RIGHTPARANTHESIS106=(IToken)Match(input,RIGHTPARANTHESIS,FOLLOW_RIGHTPARANTHESIS_in_parallelfor1397); 
            		RIGHTPARANTHESIS106_tree = (object)adaptor.Create(RIGHTPARANTHESIS106);
            		adaptor.AddChild(root_0, RIGHTPARANTHESIS106_tree);


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "parallelfor"

    public class ifelse_return : ParserRuleReturnScope
    {
        public IfStatementElement ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "ifelse"
    // spinach.g:250:1: ifelse returns [IfStatementElement ret] : ( 'if' LEFTBRACE ( varorstruct ) ( '==' | '!=' | '<' | '<=' | '>' | '>=' ) (e13= var_int_or_double_literal | e14= string_literal ) RIGHTBRACE LEFTPARANTHESIS ( (e11= ifloop ) | ) RIGHTPARANTHESIS ) ( 'else' LEFTPARANTHESIS ( (e12= ifloop ) | ) RIGHTPARANTHESIS )? ;
    public spinachParser.ifelse_return ifelse() // throws RecognitionException [1]
    {   
        spinachParser.ifelse_return retval = new spinachParser.ifelse_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken string_literal107 = null;
        IToken LEFTBRACE108 = null;
        IToken string_literal110 = null;
        IToken string_literal111 = null;
        IToken char_literal112 = null;
        IToken string_literal113 = null;
        IToken char_literal114 = null;
        IToken string_literal115 = null;
        IToken RIGHTBRACE116 = null;
        IToken LEFTPARANTHESIS117 = null;
        IToken RIGHTPARANTHESIS118 = null;
        IToken string_literal119 = null;
        IToken LEFTPARANTHESIS120 = null;
        IToken RIGHTPARANTHESIS121 = null;
        spinachParser.var_int_or_double_literal_return e13 = null;

        spinachParser.string_literal_return e14 = null;

        spinachParser.ifloop_return e11 = null;

        spinachParser.ifloop_return e12 = null;

        spinachParser.varorstruct_return varorstruct109 = null;


        object string_literal107_tree=null;
        object LEFTBRACE108_tree=null;
        object string_literal110_tree=null;
        object string_literal111_tree=null;
        object char_literal112_tree=null;
        object string_literal113_tree=null;
        object char_literal114_tree=null;
        object string_literal115_tree=null;
        object RIGHTBRACE116_tree=null;
        object LEFTPARANTHESIS117_tree=null;
        object RIGHTPARANTHESIS118_tree=null;
        object string_literal119_tree=null;
        object LEFTPARANTHESIS120_tree=null;
        object RIGHTPARANTHESIS121_tree=null;


           retval.ret = new IfStatementElement();

        try 
    	{
            // spinach.g:254:1: ( ( 'if' LEFTBRACE ( varorstruct ) ( '==' | '!=' | '<' | '<=' | '>' | '>=' ) (e13= var_int_or_double_literal | e14= string_literal ) RIGHTBRACE LEFTPARANTHESIS ( (e11= ifloop ) | ) RIGHTPARANTHESIS ) ( 'else' LEFTPARANTHESIS ( (e12= ifloop ) | ) RIGHTPARANTHESIS )? )
            // spinach.g:254:2: ( 'if' LEFTBRACE ( varorstruct ) ( '==' | '!=' | '<' | '<=' | '>' | '>=' ) (e13= var_int_or_double_literal | e14= string_literal ) RIGHTBRACE LEFTPARANTHESIS ( (e11= ifloop ) | ) RIGHTPARANTHESIS ) ( 'else' LEFTPARANTHESIS ( (e12= ifloop ) | ) RIGHTPARANTHESIS )?
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// spinach.g:254:2: ( 'if' LEFTBRACE ( varorstruct ) ( '==' | '!=' | '<' | '<=' | '>' | '>=' ) (e13= var_int_or_double_literal | e14= string_literal ) RIGHTBRACE LEFTPARANTHESIS ( (e11= ifloop ) | ) RIGHTPARANTHESIS )
            	// spinach.g:254:3: 'if' LEFTBRACE ( varorstruct ) ( '==' | '!=' | '<' | '<=' | '>' | '>=' ) (e13= var_int_or_double_literal | e14= string_literal ) RIGHTBRACE LEFTPARANTHESIS ( (e11= ifloop ) | ) RIGHTPARANTHESIS
            	{
            		string_literal107=(IToken)Match(input,39,FOLLOW_39_in_ifelse1414); 
            			string_literal107_tree = (object)adaptor.Create(string_literal107);
            			adaptor.AddChild(root_0, string_literal107_tree);

            		LEFTBRACE108=(IToken)Match(input,LEFTBRACE,FOLLOW_LEFTBRACE_in_ifelse1416); 
            			LEFTBRACE108_tree = (object)adaptor.Create(LEFTBRACE108);
            			adaptor.AddChild(root_0, LEFTBRACE108_tree);

            		// spinach.g:254:18: ( varorstruct )
            		// spinach.g:254:19: varorstruct
            		{
            			PushFollow(FOLLOW_varorstruct_in_ifelse1419);
            			varorstruct109 = varorstruct();
            			state.followingStackPointer--;

            			adaptor.AddChild(root_0, varorstruct109.Tree);
            			retval.ret.setLhs(((varorstruct109 != null) ? varorstruct109.ret : null));

            		}

            		// spinach.g:254:69: ( '==' | '!=' | '<' | '<=' | '>' | '>=' )
            		int alt31 = 6;
            		switch ( input.LA(1) ) 
            		{
            		case EQUALITYEXPRESSION:
            			{
            		    alt31 = 1;
            		    }
            		    break;
            		case NONEQUALITYEXPRESSION:
            			{
            		    alt31 = 2;
            		    }
            		    break;
            		case LESSTHANEXPRESSION:
            			{
            		    alt31 = 3;
            		    }
            		    break;
            		case LESSTHANEQUALTOEXPRESSION:
            			{
            		    alt31 = 4;
            		    }
            		    break;
            		case GREATERTHANEXPRESSION:
            			{
            		    alt31 = 5;
            		    }
            		    break;
            		case GREATERTHANEQUALTOEXPRESSION:
            			{
            		    alt31 = 6;
            		    }
            		    break;
            			default:
            			    NoViableAltException nvae_d31s0 =
            			        new NoViableAltException("", 31, 0, input);

            			    throw nvae_d31s0;
            		}

            		switch (alt31) 
            		{
            		    case 1 :
            		        // spinach.g:255:7: '=='
            		        {
            		        	string_literal110=(IToken)Match(input,EQUALITYEXPRESSION,FOLLOW_EQUALITYEXPRESSION_in_ifelse1430); 
            		        		string_literal110_tree = (object)adaptor.Create(string_literal110);
            		        		adaptor.AddChild(root_0, string_literal110_tree);

            		        	 retval.ret.OP = "eq"; 

            		        }
            		        break;
            		    case 2 :
            		        // spinach.g:256:7: '!='
            		        {
            		        	string_literal111=(IToken)Match(input,NONEQUALITYEXPRESSION,FOLLOW_NONEQUALITYEXPRESSION_in_ifelse1440); 
            		        		string_literal111_tree = (object)adaptor.Create(string_literal111);
            		        		adaptor.AddChild(root_0, string_literal111_tree);

            		        	 retval.ret.OP = "ne"; 

            		        }
            		        break;
            		    case 3 :
            		        // spinach.g:257:7: '<'
            		        {
            		        	char_literal112=(IToken)Match(input,LESSTHANEXPRESSION,FOLLOW_LESSTHANEXPRESSION_in_ifelse1450); 
            		        		char_literal112_tree = (object)adaptor.Create(char_literal112);
            		        		adaptor.AddChild(root_0, char_literal112_tree);

            		        	 retval.ret.OP = "lt"; 

            		        }
            		        break;
            		    case 4 :
            		        // spinach.g:258:7: '<='
            		        {
            		        	string_literal113=(IToken)Match(input,LESSTHANEQUALTOEXPRESSION,FOLLOW_LESSTHANEQUALTOEXPRESSION_in_ifelse1461); 
            		        		string_literal113_tree = (object)adaptor.Create(string_literal113);
            		        		adaptor.AddChild(root_0, string_literal113_tree);

            		        	 retval.ret.OP = "le"; 

            		        }
            		        break;
            		    case 5 :
            		        // spinach.g:259:7: '>'
            		        {
            		        	char_literal114=(IToken)Match(input,GREATERTHANEXPRESSION,FOLLOW_GREATERTHANEXPRESSION_in_ifelse1471); 
            		        		char_literal114_tree = (object)adaptor.Create(char_literal114);
            		        		adaptor.AddChild(root_0, char_literal114_tree);

            		        	 retval.ret.OP = "gt"; 

            		        }
            		        break;
            		    case 6 :
            		        // spinach.g:260:7: '>='
            		        {
            		        	string_literal115=(IToken)Match(input,GREATERTHANEQUALTOEXPRESSION,FOLLOW_GREATERTHANEQUALTOEXPRESSION_in_ifelse1482); 
            		        		string_literal115_tree = (object)adaptor.Create(string_literal115);
            		        		adaptor.AddChild(root_0, string_literal115_tree);

            		        	 retval.ret.OP = "ge"; 

            		        }
            		        break;

            		}

            		// spinach.g:262:1: (e13= var_int_or_double_literal | e14= string_literal )
            		int alt32 = 2;
            		int LA32_0 = input.LA(1);

            		if ( ((LA32_0 >= VARIABLE && LA32_0 <= DOUBLE_LITERAL)) )
            		{
            		    alt32 = 1;
            		}
            		else if ( (LA32_0 == 57) )
            		{
            		    alt32 = 2;
            		}
            		else 
            		{
            		    NoViableAltException nvae_d32s0 =
            		        new NoViableAltException("", 32, 0, input);

            		    throw nvae_d32s0;
            		}
            		switch (alt32) 
            		{
            		    case 1 :
            		        // spinach.g:262:2: e13= var_int_or_double_literal
            		        {
            		        	PushFollow(FOLLOW_var_int_or_double_literal_in_ifelse1495);
            		        	e13 = var_int_or_double_literal();
            		        	state.followingStackPointer--;

            		        	adaptor.AddChild(root_0, e13.Tree);
            		        	retval.ret.setRhs(((e13 != null) ? e13.ret : null));

            		        }
            		        break;
            		    case 2 :
            		        // spinach.g:262:64: e14= string_literal
            		        {
            		        	PushFollow(FOLLOW_string_literal_in_ifelse1502);
            		        	e14 = string_literal();
            		        	state.followingStackPointer--;

            		        	adaptor.AddChild(root_0, e14.Tree);
            		        	retval.ret.setRhs(((e14 != null) ? e14.ret : null));

            		        }
            		        break;

            		}

            		RIGHTBRACE116=(IToken)Match(input,RIGHTBRACE,FOLLOW_RIGHTBRACE_in_ifelse1506); 
            			RIGHTBRACE116_tree = (object)adaptor.Create(RIGHTBRACE116);
            			adaptor.AddChild(root_0, RIGHTBRACE116_tree);

            		LEFTPARANTHESIS117=(IToken)Match(input,LEFTPARANTHESIS,FOLLOW_LEFTPARANTHESIS_in_ifelse1508); 
            			LEFTPARANTHESIS117_tree = (object)adaptor.Create(LEFTPARANTHESIS117);
            			adaptor.AddChild(root_0, LEFTPARANTHESIS117_tree);

            		// spinach.g:262:143: ( (e11= ifloop ) | )
            		int alt33 = 2;
            		int LA33_0 = input.LA(1);

            		if ( (LA33_0 == VARIABLE || LA33_0 == VARTYPE || LA33_0 == STRINGTYPE || LA33_0 == 27 || LA33_0 == 31 || (LA33_0 >= 34 && LA33_0 <= 35) || LA33_0 == 39 || LA33_0 == 41 || (LA33_0 >= 45 && LA33_0 <= 46) || (LA33_0 >= 50 && LA33_0 <= 54)) )
            		{
            		    alt33 = 1;
            		}
            		else if ( (LA33_0 == RIGHTPARANTHESIS) )
            		{
            		    alt33 = 2;
            		}
            		else 
            		{
            		    NoViableAltException nvae_d33s0 =
            		        new NoViableAltException("", 33, 0, input);

            		    throw nvae_d33s0;
            		}
            		switch (alt33) 
            		{
            		    case 1 :
            		        // spinach.g:262:144: (e11= ifloop )
            		        {
            		        	// spinach.g:262:144: (e11= ifloop )
            		        	// spinach.g:262:145: e11= ifloop
            		        	{
            		        		PushFollow(FOLLOW_ifloop_in_ifelse1516);
            		        		e11 = ifloop();
            		        		state.followingStackPointer--;

            		        		adaptor.AddChild(root_0, e11.Tree);
            		        		retval.ret.IFCODE = ((e11 != null) ? e11.ret : null);

            		        	}


            		        }
            		        break;
            		    case 2 :
            		        // spinach.g:262:190: 
            		        {
            		        }
            		        break;

            		}

            		RIGHTPARANTHESIS118=(IToken)Match(input,RIGHTPARANTHESIS,FOLLOW_RIGHTPARANTHESIS_in_ifelse1521); 
            			RIGHTPARANTHESIS118_tree = (object)adaptor.Create(RIGHTPARANTHESIS118);
            			adaptor.AddChild(root_0, RIGHTPARANTHESIS118_tree);


            	}

            	// spinach.g:262:208: ( 'else' LEFTPARANTHESIS ( (e12= ifloop ) | ) RIGHTPARANTHESIS )?
            	int alt35 = 2;
            	int LA35_0 = input.LA(1);

            	if ( (LA35_0 == 40) )
            	{
            	    alt35 = 1;
            	}
            	switch (alt35) 
            	{
            	    case 1 :
            	        // spinach.g:262:209: 'else' LEFTPARANTHESIS ( (e12= ifloop ) | ) RIGHTPARANTHESIS
            	        {
            	        	string_literal119=(IToken)Match(input,40,FOLLOW_40_in_ifelse1524); 
            	        		string_literal119_tree = (object)adaptor.Create(string_literal119);
            	        		adaptor.AddChild(root_0, string_literal119_tree);

            	        	LEFTPARANTHESIS120=(IToken)Match(input,LEFTPARANTHESIS,FOLLOW_LEFTPARANTHESIS_in_ifelse1527); 
            	        		LEFTPARANTHESIS120_tree = (object)adaptor.Create(LEFTPARANTHESIS120);
            	        		adaptor.AddChild(root_0, LEFTPARANTHESIS120_tree);

            	        	// spinach.g:262:233: ( (e12= ifloop ) | )
            	        	int alt34 = 2;
            	        	int LA34_0 = input.LA(1);

            	        	if ( (LA34_0 == VARIABLE || LA34_0 == VARTYPE || LA34_0 == STRINGTYPE || LA34_0 == 27 || LA34_0 == 31 || (LA34_0 >= 34 && LA34_0 <= 35) || LA34_0 == 39 || LA34_0 == 41 || (LA34_0 >= 45 && LA34_0 <= 46) || (LA34_0 >= 50 && LA34_0 <= 54)) )
            	        	{
            	        	    alt34 = 1;
            	        	}
            	        	else if ( (LA34_0 == RIGHTPARANTHESIS) )
            	        	{
            	        	    alt34 = 2;
            	        	}
            	        	else 
            	        	{
            	        	    NoViableAltException nvae_d34s0 =
            	        	        new NoViableAltException("", 34, 0, input);

            	        	    throw nvae_d34s0;
            	        	}
            	        	switch (alt34) 
            	        	{
            	        	    case 1 :
            	        	        // spinach.g:262:234: (e12= ifloop )
            	        	        {
            	        	        	// spinach.g:262:234: (e12= ifloop )
            	        	        	// spinach.g:262:235: e12= ifloop
            	        	        	{
            	        	        		PushFollow(FOLLOW_ifloop_in_ifelse1536);
            	        	        		e12 = ifloop();
            	        	        		state.followingStackPointer--;

            	        	        		adaptor.AddChild(root_0, e12.Tree);
            	        	        		retval.ret.ELSECODE = ((e12 != null) ? e12.ret : null);

            	        	        	}


            	        	        }
            	        	        break;
            	        	    case 2 :
            	        	        // spinach.g:262:283: 
            	        	        {
            	        	        }
            	        	        break;

            	        	}

            	        	RIGHTPARANTHESIS121=(IToken)Match(input,RIGHTPARANTHESIS,FOLLOW_RIGHTPARANTHESIS_in_ifelse1542); 
            	        		RIGHTPARANTHESIS121_tree = (object)adaptor.Create(RIGHTPARANTHESIS121);
            	        		adaptor.AddChild(root_0, RIGHTPARANTHESIS121_tree);


            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "ifelse"

    public class ifloop_return : ParserRuleReturnScope
    {
        public List<Element> ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "ifloop"
    // spinach.g:264:1: ifloop returns [List<Element> ret] : ( expr1 | functionreturn )+ ;
    public spinachParser.ifloop_return ifloop() // throws RecognitionException [1]
    {   
        spinachParser.ifloop_return retval = new spinachParser.ifloop_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        spinachParser.expr1_return expr1122 = null;

        spinachParser.functionreturn_return functionreturn123 = null;




           retval.ret = new List<Element>();

        try 
    	{
            // spinach.g:269:1: ( ( expr1 | functionreturn )+ )
            // spinach.g:269:3: ( expr1 | functionreturn )+
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// spinach.g:269:3: ( expr1 | functionreturn )+
            	int cnt36 = 0;
            	do 
            	{
            	    int alt36 = 3;
            	    int LA36_0 = input.LA(1);

            	    if ( (LA36_0 == VARIABLE || LA36_0 == VARTYPE || LA36_0 == STRINGTYPE || LA36_0 == 27 || LA36_0 == 31 || (LA36_0 >= 34 && LA36_0 <= 35) || LA36_0 == 39 || LA36_0 == 41 || LA36_0 == 46 || (LA36_0 >= 50 && LA36_0 <= 54)) )
            	    {
            	        alt36 = 1;
            	    }
            	    else if ( (LA36_0 == 45) )
            	    {
            	        alt36 = 2;
            	    }


            	    switch (alt36) 
            		{
            			case 1 :
            			    // spinach.g:269:4: expr1
            			    {
            			    	PushFollow(FOLLOW_expr1_in_ifloop1563);
            			    	expr1122 = expr1();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, expr1122.Tree);
            			    	retval.ret.Add(((expr1122 != null) ? expr1122.ret : null));

            			    }
            			    break;
            			case 2 :
            			    // spinach.g:269:39: functionreturn
            			    {
            			    	PushFollow(FOLLOW_functionreturn_in_ifloop1566);
            			    	functionreturn123 = functionreturn();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, functionreturn123.Tree);
            			    	retval.ret.Add(((functionreturn123 != null) ? functionreturn123.ret : null));

            			    }
            			    break;

            			default:
            			    if ( cnt36 >= 1 ) goto loop36;
            		            EarlyExitException eee36 =
            		                new EarlyExitException(36, input);
            		            throw eee36;
            	    }
            	    cnt36++;
            	} while (true);

            	loop36:
            		;	// Stops C# compiler whining that label 'loop36' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "ifloop"

    public class forstatement_return : ParserRuleReturnScope
    {
        public ForStatementElement ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "forstatement"
    // spinach.g:273:1: forstatement returns [ForStatementElement ret] : 'for' LEFTBRACE r11= variable POINT r12= int_literal 'to' r13= int_literal RIGHTBRACE LEFTPARANTHESIS (e11= forexpr )+ RIGHTPARANTHESIS ;
    public spinachParser.forstatement_return forstatement() // throws RecognitionException [1]
    {   
        spinachParser.forstatement_return retval = new spinachParser.forstatement_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken string_literal124 = null;
        IToken LEFTBRACE125 = null;
        IToken POINT126 = null;
        IToken string_literal127 = null;
        IToken RIGHTBRACE128 = null;
        IToken LEFTPARANTHESIS129 = null;
        IToken RIGHTPARANTHESIS130 = null;
        spinachParser.variable_return r11 = null;

        spinachParser.int_literal_return r12 = null;

        spinachParser.int_literal_return r13 = null;

        spinachParser.forexpr_return e11 = null;


        object string_literal124_tree=null;
        object LEFTBRACE125_tree=null;
        object POINT126_tree=null;
        object string_literal127_tree=null;
        object RIGHTBRACE128_tree=null;
        object LEFTPARANTHESIS129_tree=null;
        object RIGHTPARANTHESIS130_tree=null;


           retval.ret = new ForStatementElement();

        try 
    	{
            // spinach.g:276:2: ( 'for' LEFTBRACE r11= variable POINT r12= int_literal 'to' r13= int_literal RIGHTBRACE LEFTPARANTHESIS (e11= forexpr )+ RIGHTPARANTHESIS )
            // spinach.g:276:3: 'for' LEFTBRACE r11= variable POINT r12= int_literal 'to' r13= int_literal RIGHTBRACE LEFTPARANTHESIS (e11= forexpr )+ RIGHTPARANTHESIS
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal124=(IToken)Match(input,41,FOLLOW_41_in_forstatement1585); 
            		string_literal124_tree = (object)adaptor.Create(string_literal124);
            		adaptor.AddChild(root_0, string_literal124_tree);

            	LEFTBRACE125=(IToken)Match(input,LEFTBRACE,FOLLOW_LEFTBRACE_in_forstatement1587); 
            		LEFTBRACE125_tree = (object)adaptor.Create(LEFTBRACE125);
            		adaptor.AddChild(root_0, LEFTBRACE125_tree);

            	PushFollow(FOLLOW_variable_in_forstatement1593);
            	r11 = variable();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, r11.Tree);
            	retval.ret.RANGEVARIABLE = ((r11 != null) ? r11.ret : null);
            	POINT126=(IToken)Match(input,POINT,FOLLOW_POINT_in_forstatement1596); 
            		POINT126_tree = (object)adaptor.Create(POINT126);
            		adaptor.AddChild(root_0, POINT126_tree);

            	PushFollow(FOLLOW_int_literal_in_forstatement1602);
            	r12 = int_literal();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, r12.Tree);
            	retval.ret.STARTINGRANGE = ((r12 != null) ? r12.ret : null);
            	string_literal127=(IToken)Match(input,37,FOLLOW_37_in_forstatement1605); 
            		string_literal127_tree = (object)adaptor.Create(string_literal127);
            		adaptor.AddChild(root_0, string_literal127_tree);

            	PushFollow(FOLLOW_int_literal_in_forstatement1610);
            	r13 = int_literal();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, r13.Tree);
            	retval.ret.ENDINGRANGE = ((r13 != null) ? r13.ret : null);
            	RIGHTBRACE128=(IToken)Match(input,RIGHTBRACE,FOLLOW_RIGHTBRACE_in_forstatement1613); 
            		RIGHTBRACE128_tree = (object)adaptor.Create(RIGHTBRACE128);
            		adaptor.AddChild(root_0, RIGHTBRACE128_tree);

            	LEFTPARANTHESIS129=(IToken)Match(input,LEFTPARANTHESIS,FOLLOW_LEFTPARANTHESIS_in_forstatement1615); 
            		LEFTPARANTHESIS129_tree = (object)adaptor.Create(LEFTPARANTHESIS129);
            		adaptor.AddChild(root_0, LEFTPARANTHESIS129_tree);

            	// spinach.g:276:219: (e11= forexpr )+
            	int cnt37 = 0;
            	do 
            	{
            	    int alt37 = 2;
            	    int LA37_0 = input.LA(1);

            	    if ( (LA37_0 == VARIABLE || LA37_0 == VARTYPE || LA37_0 == STRINGTYPE || LA37_0 == 27 || LA37_0 == 31 || LA37_0 == 34 || LA37_0 == 39 || LA37_0 == 41 || LA37_0 == 46 || (LA37_0 >= 50 && LA37_0 <= 54)) )
            	    {
            	        alt37 = 1;
            	    }


            	    switch (alt37) 
            		{
            			case 1 :
            			    // spinach.g:276:220: e11= forexpr
            			    {
            			    	PushFollow(FOLLOW_forexpr_in_forstatement1620);
            			    	e11 = forexpr();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, e11.Tree);
            			    	retval.ret.ADDCODE =((e11 != null) ? e11.ret : null);

            			    }
            			    break;

            			default:
            			    if ( cnt37 >= 1 ) goto loop37;
            		            EarlyExitException eee37 =
            		                new EarlyExitException(37, input);
            		            throw eee37;
            	    }
            	    cnt37++;
            	} while (true);

            	loop37:
            		;	// Stops C# compiler whining that label 'loop37' has no statements

            	RIGHTPARANTHESIS130=(IToken)Match(input,RIGHTPARANTHESIS,FOLLOW_RIGHTPARANTHESIS_in_forstatement1625); 
            		RIGHTPARANTHESIS130_tree = (object)adaptor.Create(RIGHTPARANTHESIS130);
            		adaptor.AddChild(root_0, RIGHTPARANTHESIS130_tree);


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "forstatement"

    public class functioncall_return : ParserRuleReturnScope
    {
        public FunctionCallElement ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "functioncall"
    // spinach.g:278:1: functioncall returns [FunctionCallElement ret] : variable '(' ( (el1= var_int_or_double_literal | e13= string_literal ) ( ',' (el2= var_int_or_double_literal | e13= string_literal ) )* )? ')' END_OF_STATEMENT ;
    public spinachParser.functioncall_return functioncall() // throws RecognitionException [1]
    {   
        spinachParser.functioncall_return retval = new spinachParser.functioncall_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken char_literal132 = null;
        IToken char_literal133 = null;
        IToken char_literal134 = null;
        IToken END_OF_STATEMENT135 = null;
        spinachParser.var_int_or_double_literal_return el1 = null;

        spinachParser.string_literal_return e13 = null;

        spinachParser.var_int_or_double_literal_return el2 = null;

        spinachParser.variable_return variable131 = null;


        object char_literal132_tree=null;
        object char_literal133_tree=null;
        object char_literal134_tree=null;
        object END_OF_STATEMENT135_tree=null;

         retval.ret = new FunctionCallElement();
         
        try 
    	{
            // spinach.g:281:3: ( variable '(' ( (el1= var_int_or_double_literal | e13= string_literal ) ( ',' (el2= var_int_or_double_literal | e13= string_literal ) )* )? ')' END_OF_STATEMENT )
            // spinach.g:281:4: variable '(' ( (el1= var_int_or_double_literal | e13= string_literal ) ( ',' (el2= var_int_or_double_literal | e13= string_literal ) )* )? ')' END_OF_STATEMENT
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_variable_in_functioncall1643);
            	variable131 = variable();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, variable131.Tree);
            	retval.ret.setfunctioncallname(((variable131 != null) ? variable131.ret : null));
            	char_literal132=(IToken)Match(input,LEFTBRACE,FOLLOW_LEFTBRACE_in_functioncall1648); 
            		char_literal132_tree = (object)adaptor.Create(char_literal132);
            		adaptor.AddChild(root_0, char_literal132_tree);

            	// spinach.g:282:6: ( (el1= var_int_or_double_literal | e13= string_literal ) ( ',' (el2= var_int_or_double_literal | e13= string_literal ) )* )?
            	int alt41 = 2;
            	int LA41_0 = input.LA(1);

            	if ( ((LA41_0 >= VARIABLE && LA41_0 <= DOUBLE_LITERAL) || LA41_0 == 57) )
            	{
            	    alt41 = 1;
            	}
            	switch (alt41) 
            	{
            	    case 1 :
            	        // spinach.g:282:7: (el1= var_int_or_double_literal | e13= string_literal ) ( ',' (el2= var_int_or_double_literal | e13= string_literal ) )*
            	        {
            	        	// spinach.g:282:7: (el1= var_int_or_double_literal | e13= string_literal )
            	        	int alt38 = 2;
            	        	int LA38_0 = input.LA(1);

            	        	if ( ((LA38_0 >= VARIABLE && LA38_0 <= DOUBLE_LITERAL)) )
            	        	{
            	        	    alt38 = 1;
            	        	}
            	        	else if ( (LA38_0 == 57) )
            	        	{
            	        	    alt38 = 2;
            	        	}
            	        	else 
            	        	{
            	        	    NoViableAltException nvae_d38s0 =
            	        	        new NoViableAltException("", 38, 0, input);

            	        	    throw nvae_d38s0;
            	        	}
            	        	switch (alt38) 
            	        	{
            	        	    case 1 :
            	        	        // spinach.g:282:8: el1= var_int_or_double_literal
            	        	        {
            	        	        	PushFollow(FOLLOW_var_int_or_double_literal_in_functioncall1653);
            	        	        	el1 = var_int_or_double_literal();
            	        	        	state.followingStackPointer--;

            	        	        	adaptor.AddChild(root_0, el1.Tree);
            	        	        	retval.ret.setparameters(((el1 != null) ? el1.ret : null));

            	        	        }
            	        	        break;
            	        	    case 2 :
            	        	        // spinach.g:282:75: e13= string_literal
            	        	        {
            	        	        	PushFollow(FOLLOW_string_literal_in_functioncall1659);
            	        	        	e13 = string_literal();
            	        	        	state.followingStackPointer--;

            	        	        	adaptor.AddChild(root_0, e13.Tree);
            	        	        	retval.ret.setparameters(((e13 != null) ? e13.ret : null));

            	        	        }
            	        	        break;

            	        	}

            	        	// spinach.g:282:133: ( ',' (el2= var_int_or_double_literal | e13= string_literal ) )*
            	        	do 
            	        	{
            	        	    int alt40 = 2;
            	        	    int LA40_0 = input.LA(1);

            	        	    if ( (LA40_0 == 30) )
            	        	    {
            	        	        alt40 = 1;
            	        	    }


            	        	    switch (alt40) 
            	        		{
            	        			case 1 :
            	        			    // spinach.g:282:134: ',' (el2= var_int_or_double_literal | e13= string_literal )
            	        			    {
            	        			    	char_literal133=(IToken)Match(input,30,FOLLOW_30_in_functioncall1664); 
            	        			    		char_literal133_tree = (object)adaptor.Create(char_literal133);
            	        			    		adaptor.AddChild(root_0, char_literal133_tree);

            	        			    	// spinach.g:282:138: (el2= var_int_or_double_literal | e13= string_literal )
            	        			    	int alt39 = 2;
            	        			    	int LA39_0 = input.LA(1);

            	        			    	if ( ((LA39_0 >= VARIABLE && LA39_0 <= DOUBLE_LITERAL)) )
            	        			    	{
            	        			    	    alt39 = 1;
            	        			    	}
            	        			    	else if ( (LA39_0 == 57) )
            	        			    	{
            	        			    	    alt39 = 2;
            	        			    	}
            	        			    	else 
            	        			    	{
            	        			    	    NoViableAltException nvae_d39s0 =
            	        			    	        new NoViableAltException("", 39, 0, input);

            	        			    	    throw nvae_d39s0;
            	        			    	}
            	        			    	switch (alt39) 
            	        			    	{
            	        			    	    case 1 :
            	        			    	        // spinach.g:282:139: el2= var_int_or_double_literal
            	        			    	        {
            	        			    	        	PushFollow(FOLLOW_var_int_or_double_literal_in_functioncall1669);
            	        			    	        	el2 = var_int_or_double_literal();
            	        			    	        	state.followingStackPointer--;

            	        			    	        	adaptor.AddChild(root_0, el2.Tree);
            	        			    	        	retval.ret.setparameters(((el2 != null) ? el2.ret : null));

            	        			    	        }
            	        			    	        break;
            	        			    	    case 2 :
            	        			    	        // spinach.g:282:206: e13= string_literal
            	        			    	        {
            	        			    	        	PushFollow(FOLLOW_string_literal_in_functioncall1675);
            	        			    	        	e13 = string_literal();
            	        			    	        	state.followingStackPointer--;

            	        			    	        	adaptor.AddChild(root_0, e13.Tree);
            	        			    	        	retval.ret.setparameters(((e13 != null) ? e13.ret : null));

            	        			    	        }
            	        			    	        break;

            	        			    	}


            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop40;
            	        	    }
            	        	} while (true);

            	        	loop40:
            	        		;	// Stops C# compiler whining that label 'loop40' has no statements


            	        }
            	        break;

            	}

            	char_literal134=(IToken)Match(input,RIGHTBRACE,FOLLOW_RIGHTBRACE_in_functioncall1683); 
            		char_literal134_tree = (object)adaptor.Create(char_literal134);
            		adaptor.AddChild(root_0, char_literal134_tree);

            	END_OF_STATEMENT135=(IToken)Match(input,END_OF_STATEMENT,FOLLOW_END_OF_STATEMENT_in_functioncall1687); 
            		END_OF_STATEMENT135_tree = (object)adaptor.Create(END_OF_STATEMENT135);
            		adaptor.AddChild(root_0, END_OF_STATEMENT135_tree);


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "functioncall"

    public class functiondefination_return : ParserRuleReturnScope
    {
        public FunctionElement ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "functiondefination"
    // spinach.g:290:1: functiondefination returns [FunctionElement ret] : ( ( VARTYPE variable '(' ( (e11= arguments ( ',' e12= arguments )* )? ) ')' '{' ( ( assignment | functioncall | scalarvardec | vectorvardec | matrixvardec | deletionofvar | print | ifelse | functionreturn | parallelfor | forstatement )+ )? '}' ) | 'void' variable '(' ( (e11= arguments ( ',' e12= arguments )* )? ) ')' '{' ( ( assignment | functioncall | scalarvardec | vectorvardec | matrixvardec | deletionofvar | print | ifelse | functionreturn | parallelfor | forstatement )+ )? '}' );
    public spinachParser.functiondefination_return functiondefination() // throws RecognitionException [1]
    {   
        spinachParser.functiondefination_return retval = new spinachParser.functiondefination_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken VARTYPE136 = null;
        IToken char_literal138 = null;
        IToken char_literal139 = null;
        IToken char_literal140 = null;
        IToken char_literal141 = null;
        IToken char_literal153 = null;
        IToken string_literal154 = null;
        IToken char_literal156 = null;
        IToken char_literal157 = null;
        IToken char_literal158 = null;
        IToken char_literal159 = null;
        IToken char_literal171 = null;
        spinachParser.arguments_return e11 = null;

        spinachParser.arguments_return e12 = null;

        spinachParser.variable_return variable137 = null;

        spinachParser.assignment_return assignment142 = null;

        spinachParser.functioncall_return functioncall143 = null;

        spinachParser.scalarvardec_return scalarvardec144 = null;

        spinachParser.vectorvardec_return vectorvardec145 = null;

        spinachParser.matrixvardec_return matrixvardec146 = null;

        spinachParser.deletionofvar_return deletionofvar147 = null;

        spinachParser.print_return print148 = null;

        spinachParser.ifelse_return ifelse149 = null;

        spinachParser.functionreturn_return functionreturn150 = null;

        spinachParser.parallelfor_return parallelfor151 = null;

        spinachParser.forstatement_return forstatement152 = null;

        spinachParser.variable_return variable155 = null;

        spinachParser.assignment_return assignment160 = null;

        spinachParser.functioncall_return functioncall161 = null;

        spinachParser.scalarvardec_return scalarvardec162 = null;

        spinachParser.vectorvardec_return vectorvardec163 = null;

        spinachParser.matrixvardec_return matrixvardec164 = null;

        spinachParser.deletionofvar_return deletionofvar165 = null;

        spinachParser.print_return print166 = null;

        spinachParser.ifelse_return ifelse167 = null;

        spinachParser.functionreturn_return functionreturn168 = null;

        spinachParser.parallelfor_return parallelfor169 = null;

        spinachParser.forstatement_return forstatement170 = null;


        object VARTYPE136_tree=null;
        object char_literal138_tree=null;
        object char_literal139_tree=null;
        object char_literal140_tree=null;
        object char_literal141_tree=null;
        object char_literal153_tree=null;
        object string_literal154_tree=null;
        object char_literal156_tree=null;
        object char_literal157_tree=null;
        object char_literal158_tree=null;
        object char_literal159_tree=null;
        object char_literal171_tree=null;


        retval.ret = new FunctionElement();

        try 
    	{
            // spinach.g:295:1: ( ( VARTYPE variable '(' ( (e11= arguments ( ',' e12= arguments )* )? ) ')' '{' ( ( assignment | functioncall | scalarvardec | vectorvardec | matrixvardec | deletionofvar | print | ifelse | functionreturn | parallelfor | forstatement )+ )? '}' ) | 'void' variable '(' ( (e11= arguments ( ',' e12= arguments )* )? ) ')' '{' ( ( assignment | functioncall | scalarvardec | vectorvardec | matrixvardec | deletionofvar | print | ifelse | functionreturn | parallelfor | forstatement )+ )? '}' )
            int alt50 = 2;
            int LA50_0 = input.LA(1);

            if ( (LA50_0 == VARTYPE) )
            {
                alt50 = 1;
            }
            else if ( (LA50_0 == 42) )
            {
                alt50 = 2;
            }
            else 
            {
                NoViableAltException nvae_d50s0 =
                    new NoViableAltException("", 50, 0, input);

                throw nvae_d50s0;
            }
            switch (alt50) 
            {
                case 1 :
                    // spinach.g:295:3: ( VARTYPE variable '(' ( (e11= arguments ( ',' e12= arguments )* )? ) ')' '{' ( ( assignment | functioncall | scalarvardec | vectorvardec | matrixvardec | deletionofvar | print | ifelse | functionreturn | parallelfor | forstatement )+ )? '}' )
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	// spinach.g:295:3: ( VARTYPE variable '(' ( (e11= arguments ( ',' e12= arguments )* )? ) ')' '{' ( ( assignment | functioncall | scalarvardec | vectorvardec | matrixvardec | deletionofvar | print | ifelse | functionreturn | parallelfor | forstatement )+ )? '}' )
                    	// spinach.g:295:4: VARTYPE variable '(' ( (e11= arguments ( ',' e12= arguments )* )? ) ')' '{' ( ( assignment | functioncall | scalarvardec | vectorvardec | matrixvardec | deletionofvar | print | ifelse | functionreturn | parallelfor | forstatement )+ )? '}'
                    	{
                    		VARTYPE136=(IToken)Match(input,VARTYPE,FOLLOW_VARTYPE_in_functiondefination1714); 
                    			VARTYPE136_tree = (object)adaptor.Create(VARTYPE136);
                    			adaptor.AddChild(root_0, VARTYPE136_tree);

                    		retval.ret.setreturntype(((VARTYPE136 != null) ? VARTYPE136.Text : null));
                    		PushFollow(FOLLOW_variable_in_functiondefination1719);
                    		variable137 = variable();
                    		state.followingStackPointer--;

                    		adaptor.AddChild(root_0, variable137.Tree);
                    		retval.ret.setfunctionname(((variable137 != null) ? variable137.ret : null));
                    		char_literal138=(IToken)Match(input,LEFTBRACE,FOLLOW_LEFTBRACE_in_functiondefination1725); 
                    			char_literal138_tree = (object)adaptor.Create(char_literal138);
                    			adaptor.AddChild(root_0, char_literal138_tree);

                    		// spinach.g:298:2: ( (e11= arguments ( ',' e12= arguments )* )? )
                    		// spinach.g:298:3: (e11= arguments ( ',' e12= arguments )* )?
                    		{
                    			// spinach.g:298:3: (e11= arguments ( ',' e12= arguments )* )?
                    			int alt43 = 2;
                    			int LA43_0 = input.LA(1);

                    			if ( (LA43_0 == VARTYPE || LA43_0 == 27 || LA43_0 == 31) )
                    			{
                    			    alt43 = 1;
                    			}
                    			switch (alt43) 
                    			{
                    			    case 1 :
                    			        // spinach.g:298:4: e11= arguments ( ',' e12= arguments )*
                    			        {
                    			        	PushFollow(FOLLOW_arguments_in_functiondefination1733);
                    			        	e11 = arguments();
                    			        	state.followingStackPointer--;

                    			        	adaptor.AddChild(root_0, e11.Tree);
                    			        	retval.ret.setArguments(((e11 != null) ? e11.ret : null));
                    			        	// spinach.g:298:54: ( ',' e12= arguments )*
                    			        	do 
                    			        	{
                    			        	    int alt42 = 2;
                    			        	    int LA42_0 = input.LA(1);

                    			        	    if ( (LA42_0 == 30) )
                    			        	    {
                    			        	        alt42 = 1;
                    			        	    }


                    			        	    switch (alt42) 
                    			        		{
                    			        			case 1 :
                    			        			    // spinach.g:298:55: ',' e12= arguments
                    			        			    {
                    			        			    	char_literal139=(IToken)Match(input,30,FOLLOW_30_in_functiondefination1736); 
                    			        			    		char_literal139_tree = (object)adaptor.Create(char_literal139);
                    			        			    		adaptor.AddChild(root_0, char_literal139_tree);

                    			        			    	PushFollow(FOLLOW_arguments_in_functiondefination1741);
                    			        			    	e12 = arguments();
                    			        			    	state.followingStackPointer--;

                    			        			    	adaptor.AddChild(root_0, e12.Tree);
                    			        			    	retval.ret.setArguments(((e12 != null) ? e12.ret : null));

                    			        			    }
                    			        			    break;

                    			        			default:
                    			        			    goto loop42;
                    			        	    }
                    			        	} while (true);

                    			        	loop42:
                    			        		;	// Stops C# compiler whining that label 'loop42' has no statements


                    			        }
                    			        break;

                    			}


                    		}

                    		char_literal140=(IToken)Match(input,RIGHTBRACE,FOLLOW_RIGHTBRACE_in_functiondefination1750); 
                    			char_literal140_tree = (object)adaptor.Create(char_literal140);
                    			adaptor.AddChild(root_0, char_literal140_tree);

                    		char_literal141=(IToken)Match(input,LEFTPARANTHESIS,FOLLOW_LEFTPARANTHESIS_in_functiondefination1752); 
                    			char_literal141_tree = (object)adaptor.Create(char_literal141);
                    			adaptor.AddChild(root_0, char_literal141_tree);

                    		// spinach.g:300:5: ( ( assignment | functioncall | scalarvardec | vectorvardec | matrixvardec | deletionofvar | print | ifelse | functionreturn | parallelfor | forstatement )+ )?
                    		int alt45 = 2;
                    		int LA45_0 = input.LA(1);

                    		if ( (LA45_0 == VARIABLE || LA45_0 == VARTYPE || LA45_0 == STRINGTYPE || LA45_0 == 27 || LA45_0 == 31 || (LA45_0 >= 34 && LA45_0 <= 36) || LA45_0 == 39 || LA45_0 == 41 || LA45_0 == 45) )
                    		{
                    		    alt45 = 1;
                    		}
                    		switch (alt45) 
                    		{
                    		    case 1 :
                    		        // spinach.g:300:6: ( assignment | functioncall | scalarvardec | vectorvardec | matrixvardec | deletionofvar | print | ifelse | functionreturn | parallelfor | forstatement )+
                    		        {
                    		        	// spinach.g:300:6: ( assignment | functioncall | scalarvardec | vectorvardec | matrixvardec | deletionofvar | print | ifelse | functionreturn | parallelfor | forstatement )+
                    		        	int cnt44 = 0;
                    		        	do 
                    		        	{
                    		        	    int alt44 = 12;
                    		        	    alt44 = dfa44.Predict(input);
                    		        	    switch (alt44) 
                    		        		{
                    		        			case 1 :
                    		        			    // spinach.g:300:7: assignment
                    		        			    {
                    		        			    	PushFollow(FOLLOW_assignment_in_functiondefination1756);
                    		        			    	assignment142 = assignment();
                    		        			    	state.followingStackPointer--;

                    		        			    	adaptor.AddChild(root_0, assignment142.Tree);
                    		        			    	retval.ret.setBody(((assignment142 != null) ? assignment142.ret : null));

                    		        			    }
                    		        			    break;
                    		        			case 2 :
                    		        			    // spinach.g:300:56: functioncall
                    		        			    {
                    		        			    	PushFollow(FOLLOW_functioncall_in_functiondefination1759);
                    		        			    	functioncall143 = functioncall();
                    		        			    	state.followingStackPointer--;

                    		        			    	adaptor.AddChild(root_0, functioncall143.Tree);
                    		        			    	retval.ret.setBody(((functioncall143 != null) ? functioncall143.ret : null));

                    		        			    }
                    		        			    break;
                    		        			case 3 :
                    		        			    // spinach.g:300:110: scalarvardec
                    		        			    {
                    		        			    	PushFollow(FOLLOW_scalarvardec_in_functiondefination1763);
                    		        			    	scalarvardec144 = scalarvardec();
                    		        			    	state.followingStackPointer--;

                    		        			    	adaptor.AddChild(root_0, scalarvardec144.Tree);
                    		        			    	 retval.ret.setBody(((scalarvardec144 != null) ? scalarvardec144.ret : null));

                    		        			    }
                    		        			    break;
                    		        			case 4 :
                    		        			    // spinach.g:301:5: vectorvardec
                    		        			    {
                    		        			    	PushFollow(FOLLOW_vectorvardec_in_functiondefination1771);
                    		        			    	vectorvardec145 = vectorvardec();
                    		        			    	state.followingStackPointer--;

                    		        			    	adaptor.AddChild(root_0, vectorvardec145.Tree);
                    		        			    	 retval.ret.setBody(((vectorvardec145 != null) ? vectorvardec145.ret : null));

                    		        			    }
                    		        			    break;
                    		        			case 5 :
                    		        			    // spinach.g:302:5: matrixvardec
                    		        			    {
                    		        			    	PushFollow(FOLLOW_matrixvardec_in_functiondefination1779);
                    		        			    	matrixvardec146 = matrixvardec();
                    		        			    	state.followingStackPointer--;

                    		        			    	adaptor.AddChild(root_0, matrixvardec146.Tree);
                    		        			    	 retval.ret.setBody(((matrixvardec146 != null) ? matrixvardec146.ret : null));

                    		        			    }
                    		        			    break;
                    		        			case 6 :
                    		        			    // spinach.g:303:5: deletionofvar
                    		        			    {
                    		        			    	PushFollow(FOLLOW_deletionofvar_in_functiondefination1787);
                    		        			    	deletionofvar147 = deletionofvar();
                    		        			    	state.followingStackPointer--;

                    		        			    	adaptor.AddChild(root_0, deletionofvar147.Tree);
                    		        			    	 retval.ret.setBody(((deletionofvar147 != null) ? deletionofvar147.ret : null));

                    		        			    }
                    		        			    break;
                    		        			case 7 :
                    		        			    // spinach.g:303:64: print
                    		        			    {
                    		        			    	PushFollow(FOLLOW_print_in_functiondefination1793);
                    		        			    	print148 = print();
                    		        			    	state.followingStackPointer--;

                    		        			    	adaptor.AddChild(root_0, print148.Tree);
                    		        			    	 retval.ret.setBody(((print148 != null) ? print148.ret : null)); 

                    		        			    }
                    		        			    break;
                    		        			case 8 :
                    		        			    // spinach.g:304:5: ifelse
                    		        			    {
                    		        			    	PushFollow(FOLLOW_ifelse_in_functiondefination1801);
                    		        			    	ifelse149 = ifelse();
                    		        			    	state.followingStackPointer--;

                    		        			    	adaptor.AddChild(root_0, ifelse149.Tree);
                    		        			    	retval.ret.setBody(((ifelse149 != null) ? ifelse149.ret : null));

                    		        			    }
                    		        			    break;
                    		        			case 9 :
                    		        			    // spinach.g:304:47: functionreturn
                    		        			    {
                    		        			    	PushFollow(FOLLOW_functionreturn_in_functiondefination1805);
                    		        			    	functionreturn150 = functionreturn();
                    		        			    	state.followingStackPointer--;

                    		        			    	adaptor.AddChild(root_0, functionreturn150.Tree);
                    		        			    	retval.ret.setBody(((functionreturn150 != null) ? functionreturn150.ret : null));

                    		        			    }
                    		        			    break;
                    		        			case 10 :
                    		        			    // spinach.g:304:105: parallelfor
                    		        			    {
                    		        			    	PushFollow(FOLLOW_parallelfor_in_functiondefination1809);
                    		        			    	parallelfor151 = parallelfor();
                    		        			    	state.followingStackPointer--;

                    		        			    	adaptor.AddChild(root_0, parallelfor151.Tree);
                    		        			    	retval.ret.setBody(((parallelfor151 != null) ? parallelfor151.ret : null));

                    		        			    }
                    		        			    break;
                    		        			case 11 :
                    		        			    // spinach.g:304:157: forstatement
                    		        			    {
                    		        			    	PushFollow(FOLLOW_forstatement_in_functiondefination1813);
                    		        			    	forstatement152 = forstatement();
                    		        			    	state.followingStackPointer--;

                    		        			    	adaptor.AddChild(root_0, forstatement152.Tree);
                    		        			    	retval.ret.setBody(((forstatement152 != null) ? forstatement152.ret : null));

                    		        			    }
                    		        			    break;

                    		        			default:
                    		        			    if ( cnt44 >= 1 ) goto loop44;
                    		        		            EarlyExitException eee44 =
                    		        		                new EarlyExitException(44, input);
                    		        		            throw eee44;
                    		        	    }
                    		        	    cnt44++;
                    		        	} while (true);

                    		        	loop44:
                    		        		;	// Stops C# compiler whining that label 'loop44' has no statements


                    		        }
                    		        break;

                    		}

                    		char_literal153=(IToken)Match(input,RIGHTPARANTHESIS,FOLLOW_RIGHTPARANTHESIS_in_functiondefination1820); 
                    			char_literal153_tree = (object)adaptor.Create(char_literal153);
                    			adaptor.AddChild(root_0, char_literal153_tree);


                    	}


                    }
                    break;
                case 2 :
                    // spinach.g:305:6: 'void' variable '(' ( (e11= arguments ( ',' e12= arguments )* )? ) ')' '{' ( ( assignment | functioncall | scalarvardec | vectorvardec | matrixvardec | deletionofvar | print | ifelse | functionreturn | parallelfor | forstatement )+ )? '}'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal154=(IToken)Match(input,42,FOLLOW_42_in_functiondefination1823); 
                    		string_literal154_tree = (object)adaptor.Create(string_literal154);
                    		adaptor.AddChild(root_0, string_literal154_tree);

                    	retval.ret.setreturntype("void");
                    	PushFollow(FOLLOW_variable_in_functiondefination1828);
                    	variable155 = variable();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, variable155.Tree);
                    	retval.ret.setfunctionname(((variable155 != null) ? variable155.ret : null));
                    	char_literal156=(IToken)Match(input,LEFTBRACE,FOLLOW_LEFTBRACE_in_functiondefination1834); 
                    		char_literal156_tree = (object)adaptor.Create(char_literal156);
                    		adaptor.AddChild(root_0, char_literal156_tree);

                    	// spinach.g:308:2: ( (e11= arguments ( ',' e12= arguments )* )? )
                    	// spinach.g:308:3: (e11= arguments ( ',' e12= arguments )* )?
                    	{
                    		// spinach.g:308:3: (e11= arguments ( ',' e12= arguments )* )?
                    		int alt47 = 2;
                    		int LA47_0 = input.LA(1);

                    		if ( (LA47_0 == VARTYPE || LA47_0 == 27 || LA47_0 == 31) )
                    		{
                    		    alt47 = 1;
                    		}
                    		switch (alt47) 
                    		{
                    		    case 1 :
                    		        // spinach.g:308:4: e11= arguments ( ',' e12= arguments )*
                    		        {
                    		        	PushFollow(FOLLOW_arguments_in_functiondefination1843);
                    		        	e11 = arguments();
                    		        	state.followingStackPointer--;

                    		        	adaptor.AddChild(root_0, e11.Tree);
                    		        	retval.ret.setArguments(((e11 != null) ? e11.ret : null));
                    		        	// spinach.g:308:55: ( ',' e12= arguments )*
                    		        	do 
                    		        	{
                    		        	    int alt46 = 2;
                    		        	    int LA46_0 = input.LA(1);

                    		        	    if ( (LA46_0 == 30) )
                    		        	    {
                    		        	        alt46 = 1;
                    		        	    }


                    		        	    switch (alt46) 
                    		        		{
                    		        			case 1 :
                    		        			    // spinach.g:308:56: ',' e12= arguments
                    		        			    {
                    		        			    	char_literal157=(IToken)Match(input,30,FOLLOW_30_in_functiondefination1846); 
                    		        			    		char_literal157_tree = (object)adaptor.Create(char_literal157);
                    		        			    		adaptor.AddChild(root_0, char_literal157_tree);

                    		        			    	PushFollow(FOLLOW_arguments_in_functiondefination1850);
                    		        			    	e12 = arguments();
                    		        			    	state.followingStackPointer--;

                    		        			    	adaptor.AddChild(root_0, e12.Tree);
                    		        			    	retval.ret.setArguments(((e12 != null) ? e12.ret : null));

                    		        			    }
                    		        			    break;

                    		        			default:
                    		        			    goto loop46;
                    		        	    }
                    		        	} while (true);

                    		        	loop46:
                    		        		;	// Stops C# compiler whining that label 'loop46' has no statements


                    		        }
                    		        break;

                    		}


                    	}

                    	char_literal158=(IToken)Match(input,RIGHTBRACE,FOLLOW_RIGHTBRACE_in_functiondefination1859); 
                    		char_literal158_tree = (object)adaptor.Create(char_literal158);
                    		adaptor.AddChild(root_0, char_literal158_tree);

                    	char_literal159=(IToken)Match(input,LEFTPARANTHESIS,FOLLOW_LEFTPARANTHESIS_in_functiondefination1861); 
                    		char_literal159_tree = (object)adaptor.Create(char_literal159);
                    		adaptor.AddChild(root_0, char_literal159_tree);

                    	// spinach.g:310:5: ( ( assignment | functioncall | scalarvardec | vectorvardec | matrixvardec | deletionofvar | print | ifelse | functionreturn | parallelfor | forstatement )+ )?
                    	int alt49 = 2;
                    	int LA49_0 = input.LA(1);

                    	if ( (LA49_0 == VARIABLE || LA49_0 == VARTYPE || LA49_0 == STRINGTYPE || LA49_0 == 27 || LA49_0 == 31 || (LA49_0 >= 34 && LA49_0 <= 36) || LA49_0 == 39 || LA49_0 == 41 || LA49_0 == 45) )
                    	{
                    	    alt49 = 1;
                    	}
                    	switch (alt49) 
                    	{
                    	    case 1 :
                    	        // spinach.g:310:6: ( assignment | functioncall | scalarvardec | vectorvardec | matrixvardec | deletionofvar | print | ifelse | functionreturn | parallelfor | forstatement )+
                    	        {
                    	        	// spinach.g:310:6: ( assignment | functioncall | scalarvardec | vectorvardec | matrixvardec | deletionofvar | print | ifelse | functionreturn | parallelfor | forstatement )+
                    	        	int cnt48 = 0;
                    	        	do 
                    	        	{
                    	        	    int alt48 = 12;
                    	        	    alt48 = dfa48.Predict(input);
                    	        	    switch (alt48) 
                    	        		{
                    	        			case 1 :
                    	        			    // spinach.g:310:7: assignment
                    	        			    {
                    	        			    	PushFollow(FOLLOW_assignment_in_functiondefination1865);
                    	        			    	assignment160 = assignment();
                    	        			    	state.followingStackPointer--;

                    	        			    	adaptor.AddChild(root_0, assignment160.Tree);
                    	        			    	retval.ret.setBody(((assignment160 != null) ? assignment160.ret : null));

                    	        			    }
                    	        			    break;
                    	        			case 2 :
                    	        			    // spinach.g:310:56: functioncall
                    	        			    {
                    	        			    	PushFollow(FOLLOW_functioncall_in_functiondefination1868);
                    	        			    	functioncall161 = functioncall();
                    	        			    	state.followingStackPointer--;

                    	        			    	adaptor.AddChild(root_0, functioncall161.Tree);
                    	        			    	retval.ret.setBody(((functioncall161 != null) ? functioncall161.ret : null));

                    	        			    }
                    	        			    break;
                    	        			case 3 :
                    	        			    // spinach.g:310:110: scalarvardec
                    	        			    {
                    	        			    	PushFollow(FOLLOW_scalarvardec_in_functiondefination1872);
                    	        			    	scalarvardec162 = scalarvardec();
                    	        			    	state.followingStackPointer--;

                    	        			    	adaptor.AddChild(root_0, scalarvardec162.Tree);
                    	        			    	 retval.ret.setBody(((scalarvardec162 != null) ? scalarvardec162.ret : null));

                    	        			    }
                    	        			    break;
                    	        			case 4 :
                    	        			    // spinach.g:311:5: vectorvardec
                    	        			    {
                    	        			    	PushFollow(FOLLOW_vectorvardec_in_functiondefination1880);
                    	        			    	vectorvardec163 = vectorvardec();
                    	        			    	state.followingStackPointer--;

                    	        			    	adaptor.AddChild(root_0, vectorvardec163.Tree);
                    	        			    	 retval.ret.setBody(((vectorvardec163 != null) ? vectorvardec163.ret : null));

                    	        			    }
                    	        			    break;
                    	        			case 5 :
                    	        			    // spinach.g:312:5: matrixvardec
                    	        			    {
                    	        			    	PushFollow(FOLLOW_matrixvardec_in_functiondefination1888);
                    	        			    	matrixvardec164 = matrixvardec();
                    	        			    	state.followingStackPointer--;

                    	        			    	adaptor.AddChild(root_0, matrixvardec164.Tree);
                    	        			    	 retval.ret.setBody(((matrixvardec164 != null) ? matrixvardec164.ret : null));

                    	        			    }
                    	        			    break;
                    	        			case 6 :
                    	        			    // spinach.g:313:5: deletionofvar
                    	        			    {
                    	        			    	PushFollow(FOLLOW_deletionofvar_in_functiondefination1896);
                    	        			    	deletionofvar165 = deletionofvar();
                    	        			    	state.followingStackPointer--;

                    	        			    	adaptor.AddChild(root_0, deletionofvar165.Tree);
                    	        			    	 retval.ret.setBody(((deletionofvar165 != null) ? deletionofvar165.ret : null));

                    	        			    }
                    	        			    break;
                    	        			case 7 :
                    	        			    // spinach.g:313:64: print
                    	        			    {
                    	        			    	PushFollow(FOLLOW_print_in_functiondefination1902);
                    	        			    	print166 = print();
                    	        			    	state.followingStackPointer--;

                    	        			    	adaptor.AddChild(root_0, print166.Tree);
                    	        			    	 retval.ret.setBody(((print166 != null) ? print166.ret : null)); 

                    	        			    }
                    	        			    break;
                    	        			case 8 :
                    	        			    // spinach.g:314:5: ifelse
                    	        			    {
                    	        			    	PushFollow(FOLLOW_ifelse_in_functiondefination1910);
                    	        			    	ifelse167 = ifelse();
                    	        			    	state.followingStackPointer--;

                    	        			    	adaptor.AddChild(root_0, ifelse167.Tree);
                    	        			    	retval.ret.setBody(((ifelse167 != null) ? ifelse167.ret : null));

                    	        			    }
                    	        			    break;
                    	        			case 9 :
                    	        			    // spinach.g:314:47: functionreturn
                    	        			    {
                    	        			    	PushFollow(FOLLOW_functionreturn_in_functiondefination1914);
                    	        			    	functionreturn168 = functionreturn();
                    	        			    	state.followingStackPointer--;

                    	        			    	adaptor.AddChild(root_0, functionreturn168.Tree);
                    	        			    	retval.ret.setBody(((functionreturn168 != null) ? functionreturn168.ret : null));

                    	        			    }
                    	        			    break;
                    	        			case 10 :
                    	        			    // spinach.g:314:105: parallelfor
                    	        			    {
                    	        			    	PushFollow(FOLLOW_parallelfor_in_functiondefination1918);
                    	        			    	parallelfor169 = parallelfor();
                    	        			    	state.followingStackPointer--;

                    	        			    	adaptor.AddChild(root_0, parallelfor169.Tree);
                    	        			    	retval.ret.setBody(((parallelfor169 != null) ? parallelfor169.ret : null));

                    	        			    }
                    	        			    break;
                    	        			case 11 :
                    	        			    // spinach.g:314:157: forstatement
                    	        			    {
                    	        			    	PushFollow(FOLLOW_forstatement_in_functiondefination1922);
                    	        			    	forstatement170 = forstatement();
                    	        			    	state.followingStackPointer--;

                    	        			    	adaptor.AddChild(root_0, forstatement170.Tree);
                    	        			    	retval.ret.setBody(((forstatement170 != null) ? forstatement170.ret : null));

                    	        			    }
                    	        			    break;

                    	        			default:
                    	        			    if ( cnt48 >= 1 ) goto loop48;
                    	        		            EarlyExitException eee48 =
                    	        		                new EarlyExitException(48, input);
                    	        		            throw eee48;
                    	        	    }
                    	        	    cnt48++;
                    	        	} while (true);

                    	        	loop48:
                    	        		;	// Stops C# compiler whining that label 'loop48' has no statements


                    	        }
                    	        break;

                    	}

                    	char_literal171=(IToken)Match(input,RIGHTPARANTHESIS,FOLLOW_RIGHTPARANTHESIS_in_functiondefination1929); 
                    		char_literal171_tree = (object)adaptor.Create(char_literal171);
                    		adaptor.AddChild(root_0, char_literal171_tree);


                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "functiondefination"

    public class dotproduct_return : ParserRuleReturnScope
    {
        public DotProductElement ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "dotproduct"
    // spinach.g:319:1: dotproduct returns [DotProductElement ret] : e11= variable 'DOT' e12= variable ;
    public spinachParser.dotproduct_return dotproduct() // throws RecognitionException [1]
    {   
        spinachParser.dotproduct_return retval = new spinachParser.dotproduct_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken string_literal172 = null;
        spinachParser.variable_return e11 = null;

        spinachParser.variable_return e12 = null;


        object string_literal172_tree=null;


        retval.ret = new DotProductElement ();

        try 
    	{
            // spinach.g:323:1: (e11= variable 'DOT' e12= variable )
            // spinach.g:323:3: e11= variable 'DOT' e12= variable
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_variable_in_dotproduct1951);
            	e11 = variable();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, e11.Tree);
            	retval.ret.setLhs(((e11 != null) ? e11.ret : null)); 
            	string_literal172=(IToken)Match(input,43,FOLLOW_43_in_dotproduct1955); 
            		string_literal172_tree = (object)adaptor.Create(string_literal172);
            		adaptor.AddChild(root_0, string_literal172_tree);

            	PushFollow(FOLLOW_variable_in_dotproduct1961);
            	e12 = variable();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, e12.Tree);
            	retval.ret.setRhs(((e12 != null) ? e12.ret : null)); 

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "dotproduct"

    public class matrixtranspose_return : ParserRuleReturnScope
    {
        public MatrixTranspose ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "matrixtranspose"
    // spinach.g:325:1: matrixtranspose returns [MatrixTranspose ret] : 'T' LEFTBRACE variable ')' ;
    public spinachParser.matrixtranspose_return matrixtranspose() // throws RecognitionException [1]
    {   
        spinachParser.matrixtranspose_return retval = new spinachParser.matrixtranspose_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken char_literal173 = null;
        IToken LEFTBRACE174 = null;
        IToken char_literal176 = null;
        spinachParser.variable_return variable175 = null;


        object char_literal173_tree=null;
        object LEFTBRACE174_tree=null;
        object char_literal176_tree=null;


        retval.ret = new MatrixTranspose();

        try 
    	{
            // spinach.g:330:1: ( 'T' LEFTBRACE variable ')' )
            // spinach.g:330:3: 'T' LEFTBRACE variable ')'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	char_literal173=(IToken)Match(input,44,FOLLOW_44_in_matrixtranspose1980); 
            		char_literal173_tree = (object)adaptor.Create(char_literal173);
            		adaptor.AddChild(root_0, char_literal173_tree);

            	LEFTBRACE174=(IToken)Match(input,LEFTBRACE,FOLLOW_LEFTBRACE_in_matrixtranspose1982); 
            		LEFTBRACE174_tree = (object)adaptor.Create(LEFTBRACE174);
            		adaptor.AddChild(root_0, LEFTBRACE174_tree);

            	PushFollow(FOLLOW_variable_in_matrixtranspose1984);
            	variable175 = variable();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, variable175.Tree);
            	retval.ret.setvariable(((variable175 != null) ? variable175.ret : null)); 
            	char_literal176=(IToken)Match(input,RIGHTBRACE,FOLLOW_RIGHTBRACE_in_matrixtranspose1987); 
            		char_literal176_tree = (object)adaptor.Create(char_literal176);
            		adaptor.AddChild(root_0, char_literal176_tree);


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "matrixtranspose"

    public class matrixreference_return : ParserRuleReturnScope
    {
        public MatrixReference ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "matrixreference"
    // spinach.g:333:1: matrixreference returns [MatrixReference ret] : 'matrix' '<' (el1= VARTYPE '>' el2= variable ) ;
    public spinachParser.matrixreference_return matrixreference() // throws RecognitionException [1]
    {   
        spinachParser.matrixreference_return retval = new spinachParser.matrixreference_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken el1 = null;
        IToken string_literal177 = null;
        IToken char_literal178 = null;
        IToken char_literal179 = null;
        spinachParser.variable_return el2 = null;


        object el1_tree=null;
        object string_literal177_tree=null;
        object char_literal178_tree=null;
        object char_literal179_tree=null;

         retval.ret = new MatrixReference();

        try 
    	{
            // spinach.g:336:1: ( 'matrix' '<' (el1= VARTYPE '>' el2= variable ) )
            // spinach.g:336:2: 'matrix' '<' (el1= VARTYPE '>' el2= variable )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal177=(IToken)Match(input,27,FOLLOW_27_in_matrixreference2003); 
            		string_literal177_tree = (object)adaptor.Create(string_literal177);
            		adaptor.AddChild(root_0, string_literal177_tree);

            	char_literal178=(IToken)Match(input,LESSTHANEXPRESSION,FOLLOW_LESSTHANEXPRESSION_in_matrixreference2005); 
            		char_literal178_tree = (object)adaptor.Create(char_literal178);
            		adaptor.AddChild(root_0, char_literal178_tree);

            	// spinach.g:336:15: (el1= VARTYPE '>' el2= variable )
            	// spinach.g:336:16: el1= VARTYPE '>' el2= variable
            	{
            		el1=(IToken)Match(input,VARTYPE,FOLLOW_VARTYPE_in_matrixreference2010); 
            			el1_tree = (object)adaptor.Create(el1);
            			adaptor.AddChild(root_0, el1_tree);

            		retval.ret.settype(((el1 != null) ? el1.Text : null));
            		char_literal179=(IToken)Match(input,GREATERTHANEXPRESSION,FOLLOW_GREATERTHANEXPRESSION_in_matrixreference2012); 
            			char_literal179_tree = (object)adaptor.Create(char_literal179);
            			adaptor.AddChild(root_0, char_literal179_tree);

            		PushFollow(FOLLOW_variable_in_matrixreference2016);
            		el2 = variable();
            		state.followingStackPointer--;

            		adaptor.AddChild(root_0, el2.Tree);
            		retval.ret.setvariable(((el2 != null) ? el2.ret : null));

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "matrixreference"

    public class vectorreference_return : ParserRuleReturnScope
    {
        public VectorReference ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "vectorreference"
    // spinach.g:339:1: vectorreference returns [VectorReference ret] : 'vector' '<' (el1= VARTYPE '>' el2= variable ) ;
    public spinachParser.vectorreference_return vectorreference() // throws RecognitionException [1]
    {   
        spinachParser.vectorreference_return retval = new spinachParser.vectorreference_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken el1 = null;
        IToken string_literal180 = null;
        IToken char_literal181 = null;
        IToken char_literal182 = null;
        spinachParser.variable_return el2 = null;


        object el1_tree=null;
        object string_literal180_tree=null;
        object char_literal181_tree=null;
        object char_literal182_tree=null;

         retval.ret = new VectorReference();

        try 
    	{
            // spinach.g:342:1: ( 'vector' '<' (el1= VARTYPE '>' el2= variable ) )
            // spinach.g:342:2: 'vector' '<' (el1= VARTYPE '>' el2= variable )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal180=(IToken)Match(input,31,FOLLOW_31_in_vectorreference2035); 
            		string_literal180_tree = (object)adaptor.Create(string_literal180);
            		adaptor.AddChild(root_0, string_literal180_tree);

            	char_literal181=(IToken)Match(input,LESSTHANEXPRESSION,FOLLOW_LESSTHANEXPRESSION_in_vectorreference2037); 
            		char_literal181_tree = (object)adaptor.Create(char_literal181);
            		adaptor.AddChild(root_0, char_literal181_tree);

            	// spinach.g:342:15: (el1= VARTYPE '>' el2= variable )
            	// spinach.g:342:16: el1= VARTYPE '>' el2= variable
            	{
            		el1=(IToken)Match(input,VARTYPE,FOLLOW_VARTYPE_in_vectorreference2042); 
            			el1_tree = (object)adaptor.Create(el1);
            			adaptor.AddChild(root_0, el1_tree);

            		retval.ret.settype(((el1 != null) ? el1.Text : null));
            		char_literal182=(IToken)Match(input,GREATERTHANEXPRESSION,FOLLOW_GREATERTHANEXPRESSION_in_vectorreference2044); 
            			char_literal182_tree = (object)adaptor.Create(char_literal182);
            			adaptor.AddChild(root_0, char_literal182_tree);

            		PushFollow(FOLLOW_variable_in_vectorreference2048);
            		el2 = variable();
            		state.followingStackPointer--;

            		adaptor.AddChild(root_0, el2.Tree);
            		retval.ret.setvariable(((el2 != null) ? el2.ret : null));

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "vectorreference"

    public class arguments_return : ParserRuleReturnScope
    {
        public Element ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "arguments"
    // spinach.g:344:1: arguments returns [Element ret] : ( scalarargument | matrixreference | vectorreference ) ;
    public spinachParser.arguments_return arguments() // throws RecognitionException [1]
    {   
        spinachParser.arguments_return retval = new spinachParser.arguments_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        spinachParser.scalarargument_return scalarargument183 = null;

        spinachParser.matrixreference_return matrixreference184 = null;

        spinachParser.vectorreference_return vectorreference185 = null;



        try 
    	{
            // spinach.g:345:1: ( ( scalarargument | matrixreference | vectorreference ) )
            // spinach.g:345:3: ( scalarargument | matrixreference | vectorreference )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// spinach.g:345:3: ( scalarargument | matrixreference | vectorreference )
            	int alt51 = 3;
            	switch ( input.LA(1) ) 
            	{
            	case VARTYPE:
            		{
            	    alt51 = 1;
            	    }
            	    break;
            	case 27:
            		{
            	    alt51 = 2;
            	    }
            	    break;
            	case 31:
            		{
            	    alt51 = 3;
            	    }
            	    break;
            		default:
            		    NoViableAltException nvae_d51s0 =
            		        new NoViableAltException("", 51, 0, input);

            		    throw nvae_d51s0;
            	}

            	switch (alt51) 
            	{
            	    case 1 :
            	        // spinach.g:345:4: scalarargument
            	        {
            	        	PushFollow(FOLLOW_scalarargument_in_arguments2064);
            	        	scalarargument183 = scalarargument();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, scalarargument183.Tree);
            	        	 retval.ret = ((scalarargument183 != null) ? scalarargument183.ret : null); 

            	        }
            	        break;
            	    case 2 :
            	        // spinach.g:346:3: matrixreference
            	        {
            	        	PushFollow(FOLLOW_matrixreference_in_arguments2070);
            	        	matrixreference184 = matrixreference();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, matrixreference184.Tree);
            	        	retval.ret = ((matrixreference184 != null) ? matrixreference184.ret : null); 

            	        }
            	        break;
            	    case 3 :
            	        // spinach.g:347:3: vectorreference
            	        {
            	        	PushFollow(FOLLOW_vectorreference_in_arguments2076);
            	        	vectorreference185 = vectorreference();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, vectorreference185.Tree);
            	        	retval.ret = ((vectorreference185 != null) ? vectorreference185.ret : null);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "arguments"

    public class scalarargument_return : ParserRuleReturnScope
    {
        public ScalarArgument ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "scalarargument"
    // spinach.g:358:1: scalarargument returns [ScalarArgument ret] : ( (e11= VARTYPE ) e12= variable ) ;
    public spinachParser.scalarargument_return scalarargument() // throws RecognitionException [1]
    {   
        spinachParser.scalarargument_return retval = new spinachParser.scalarargument_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken e11 = null;
        spinachParser.variable_return e12 = null;


        object e11_tree=null;

        retval.ret = new ScalarArgument();

        try 
    	{
            // spinach.g:360:2: ( ( (e11= VARTYPE ) e12= variable ) )
            // spinach.g:361:1: ( (e11= VARTYPE ) e12= variable )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// spinach.g:361:1: ( (e11= VARTYPE ) e12= variable )
            	// spinach.g:361:2: (e11= VARTYPE ) e12= variable
            	{
            		// spinach.g:361:2: (e11= VARTYPE )
            		// spinach.g:361:3: e11= VARTYPE
            		{
            			e11=(IToken)Match(input,VARTYPE,FOLLOW_VARTYPE_in_scalarargument2108); 
            				e11_tree = (object)adaptor.Create(e11);
            				adaptor.AddChild(root_0, e11_tree);

            			retval.ret.settype(((e11 != null) ? e11.Text : null));

            		}

            		PushFollow(FOLLOW_variable_in_scalarargument2115);
            		e12 = variable();
            		state.followingStackPointer--;

            		adaptor.AddChild(root_0, e12.Tree);
            		retval.ret.setvariable(((e12 != null) ? e12.ret : null)); 

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "scalarargument"

    public class functionreturn_return : ParserRuleReturnScope
    {
        public ReturnElement ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "functionreturn"
    // spinach.g:373:1: functionreturn returns [ReturnElement ret] : 'return' ( var_int_or_double_literal ) END_OF_STATEMENT ;
    public spinachParser.functionreturn_return functionreturn() // throws RecognitionException [1]
    {   
        spinachParser.functionreturn_return retval = new spinachParser.functionreturn_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken string_literal186 = null;
        IToken END_OF_STATEMENT188 = null;
        spinachParser.var_int_or_double_literal_return var_int_or_double_literal187 = null;


        object string_literal186_tree=null;
        object END_OF_STATEMENT188_tree=null;


        retval.ret = new ReturnElement();

        try 
    	{
            // spinach.g:377:1: ( 'return' ( var_int_or_double_literal ) END_OF_STATEMENT )
            // spinach.g:377:2: 'return' ( var_int_or_double_literal ) END_OF_STATEMENT
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal186=(IToken)Match(input,45,FOLLOW_45_in_functionreturn2142); 
            		string_literal186_tree = (object)adaptor.Create(string_literal186);
            		adaptor.AddChild(root_0, string_literal186_tree);

            	// spinach.g:377:11: ( var_int_or_double_literal )
            	// spinach.g:377:12: var_int_or_double_literal
            	{
            		PushFollow(FOLLOW_var_int_or_double_literal_in_functionreturn2145);
            		var_int_or_double_literal187 = var_int_or_double_literal();
            		state.followingStackPointer--;

            		adaptor.AddChild(root_0, var_int_or_double_literal187.Tree);
            		retval.ret.setreturnvariable(((var_int_or_double_literal187 != null) ? var_int_or_double_literal187.ret : null));

            	}

            	END_OF_STATEMENT188=(IToken)Match(input,END_OF_STATEMENT,FOLLOW_END_OF_STATEMENT_in_functionreturn2149); 
            		END_OF_STATEMENT188_tree = (object)adaptor.Create(END_OF_STATEMENT188);
            		adaptor.AddChild(root_0, END_OF_STATEMENT188_tree);


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "functionreturn"

    public class plotfunctions_return : ParserRuleReturnScope
    {
        public PlotFunctionElement ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "plotfunctions"
    // spinach.g:383:1: plotfunctions returns [PlotFunctionElement ret] : ( ( 'subPlot' '(' (el1= int_literal ) ',' (vll1= variable ) ',' (vll2= string_literal ) ',' ( ( '1D' ) | ( '2D' ) | ( '3D' ( ',' (el3= int_literal ) )? ) ) ')' END_OF_STATEMENT ) | ( 'plot' '(' (vll3= variable ) ',' (vll4= string_literal ) ',' ( ( '1D' ) | ( '2D' ) | ( '3D' ( ',' (el3= int_literal ) )? ) ) ')' END_OF_STATEMENT ) | ( 'resetPlot' '(' ')' END_OF_STATEMENT ) | 'setPlotAxis' '(' e112= double_literal ( ')' END_OF_STATEMENT | ',' e113= double_literal ( ')' END_OF_STATEMENT | ',' e114= double_literal ')' END_OF_STATEMENT ) ) | 'setAxisTitle' '(' v112= string_literal ( ')' END_OF_STATEMENT | ',' v113= string_literal ( ')' END_OF_STATEMENT | ',' v114= string_literal ')' END_OF_STATEMENT ) ) | ( 'setScaleMode(' SCALEMODE ')' END_OF_STATEMENT ) );
    public spinachParser.plotfunctions_return plotfunctions() // throws RecognitionException [1]
    {   
        spinachParser.plotfunctions_return retval = new spinachParser.plotfunctions_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken string_literal189 = null;
        IToken char_literal190 = null;
        IToken char_literal191 = null;
        IToken char_literal192 = null;
        IToken char_literal193 = null;
        IToken string_literal194 = null;
        IToken string_literal195 = null;
        IToken string_literal196 = null;
        IToken char_literal197 = null;
        IToken char_literal198 = null;
        IToken END_OF_STATEMENT199 = null;
        IToken string_literal200 = null;
        IToken char_literal201 = null;
        IToken char_literal202 = null;
        IToken char_literal203 = null;
        IToken string_literal204 = null;
        IToken string_literal205 = null;
        IToken string_literal206 = null;
        IToken char_literal207 = null;
        IToken char_literal208 = null;
        IToken END_OF_STATEMENT209 = null;
        IToken string_literal210 = null;
        IToken char_literal211 = null;
        IToken char_literal212 = null;
        IToken END_OF_STATEMENT213 = null;
        IToken string_literal214 = null;
        IToken char_literal215 = null;
        IToken char_literal216 = null;
        IToken END_OF_STATEMENT217 = null;
        IToken char_literal218 = null;
        IToken char_literal219 = null;
        IToken END_OF_STATEMENT220 = null;
        IToken char_literal221 = null;
        IToken char_literal222 = null;
        IToken END_OF_STATEMENT223 = null;
        IToken string_literal224 = null;
        IToken char_literal225 = null;
        IToken char_literal226 = null;
        IToken END_OF_STATEMENT227 = null;
        IToken char_literal228 = null;
        IToken char_literal229 = null;
        IToken END_OF_STATEMENT230 = null;
        IToken char_literal231 = null;
        IToken char_literal232 = null;
        IToken END_OF_STATEMENT233 = null;
        IToken string_literal234 = null;
        IToken SCALEMODE235 = null;
        IToken char_literal236 = null;
        IToken END_OF_STATEMENT237 = null;
        spinachParser.int_literal_return el1 = null;

        spinachParser.variable_return vll1 = null;

        spinachParser.string_literal_return vll2 = null;

        spinachParser.int_literal_return el3 = null;

        spinachParser.variable_return vll3 = null;

        spinachParser.string_literal_return vll4 = null;

        spinachParser.double_literal_return e112 = null;

        spinachParser.double_literal_return e113 = null;

        spinachParser.double_literal_return e114 = null;

        spinachParser.string_literal_return v112 = null;

        spinachParser.string_literal_return v113 = null;

        spinachParser.string_literal_return v114 = null;


        object string_literal189_tree=null;
        object char_literal190_tree=null;
        object char_literal191_tree=null;
        object char_literal192_tree=null;
        object char_literal193_tree=null;
        object string_literal194_tree=null;
        object string_literal195_tree=null;
        object string_literal196_tree=null;
        object char_literal197_tree=null;
        object char_literal198_tree=null;
        object END_OF_STATEMENT199_tree=null;
        object string_literal200_tree=null;
        object char_literal201_tree=null;
        object char_literal202_tree=null;
        object char_literal203_tree=null;
        object string_literal204_tree=null;
        object string_literal205_tree=null;
        object string_literal206_tree=null;
        object char_literal207_tree=null;
        object char_literal208_tree=null;
        object END_OF_STATEMENT209_tree=null;
        object string_literal210_tree=null;
        object char_literal211_tree=null;
        object char_literal212_tree=null;
        object END_OF_STATEMENT213_tree=null;
        object string_literal214_tree=null;
        object char_literal215_tree=null;
        object char_literal216_tree=null;
        object END_OF_STATEMENT217_tree=null;
        object char_literal218_tree=null;
        object char_literal219_tree=null;
        object END_OF_STATEMENT220_tree=null;
        object char_literal221_tree=null;
        object char_literal222_tree=null;
        object END_OF_STATEMENT223_tree=null;
        object string_literal224_tree=null;
        object char_literal225_tree=null;
        object char_literal226_tree=null;
        object END_OF_STATEMENT227_tree=null;
        object char_literal228_tree=null;
        object char_literal229_tree=null;
        object END_OF_STATEMENT230_tree=null;
        object char_literal231_tree=null;
        object char_literal232_tree=null;
        object END_OF_STATEMENT233_tree=null;
        object string_literal234_tree=null;
        object SCALEMODE235_tree=null;
        object char_literal236_tree=null;
        object END_OF_STATEMENT237_tree=null;

         retval.ret = new PlotFunctionElement();

        try 
    	{
            // spinach.g:386:1: ( ( 'subPlot' '(' (el1= int_literal ) ',' (vll1= variable ) ',' (vll2= string_literal ) ',' ( ( '1D' ) | ( '2D' ) | ( '3D' ( ',' (el3= int_literal ) )? ) ) ')' END_OF_STATEMENT ) | ( 'plot' '(' (vll3= variable ) ',' (vll4= string_literal ) ',' ( ( '1D' ) | ( '2D' ) | ( '3D' ( ',' (el3= int_literal ) )? ) ) ')' END_OF_STATEMENT ) | ( 'resetPlot' '(' ')' END_OF_STATEMENT ) | 'setPlotAxis' '(' e112= double_literal ( ')' END_OF_STATEMENT | ',' e113= double_literal ( ')' END_OF_STATEMENT | ',' e114= double_literal ')' END_OF_STATEMENT ) ) | 'setAxisTitle' '(' v112= string_literal ( ')' END_OF_STATEMENT | ',' v113= string_literal ( ')' END_OF_STATEMENT | ',' v114= string_literal ')' END_OF_STATEMENT ) ) | ( 'setScaleMode(' SCALEMODE ')' END_OF_STATEMENT ) )
            int alt60 = 6;
            switch ( input.LA(1) ) 
            {
            case 46:
            	{
                alt60 = 1;
                }
                break;
            case 50:
            	{
                alt60 = 2;
                }
                break;
            case 51:
            	{
                alt60 = 3;
                }
                break;
            case 52:
            	{
                alt60 = 4;
                }
                break;
            case 53:
            	{
                alt60 = 5;
                }
                break;
            case 54:
            	{
                alt60 = 6;
                }
                break;
            	default:
            	    NoViableAltException nvae_d60s0 =
            	        new NoViableAltException("", 60, 0, input);

            	    throw nvae_d60s0;
            }

            switch (alt60) 
            {
                case 1 :
                    // spinach.g:387:2: ( 'subPlot' '(' (el1= int_literal ) ',' (vll1= variable ) ',' (vll2= string_literal ) ',' ( ( '1D' ) | ( '2D' ) | ( '3D' ( ',' (el3= int_literal ) )? ) ) ')' END_OF_STATEMENT )
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	// spinach.g:387:2: ( 'subPlot' '(' (el1= int_literal ) ',' (vll1= variable ) ',' (vll2= string_literal ) ',' ( ( '1D' ) | ( '2D' ) | ( '3D' ( ',' (el3= int_literal ) )? ) ) ')' END_OF_STATEMENT )
                    	// spinach.g:387:3: 'subPlot' '(' (el1= int_literal ) ',' (vll1= variable ) ',' (vll2= string_literal ) ',' ( ( '1D' ) | ( '2D' ) | ( '3D' ( ',' (el3= int_literal ) )? ) ) ')' END_OF_STATEMENT
                    	{
                    		string_literal189=(IToken)Match(input,46,FOLLOW_46_in_plotfunctions2174); 
                    			string_literal189_tree = (object)adaptor.Create(string_literal189);
                    			adaptor.AddChild(root_0, string_literal189_tree);

                    		retval.ret.setPlotFunction("subPlot");
                    		char_literal190=(IToken)Match(input,LEFTBRACE,FOLLOW_LEFTBRACE_in_plotfunctions2177); 
                    			char_literal190_tree = (object)adaptor.Create(char_literal190);
                    			adaptor.AddChild(root_0, char_literal190_tree);

                    		// spinach.g:388:1: (el1= int_literal )
                    		// spinach.g:388:2: el1= int_literal
                    		{
                    			PushFollow(FOLLOW_int_literal_in_plotfunctions2184);
                    			el1 = int_literal();
                    			state.followingStackPointer--;

                    			adaptor.AddChild(root_0, el1.Tree);
                    			retval.ret.setPeno(((el1 != null) ? el1.ret : null));

                    		}

                    		char_literal191=(IToken)Match(input,30,FOLLOW_30_in_plotfunctions2189); 
                    			char_literal191_tree = (object)adaptor.Create(char_literal191);
                    			adaptor.AddChild(root_0, char_literal191_tree);

                    		// spinach.g:389:1: (vll1= variable )
                    		// spinach.g:389:2: vll1= variable
                    		{
                    			PushFollow(FOLLOW_variable_in_plotfunctions2196);
                    			vll1 = variable();
                    			state.followingStackPointer--;

                    			adaptor.AddChild(root_0, vll1.Tree);
                    			retval.ret.setData(((vll1 != null) ? vll1.ret : null));

                    		}

                    		char_literal192=(IToken)Match(input,30,FOLLOW_30_in_plotfunctions2201); 
                    			char_literal192_tree = (object)adaptor.Create(char_literal192);
                    			adaptor.AddChild(root_0, char_literal192_tree);

                    		// spinach.g:390:1: (vll2= string_literal )
                    		// spinach.g:390:2: vll2= string_literal
                    		{
                    			PushFollow(FOLLOW_string_literal_in_plotfunctions2208);
                    			vll2 = string_literal();
                    			state.followingStackPointer--;

                    			adaptor.AddChild(root_0, vll2.Tree);
                    			retval.ret.setTitle(((vll2 != null) ? vll2.ret : null));

                    		}

                    		char_literal193=(IToken)Match(input,30,FOLLOW_30_in_plotfunctions2212); 
                    			char_literal193_tree = (object)adaptor.Create(char_literal193);
                    			adaptor.AddChild(root_0, char_literal193_tree);

                    		// spinach.g:391:1: ( ( '1D' ) | ( '2D' ) | ( '3D' ( ',' (el3= int_literal ) )? ) )
                    		int alt53 = 3;
                    		switch ( input.LA(1) ) 
                    		{
                    		case 47:
                    			{
                    		    alt53 = 1;
                    		    }
                    		    break;
                    		case 48:
                    			{
                    		    alt53 = 2;
                    		    }
                    		    break;
                    		case 49:
                    			{
                    		    alt53 = 3;
                    		    }
                    		    break;
                    			default:
                    			    NoViableAltException nvae_d53s0 =
                    			        new NoViableAltException("", 53, 0, input);

                    			    throw nvae_d53s0;
                    		}

                    		switch (alt53) 
                    		{
                    		    case 1 :
                    		        // spinach.g:391:2: ( '1D' )
                    		        {
                    		        	// spinach.g:391:2: ( '1D' )
                    		        	// spinach.g:391:3: '1D'
                    		        	{
                    		        		string_literal194=(IToken)Match(input,47,FOLLOW_47_in_plotfunctions2216); 
                    		        			string_literal194_tree = (object)adaptor.Create(string_literal194);
                    		        			adaptor.AddChild(root_0, string_literal194_tree);

                    		        		retval.ret.setPlotType("1D");

                    		        	}


                    		        }
                    		        break;
                    		    case 2 :
                    		        // spinach.g:391:40: ( '2D' )
                    		        {
                    		        	// spinach.g:391:40: ( '2D' )
                    		        	// spinach.g:391:41: '2D'
                    		        	{
                    		        		string_literal195=(IToken)Match(input,48,FOLLOW_48_in_plotfunctions2221); 
                    		        			string_literal195_tree = (object)adaptor.Create(string_literal195);
                    		        			adaptor.AddChild(root_0, string_literal195_tree);

                    		        		retval.ret.setPlotType("2D");

                    		        	}


                    		        }
                    		        break;
                    		    case 3 :
                    		        // spinach.g:391:78: ( '3D' ( ',' (el3= int_literal ) )? )
                    		        {
                    		        	// spinach.g:391:78: ( '3D' ( ',' (el3= int_literal ) )? )
                    		        	// spinach.g:391:79: '3D' ( ',' (el3= int_literal ) )?
                    		        	{
                    		        		string_literal196=(IToken)Match(input,49,FOLLOW_49_in_plotfunctions2226); 
                    		        			string_literal196_tree = (object)adaptor.Create(string_literal196);
                    		        			adaptor.AddChild(root_0, string_literal196_tree);

                    		        		retval.ret.setPlotType("3D");
                    		        		// spinach.g:391:114: ( ',' (el3= int_literal ) )?
                    		        		int alt52 = 2;
                    		        		int LA52_0 = input.LA(1);

                    		        		if ( (LA52_0 == 30) )
                    		        		{
                    		        		    alt52 = 1;
                    		        		}
                    		        		switch (alt52) 
                    		        		{
                    		        		    case 1 :
                    		        		        // spinach.g:391:115: ',' (el3= int_literal )
                    		        		        {
                    		        		        	char_literal197=(IToken)Match(input,30,FOLLOW_30_in_plotfunctions2229); 
                    		        		        		char_literal197_tree = (object)adaptor.Create(char_literal197);
                    		        		        		adaptor.AddChild(root_0, char_literal197_tree);

                    		        		        	// spinach.g:391:118: (el3= int_literal )
                    		        		        	// spinach.g:391:119: el3= int_literal
                    		        		        	{
                    		        		        		PushFollow(FOLLOW_int_literal_in_plotfunctions2235);
                    		        		        		el3 = int_literal();
                    		        		        		state.followingStackPointer--;

                    		        		        		adaptor.AddChild(root_0, el3.Tree);
                    		        		        		retval.ret.setMode(((el3 != null) ? el3.ret : null));

                    		        		        	}


                    		        		        }
                    		        		        break;

                    		        		}


                    		        	}


                    		        }
                    		        break;

                    		}

                    		char_literal198=(IToken)Match(input,RIGHTBRACE,FOLLOW_RIGHTBRACE_in_plotfunctions2243); 
                    			char_literal198_tree = (object)adaptor.Create(char_literal198);
                    			adaptor.AddChild(root_0, char_literal198_tree);

                    		END_OF_STATEMENT199=(IToken)Match(input,END_OF_STATEMENT,FOLLOW_END_OF_STATEMENT_in_plotfunctions2244); 
                    			END_OF_STATEMENT199_tree = (object)adaptor.Create(END_OF_STATEMENT199);
                    			adaptor.AddChild(root_0, END_OF_STATEMENT199_tree);


                    	}


                    }
                    break;
                case 2 :
                    // spinach.g:393:3: ( 'plot' '(' (vll3= variable ) ',' (vll4= string_literal ) ',' ( ( '1D' ) | ( '2D' ) | ( '3D' ( ',' (el3= int_literal ) )? ) ) ')' END_OF_STATEMENT )
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	// spinach.g:393:3: ( 'plot' '(' (vll3= variable ) ',' (vll4= string_literal ) ',' ( ( '1D' ) | ( '2D' ) | ( '3D' ( ',' (el3= int_literal ) )? ) ) ')' END_OF_STATEMENT )
                    	// spinach.g:393:4: 'plot' '(' (vll3= variable ) ',' (vll4= string_literal ) ',' ( ( '1D' ) | ( '2D' ) | ( '3D' ( ',' (el3= int_literal ) )? ) ) ')' END_OF_STATEMENT
                    	{
                    		string_literal200=(IToken)Match(input,50,FOLLOW_50_in_plotfunctions2250); 
                    			string_literal200_tree = (object)adaptor.Create(string_literal200);
                    			adaptor.AddChild(root_0, string_literal200_tree);

                    		retval.ret.setPlotFunction("plot");
                    		char_literal201=(IToken)Match(input,LEFTBRACE,FOLLOW_LEFTBRACE_in_plotfunctions2253); 
                    			char_literal201_tree = (object)adaptor.Create(char_literal201);
                    			adaptor.AddChild(root_0, char_literal201_tree);

                    		// spinach.g:394:1: (vll3= variable )
                    		// spinach.g:394:2: vll3= variable
                    		{
                    			PushFollow(FOLLOW_variable_in_plotfunctions2259);
                    			vll3 = variable();
                    			state.followingStackPointer--;

                    			adaptor.AddChild(root_0, vll3.Tree);
                    			retval.ret.setData(((vll3 != null) ? vll3.ret : null));

                    		}

                    		char_literal202=(IToken)Match(input,30,FOLLOW_30_in_plotfunctions2264); 
                    			char_literal202_tree = (object)adaptor.Create(char_literal202);
                    			adaptor.AddChild(root_0, char_literal202_tree);

                    		// spinach.g:395:1: (vll4= string_literal )
                    		// spinach.g:395:2: vll4= string_literal
                    		{
                    			PushFollow(FOLLOW_string_literal_in_plotfunctions2270);
                    			vll4 = string_literal();
                    			state.followingStackPointer--;

                    			adaptor.AddChild(root_0, vll4.Tree);
                    			retval.ret.setTitle(((vll4 != null) ? vll4.ret : null));

                    		}

                    		char_literal203=(IToken)Match(input,30,FOLLOW_30_in_plotfunctions2274); 
                    			char_literal203_tree = (object)adaptor.Create(char_literal203);
                    			adaptor.AddChild(root_0, char_literal203_tree);

                    		// spinach.g:396:1: ( ( '1D' ) | ( '2D' ) | ( '3D' ( ',' (el3= int_literal ) )? ) )
                    		int alt55 = 3;
                    		switch ( input.LA(1) ) 
                    		{
                    		case 47:
                    			{
                    		    alt55 = 1;
                    		    }
                    		    break;
                    		case 48:
                    			{
                    		    alt55 = 2;
                    		    }
                    		    break;
                    		case 49:
                    			{
                    		    alt55 = 3;
                    		    }
                    		    break;
                    			default:
                    			    NoViableAltException nvae_d55s0 =
                    			        new NoViableAltException("", 55, 0, input);

                    			    throw nvae_d55s0;
                    		}

                    		switch (alt55) 
                    		{
                    		    case 1 :
                    		        // spinach.g:396:2: ( '1D' )
                    		        {
                    		        	// spinach.g:396:2: ( '1D' )
                    		        	// spinach.g:396:3: '1D'
                    		        	{
                    		        		string_literal204=(IToken)Match(input,47,FOLLOW_47_in_plotfunctions2278); 
                    		        			string_literal204_tree = (object)adaptor.Create(string_literal204);
                    		        			adaptor.AddChild(root_0, string_literal204_tree);

                    		        		retval.ret.setPlotType("1D");

                    		        	}


                    		        }
                    		        break;
                    		    case 2 :
                    		        // spinach.g:396:40: ( '2D' )
                    		        {
                    		        	// spinach.g:396:40: ( '2D' )
                    		        	// spinach.g:396:41: '2D'
                    		        	{
                    		        		string_literal205=(IToken)Match(input,48,FOLLOW_48_in_plotfunctions2283); 
                    		        			string_literal205_tree = (object)adaptor.Create(string_literal205);
                    		        			adaptor.AddChild(root_0, string_literal205_tree);

                    		        		retval.ret.setPlotType("2D");

                    		        	}


                    		        }
                    		        break;
                    		    case 3 :
                    		        // spinach.g:396:78: ( '3D' ( ',' (el3= int_literal ) )? )
                    		        {
                    		        	// spinach.g:396:78: ( '3D' ( ',' (el3= int_literal ) )? )
                    		        	// spinach.g:396:79: '3D' ( ',' (el3= int_literal ) )?
                    		        	{
                    		        		string_literal206=(IToken)Match(input,49,FOLLOW_49_in_plotfunctions2288); 
                    		        			string_literal206_tree = (object)adaptor.Create(string_literal206);
                    		        			adaptor.AddChild(root_0, string_literal206_tree);

                    		        		retval.ret.setPlotType("3D");
                    		        		// spinach.g:396:114: ( ',' (el3= int_literal ) )?
                    		        		int alt54 = 2;
                    		        		int LA54_0 = input.LA(1);

                    		        		if ( (LA54_0 == 30) )
                    		        		{
                    		        		    alt54 = 1;
                    		        		}
                    		        		switch (alt54) 
                    		        		{
                    		        		    case 1 :
                    		        		        // spinach.g:396:115: ',' (el3= int_literal )
                    		        		        {
                    		        		        	char_literal207=(IToken)Match(input,30,FOLLOW_30_in_plotfunctions2291); 
                    		        		        		char_literal207_tree = (object)adaptor.Create(char_literal207);
                    		        		        		adaptor.AddChild(root_0, char_literal207_tree);

                    		        		        	// spinach.g:396:118: (el3= int_literal )
                    		        		        	// spinach.g:396:119: el3= int_literal
                    		        		        	{
                    		        		        		PushFollow(FOLLOW_int_literal_in_plotfunctions2297);
                    		        		        		el3 = int_literal();
                    		        		        		state.followingStackPointer--;

                    		        		        		adaptor.AddChild(root_0, el3.Tree);
                    		        		        		retval.ret.setMode(((el3 != null) ? el3.ret : null));

                    		        		        	}


                    		        		        }
                    		        		        break;

                    		        		}


                    		        	}


                    		        }
                    		        break;

                    		}

                    		char_literal208=(IToken)Match(input,RIGHTBRACE,FOLLOW_RIGHTBRACE_in_plotfunctions2305); 
                    			char_literal208_tree = (object)adaptor.Create(char_literal208);
                    			adaptor.AddChild(root_0, char_literal208_tree);

                    		END_OF_STATEMENT209=(IToken)Match(input,END_OF_STATEMENT,FOLLOW_END_OF_STATEMENT_in_plotfunctions2306); 
                    			END_OF_STATEMENT209_tree = (object)adaptor.Create(END_OF_STATEMENT209);
                    			adaptor.AddChild(root_0, END_OF_STATEMENT209_tree);


                    	}


                    }
                    break;
                case 3 :
                    // spinach.g:398:3: ( 'resetPlot' '(' ')' END_OF_STATEMENT )
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	// spinach.g:398:3: ( 'resetPlot' '(' ')' END_OF_STATEMENT )
                    	// spinach.g:398:4: 'resetPlot' '(' ')' END_OF_STATEMENT
                    	{
                    		string_literal210=(IToken)Match(input,51,FOLLOW_51_in_plotfunctions2312); 
                    			string_literal210_tree = (object)adaptor.Create(string_literal210);
                    			adaptor.AddChild(root_0, string_literal210_tree);

                    		char_literal211=(IToken)Match(input,LEFTBRACE,FOLLOW_LEFTBRACE_in_plotfunctions2313); 
                    			char_literal211_tree = (object)adaptor.Create(char_literal211);
                    			adaptor.AddChild(root_0, char_literal211_tree);

                    		char_literal212=(IToken)Match(input,RIGHTBRACE,FOLLOW_RIGHTBRACE_in_plotfunctions2314); 
                    			char_literal212_tree = (object)adaptor.Create(char_literal212);
                    			adaptor.AddChild(root_0, char_literal212_tree);

                    		retval.ret.setPlotFunction("resetPlot");
                    		END_OF_STATEMENT213=(IToken)Match(input,END_OF_STATEMENT,FOLLOW_END_OF_STATEMENT_in_plotfunctions2316); 
                    			END_OF_STATEMENT213_tree = (object)adaptor.Create(END_OF_STATEMENT213);
                    			adaptor.AddChild(root_0, END_OF_STATEMENT213_tree);


                    	}


                    }
                    break;
                case 4 :
                    // spinach.g:399:2: 'setPlotAxis' '(' e112= double_literal ( ')' END_OF_STATEMENT | ',' e113= double_literal ( ')' END_OF_STATEMENT | ',' e114= double_literal ')' END_OF_STATEMENT ) )
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal214=(IToken)Match(input,52,FOLLOW_52_in_plotfunctions2320); 
                    		string_literal214_tree = (object)adaptor.Create(string_literal214);
                    		adaptor.AddChild(root_0, string_literal214_tree);

                    	retval.ret.setPlotFunction("setPlotAxis");
                    	char_literal215=(IToken)Match(input,LEFTBRACE,FOLLOW_LEFTBRACE_in_plotfunctions2324); 
                    		char_literal215_tree = (object)adaptor.Create(char_literal215);
                    		adaptor.AddChild(root_0, char_literal215_tree);

                    	PushFollow(FOLLOW_double_literal_in_plotfunctions2331);
                    	e112 = double_literal();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, e112.Tree);
                    	retval.ret.setXFact(((e112 != null) ? e112.ret : null));
                    	// spinach.g:401:2: ( ')' END_OF_STATEMENT | ',' e113= double_literal ( ')' END_OF_STATEMENT | ',' e114= double_literal ')' END_OF_STATEMENT ) )
                    	int alt57 = 2;
                    	int LA57_0 = input.LA(1);

                    	if ( (LA57_0 == RIGHTBRACE) )
                    	{
                    	    alt57 = 1;
                    	}
                    	else if ( (LA57_0 == 30) )
                    	{
                    	    alt57 = 2;
                    	}
                    	else 
                    	{
                    	    NoViableAltException nvae_d57s0 =
                    	        new NoViableAltException("", 57, 0, input);

                    	    throw nvae_d57s0;
                    	}
                    	switch (alt57) 
                    	{
                    	    case 1 :
                    	        // spinach.g:401:3: ')' END_OF_STATEMENT
                    	        {
                    	        	char_literal216=(IToken)Match(input,RIGHTBRACE,FOLLOW_RIGHTBRACE_in_plotfunctions2336); 
                    	        		char_literal216_tree = (object)adaptor.Create(char_literal216);
                    	        		adaptor.AddChild(root_0, char_literal216_tree);

                    	        	END_OF_STATEMENT217=(IToken)Match(input,END_OF_STATEMENT,FOLLOW_END_OF_STATEMENT_in_plotfunctions2338); 
                    	        		END_OF_STATEMENT217_tree = (object)adaptor.Create(END_OF_STATEMENT217);
                    	        		adaptor.AddChild(root_0, END_OF_STATEMENT217_tree);


                    	        }
                    	        break;
                    	    case 2 :
                    	        // spinach.g:401:24: ',' e113= double_literal ( ')' END_OF_STATEMENT | ',' e114= double_literal ')' END_OF_STATEMENT )
                    	        {
                    	        	char_literal218=(IToken)Match(input,30,FOLLOW_30_in_plotfunctions2340); 
                    	        		char_literal218_tree = (object)adaptor.Create(char_literal218);
                    	        		adaptor.AddChild(root_0, char_literal218_tree);

                    	        	PushFollow(FOLLOW_double_literal_in_plotfunctions2345);
                    	        	e113 = double_literal();
                    	        	state.followingStackPointer--;

                    	        	adaptor.AddChild(root_0, e113.Tree);
                    	        	retval.ret.setYFact(((e113 != null) ? e113.ret : null));
                    	        	// spinach.g:401:81: ( ')' END_OF_STATEMENT | ',' e114= double_literal ')' END_OF_STATEMENT )
                    	        	int alt56 = 2;
                    	        	int LA56_0 = input.LA(1);

                    	        	if ( (LA56_0 == RIGHTBRACE) )
                    	        	{
                    	        	    alt56 = 1;
                    	        	}
                    	        	else if ( (LA56_0 == 30) )
                    	        	{
                    	        	    alt56 = 2;
                    	        	}
                    	        	else 
                    	        	{
                    	        	    NoViableAltException nvae_d56s0 =
                    	        	        new NoViableAltException("", 56, 0, input);

                    	        	    throw nvae_d56s0;
                    	        	}
                    	        	switch (alt56) 
                    	        	{
                    	        	    case 1 :
                    	        	        // spinach.g:401:82: ')' END_OF_STATEMENT
                    	        	        {
                    	        	        	char_literal219=(IToken)Match(input,RIGHTBRACE,FOLLOW_RIGHTBRACE_in_plotfunctions2348); 
                    	        	        		char_literal219_tree = (object)adaptor.Create(char_literal219);
                    	        	        		adaptor.AddChild(root_0, char_literal219_tree);

                    	        	        	END_OF_STATEMENT220=(IToken)Match(input,END_OF_STATEMENT,FOLLOW_END_OF_STATEMENT_in_plotfunctions2349); 
                    	        	        		END_OF_STATEMENT220_tree = (object)adaptor.Create(END_OF_STATEMENT220);
                    	        	        		adaptor.AddChild(root_0, END_OF_STATEMENT220_tree);


                    	        	        }
                    	        	        break;
                    	        	    case 2 :
                    	        	        // spinach.g:401:102: ',' e114= double_literal ')' END_OF_STATEMENT
                    	        	        {
                    	        	        	char_literal221=(IToken)Match(input,30,FOLLOW_30_in_plotfunctions2351); 
                    	        	        		char_literal221_tree = (object)adaptor.Create(char_literal221);
                    	        	        		adaptor.AddChild(root_0, char_literal221_tree);

                    	        	        	PushFollow(FOLLOW_double_literal_in_plotfunctions2356);
                    	        	        	e114 = double_literal();
                    	        	        	state.followingStackPointer--;

                    	        	        	adaptor.AddChild(root_0, e114.Tree);
                    	        	        	retval.ret.setZFact(((e114 != null) ? e114.ret : null));
                    	        	        	char_literal222=(IToken)Match(input,RIGHTBRACE,FOLLOW_RIGHTBRACE_in_plotfunctions2359); 
                    	        	        		char_literal222_tree = (object)adaptor.Create(char_literal222);
                    	        	        		adaptor.AddChild(root_0, char_literal222_tree);

                    	        	        	END_OF_STATEMENT223=(IToken)Match(input,END_OF_STATEMENT,FOLLOW_END_OF_STATEMENT_in_plotfunctions2361); 
                    	        	        		END_OF_STATEMENT223_tree = (object)adaptor.Create(END_OF_STATEMENT223);
                    	        	        		adaptor.AddChild(root_0, END_OF_STATEMENT223_tree);


                    	        	        }
                    	        	        break;

                    	        	}


                    	        }
                    	        break;

                    	}


                    }
                    break;
                case 5 :
                    // spinach.g:402:2: 'setAxisTitle' '(' v112= string_literal ( ')' END_OF_STATEMENT | ',' v113= string_literal ( ')' END_OF_STATEMENT | ',' v114= string_literal ')' END_OF_STATEMENT ) )
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal224=(IToken)Match(input,53,FOLLOW_53_in_plotfunctions2366); 
                    		string_literal224_tree = (object)adaptor.Create(string_literal224);
                    		adaptor.AddChild(root_0, string_literal224_tree);

                    	retval.ret.setPlotFunction("setAxisTitle");
                    	char_literal225=(IToken)Match(input,LEFTBRACE,FOLLOW_LEFTBRACE_in_plotfunctions2370); 
                    		char_literal225_tree = (object)adaptor.Create(char_literal225);
                    		adaptor.AddChild(root_0, char_literal225_tree);

                    	PushFollow(FOLLOW_string_literal_in_plotfunctions2377);
                    	v112 = string_literal();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, v112.Tree);
                    	retval.ret.setXTitle(((v112 != null) ? v112.ret : null));
                    	// spinach.g:404:2: ( ')' END_OF_STATEMENT | ',' v113= string_literal ( ')' END_OF_STATEMENT | ',' v114= string_literal ')' END_OF_STATEMENT ) )
                    	int alt59 = 2;
                    	int LA59_0 = input.LA(1);

                    	if ( (LA59_0 == RIGHTBRACE) )
                    	{
                    	    alt59 = 1;
                    	}
                    	else if ( (LA59_0 == 30) )
                    	{
                    	    alt59 = 2;
                    	}
                    	else 
                    	{
                    	    NoViableAltException nvae_d59s0 =
                    	        new NoViableAltException("", 59, 0, input);

                    	    throw nvae_d59s0;
                    	}
                    	switch (alt59) 
                    	{
                    	    case 1 :
                    	        // spinach.g:404:3: ')' END_OF_STATEMENT
                    	        {
                    	        	char_literal226=(IToken)Match(input,RIGHTBRACE,FOLLOW_RIGHTBRACE_in_plotfunctions2382); 
                    	        		char_literal226_tree = (object)adaptor.Create(char_literal226);
                    	        		adaptor.AddChild(root_0, char_literal226_tree);

                    	        	END_OF_STATEMENT227=(IToken)Match(input,END_OF_STATEMENT,FOLLOW_END_OF_STATEMENT_in_plotfunctions2384); 
                    	        		END_OF_STATEMENT227_tree = (object)adaptor.Create(END_OF_STATEMENT227);
                    	        		adaptor.AddChild(root_0, END_OF_STATEMENT227_tree);


                    	        }
                    	        break;
                    	    case 2 :
                    	        // spinach.g:404:24: ',' v113= string_literal ( ')' END_OF_STATEMENT | ',' v114= string_literal ')' END_OF_STATEMENT )
                    	        {
                    	        	char_literal228=(IToken)Match(input,30,FOLLOW_30_in_plotfunctions2386); 
                    	        		char_literal228_tree = (object)adaptor.Create(char_literal228);
                    	        		adaptor.AddChild(root_0, char_literal228_tree);

                    	        	PushFollow(FOLLOW_string_literal_in_plotfunctions2391);
                    	        	v113 = string_literal();
                    	        	state.followingStackPointer--;

                    	        	adaptor.AddChild(root_0, v113.Tree);
                    	        	retval.ret.setYTitle(((v113 != null) ? v113.ret : null));
                    	        	// spinach.g:404:82: ( ')' END_OF_STATEMENT | ',' v114= string_literal ')' END_OF_STATEMENT )
                    	        	int alt58 = 2;
                    	        	int LA58_0 = input.LA(1);

                    	        	if ( (LA58_0 == RIGHTBRACE) )
                    	        	{
                    	        	    alt58 = 1;
                    	        	}
                    	        	else if ( (LA58_0 == 30) )
                    	        	{
                    	        	    alt58 = 2;
                    	        	}
                    	        	else 
                    	        	{
                    	        	    NoViableAltException nvae_d58s0 =
                    	        	        new NoViableAltException("", 58, 0, input);

                    	        	    throw nvae_d58s0;
                    	        	}
                    	        	switch (alt58) 
                    	        	{
                    	        	    case 1 :
                    	        	        // spinach.g:404:83: ')' END_OF_STATEMENT
                    	        	        {
                    	        	        	char_literal229=(IToken)Match(input,RIGHTBRACE,FOLLOW_RIGHTBRACE_in_plotfunctions2394); 
                    	        	        		char_literal229_tree = (object)adaptor.Create(char_literal229);
                    	        	        		adaptor.AddChild(root_0, char_literal229_tree);

                    	        	        	END_OF_STATEMENT230=(IToken)Match(input,END_OF_STATEMENT,FOLLOW_END_OF_STATEMENT_in_plotfunctions2395); 
                    	        	        		END_OF_STATEMENT230_tree = (object)adaptor.Create(END_OF_STATEMENT230);
                    	        	        		adaptor.AddChild(root_0, END_OF_STATEMENT230_tree);


                    	        	        }
                    	        	        break;
                    	        	    case 2 :
                    	        	        // spinach.g:404:103: ',' v114= string_literal ')' END_OF_STATEMENT
                    	        	        {
                    	        	        	char_literal231=(IToken)Match(input,30,FOLLOW_30_in_plotfunctions2397); 
                    	        	        		char_literal231_tree = (object)adaptor.Create(char_literal231);
                    	        	        		adaptor.AddChild(root_0, char_literal231_tree);

                    	        	        	PushFollow(FOLLOW_string_literal_in_plotfunctions2402);
                    	        	        	v114 = string_literal();
                    	        	        	state.followingStackPointer--;

                    	        	        	adaptor.AddChild(root_0, v114.Tree);
                    	        	        	retval.ret.setZTitle(((v114 != null) ? v114.ret : null));
                    	        	        	char_literal232=(IToken)Match(input,RIGHTBRACE,FOLLOW_RIGHTBRACE_in_plotfunctions2405); 
                    	        	        		char_literal232_tree = (object)adaptor.Create(char_literal232);
                    	        	        		adaptor.AddChild(root_0, char_literal232_tree);

                    	        	        	END_OF_STATEMENT233=(IToken)Match(input,END_OF_STATEMENT,FOLLOW_END_OF_STATEMENT_in_plotfunctions2407); 
                    	        	        		END_OF_STATEMENT233_tree = (object)adaptor.Create(END_OF_STATEMENT233);
                    	        	        		adaptor.AddChild(root_0, END_OF_STATEMENT233_tree);


                    	        	        }
                    	        	        break;

                    	        	}


                    	        }
                    	        break;

                    	}


                    }
                    break;
                case 6 :
                    // spinach.g:405:2: ( 'setScaleMode(' SCALEMODE ')' END_OF_STATEMENT )
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	// spinach.g:405:2: ( 'setScaleMode(' SCALEMODE ')' END_OF_STATEMENT )
                    	// spinach.g:405:3: 'setScaleMode(' SCALEMODE ')' END_OF_STATEMENT
                    	{
                    		string_literal234=(IToken)Match(input,54,FOLLOW_54_in_plotfunctions2413); 
                    			string_literal234_tree = (object)adaptor.Create(string_literal234);
                    			adaptor.AddChild(root_0, string_literal234_tree);

                    		retval.ret.setPlotFunction("setScaleMode");
                    		SCALEMODE235=(IToken)Match(input,SCALEMODE,FOLLOW_SCALEMODE_in_plotfunctions2416); 
                    			SCALEMODE235_tree = (object)adaptor.Create(SCALEMODE235);
                    			adaptor.AddChild(root_0, SCALEMODE235_tree);

                    		retval.ret.setScaleMode(SCALEMODE235.Text);
                    		char_literal236=(IToken)Match(input,RIGHTBRACE,FOLLOW_RIGHTBRACE_in_plotfunctions2420); 
                    			char_literal236_tree = (object)adaptor.Create(char_literal236);
                    			adaptor.AddChild(root_0, char_literal236_tree);

                    		END_OF_STATEMENT237=(IToken)Match(input,END_OF_STATEMENT,FOLLOW_END_OF_STATEMENT_in_plotfunctions2422); 
                    			END_OF_STATEMENT237_tree = (object)adaptor.Create(END_OF_STATEMENT237);
                    			adaptor.AddChild(root_0, END_OF_STATEMENT237_tree);


                    	}


                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "plotfunctions"

    public class comment_return : ParserRuleReturnScope
    {
        public CommentElement ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "comment"
    // spinach.g:412:1: comment returns [CommentElement ret] : ( '//' (el3= VARIABLE | el2= INT_LITERAL | el1= DOUBLE_LITERAL | '.' | 'matrix' | 'vector' | '<' | '>' | VARTYPE | SCALEMODE | STRINGTYPE | ASSIGNMENT | PLUS | MULTIPLY | 'print' | 'subPlot' | 'plot' | 'resetPlot' | 'setPlotAxis' | 'setAxisTitle' | 'setScaleMode' | '\"' | '(' | ')' | '{' | '}' | '->' | '==' | '!=' | '<=' | '&' | '-' | ';' | ':' | '^' | '$' | '#' | '@' | '!' | '?' | '/' | '[' | ']' | ',' | '1D' | '2D' | '3D' | 'void' | 'struct' )* '//' ) ;
    public spinachParser.comment_return comment() // throws RecognitionException [1]
    {   
        spinachParser.comment_return retval = new spinachParser.comment_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken el3 = null;
        IToken el2 = null;
        IToken el1 = null;
        IToken string_literal238 = null;
        IToken char_literal239 = null;
        IToken string_literal240 = null;
        IToken string_literal241 = null;
        IToken char_literal242 = null;
        IToken char_literal243 = null;
        IToken VARTYPE244 = null;
        IToken SCALEMODE245 = null;
        IToken STRINGTYPE246 = null;
        IToken ASSIGNMENT247 = null;
        IToken PLUS248 = null;
        IToken MULTIPLY249 = null;
        IToken string_literal250 = null;
        IToken string_literal251 = null;
        IToken string_literal252 = null;
        IToken string_literal253 = null;
        IToken string_literal254 = null;
        IToken string_literal255 = null;
        IToken string_literal256 = null;
        IToken char_literal257 = null;
        IToken char_literal258 = null;
        IToken char_literal259 = null;
        IToken char_literal260 = null;
        IToken char_literal261 = null;
        IToken string_literal262 = null;
        IToken string_literal263 = null;
        IToken string_literal264 = null;
        IToken string_literal265 = null;
        IToken char_literal266 = null;
        IToken char_literal267 = null;
        IToken char_literal268 = null;
        IToken char_literal269 = null;
        IToken char_literal270 = null;
        IToken char_literal271 = null;
        IToken char_literal272 = null;
        IToken char_literal273 = null;
        IToken char_literal274 = null;
        IToken char_literal275 = null;
        IToken char_literal276 = null;
        IToken char_literal277 = null;
        IToken char_literal278 = null;
        IToken char_literal279 = null;
        IToken string_literal280 = null;
        IToken string_literal281 = null;
        IToken string_literal282 = null;
        IToken string_literal283 = null;
        IToken string_literal284 = null;
        IToken string_literal285 = null;

        object el3_tree=null;
        object el2_tree=null;
        object el1_tree=null;
        object string_literal238_tree=null;
        object char_literal239_tree=null;
        object string_literal240_tree=null;
        object string_literal241_tree=null;
        object char_literal242_tree=null;
        object char_literal243_tree=null;
        object VARTYPE244_tree=null;
        object SCALEMODE245_tree=null;
        object STRINGTYPE246_tree=null;
        object ASSIGNMENT247_tree=null;
        object PLUS248_tree=null;
        object MULTIPLY249_tree=null;
        object string_literal250_tree=null;
        object string_literal251_tree=null;
        object string_literal252_tree=null;
        object string_literal253_tree=null;
        object string_literal254_tree=null;
        object string_literal255_tree=null;
        object string_literal256_tree=null;
        object char_literal257_tree=null;
        object char_literal258_tree=null;
        object char_literal259_tree=null;
        object char_literal260_tree=null;
        object char_literal261_tree=null;
        object string_literal262_tree=null;
        object string_literal263_tree=null;
        object string_literal264_tree=null;
        object string_literal265_tree=null;
        object char_literal266_tree=null;
        object char_literal267_tree=null;
        object char_literal268_tree=null;
        object char_literal269_tree=null;
        object char_literal270_tree=null;
        object char_literal271_tree=null;
        object char_literal272_tree=null;
        object char_literal273_tree=null;
        object char_literal274_tree=null;
        object char_literal275_tree=null;
        object char_literal276_tree=null;
        object char_literal277_tree=null;
        object char_literal278_tree=null;
        object char_literal279_tree=null;
        object string_literal280_tree=null;
        object string_literal281_tree=null;
        object string_literal282_tree=null;
        object string_literal283_tree=null;
        object string_literal284_tree=null;
        object string_literal285_tree=null;


         retval.ret = new CommentElement();

        try 
    	{
            // spinach.g:416:2: ( ( '//' (el3= VARIABLE | el2= INT_LITERAL | el1= DOUBLE_LITERAL | '.' | 'matrix' | 'vector' | '<' | '>' | VARTYPE | SCALEMODE | STRINGTYPE | ASSIGNMENT | PLUS | MULTIPLY | 'print' | 'subPlot' | 'plot' | 'resetPlot' | 'setPlotAxis' | 'setAxisTitle' | 'setScaleMode' | '\"' | '(' | ')' | '{' | '}' | '->' | '==' | '!=' | '<=' | '&' | '-' | ';' | ':' | '^' | '$' | '#' | '@' | '!' | '?' | '/' | '[' | ']' | ',' | '1D' | '2D' | '3D' | 'void' | 'struct' )* '//' ) )
            // spinach.g:416:3: ( '//' (el3= VARIABLE | el2= INT_LITERAL | el1= DOUBLE_LITERAL | '.' | 'matrix' | 'vector' | '<' | '>' | VARTYPE | SCALEMODE | STRINGTYPE | ASSIGNMENT | PLUS | MULTIPLY | 'print' | 'subPlot' | 'plot' | 'resetPlot' | 'setPlotAxis' | 'setAxisTitle' | 'setScaleMode' | '\"' | '(' | ')' | '{' | '}' | '->' | '==' | '!=' | '<=' | '&' | '-' | ';' | ':' | '^' | '$' | '#' | '@' | '!' | '?' | '/' | '[' | ']' | ',' | '1D' | '2D' | '3D' | 'void' | 'struct' )* '//' )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// spinach.g:416:3: ( '//' (el3= VARIABLE | el2= INT_LITERAL | el1= DOUBLE_LITERAL | '.' | 'matrix' | 'vector' | '<' | '>' | VARTYPE | SCALEMODE | STRINGTYPE | ASSIGNMENT | PLUS | MULTIPLY | 'print' | 'subPlot' | 'plot' | 'resetPlot' | 'setPlotAxis' | 'setAxisTitle' | 'setScaleMode' | '\"' | '(' | ')' | '{' | '}' | '->' | '==' | '!=' | '<=' | '&' | '-' | ';' | ':' | '^' | '$' | '#' | '@' | '!' | '?' | '/' | '[' | ']' | ',' | '1D' | '2D' | '3D' | 'void' | 'struct' )* '//' )
            	// spinach.g:416:4: '//' (el3= VARIABLE | el2= INT_LITERAL | el1= DOUBLE_LITERAL | '.' | 'matrix' | 'vector' | '<' | '>' | VARTYPE | SCALEMODE | STRINGTYPE | ASSIGNMENT | PLUS | MULTIPLY | 'print' | 'subPlot' | 'plot' | 'resetPlot' | 'setPlotAxis' | 'setAxisTitle' | 'setScaleMode' | '\"' | '(' | ')' | '{' | '}' | '->' | '==' | '!=' | '<=' | '&' | '-' | ';' | ':' | '^' | '$' | '#' | '@' | '!' | '?' | '/' | '[' | ']' | ',' | '1D' | '2D' | '3D' | 'void' | 'struct' )* '//'
            	{
            		string_literal238=(IToken)Match(input,55,FOLLOW_55_in_comment2443); 
            			string_literal238_tree = (object)adaptor.Create(string_literal238);
            			adaptor.AddChild(root_0, string_literal238_tree);

            		// spinach.g:417:1: (el3= VARIABLE | el2= INT_LITERAL | el1= DOUBLE_LITERAL | '.' | 'matrix' | 'vector' | '<' | '>' | VARTYPE | SCALEMODE | STRINGTYPE | ASSIGNMENT | PLUS | MULTIPLY | 'print' | 'subPlot' | 'plot' | 'resetPlot' | 'setPlotAxis' | 'setAxisTitle' | 'setScaleMode' | '\"' | '(' | ')' | '{' | '}' | '->' | '==' | '!=' | '<=' | '&' | '-' | ';' | ':' | '^' | '$' | '#' | '@' | '!' | '?' | '/' | '[' | ']' | ',' | '1D' | '2D' | '3D' | 'void' | 'struct' )*
            		do 
            		{
            		    int alt61 = 50;
            		    switch ( input.LA(1) ) 
            		    {
            		    case VARIABLE:
            		    	{
            		        alt61 = 1;
            		        }
            		        break;
            		    case INT_LITERAL:
            		    	{
            		        alt61 = 2;
            		        }
            		        break;
            		    case DOUBLE_LITERAL:
            		    	{
            		        alt61 = 3;
            		        }
            		        break;
            		    case DOT:
            		    	{
            		        alt61 = 4;
            		        }
            		        break;
            		    case 27:
            		    	{
            		        alt61 = 5;
            		        }
            		        break;
            		    case 31:
            		    	{
            		        alt61 = 6;
            		        }
            		        break;
            		    case LESSTHANEXPRESSION:
            		    	{
            		        alt61 = 7;
            		        }
            		        break;
            		    case GREATERTHANEXPRESSION:
            		    	{
            		        alt61 = 8;
            		        }
            		        break;
            		    case VARTYPE:
            		    	{
            		        alt61 = 9;
            		        }
            		        break;
            		    case SCALEMODE:
            		    	{
            		        alt61 = 10;
            		        }
            		        break;
            		    case STRINGTYPE:
            		    	{
            		        alt61 = 11;
            		        }
            		        break;
            		    case ASSIGNMENT:
            		    	{
            		        alt61 = 12;
            		        }
            		        break;
            		    case PLUS:
            		    	{
            		        alt61 = 13;
            		        }
            		        break;
            		    case MULTIPLY:
            		    	{
            		        alt61 = 14;
            		        }
            		        break;
            		    case 35:
            		    	{
            		        alt61 = 15;
            		        }
            		        break;
            		    case 46:
            		    	{
            		        alt61 = 16;
            		        }
            		        break;
            		    case 50:
            		    	{
            		        alt61 = 17;
            		        }
            		        break;
            		    case 51:
            		    	{
            		        alt61 = 18;
            		        }
            		        break;
            		    case 52:
            		    	{
            		        alt61 = 19;
            		        }
            		        break;
            		    case 53:
            		    	{
            		        alt61 = 20;
            		        }
            		        break;
            		    case 56:
            		    	{
            		        alt61 = 21;
            		        }
            		        break;
            		    case 57:
            		    	{
            		        alt61 = 22;
            		        }
            		        break;
            		    case LEFTBRACE:
            		    	{
            		        alt61 = 23;
            		        }
            		        break;
            		    case RIGHTBRACE:
            		    	{
            		        alt61 = 24;
            		        }
            		        break;
            		    case LEFTPARANTHESIS:
            		    	{
            		        alt61 = 25;
            		        }
            		        break;
            		    case RIGHTPARANTHESIS:
            		    	{
            		        alt61 = 26;
            		        }
            		        break;
            		    case POINT:
            		    	{
            		        alt61 = 27;
            		        }
            		        break;
            		    case EQUALITYEXPRESSION:
            		    	{
            		        alt61 = 28;
            		        }
            		        break;
            		    case NONEQUALITYEXPRESSION:
            		    	{
            		        alt61 = 29;
            		        }
            		        break;
            		    case LESSTHANEQUALTOEXPRESSION:
            		    	{
            		        alt61 = 30;
            		        }
            		        break;
            		    case 58:
            		    	{
            		        alt61 = 31;
            		        }
            		        break;
            		    case 32:
            		    	{
            		        alt61 = 32;
            		        }
            		        break;
            		    case END_OF_STATEMENT:
            		    	{
            		        alt61 = 33;
            		        }
            		        break;
            		    case 59:
            		    	{
            		        alt61 = 34;
            		        }
            		        break;
            		    case 60:
            		    	{
            		        alt61 = 35;
            		        }
            		        break;
            		    case 61:
            		    	{
            		        alt61 = 36;
            		        }
            		        break;
            		    case 62:
            		    	{
            		        alt61 = 37;
            		        }
            		        break;
            		    case 63:
            		    	{
            		        alt61 = 38;
            		        }
            		        break;
            		    case 64:
            		    	{
            		        alt61 = 39;
            		        }
            		        break;
            		    case 65:
            		    	{
            		        alt61 = 40;
            		        }
            		        break;
            		    case 66:
            		    	{
            		        alt61 = 41;
            		        }
            		        break;
            		    case 28:
            		    	{
            		        alt61 = 42;
            		        }
            		        break;
            		    case 29:
            		    	{
            		        alt61 = 43;
            		        }
            		        break;
            		    case 30:
            		    	{
            		        alt61 = 44;
            		        }
            		        break;
            		    case 47:
            		    	{
            		        alt61 = 45;
            		        }
            		        break;
            		    case 48:
            		    	{
            		        alt61 = 46;
            		        }
            		        break;
            		    case 49:
            		    	{
            		        alt61 = 47;
            		        }
            		        break;
            		    case 42:
            		    	{
            		        alt61 = 48;
            		        }
            		        break;
            		    case 33:
            		    	{
            		        alt61 = 49;
            		        }
            		        break;

            		    }

            		    switch (alt61) 
            			{
            				case 1 :
            				    // spinach.g:417:2: el3= VARIABLE
            				    {
            				    	el3=(IToken)Match(input,VARIABLE,FOLLOW_VARIABLE_in_comment2448); 
            				    		el3_tree = (object)adaptor.Create(el3);
            				    		adaptor.AddChild(root_0, el3_tree);



            				    }
            				    break;
            				case 2 :
            				    // spinach.g:418:3: el2= INT_LITERAL
            				    {
            				    	el2=(IToken)Match(input,INT_LITERAL,FOLLOW_INT_LITERAL_in_comment2455); 
            				    		el2_tree = (object)adaptor.Create(el2);
            				    		adaptor.AddChild(root_0, el2_tree);



            				    }
            				    break;
            				case 3 :
            				    // spinach.g:419:3: el1= DOUBLE_LITERAL
            				    {
            				    	el1=(IToken)Match(input,DOUBLE_LITERAL,FOLLOW_DOUBLE_LITERAL_in_comment2462); 
            				    		el1_tree = (object)adaptor.Create(el1);
            				    		adaptor.AddChild(root_0, el1_tree);



            				    }
            				    break;
            				case 4 :
            				    // spinach.g:420:3: '.'
            				    {
            				    	char_literal239=(IToken)Match(input,DOT,FOLLOW_DOT_in_comment2467); 
            				    		char_literal239_tree = (object)adaptor.Create(char_literal239);
            				    		adaptor.AddChild(root_0, char_literal239_tree);



            				    }
            				    break;
            				case 5 :
            				    // spinach.g:421:3: 'matrix'
            				    {
            				    	string_literal240=(IToken)Match(input,27,FOLLOW_27_in_comment2472); 
            				    		string_literal240_tree = (object)adaptor.Create(string_literal240);
            				    		adaptor.AddChild(root_0, string_literal240_tree);



            				    }
            				    break;
            				case 6 :
            				    // spinach.g:422:3: 'vector'
            				    {
            				    	string_literal241=(IToken)Match(input,31,FOLLOW_31_in_comment2477); 
            				    		string_literal241_tree = (object)adaptor.Create(string_literal241);
            				    		adaptor.AddChild(root_0, string_literal241_tree);



            				    }
            				    break;
            				case 7 :
            				    // spinach.g:423:3: '<'
            				    {
            				    	char_literal242=(IToken)Match(input,LESSTHANEXPRESSION,FOLLOW_LESSTHANEXPRESSION_in_comment2482); 
            				    		char_literal242_tree = (object)adaptor.Create(char_literal242);
            				    		adaptor.AddChild(root_0, char_literal242_tree);



            				    }
            				    break;
            				case 8 :
            				    // spinach.g:424:3: '>'
            				    {
            				    	char_literal243=(IToken)Match(input,GREATERTHANEXPRESSION,FOLLOW_GREATERTHANEXPRESSION_in_comment2487); 
            				    		char_literal243_tree = (object)adaptor.Create(char_literal243);
            				    		adaptor.AddChild(root_0, char_literal243_tree);



            				    }
            				    break;
            				case 9 :
            				    // spinach.g:425:3: VARTYPE
            				    {
            				    	VARTYPE244=(IToken)Match(input,VARTYPE,FOLLOW_VARTYPE_in_comment2492); 
            				    		VARTYPE244_tree = (object)adaptor.Create(VARTYPE244);
            				    		adaptor.AddChild(root_0, VARTYPE244_tree);



            				    }
            				    break;
            				case 10 :
            				    // spinach.g:426:3: SCALEMODE
            				    {
            				    	SCALEMODE245=(IToken)Match(input,SCALEMODE,FOLLOW_SCALEMODE_in_comment2497); 
            				    		SCALEMODE245_tree = (object)adaptor.Create(SCALEMODE245);
            				    		adaptor.AddChild(root_0, SCALEMODE245_tree);



            				    }
            				    break;
            				case 11 :
            				    // spinach.g:427:3: STRINGTYPE
            				    {
            				    	STRINGTYPE246=(IToken)Match(input,STRINGTYPE,FOLLOW_STRINGTYPE_in_comment2502); 
            				    		STRINGTYPE246_tree = (object)adaptor.Create(STRINGTYPE246);
            				    		adaptor.AddChild(root_0, STRINGTYPE246_tree);



            				    }
            				    break;
            				case 12 :
            				    // spinach.g:428:3: ASSIGNMENT
            				    {
            				    	ASSIGNMENT247=(IToken)Match(input,ASSIGNMENT,FOLLOW_ASSIGNMENT_in_comment2507); 
            				    		ASSIGNMENT247_tree = (object)adaptor.Create(ASSIGNMENT247);
            				    		adaptor.AddChild(root_0, ASSIGNMENT247_tree);



            				    }
            				    break;
            				case 13 :
            				    // spinach.g:429:3: PLUS
            				    {
            				    	PLUS248=(IToken)Match(input,PLUS,FOLLOW_PLUS_in_comment2512); 
            				    		PLUS248_tree = (object)adaptor.Create(PLUS248);
            				    		adaptor.AddChild(root_0, PLUS248_tree);



            				    }
            				    break;
            				case 14 :
            				    // spinach.g:430:3: MULTIPLY
            				    {
            				    	MULTIPLY249=(IToken)Match(input,MULTIPLY,FOLLOW_MULTIPLY_in_comment2517); 
            				    		MULTIPLY249_tree = (object)adaptor.Create(MULTIPLY249);
            				    		adaptor.AddChild(root_0, MULTIPLY249_tree);



            				    }
            				    break;
            				case 15 :
            				    // spinach.g:431:3: 'print'
            				    {
            				    	string_literal250=(IToken)Match(input,35,FOLLOW_35_in_comment2522); 
            				    		string_literal250_tree = (object)adaptor.Create(string_literal250);
            				    		adaptor.AddChild(root_0, string_literal250_tree);



            				    }
            				    break;
            				case 16 :
            				    // spinach.g:432:2: 'subPlot'
            				    {
            				    	string_literal251=(IToken)Match(input,46,FOLLOW_46_in_comment2526); 
            				    		string_literal251_tree = (object)adaptor.Create(string_literal251);
            				    		adaptor.AddChild(root_0, string_literal251_tree);



            				    }
            				    break;
            				case 17 :
            				    // spinach.g:433:2: 'plot'
            				    {
            				    	string_literal252=(IToken)Match(input,50,FOLLOW_50_in_comment2530); 
            				    		string_literal252_tree = (object)adaptor.Create(string_literal252);
            				    		adaptor.AddChild(root_0, string_literal252_tree);



            				    }
            				    break;
            				case 18 :
            				    // spinach.g:434:2: 'resetPlot'
            				    {
            				    	string_literal253=(IToken)Match(input,51,FOLLOW_51_in_comment2534); 
            				    		string_literal253_tree = (object)adaptor.Create(string_literal253);
            				    		adaptor.AddChild(root_0, string_literal253_tree);



            				    }
            				    break;
            				case 19 :
            				    // spinach.g:435:2: 'setPlotAxis'
            				    {
            				    	string_literal254=(IToken)Match(input,52,FOLLOW_52_in_comment2538); 
            				    		string_literal254_tree = (object)adaptor.Create(string_literal254);
            				    		adaptor.AddChild(root_0, string_literal254_tree);



            				    }
            				    break;
            				case 20 :
            				    // spinach.g:436:2: 'setAxisTitle'
            				    {
            				    	string_literal255=(IToken)Match(input,53,FOLLOW_53_in_comment2542); 
            				    		string_literal255_tree = (object)adaptor.Create(string_literal255);
            				    		adaptor.AddChild(root_0, string_literal255_tree);



            				    }
            				    break;
            				case 21 :
            				    // spinach.g:437:2: 'setScaleMode'
            				    {
            				    	string_literal256=(IToken)Match(input,56,FOLLOW_56_in_comment2546); 
            				    		string_literal256_tree = (object)adaptor.Create(string_literal256);
            				    		adaptor.AddChild(root_0, string_literal256_tree);



            				    }
            				    break;
            				case 22 :
            				    // spinach.g:438:3: '\"'
            				    {
            				    	char_literal257=(IToken)Match(input,57,FOLLOW_57_in_comment2551); 
            				    		char_literal257_tree = (object)adaptor.Create(char_literal257);
            				    		adaptor.AddChild(root_0, char_literal257_tree);



            				    }
            				    break;
            				case 23 :
            				    // spinach.g:439:3: '('
            				    {
            				    	char_literal258=(IToken)Match(input,LEFTBRACE,FOLLOW_LEFTBRACE_in_comment2557); 
            				    		char_literal258_tree = (object)adaptor.Create(char_literal258);
            				    		adaptor.AddChild(root_0, char_literal258_tree);



            				    }
            				    break;
            				case 24 :
            				    // spinach.g:440:3: ')'
            				    {
            				    	char_literal259=(IToken)Match(input,RIGHTBRACE,FOLLOW_RIGHTBRACE_in_comment2562); 
            				    		char_literal259_tree = (object)adaptor.Create(char_literal259);
            				    		adaptor.AddChild(root_0, char_literal259_tree);



            				    }
            				    break;
            				case 25 :
            				    // spinach.g:441:3: '{'
            				    {
            				    	char_literal260=(IToken)Match(input,LEFTPARANTHESIS,FOLLOW_LEFTPARANTHESIS_in_comment2567); 
            				    		char_literal260_tree = (object)adaptor.Create(char_literal260);
            				    		adaptor.AddChild(root_0, char_literal260_tree);



            				    }
            				    break;
            				case 26 :
            				    // spinach.g:442:3: '}'
            				    {
            				    	char_literal261=(IToken)Match(input,RIGHTPARANTHESIS,FOLLOW_RIGHTPARANTHESIS_in_comment2572); 
            				    		char_literal261_tree = (object)adaptor.Create(char_literal261);
            				    		adaptor.AddChild(root_0, char_literal261_tree);



            				    }
            				    break;
            				case 27 :
            				    // spinach.g:443:3: '->'
            				    {
            				    	string_literal262=(IToken)Match(input,POINT,FOLLOW_POINT_in_comment2577); 
            				    		string_literal262_tree = (object)adaptor.Create(string_literal262);
            				    		adaptor.AddChild(root_0, string_literal262_tree);



            				    }
            				    break;
            				case 28 :
            				    // spinach.g:444:3: '=='
            				    {
            				    	string_literal263=(IToken)Match(input,EQUALITYEXPRESSION,FOLLOW_EQUALITYEXPRESSION_in_comment2582); 
            				    		string_literal263_tree = (object)adaptor.Create(string_literal263);
            				    		adaptor.AddChild(root_0, string_literal263_tree);



            				    }
            				    break;
            				case 29 :
            				    // spinach.g:445:3: '!='
            				    {
            				    	string_literal264=(IToken)Match(input,NONEQUALITYEXPRESSION,FOLLOW_NONEQUALITYEXPRESSION_in_comment2587); 
            				    		string_literal264_tree = (object)adaptor.Create(string_literal264);
            				    		adaptor.AddChild(root_0, string_literal264_tree);



            				    }
            				    break;
            				case 30 :
            				    // spinach.g:446:3: '<='
            				    {
            				    	string_literal265=(IToken)Match(input,LESSTHANEQUALTOEXPRESSION,FOLLOW_LESSTHANEQUALTOEXPRESSION_in_comment2592); 
            				    		string_literal265_tree = (object)adaptor.Create(string_literal265);
            				    		adaptor.AddChild(root_0, string_literal265_tree);



            				    }
            				    break;
            				case 31 :
            				    // spinach.g:447:4: '&'
            				    {
            				    	char_literal266=(IToken)Match(input,58,FOLLOW_58_in_comment2598); 
            				    		char_literal266_tree = (object)adaptor.Create(char_literal266);
            				    		adaptor.AddChild(root_0, char_literal266_tree);



            				    }
            				    break;
            				case 32 :
            				    // spinach.g:448:4: '-'
            				    {
            				    	char_literal267=(IToken)Match(input,32,FOLLOW_32_in_comment2604); 
            				    		char_literal267_tree = (object)adaptor.Create(char_literal267);
            				    		adaptor.AddChild(root_0, char_literal267_tree);



            				    }
            				    break;
            				case 33 :
            				    // spinach.g:449:4: ';'
            				    {
            				    	char_literal268=(IToken)Match(input,END_OF_STATEMENT,FOLLOW_END_OF_STATEMENT_in_comment2610); 
            				    		char_literal268_tree = (object)adaptor.Create(char_literal268);
            				    		adaptor.AddChild(root_0, char_literal268_tree);



            				    }
            				    break;
            				case 34 :
            				    // spinach.g:450:4: ':'
            				    {
            				    	char_literal269=(IToken)Match(input,59,FOLLOW_59_in_comment2616); 
            				    		char_literal269_tree = (object)adaptor.Create(char_literal269);
            				    		adaptor.AddChild(root_0, char_literal269_tree);



            				    }
            				    break;
            				case 35 :
            				    // spinach.g:452:5: '^'
            				    {
            				    	char_literal270=(IToken)Match(input,60,FOLLOW_60_in_comment2627); 
            				    		char_literal270_tree = (object)adaptor.Create(char_literal270);
            				    		adaptor.AddChild(root_0, char_literal270_tree);



            				    }
            				    break;
            				case 36 :
            				    // spinach.g:453:5: '$'
            				    {
            				    	char_literal271=(IToken)Match(input,61,FOLLOW_61_in_comment2634); 
            				    		char_literal271_tree = (object)adaptor.Create(char_literal271);
            				    		adaptor.AddChild(root_0, char_literal271_tree);



            				    }
            				    break;
            				case 37 :
            				    // spinach.g:454:5: '#'
            				    {
            				    	char_literal272=(IToken)Match(input,62,FOLLOW_62_in_comment2641); 
            				    		char_literal272_tree = (object)adaptor.Create(char_literal272);
            				    		adaptor.AddChild(root_0, char_literal272_tree);



            				    }
            				    break;
            				case 38 :
            				    // spinach.g:455:5: '@'
            				    {
            				    	char_literal273=(IToken)Match(input,63,FOLLOW_63_in_comment2648); 
            				    		char_literal273_tree = (object)adaptor.Create(char_literal273);
            				    		adaptor.AddChild(root_0, char_literal273_tree);



            				    }
            				    break;
            				case 39 :
            				    // spinach.g:456:5: '!'
            				    {
            				    	char_literal274=(IToken)Match(input,64,FOLLOW_64_in_comment2655); 
            				    		char_literal274_tree = (object)adaptor.Create(char_literal274);
            				    		adaptor.AddChild(root_0, char_literal274_tree);



            				    }
            				    break;
            				case 40 :
            				    // spinach.g:457:6: '?'
            				    {
            				    	char_literal275=(IToken)Match(input,65,FOLLOW_65_in_comment2663); 
            				    		char_literal275_tree = (object)adaptor.Create(char_literal275);
            				    		adaptor.AddChild(root_0, char_literal275_tree);



            				    }
            				    break;
            				case 41 :
            				    // spinach.g:458:7: '/'
            				    {
            				    	char_literal276=(IToken)Match(input,66,FOLLOW_66_in_comment2672); 
            				    		char_literal276_tree = (object)adaptor.Create(char_literal276);
            				    		adaptor.AddChild(root_0, char_literal276_tree);



            				    }
            				    break;
            				case 42 :
            				    // spinach.g:459:7: '['
            				    {
            				    	char_literal277=(IToken)Match(input,28,FOLLOW_28_in_comment2683); 
            				    		char_literal277_tree = (object)adaptor.Create(char_literal277);
            				    		adaptor.AddChild(root_0, char_literal277_tree);



            				    }
            				    break;
            				case 43 :
            				    // spinach.g:460:7: ']'
            				    {
            				    	char_literal278=(IToken)Match(input,29,FOLLOW_29_in_comment2692); 
            				    		char_literal278_tree = (object)adaptor.Create(char_literal278);
            				    		adaptor.AddChild(root_0, char_literal278_tree);



            				    }
            				    break;
            				case 44 :
            				    // spinach.g:461:7: ','
            				    {
            				    	char_literal279=(IToken)Match(input,30,FOLLOW_30_in_comment2701); 
            				    		char_literal279_tree = (object)adaptor.Create(char_literal279);
            				    		adaptor.AddChild(root_0, char_literal279_tree);



            				    }
            				    break;
            				case 45 :
            				    // spinach.g:462:7: '1D'
            				    {
            				    	string_literal280=(IToken)Match(input,47,FOLLOW_47_in_comment2710); 
            				    		string_literal280_tree = (object)adaptor.Create(string_literal280);
            				    		adaptor.AddChild(root_0, string_literal280_tree);



            				    }
            				    break;
            				case 46 :
            				    // spinach.g:463:7: '2D'
            				    {
            				    	string_literal281=(IToken)Match(input,48,FOLLOW_48_in_comment2719); 
            				    		string_literal281_tree = (object)adaptor.Create(string_literal281);
            				    		adaptor.AddChild(root_0, string_literal281_tree);



            				    }
            				    break;
            				case 47 :
            				    // spinach.g:464:7: '3D'
            				    {
            				    	string_literal282=(IToken)Match(input,49,FOLLOW_49_in_comment2728); 
            				    		string_literal282_tree = (object)adaptor.Create(string_literal282);
            				    		adaptor.AddChild(root_0, string_literal282_tree);



            				    }
            				    break;
            				case 48 :
            				    // spinach.g:465:7: 'void'
            				    {
            				    	string_literal283=(IToken)Match(input,42,FOLLOW_42_in_comment2737); 
            				    		string_literal283_tree = (object)adaptor.Create(string_literal283);
            				    		adaptor.AddChild(root_0, string_literal283_tree);



            				    }
            				    break;
            				case 49 :
            				    // spinach.g:466:7: 'struct'
            				    {
            				    	string_literal284=(IToken)Match(input,33,FOLLOW_33_in_comment2746); 
            				    		string_literal284_tree = (object)adaptor.Create(string_literal284);
            				    		adaptor.AddChild(root_0, string_literal284_tree);



            				    }
            				    break;

            				default:
            				    goto loop61;
            		    }
            		} while (true);

            		loop61:
            			;	// Stops C# compiler whining that label 'loop61' has no statements

            		string_literal285=(IToken)Match(input,55,FOLLOW_55_in_comment2766); 
            			string_literal285_tree = (object)adaptor.Create(string_literal285);
            			adaptor.AddChild(root_0, string_literal285_tree);


            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "comment"

    public class string_literal_return : ParserRuleReturnScope
    {
        public StringElement ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "string_literal"
    // spinach.g:474:1: string_literal returns [StringElement ret] : ( '\"' (el3= VARIABLE | el2= INT_LITERAL | el1= DOUBLE_LITERAL | '.' | 'matrix' | 'vector' | '<' | '>' | VARTYPE | SCALEMODE | STRINGTYPE | ASSIGNMENT | '-' | PLUS | MULTIPLY | 'subPlot' | 'plot' | 'resetPlot' | 'setPlotAxis' | 'setAxisTitle' | 'setScaleMode' | '(' | ')' | '{' | '}' | '->' | '==' | '!=' | '<=' | '&' | '^' | '$' | '#' | '@' | ';' | '!' | '?' | '/' | ':' | ',' | '1D' | '2D' | '3D' | 'void' | 'struct' )* '\"' ) ;
    public spinachParser.string_literal_return string_literal() // throws RecognitionException [1]
    {   
        spinachParser.string_literal_return retval = new spinachParser.string_literal_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken el3 = null;
        IToken el2 = null;
        IToken el1 = null;
        IToken char_literal286 = null;
        IToken char_literal287 = null;
        IToken string_literal288 = null;
        IToken string_literal289 = null;
        IToken char_literal290 = null;
        IToken char_literal291 = null;
        IToken VARTYPE292 = null;
        IToken SCALEMODE293 = null;
        IToken STRINGTYPE294 = null;
        IToken ASSIGNMENT295 = null;
        IToken char_literal296 = null;
        IToken PLUS297 = null;
        IToken MULTIPLY298 = null;
        IToken string_literal299 = null;
        IToken string_literal300 = null;
        IToken string_literal301 = null;
        IToken string_literal302 = null;
        IToken string_literal303 = null;
        IToken string_literal304 = null;
        IToken char_literal305 = null;
        IToken char_literal306 = null;
        IToken char_literal307 = null;
        IToken char_literal308 = null;
        IToken string_literal309 = null;
        IToken string_literal310 = null;
        IToken string_literal311 = null;
        IToken string_literal312 = null;
        IToken char_literal313 = null;
        IToken char_literal314 = null;
        IToken char_literal315 = null;
        IToken char_literal316 = null;
        IToken char_literal317 = null;
        IToken char_literal318 = null;
        IToken char_literal319 = null;
        IToken char_literal320 = null;
        IToken char_literal321 = null;
        IToken char_literal322 = null;
        IToken char_literal323 = null;
        IToken string_literal324 = null;
        IToken string_literal325 = null;
        IToken string_literal326 = null;
        IToken string_literal327 = null;
        IToken string_literal328 = null;
        IToken char_literal329 = null;

        object el3_tree=null;
        object el2_tree=null;
        object el1_tree=null;
        object char_literal286_tree=null;
        object char_literal287_tree=null;
        object string_literal288_tree=null;
        object string_literal289_tree=null;
        object char_literal290_tree=null;
        object char_literal291_tree=null;
        object VARTYPE292_tree=null;
        object SCALEMODE293_tree=null;
        object STRINGTYPE294_tree=null;
        object ASSIGNMENT295_tree=null;
        object char_literal296_tree=null;
        object PLUS297_tree=null;
        object MULTIPLY298_tree=null;
        object string_literal299_tree=null;
        object string_literal300_tree=null;
        object string_literal301_tree=null;
        object string_literal302_tree=null;
        object string_literal303_tree=null;
        object string_literal304_tree=null;
        object char_literal305_tree=null;
        object char_literal306_tree=null;
        object char_literal307_tree=null;
        object char_literal308_tree=null;
        object string_literal309_tree=null;
        object string_literal310_tree=null;
        object string_literal311_tree=null;
        object string_literal312_tree=null;
        object char_literal313_tree=null;
        object char_literal314_tree=null;
        object char_literal315_tree=null;
        object char_literal316_tree=null;
        object char_literal317_tree=null;
        object char_literal318_tree=null;
        object char_literal319_tree=null;
        object char_literal320_tree=null;
        object char_literal321_tree=null;
        object char_literal322_tree=null;
        object char_literal323_tree=null;
        object string_literal324_tree=null;
        object string_literal325_tree=null;
        object string_literal326_tree=null;
        object string_literal327_tree=null;
        object string_literal328_tree=null;
        object char_literal329_tree=null;


         retval.ret = new StringElement();

        try 
    	{
            // spinach.g:478:2: ( ( '\"' (el3= VARIABLE | el2= INT_LITERAL | el1= DOUBLE_LITERAL | '.' | 'matrix' | 'vector' | '<' | '>' | VARTYPE | SCALEMODE | STRINGTYPE | ASSIGNMENT | '-' | PLUS | MULTIPLY | 'subPlot' | 'plot' | 'resetPlot' | 'setPlotAxis' | 'setAxisTitle' | 'setScaleMode' | '(' | ')' | '{' | '}' | '->' | '==' | '!=' | '<=' | '&' | '^' | '$' | '#' | '@' | ';' | '!' | '?' | '/' | ':' | ',' | '1D' | '2D' | '3D' | 'void' | 'struct' )* '\"' ) )
            // spinach.g:478:3: ( '\"' (el3= VARIABLE | el2= INT_LITERAL | el1= DOUBLE_LITERAL | '.' | 'matrix' | 'vector' | '<' | '>' | VARTYPE | SCALEMODE | STRINGTYPE | ASSIGNMENT | '-' | PLUS | MULTIPLY | 'subPlot' | 'plot' | 'resetPlot' | 'setPlotAxis' | 'setAxisTitle' | 'setScaleMode' | '(' | ')' | '{' | '}' | '->' | '==' | '!=' | '<=' | '&' | '^' | '$' | '#' | '@' | ';' | '!' | '?' | '/' | ':' | ',' | '1D' | '2D' | '3D' | 'void' | 'struct' )* '\"' )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// spinach.g:478:3: ( '\"' (el3= VARIABLE | el2= INT_LITERAL | el1= DOUBLE_LITERAL | '.' | 'matrix' | 'vector' | '<' | '>' | VARTYPE | SCALEMODE | STRINGTYPE | ASSIGNMENT | '-' | PLUS | MULTIPLY | 'subPlot' | 'plot' | 'resetPlot' | 'setPlotAxis' | 'setAxisTitle' | 'setScaleMode' | '(' | ')' | '{' | '}' | '->' | '==' | '!=' | '<=' | '&' | '^' | '$' | '#' | '@' | ';' | '!' | '?' | '/' | ':' | ',' | '1D' | '2D' | '3D' | 'void' | 'struct' )* '\"' )
            	// spinach.g:478:4: '\"' (el3= VARIABLE | el2= INT_LITERAL | el1= DOUBLE_LITERAL | '.' | 'matrix' | 'vector' | '<' | '>' | VARTYPE | SCALEMODE | STRINGTYPE | ASSIGNMENT | '-' | PLUS | MULTIPLY | 'subPlot' | 'plot' | 'resetPlot' | 'setPlotAxis' | 'setAxisTitle' | 'setScaleMode' | '(' | ')' | '{' | '}' | '->' | '==' | '!=' | '<=' | '&' | '^' | '$' | '#' | '@' | ';' | '!' | '?' | '/' | ':' | ',' | '1D' | '2D' | '3D' | 'void' | 'struct' )* '\"'
            	{
            		char_literal286=(IToken)Match(input,57,FOLLOW_57_in_string_literal2787); 
            			char_literal286_tree = (object)adaptor.Create(char_literal286);
            			adaptor.AddChild(root_0, char_literal286_tree);

            		// spinach.g:479:2: (el3= VARIABLE | el2= INT_LITERAL | el1= DOUBLE_LITERAL | '.' | 'matrix' | 'vector' | '<' | '>' | VARTYPE | SCALEMODE | STRINGTYPE | ASSIGNMENT | '-' | PLUS | MULTIPLY | 'subPlot' | 'plot' | 'resetPlot' | 'setPlotAxis' | 'setAxisTitle' | 'setScaleMode' | '(' | ')' | '{' | '}' | '->' | '==' | '!=' | '<=' | '&' | '^' | '$' | '#' | '@' | ';' | '!' | '?' | '/' | ':' | ',' | '1D' | '2D' | '3D' | 'void' | 'struct' )*
            		do 
            		{
            		    int alt62 = 46;
            		    switch ( input.LA(1) ) 
            		    {
            		    case VARIABLE:
            		    	{
            		        alt62 = 1;
            		        }
            		        break;
            		    case INT_LITERAL:
            		    	{
            		        alt62 = 2;
            		        }
            		        break;
            		    case DOUBLE_LITERAL:
            		    	{
            		        alt62 = 3;
            		        }
            		        break;
            		    case DOT:
            		    	{
            		        alt62 = 4;
            		        }
            		        break;
            		    case 27:
            		    	{
            		        alt62 = 5;
            		        }
            		        break;
            		    case 31:
            		    	{
            		        alt62 = 6;
            		        }
            		        break;
            		    case LESSTHANEXPRESSION:
            		    	{
            		        alt62 = 7;
            		        }
            		        break;
            		    case GREATERTHANEXPRESSION:
            		    	{
            		        alt62 = 8;
            		        }
            		        break;
            		    case VARTYPE:
            		    	{
            		        alt62 = 9;
            		        }
            		        break;
            		    case SCALEMODE:
            		    	{
            		        alt62 = 10;
            		        }
            		        break;
            		    case STRINGTYPE:
            		    	{
            		        alt62 = 11;
            		        }
            		        break;
            		    case ASSIGNMENT:
            		    	{
            		        alt62 = 12;
            		        }
            		        break;
            		    case 32:
            		    	{
            		        alt62 = 13;
            		        }
            		        break;
            		    case PLUS:
            		    	{
            		        alt62 = 14;
            		        }
            		        break;
            		    case MULTIPLY:
            		    	{
            		        alt62 = 15;
            		        }
            		        break;
            		    case 46:
            		    	{
            		        alt62 = 16;
            		        }
            		        break;
            		    case 50:
            		    	{
            		        alt62 = 17;
            		        }
            		        break;
            		    case 51:
            		    	{
            		        alt62 = 18;
            		        }
            		        break;
            		    case 52:
            		    	{
            		        alt62 = 19;
            		        }
            		        break;
            		    case 53:
            		    	{
            		        alt62 = 20;
            		        }
            		        break;
            		    case 56:
            		    	{
            		        alt62 = 21;
            		        }
            		        break;
            		    case LEFTBRACE:
            		    	{
            		        alt62 = 22;
            		        }
            		        break;
            		    case RIGHTBRACE:
            		    	{
            		        alt62 = 23;
            		        }
            		        break;
            		    case LEFTPARANTHESIS:
            		    	{
            		        alt62 = 24;
            		        }
            		        break;
            		    case RIGHTPARANTHESIS:
            		    	{
            		        alt62 = 25;
            		        }
            		        break;
            		    case POINT:
            		    	{
            		        alt62 = 26;
            		        }
            		        break;
            		    case EQUALITYEXPRESSION:
            		    	{
            		        alt62 = 27;
            		        }
            		        break;
            		    case NONEQUALITYEXPRESSION:
            		    	{
            		        alt62 = 28;
            		        }
            		        break;
            		    case LESSTHANEQUALTOEXPRESSION:
            		    	{
            		        alt62 = 29;
            		        }
            		        break;
            		    case 58:
            		    	{
            		        alt62 = 30;
            		        }
            		        break;
            		    case 60:
            		    	{
            		        alt62 = 31;
            		        }
            		        break;
            		    case 61:
            		    	{
            		        alt62 = 32;
            		        }
            		        break;
            		    case 62:
            		    	{
            		        alt62 = 33;
            		        }
            		        break;
            		    case 63:
            		    	{
            		        alt62 = 34;
            		        }
            		        break;
            		    case END_OF_STATEMENT:
            		    	{
            		        alt62 = 35;
            		        }
            		        break;
            		    case 64:
            		    	{
            		        alt62 = 36;
            		        }
            		        break;
            		    case 65:
            		    	{
            		        alt62 = 37;
            		        }
            		        break;
            		    case 66:
            		    	{
            		        alt62 = 38;
            		        }
            		        break;
            		    case 59:
            		    	{
            		        alt62 = 39;
            		        }
            		        break;
            		    case 30:
            		    	{
            		        alt62 = 40;
            		        }
            		        break;
            		    case 47:
            		    	{
            		        alt62 = 41;
            		        }
            		        break;
            		    case 48:
            		    	{
            		        alt62 = 42;
            		        }
            		        break;
            		    case 49:
            		    	{
            		        alt62 = 43;
            		        }
            		        break;
            		    case 42:
            		    	{
            		        alt62 = 44;
            		        }
            		        break;
            		    case 33:
            		    	{
            		        alt62 = 45;
            		        }
            		        break;

            		    }

            		    switch (alt62) 
            			{
            				case 1 :
            				    // spinach.g:479:3: el3= VARIABLE
            				    {
            				    	el3=(IToken)Match(input,VARIABLE,FOLLOW_VARIABLE_in_string_literal2793); 
            				    		el3_tree = (object)adaptor.Create(el3);
            				    		adaptor.AddChild(root_0, el3_tree);

            				    	retval.ret.setText(((el3 != null) ? el3.Text : null));

            				    }
            				    break;
            				case 2 :
            				    // spinach.g:480:3: el2= INT_LITERAL
            				    {
            				    	el2=(IToken)Match(input,INT_LITERAL,FOLLOW_INT_LITERAL_in_string_literal2800); 
            				    		el2_tree = (object)adaptor.Create(el2);
            				    		adaptor.AddChild(root_0, el2_tree);

            				    	retval.ret.setText(((el2 != null) ? el2.Text : null));

            				    }
            				    break;
            				case 3 :
            				    // spinach.g:481:3: el1= DOUBLE_LITERAL
            				    {
            				    	el1=(IToken)Match(input,DOUBLE_LITERAL,FOLLOW_DOUBLE_LITERAL_in_string_literal2807); 
            				    		el1_tree = (object)adaptor.Create(el1);
            				    		adaptor.AddChild(root_0, el1_tree);

            				    	retval.ret.setText(((el1 != null) ? el1.Text : null));

            				    }
            				    break;
            				case 4 :
            				    // spinach.g:482:3: '.'
            				    {
            				    	char_literal287=(IToken)Match(input,DOT,FOLLOW_DOT_in_string_literal2812); 
            				    		char_literal287_tree = (object)adaptor.Create(char_literal287);
            				    		adaptor.AddChild(root_0, char_literal287_tree);

            				    	retval.ret.setText(".");

            				    }
            				    break;
            				case 5 :
            				    // spinach.g:483:3: 'matrix'
            				    {
            				    	string_literal288=(IToken)Match(input,27,FOLLOW_27_in_string_literal2817); 
            				    		string_literal288_tree = (object)adaptor.Create(string_literal288);
            				    		adaptor.AddChild(root_0, string_literal288_tree);

            				    	retval.ret.setText("matrix");

            				    }
            				    break;
            				case 6 :
            				    // spinach.g:484:3: 'vector'
            				    {
            				    	string_literal289=(IToken)Match(input,31,FOLLOW_31_in_string_literal2822); 
            				    		string_literal289_tree = (object)adaptor.Create(string_literal289);
            				    		adaptor.AddChild(root_0, string_literal289_tree);

            				    	retval.ret.setText("vector");

            				    }
            				    break;
            				case 7 :
            				    // spinach.g:485:3: '<'
            				    {
            				    	char_literal290=(IToken)Match(input,LESSTHANEXPRESSION,FOLLOW_LESSTHANEXPRESSION_in_string_literal2827); 
            				    		char_literal290_tree = (object)adaptor.Create(char_literal290);
            				    		adaptor.AddChild(root_0, char_literal290_tree);

            				    	retval.ret.setText("<");

            				    }
            				    break;
            				case 8 :
            				    // spinach.g:486:3: '>'
            				    {
            				    	char_literal291=(IToken)Match(input,GREATERTHANEXPRESSION,FOLLOW_GREATERTHANEXPRESSION_in_string_literal2832); 
            				    		char_literal291_tree = (object)adaptor.Create(char_literal291);
            				    		adaptor.AddChild(root_0, char_literal291_tree);

            				    	retval.ret.setText(">");

            				    }
            				    break;
            				case 9 :
            				    // spinach.g:487:3: VARTYPE
            				    {
            				    	VARTYPE292=(IToken)Match(input,VARTYPE,FOLLOW_VARTYPE_in_string_literal2837); 
            				    		VARTYPE292_tree = (object)adaptor.Create(VARTYPE292);
            				    		adaptor.AddChild(root_0, VARTYPE292_tree);

            				    	retval.ret.setText(((VARTYPE292 != null) ? VARTYPE292.Text : null));

            				    }
            				    break;
            				case 10 :
            				    // spinach.g:488:3: SCALEMODE
            				    {
            				    	SCALEMODE293=(IToken)Match(input,SCALEMODE,FOLLOW_SCALEMODE_in_string_literal2842); 
            				    		SCALEMODE293_tree = (object)adaptor.Create(SCALEMODE293);
            				    		adaptor.AddChild(root_0, SCALEMODE293_tree);

            				    	retval.ret.setText(((SCALEMODE293 != null) ? SCALEMODE293.Text : null));

            				    }
            				    break;
            				case 11 :
            				    // spinach.g:489:3: STRINGTYPE
            				    {
            				    	STRINGTYPE294=(IToken)Match(input,STRINGTYPE,FOLLOW_STRINGTYPE_in_string_literal2847); 
            				    		STRINGTYPE294_tree = (object)adaptor.Create(STRINGTYPE294);
            				    		adaptor.AddChild(root_0, STRINGTYPE294_tree);

            				    	retval.ret.setText(((STRINGTYPE294 != null) ? STRINGTYPE294.Text : null));

            				    }
            				    break;
            				case 12 :
            				    // spinach.g:490:3: ASSIGNMENT
            				    {
            				    	ASSIGNMENT295=(IToken)Match(input,ASSIGNMENT,FOLLOW_ASSIGNMENT_in_string_literal2852); 
            				    		ASSIGNMENT295_tree = (object)adaptor.Create(ASSIGNMENT295);
            				    		adaptor.AddChild(root_0, ASSIGNMENT295_tree);

            				    	retval.ret.setText(((ASSIGNMENT295 != null) ? ASSIGNMENT295.Text : null));

            				    }
            				    break;
            				case 13 :
            				    // spinach.g:491:3: '-'
            				    {
            				    	char_literal296=(IToken)Match(input,32,FOLLOW_32_in_string_literal2857); 
            				    		char_literal296_tree = (object)adaptor.Create(char_literal296);
            				    		adaptor.AddChild(root_0, char_literal296_tree);

            				    	retval.ret.setText("-");

            				    }
            				    break;
            				case 14 :
            				    // spinach.g:492:3: PLUS
            				    {
            				    	PLUS297=(IToken)Match(input,PLUS,FOLLOW_PLUS_in_string_literal2862); 
            				    		PLUS297_tree = (object)adaptor.Create(PLUS297);
            				    		adaptor.AddChild(root_0, PLUS297_tree);

            				    	retval.ret.setText(((PLUS297 != null) ? PLUS297.Text : null));

            				    }
            				    break;
            				case 15 :
            				    // spinach.g:493:3: MULTIPLY
            				    {
            				    	MULTIPLY298=(IToken)Match(input,MULTIPLY,FOLLOW_MULTIPLY_in_string_literal2867); 
            				    		MULTIPLY298_tree = (object)adaptor.Create(MULTIPLY298);
            				    		adaptor.AddChild(root_0, MULTIPLY298_tree);

            				    	retval.ret.setText(((MULTIPLY298 != null) ? MULTIPLY298.Text : null));

            				    }
            				    break;
            				case 16 :
            				    // spinach.g:494:3: 'subPlot'
            				    {
            				    	string_literal299=(IToken)Match(input,46,FOLLOW_46_in_string_literal2872); 
            				    		string_literal299_tree = (object)adaptor.Create(string_literal299);
            				    		adaptor.AddChild(root_0, string_literal299_tree);

            				    	retval.ret.setText("subPlot");

            				    }
            				    break;
            				case 17 :
            				    // spinach.g:495:2: 'plot'
            				    {
            				    	string_literal300=(IToken)Match(input,50,FOLLOW_50_in_string_literal2876); 
            				    		string_literal300_tree = (object)adaptor.Create(string_literal300);
            				    		adaptor.AddChild(root_0, string_literal300_tree);

            				    	retval.ret.setText("plot");

            				    }
            				    break;
            				case 18 :
            				    // spinach.g:496:2: 'resetPlot'
            				    {
            				    	string_literal301=(IToken)Match(input,51,FOLLOW_51_in_string_literal2880); 
            				    		string_literal301_tree = (object)adaptor.Create(string_literal301);
            				    		adaptor.AddChild(root_0, string_literal301_tree);

            				    	retval.ret.setText("resetPlot");

            				    }
            				    break;
            				case 19 :
            				    // spinach.g:497:2: 'setPlotAxis'
            				    {
            				    	string_literal302=(IToken)Match(input,52,FOLLOW_52_in_string_literal2884); 
            				    		string_literal302_tree = (object)adaptor.Create(string_literal302);
            				    		adaptor.AddChild(root_0, string_literal302_tree);

            				    	retval.ret.setText("setPlotAxis");

            				    }
            				    break;
            				case 20 :
            				    // spinach.g:498:2: 'setAxisTitle'
            				    {
            				    	string_literal303=(IToken)Match(input,53,FOLLOW_53_in_string_literal2888); 
            				    		string_literal303_tree = (object)adaptor.Create(string_literal303);
            				    		adaptor.AddChild(root_0, string_literal303_tree);

            				    	retval.ret.setText("setAxisTitle");

            				    }
            				    break;
            				case 21 :
            				    // spinach.g:499:2: 'setScaleMode'
            				    {
            				    	string_literal304=(IToken)Match(input,56,FOLLOW_56_in_string_literal2892); 
            				    		string_literal304_tree = (object)adaptor.Create(string_literal304);
            				    		adaptor.AddChild(root_0, string_literal304_tree);

            				    	retval.ret.setText("setScaleMode");

            				    }
            				    break;
            				case 22 :
            				    // spinach.g:500:3: '('
            				    {
            				    	char_literal305=(IToken)Match(input,LEFTBRACE,FOLLOW_LEFTBRACE_in_string_literal2897); 
            				    		char_literal305_tree = (object)adaptor.Create(char_literal305);
            				    		adaptor.AddChild(root_0, char_literal305_tree);

            				    	retval.ret.setText("(");

            				    }
            				    break;
            				case 23 :
            				    // spinach.g:501:3: ')'
            				    {
            				    	char_literal306=(IToken)Match(input,RIGHTBRACE,FOLLOW_RIGHTBRACE_in_string_literal2902); 
            				    		char_literal306_tree = (object)adaptor.Create(char_literal306);
            				    		adaptor.AddChild(root_0, char_literal306_tree);

            				    	retval.ret.setText(")");

            				    }
            				    break;
            				case 24 :
            				    // spinach.g:502:3: '{'
            				    {
            				    	char_literal307=(IToken)Match(input,LEFTPARANTHESIS,FOLLOW_LEFTPARANTHESIS_in_string_literal2907); 
            				    		char_literal307_tree = (object)adaptor.Create(char_literal307);
            				    		adaptor.AddChild(root_0, char_literal307_tree);

            				    	retval.ret.setText("{");

            				    }
            				    break;
            				case 25 :
            				    // spinach.g:503:3: '}'
            				    {
            				    	char_literal308=(IToken)Match(input,RIGHTPARANTHESIS,FOLLOW_RIGHTPARANTHESIS_in_string_literal2912); 
            				    		char_literal308_tree = (object)adaptor.Create(char_literal308);
            				    		adaptor.AddChild(root_0, char_literal308_tree);

            				    	retval.ret.setText("}");

            				    }
            				    break;
            				case 26 :
            				    // spinach.g:504:3: '->'
            				    {
            				    	string_literal309=(IToken)Match(input,POINT,FOLLOW_POINT_in_string_literal2917); 
            				    		string_literal309_tree = (object)adaptor.Create(string_literal309);
            				    		adaptor.AddChild(root_0, string_literal309_tree);

            				    	retval.ret.setText("->");

            				    }
            				    break;
            				case 27 :
            				    // spinach.g:505:3: '=='
            				    {
            				    	string_literal310=(IToken)Match(input,EQUALITYEXPRESSION,FOLLOW_EQUALITYEXPRESSION_in_string_literal2922); 
            				    		string_literal310_tree = (object)adaptor.Create(string_literal310);
            				    		adaptor.AddChild(root_0, string_literal310_tree);

            				    	retval.ret.setText("==");

            				    }
            				    break;
            				case 28 :
            				    // spinach.g:506:3: '!='
            				    {
            				    	string_literal311=(IToken)Match(input,NONEQUALITYEXPRESSION,FOLLOW_NONEQUALITYEXPRESSION_in_string_literal2927); 
            				    		string_literal311_tree = (object)adaptor.Create(string_literal311);
            				    		adaptor.AddChild(root_0, string_literal311_tree);

            				    	retval.ret.setText("!=");

            				    }
            				    break;
            				case 29 :
            				    // spinach.g:507:3: '<='
            				    {
            				    	string_literal312=(IToken)Match(input,LESSTHANEQUALTOEXPRESSION,FOLLOW_LESSTHANEQUALTOEXPRESSION_in_string_literal2932); 
            				    		string_literal312_tree = (object)adaptor.Create(string_literal312);
            				    		adaptor.AddChild(root_0, string_literal312_tree);

            				    	retval.ret.setText("<=");

            				    }
            				    break;
            				case 30 :
            				    // spinach.g:508:4: '&'
            				    {
            				    	char_literal313=(IToken)Match(input,58,FOLLOW_58_in_string_literal2938); 
            				    		char_literal313_tree = (object)adaptor.Create(char_literal313);
            				    		adaptor.AddChild(root_0, char_literal313_tree);

            				    	retval.ret.setText("&");

            				    }
            				    break;
            				case 31 :
            				    // spinach.g:510:5: '^'
            				    {
            				    	char_literal314=(IToken)Match(input,60,FOLLOW_60_in_string_literal2949); 
            				    		char_literal314_tree = (object)adaptor.Create(char_literal314);
            				    		adaptor.AddChild(root_0, char_literal314_tree);

            				    	retval.ret.setText("^");

            				    }
            				    break;
            				case 32 :
            				    // spinach.g:511:5: '$'
            				    {
            				    	char_literal315=(IToken)Match(input,61,FOLLOW_61_in_string_literal2956); 
            				    		char_literal315_tree = (object)adaptor.Create(char_literal315);
            				    		adaptor.AddChild(root_0, char_literal315_tree);

            				    	retval.ret.setText("$");

            				    }
            				    break;
            				case 33 :
            				    // spinach.g:512:5: '#'
            				    {
            				    	char_literal316=(IToken)Match(input,62,FOLLOW_62_in_string_literal2963); 
            				    		char_literal316_tree = (object)adaptor.Create(char_literal316);
            				    		adaptor.AddChild(root_0, char_literal316_tree);

            				    	retval.ret.setText("#");

            				    }
            				    break;
            				case 34 :
            				    // spinach.g:513:5: '@'
            				    {
            				    	char_literal317=(IToken)Match(input,63,FOLLOW_63_in_string_literal2970); 
            				    		char_literal317_tree = (object)adaptor.Create(char_literal317);
            				    		adaptor.AddChild(root_0, char_literal317_tree);

            				    	retval.ret.setText("@");

            				    }
            				    break;
            				case 35 :
            				    // spinach.g:514:5: ';'
            				    {
            				    	char_literal318=(IToken)Match(input,END_OF_STATEMENT,FOLLOW_END_OF_STATEMENT_in_string_literal2977); 
            				    		char_literal318_tree = (object)adaptor.Create(char_literal318);
            				    		adaptor.AddChild(root_0, char_literal318_tree);

            				    	retval.ret.setText(";");

            				    }
            				    break;
            				case 36 :
            				    // spinach.g:515:5: '!'
            				    {
            				    	char_literal319=(IToken)Match(input,64,FOLLOW_64_in_string_literal2984); 
            				    		char_literal319_tree = (object)adaptor.Create(char_literal319);
            				    		adaptor.AddChild(root_0, char_literal319_tree);

            				    	retval.ret.setText("!");

            				    }
            				    break;
            				case 37 :
            				    // spinach.g:516:6: '?'
            				    {
            				    	char_literal320=(IToken)Match(input,65,FOLLOW_65_in_string_literal2992); 
            				    		char_literal320_tree = (object)adaptor.Create(char_literal320);
            				    		adaptor.AddChild(root_0, char_literal320_tree);

            				    	retval.ret.setText("?");

            				    }
            				    break;
            				case 38 :
            				    // spinach.g:517:7: '/'
            				    {
            				    	char_literal321=(IToken)Match(input,66,FOLLOW_66_in_string_literal3001); 
            				    		char_literal321_tree = (object)adaptor.Create(char_literal321);
            				    		adaptor.AddChild(root_0, char_literal321_tree);

            				    	retval.ret.setText("/");

            				    }
            				    break;
            				case 39 :
            				    // spinach.g:518:10: ':'
            				    {
            				    	char_literal322=(IToken)Match(input,59,FOLLOW_59_in_string_literal3013); 
            				    		char_literal322_tree = (object)adaptor.Create(char_literal322);
            				    		adaptor.AddChild(root_0, char_literal322_tree);

            				    	retval.ret.setText(":");

            				    }
            				    break;
            				case 40 :
            				    // spinach.g:519:12: ','
            				    {
            				    	char_literal323=(IToken)Match(input,30,FOLLOW_30_in_string_literal3027); 
            				    		char_literal323_tree = (object)adaptor.Create(char_literal323);
            				    		adaptor.AddChild(root_0, char_literal323_tree);

            				    	retval.ret.setText(",");

            				    }
            				    break;
            				case 41 :
            				    // spinach.g:520:14: '1D'
            				    {
            				    	string_literal324=(IToken)Match(input,47,FOLLOW_47_in_string_literal3043); 
            				    		string_literal324_tree = (object)adaptor.Create(string_literal324);
            				    		adaptor.AddChild(root_0, string_literal324_tree);

            				    	retval.ret.setText("1D");

            				    }
            				    break;
            				case 42 :
            				    // spinach.g:521:16: '2D'
            				    {
            				    	string_literal325=(IToken)Match(input,48,FOLLOW_48_in_string_literal3061); 
            				    		string_literal325_tree = (object)adaptor.Create(string_literal325);
            				    		adaptor.AddChild(root_0, string_literal325_tree);

            				    	retval.ret.setText("2D");

            				    }
            				    break;
            				case 43 :
            				    // spinach.g:522:18: '3D'
            				    {
            				    	string_literal326=(IToken)Match(input,49,FOLLOW_49_in_string_literal3081); 
            				    		string_literal326_tree = (object)adaptor.Create(string_literal326);
            				    		adaptor.AddChild(root_0, string_literal326_tree);

            				    	retval.ret.setText("3D");

            				    }
            				    break;
            				case 44 :
            				    // spinach.g:523:11: 'void'
            				    {
            				    	string_literal327=(IToken)Match(input,42,FOLLOW_42_in_string_literal3094); 
            				    		string_literal327_tree = (object)adaptor.Create(string_literal327);
            				    		adaptor.AddChild(root_0, string_literal327_tree);

            				    	retval.ret.setText("void");

            				    }
            				    break;
            				case 45 :
            				    // spinach.g:524:9: 'struct'
            				    {
            				    	string_literal328=(IToken)Match(input,33,FOLLOW_33_in_string_literal3105); 
            				    		string_literal328_tree = (object)adaptor.Create(string_literal328);
            				    		adaptor.AddChild(root_0, string_literal328_tree);

            				    	retval.ret.setText("struct");

            				    }
            				    break;

            				default:
            				    goto loop62;
            		    }
            		} while (true);

            		loop62:
            			;	// Stops C# compiler whining that label 'loop62' has no statements

            		char_literal329=(IToken)Match(input,57,FOLLOW_57_in_string_literal3115); 
            			char_literal329_tree = (object)adaptor.Create(char_literal329);
            			adaptor.AddChild(root_0, char_literal329_tree);


            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "string_literal"

    // Delegated rules


   	protected DFA7 dfa7;
   	protected DFA17 dfa17;
   	protected DFA44 dfa44;
   	protected DFA48 dfa48;
	private void InitializeCyclicDFAs()
	{
    	this.dfa7 = new DFA7(this);
    	this.dfa17 = new DFA17(this);
    	this.dfa44 = new DFA44(this);
    	this.dfa48 = new DFA48(this);




	}

    const string DFA7_eotS =
        "\x0a\uffff";
    const string DFA7_eofS =
        "\x0a\uffff";
    const string DFA7_minS =
        "\x01\x04\x01\x09\x01\uffff\x01\x04\x01\uffff\x02\x1d\x01\x09\x02"+
        "\uffff";
    const string DFA7_maxS =
        "\x01\x04\x01\x20\x01\uffff\x01\x05\x01\uffff\x02\x1d\x01\x20\x02"+
        "\uffff";
    const string DFA7_acceptS =
        "\x02\uffff\x01\x04\x01\uffff\x01\x01\x03\uffff\x01\x02\x01\x03";
    const string DFA7_specialS =
        "\x0a\uffff}>";
    static readonly string[] DFA7_transitionS = {
            "\x01\x01",
            "\x01\x04\x03\uffff\x01\x04\x03\uffff\x02\x04\x01\x02\x01\uffff"+
            "\x06\x04\x01\uffff\x01\x03\x01\uffff\x01\x04\x01\uffff\x01\x04",
            "",
            "\x01\x06\x01\x05",
            "",
            "\x01\x07",
            "\x01\x07",
            "\x01\x09\x03\uffff\x01\x09\x03\uffff\x02\x09\x02\uffff\x06"+
            "\x09\x01\uffff\x01\x08\x01\uffff\x01\x09\x01\uffff\x01\x09",
            "",
            ""
    };

    static readonly short[] DFA7_eot = DFA.UnpackEncodedString(DFA7_eotS);
    static readonly short[] DFA7_eof = DFA.UnpackEncodedString(DFA7_eofS);
    static readonly char[] DFA7_min = DFA.UnpackEncodedStringToUnsignedChars(DFA7_minS);
    static readonly char[] DFA7_max = DFA.UnpackEncodedStringToUnsignedChars(DFA7_maxS);
    static readonly short[] DFA7_accept = DFA.UnpackEncodedString(DFA7_acceptS);
    static readonly short[] DFA7_special = DFA.UnpackEncodedString(DFA7_specialS);
    static readonly short[][] DFA7_transition = DFA.UnpackEncodedStringArray(DFA7_transitionS);

    protected class DFA7 : DFA
    {
        public DFA7(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 7;
            this.eot = DFA7_eot;
            this.eof = DFA7_eof;
            this.min = DFA7_min;
            this.max = DFA7_max;
            this.accept = DFA7_accept;
            this.special = DFA7_special;
            this.transition = DFA7_transition;

        }

        override public string Description
        {
            get { return "69:3: ( variable | matrixelem | vectorelem | structassign )"; }
        }

    }

    const string DFA17_eotS =
        "\x0a\uffff";
    const string DFA17_eofS =
        "\x0a\uffff";
    const string DFA17_minS =
        "\x01\x04\x01\x08\x02\uffff\x01\x04\x02\x1d\x01\x08\x02\uffff";
    const string DFA17_maxS =
        "\x01\x04\x01\x1c\x02\uffff\x01\x05\x02\x1d\x01\x1c\x02\uffff";
    const string DFA17_acceptS =
        "\x02\uffff\x01\x02\x01\x01\x04\uffff\x01\x04\x01\x03";
    const string DFA17_specialS =
        "\x0a\uffff}>";
    static readonly string[] DFA17_transitionS = {
            "\x01\x01",
            "\x01\x03\x0a\uffff\x01\x02\x08\uffff\x01\x04",
            "",
            "",
            "\x01\x06\x01\x05",
            "\x01\x07",
            "\x01\x07",
            "\x01\x09\x13\uffff\x01\x08",
            "",
            ""
    };

    static readonly short[] DFA17_eot = DFA.UnpackEncodedString(DFA17_eotS);
    static readonly short[] DFA17_eof = DFA.UnpackEncodedString(DFA17_eofS);
    static readonly char[] DFA17_min = DFA.UnpackEncodedStringToUnsignedChars(DFA17_minS);
    static readonly char[] DFA17_max = DFA.UnpackEncodedStringToUnsignedChars(DFA17_maxS);
    static readonly short[] DFA17_accept = DFA.UnpackEncodedString(DFA17_acceptS);
    static readonly short[] DFA17_special = DFA.UnpackEncodedString(DFA17_specialS);
    static readonly short[][] DFA17_transition = DFA.UnpackEncodedStringArray(DFA17_transitionS);

    protected class DFA17 : DFA
    {
        public DFA17(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 17;
            this.eot = DFA17_eot;
            this.eof = DFA17_eof;
            this.min = DFA17_min;
            this.max = DFA17_max;
            this.accept = DFA17_accept;
            this.special = DFA17_special;
            this.transition = DFA17_transition;

        }

        override public string Description
        {
            get { return "142:6: ( variable | structassign | e12= vectorelem | e11= matrixelem )"; }
        }

    }

    const string DFA44_eotS =
        "\x0e\uffff";
    const string DFA44_eofS =
        "\x0e\uffff";
    const string DFA44_minS =
        "\x01\x04\x01\uffff\x01\x08\x0b\uffff";
    const string DFA44_maxS =
        "\x01\x2d\x01\uffff\x01\x1c\x0b\uffff";
    const string DFA44_acceptS =
        "\x01\uffff\x01\x0c\x01\uffff\x01\x03\x01\x04\x01\x05\x01\x06\x01"+
        "\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x01\x01\x02";
    const string DFA44_specialS =
        "\x0e\uffff}>";
    static readonly string[] DFA44_transitionS = {
            "\x01\x02\x02\uffff\x01\x03\x02\uffff\x01\x03\x04\uffff\x01"+
            "\x01\x0b\uffff\x01\x05\x03\uffff\x01\x04\x02\uffff\x01\x06\x01"+
            "\x07\x01\x0a\x02\uffff\x01\x08\x01\uffff\x01\x0b\x03\uffff\x01"+
            "\x09",
            "",
            "\x01\x0c\x02\uffff\x01\x0d\x07\uffff\x01\x0c\x08\uffff\x01"+
            "\x0c",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA44_eot = DFA.UnpackEncodedString(DFA44_eotS);
    static readonly short[] DFA44_eof = DFA.UnpackEncodedString(DFA44_eofS);
    static readonly char[] DFA44_min = DFA.UnpackEncodedStringToUnsignedChars(DFA44_minS);
    static readonly char[] DFA44_max = DFA.UnpackEncodedStringToUnsignedChars(DFA44_maxS);
    static readonly short[] DFA44_accept = DFA.UnpackEncodedString(DFA44_acceptS);
    static readonly short[] DFA44_special = DFA.UnpackEncodedString(DFA44_specialS);
    static readonly short[][] DFA44_transition = DFA.UnpackEncodedStringArray(DFA44_transitionS);

    protected class DFA44 : DFA
    {
        public DFA44(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 44;
            this.eot = DFA44_eot;
            this.eof = DFA44_eof;
            this.min = DFA44_min;
            this.max = DFA44_max;
            this.accept = DFA44_accept;
            this.special = DFA44_special;
            this.transition = DFA44_transition;

        }

        override public string Description
        {
            get { return "()+ loopback of 300:6: ( assignment | functioncall | scalarvardec | vectorvardec | matrixvardec | deletionofvar | print | ifelse | functionreturn | parallelfor | forstatement )+"; }
        }

    }

    const string DFA48_eotS =
        "\x0e\uffff";
    const string DFA48_eofS =
        "\x0e\uffff";
    const string DFA48_minS =
        "\x01\x04\x01\uffff\x01\x08\x0b\uffff";
    const string DFA48_maxS =
        "\x01\x2d\x01\uffff\x01\x1c\x0b\uffff";
    const string DFA48_acceptS =
        "\x01\uffff\x01\x0c\x01\uffff\x01\x03\x01\x04\x01\x05\x01\x06\x01"+
        "\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x01\x01\x02";
    const string DFA48_specialS =
        "\x0e\uffff}>";
    static readonly string[] DFA48_transitionS = {
            "\x01\x02\x02\uffff\x01\x03\x02\uffff\x01\x03\x04\uffff\x01"+
            "\x01\x0b\uffff\x01\x05\x03\uffff\x01\x04\x02\uffff\x01\x06\x01"+
            "\x07\x01\x0a\x02\uffff\x01\x08\x01\uffff\x01\x0b\x03\uffff\x01"+
            "\x09",
            "",
            "\x01\x0c\x02\uffff\x01\x0d\x07\uffff\x01\x0c\x08\uffff\x01"+
            "\x0c",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA48_eot = DFA.UnpackEncodedString(DFA48_eotS);
    static readonly short[] DFA48_eof = DFA.UnpackEncodedString(DFA48_eofS);
    static readonly char[] DFA48_min = DFA.UnpackEncodedStringToUnsignedChars(DFA48_minS);
    static readonly char[] DFA48_max = DFA.UnpackEncodedStringToUnsignedChars(DFA48_maxS);
    static readonly short[] DFA48_accept = DFA.UnpackEncodedString(DFA48_acceptS);
    static readonly short[] DFA48_special = DFA.UnpackEncodedString(DFA48_specialS);
    static readonly short[][] DFA48_transition = DFA.UnpackEncodedStringArray(DFA48_transitionS);

    protected class DFA48 : DFA
    {
        public DFA48(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 48;
            this.eot = DFA48_eot;
            this.eof = DFA48_eof;
            this.min = DFA48_min;
            this.max = DFA48_max;
            this.accept = DFA48_accept;
            this.special = DFA48_special;
            this.transition = DFA48_transition;

        }

        override public string Description
        {
            get { return "()+ loopback of 310:6: ( assignment | functioncall | scalarvardec | vectorvardec | matrixvardec | deletionofvar | print | ifelse | functionreturn | parallelfor | forstatement )+"; }
        }

    }

 

    public static readonly BitSet FOLLOW_expr_in_program70 = new BitSet(new ulong[]{0x00FC469E88000490UL});
    public static readonly BitSet FOLLOW_comment_in_program76 = new BitSet(new ulong[]{0x00FC469E88000490UL});
    public static readonly BitSet FOLLOW_EOF_in_program82 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_expr1_in_expr105 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_parallelfor_in_expr109 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_structdec_in_expr113 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_functiondefination_in_expr124 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_forexpr_in_expr1140 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_print_in_expr1152 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_expr2_in_forexpr185 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_matrixvardec_in_forexpr194 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_plotfunctions_in_forexpr204 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_functioncall_in_forexpr213 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_vectorvardec_in_forexpr222 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_assignment_in_expr2242 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ifelse_in_expr2252 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_forstatement_in_expr2262 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_scalarvardec_in_expr2274 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_deletionofvar_in_expr2286 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_structobjdec_in_expr2293 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_int_literal_in_var_int_or_double_literal318 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_double_literal_in_var_int_or_double_literal328 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_varorstruct_in_var_int_or_double_literal336 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_variable_in_varorstruct351 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_matrixelem_in_varorstruct355 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_vectorelem_in_varorstruct359 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_structassign_in_varorstruct365 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_VARIABLE_in_variable387 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_INT_LITERAL_in_int_literal408 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DOUBLE_LITERAL_in_double_literal430 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_27_in_matrixvardec452 = new BitSet(new ulong[]{0x0000000000800000UL});
    public static readonly BitSet FOLLOW_LESSTHANEXPRESSION_in_matrixvardec454 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_VARTYPE_in_matrixvardec461 = new BitSet(new ulong[]{0x0000000002000000UL});
    public static readonly BitSet FOLLOW_GREATERTHANEXPRESSION_in_matrixvardec463 = new BitSet(new ulong[]{0x0000000010000000UL});
    public static readonly BitSet FOLLOW_28_in_matrixvardec465 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_int_literal_in_matrixvardec468 = new BitSet(new ulong[]{0x0000000020000000UL});
    public static readonly BitSet FOLLOW_29_in_matrixvardec471 = new BitSet(new ulong[]{0x0000000010000000UL});
    public static readonly BitSet FOLLOW_28_in_matrixvardec474 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_int_literal_in_matrixvardec478 = new BitSet(new ulong[]{0x0000000020000000UL});
    public static readonly BitSet FOLLOW_29_in_matrixvardec481 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_variable_in_matrixvardec489 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_ASSIGNMENT_in_matrixvardec496 = new BitSet(new ulong[]{0x0000000010000000UL});
    public static readonly BitSet FOLLOW_28_in_matrixvardec502 = new BitSet(new ulong[]{0x0000000020000000UL});
    public static readonly BitSet FOLLOW_29_in_matrixvardec503 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_28_in_matrixvardec510 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_int_literal_in_matrixvardec514 = new BitSet(new ulong[]{0x0000000060000000UL});
    public static readonly BitSet FOLLOW_30_in_matrixvardec519 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_int_literal_in_matrixvardec522 = new BitSet(new ulong[]{0x0000000060000000UL});
    public static readonly BitSet FOLLOW_29_in_matrixvardec528 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_28_in_matrixvardec535 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_double_literal_in_matrixvardec538 = new BitSet(new ulong[]{0x0000000060000000UL});
    public static readonly BitSet FOLLOW_30_in_matrixvardec542 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_double_literal_in_matrixvardec545 = new BitSet(new ulong[]{0x0000000060000000UL});
    public static readonly BitSet FOLLOW_29_in_matrixvardec551 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_END_OF_STATEMENT_in_matrixvardec562 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_31_in_vectorvardec580 = new BitSet(new ulong[]{0x0000000000800000UL});
    public static readonly BitSet FOLLOW_LESSTHANEXPRESSION_in_vectorvardec582 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_VARTYPE_in_vectorvardec584 = new BitSet(new ulong[]{0x0000000002000000UL});
    public static readonly BitSet FOLLOW_GREATERTHANEXPRESSION_in_vectorvardec587 = new BitSet(new ulong[]{0x0000000010000000UL});
    public static readonly BitSet FOLLOW_28_in_vectorvardec589 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_int_literal_in_vectorvardec592 = new BitSet(new ulong[]{0x0000000020000000UL});
    public static readonly BitSet FOLLOW_29_in_vectorvardec595 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_variable_in_vectorvardec601 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_ASSIGNMENT_in_vectorvardec608 = new BitSet(new ulong[]{0x0000000010000000UL});
    public static readonly BitSet FOLLOW_28_in_vectorvardec615 = new BitSet(new ulong[]{0x0000000020000000UL});
    public static readonly BitSet FOLLOW_29_in_vectorvardec616 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_28_in_vectorvardec623 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_int_literal_in_vectorvardec626 = new BitSet(new ulong[]{0x0000000060000000UL});
    public static readonly BitSet FOLLOW_30_in_vectorvardec631 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_int_literal_in_vectorvardec634 = new BitSet(new ulong[]{0x0000000060000000UL});
    public static readonly BitSet FOLLOW_29_in_vectorvardec639 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_28_in_vectorvardec646 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_double_literal_in_vectorvardec649 = new BitSet(new ulong[]{0x0000000060000000UL});
    public static readonly BitSet FOLLOW_30_in_vectorvardec656 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_double_literal_in_vectorvardec659 = new BitSet(new ulong[]{0x0000000060000000UL});
    public static readonly BitSet FOLLOW_29_in_vectorvardec665 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_END_OF_STATEMENT_in_vectorvardec672 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_variable_in_matrixelem692 = new BitSet(new ulong[]{0x0000000010000000UL});
    public static readonly BitSet FOLLOW_28_in_matrixelem698 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_int_literal_in_matrixelem702 = new BitSet(new ulong[]{0x0000000020000000UL});
    public static readonly BitSet FOLLOW_variable_in_matrixelem707 = new BitSet(new ulong[]{0x0000000020000000UL});
    public static readonly BitSet FOLLOW_29_in_matrixelem710 = new BitSet(new ulong[]{0x0000000010000000UL});
    public static readonly BitSet FOLLOW_28_in_matrixelem713 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_int_literal_in_matrixelem717 = new BitSet(new ulong[]{0x0000000020000000UL});
    public static readonly BitSet FOLLOW_variable_in_matrixelem722 = new BitSet(new ulong[]{0x0000000020000000UL});
    public static readonly BitSet FOLLOW_29_in_matrixelem725 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_variable_in_vectorelem747 = new BitSet(new ulong[]{0x0000000010000000UL});
    public static readonly BitSet FOLLOW_28_in_vectorelem753 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_int_literal_in_vectorelem757 = new BitSet(new ulong[]{0x0000000020000000UL});
    public static readonly BitSet FOLLOW_variable_in_vectorelem763 = new BitSet(new ulong[]{0x0000000020000000UL});
    public static readonly BitSet FOLLOW_29_in_vectorelem766 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_variable_in_assignment789 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_structassign_in_assignment799 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_vectorelem_in_assignment811 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_matrixelem_in_assignment824 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_ASSIGNMENT_in_assignment832 = new BitSet(new ulong[]{0x0200100000000870UL});
    public static readonly BitSet FOLLOW_subtractive_exp_in_assignment842 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_dotproduct_in_assignment846 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_matrixtranspose_in_assignment855 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_string_literal_in_assignment859 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_END_OF_STATEMENT_in_assignment867 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_functioncall_in_assignment875 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_multiplicative_expression_in_additive_expression906 = new BitSet(new ulong[]{0x0000000000020002UL});
    public static readonly BitSet FOLLOW_PLUS_in_additive_expression911 = new BitSet(new ulong[]{0x0000000000000870UL});
    public static readonly BitSet FOLLOW_additive_expression_in_additive_expression917 = new BitSet(new ulong[]{0x0000000000020002UL});
    public static readonly BitSet FOLLOW_var_int_or_double_literal_in_multiplicative_expression945 = new BitSet(new ulong[]{0x0000000000040002UL});
    public static readonly BitSet FOLLOW_bracket_exp_in_multiplicative_expression957 = new BitSet(new ulong[]{0x0000000000040002UL});
    public static readonly BitSet FOLLOW_MULTIPLY_in_multiplicative_expression981 = new BitSet(new ulong[]{0x0000000000000870UL});
    public static readonly BitSet FOLLOW_multiplicative_expression_in_multiplicative_expression991 = new BitSet(new ulong[]{0x0000000000040002UL});
    public static readonly BitSet FOLLOW_LEFTBRACE_in_bracket_exp1037 = new BitSet(new ulong[]{0x0000000000000870UL});
    public static readonly BitSet FOLLOW_subtractive_exp_in_bracket_exp1038 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_RIGHTBRACE_in_bracket_exp1040 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_additive_expression_in_subtractive_exp1069 = new BitSet(new ulong[]{0x0000000100000002UL});
    public static readonly BitSet FOLLOW_32_in_subtractive_exp1074 = new BitSet(new ulong[]{0x0000000000000870UL});
    public static readonly BitSet FOLLOW_subtractive_exp_in_subtractive_exp1080 = new BitSet(new ulong[]{0x0000000100000002UL});
    public static readonly BitSet FOLLOW_33_in_structdec1110 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_variable_in_structdec1112 = new BitSet(new ulong[]{0x0000000000004000UL});
    public static readonly BitSet FOLLOW_LEFTPARANTHESIS_in_structdec1118 = new BitSet(new ulong[]{0x0000000000008000UL});
    public static readonly BitSet FOLLOW_RIGHTPARANTHESIS_in_structdec1119 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_LEFTPARANTHESIS_in_structdec1123 = new BitSet(new ulong[]{0x0000000000000480UL});
    public static readonly BitSet FOLLOW_scalarvardec_in_structdec1128 = new BitSet(new ulong[]{0x0000000000008480UL});
    public static readonly BitSet FOLLOW_RIGHTPARANTHESIS_in_structdec1133 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_END_OF_STATEMENT_in_structdec1138 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_VARTYPE_in_scalarvardec1159 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_STRINGTYPE_in_scalarvardec1166 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_variable_in_scalarvardec1173 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_END_OF_STATEMENT_in_scalarvardec1177 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_variable_in_structobjdec1199 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_variable_in_structobjdec1206 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_END_OF_STATEMENT_in_structobjdec1212 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_variable_in_structassign1231 = new BitSet(new ulong[]{0x0000000000080000UL});
    public static readonly BitSet FOLLOW_DOT_in_structassign1234 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_variable_in_structassign1237 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_34_in_deletionofvar1258 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_variable_in_deletionofvar1262 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_END_OF_STATEMENT_in_deletionofvar1266 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_35_in_print1285 = new BitSet(new ulong[]{0x0200100000000870UL});
    public static readonly BitSet FOLLOW_varorstruct_in_print1288 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_string_literal_in_print1297 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_END_OF_STATEMENT_in_print1322 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_36_in_parallelfor1344 = new BitSet(new ulong[]{0x0000000000000800UL});
    public static readonly BitSet FOLLOW_LEFTBRACE_in_parallelfor1345 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_variable_in_parallelfor1351 = new BitSet(new ulong[]{0x0000000000001000UL});
    public static readonly BitSet FOLLOW_POINT_in_parallelfor1354 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_int_literal_in_parallelfor1360 = new BitSet(new ulong[]{0x0000002000000000UL});
    public static readonly BitSet FOLLOW_37_in_parallelfor1363 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_int_literal_in_parallelfor1368 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_RIGHTBRACE_in_parallelfor1371 = new BitSet(new ulong[]{0x0000000000004000UL});
    public static readonly BitSet FOLLOW_LEFTPARANTHESIS_in_parallelfor1373 = new BitSet(new ulong[]{0x0000028400000490UL});
    public static readonly BitSet FOLLOW_expr2_in_parallelfor1380 = new BitSet(new ulong[]{0x000002C400008490UL});
    public static readonly BitSet FOLLOW_38_in_parallelfor1386 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_END_OF_STATEMENT_in_parallelfor1389 = new BitSet(new ulong[]{0x0000028400008490UL});
    public static readonly BitSet FOLLOW_RIGHTPARANTHESIS_in_parallelfor1397 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_39_in_ifelse1414 = new BitSet(new ulong[]{0x0000000000000800UL});
    public static readonly BitSet FOLLOW_LEFTBRACE_in_ifelse1416 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_varorstruct_in_ifelse1419 = new BitSet(new ulong[]{0x0000000007E00000UL});
    public static readonly BitSet FOLLOW_EQUALITYEXPRESSION_in_ifelse1430 = new BitSet(new ulong[]{0x0200100000000870UL});
    public static readonly BitSet FOLLOW_NONEQUALITYEXPRESSION_in_ifelse1440 = new BitSet(new ulong[]{0x0200100000000870UL});
    public static readonly BitSet FOLLOW_LESSTHANEXPRESSION_in_ifelse1450 = new BitSet(new ulong[]{0x0200100000000870UL});
    public static readonly BitSet FOLLOW_LESSTHANEQUALTOEXPRESSION_in_ifelse1461 = new BitSet(new ulong[]{0x0200100000000870UL});
    public static readonly BitSet FOLLOW_GREATERTHANEXPRESSION_in_ifelse1471 = new BitSet(new ulong[]{0x0200100000000870UL});
    public static readonly BitSet FOLLOW_GREATERTHANEQUALTOEXPRESSION_in_ifelse1482 = new BitSet(new ulong[]{0x0200100000000870UL});
    public static readonly BitSet FOLLOW_var_int_or_double_literal_in_ifelse1495 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_string_literal_in_ifelse1502 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_RIGHTBRACE_in_ifelse1506 = new BitSet(new ulong[]{0x0000000000004000UL});
    public static readonly BitSet FOLLOW_LEFTPARANTHESIS_in_ifelse1508 = new BitSet(new ulong[]{0x007C628C88008490UL});
    public static readonly BitSet FOLLOW_ifloop_in_ifelse1516 = new BitSet(new ulong[]{0x0000000000008000UL});
    public static readonly BitSet FOLLOW_RIGHTPARANTHESIS_in_ifelse1521 = new BitSet(new ulong[]{0x0000010000000002UL});
    public static readonly BitSet FOLLOW_40_in_ifelse1524 = new BitSet(new ulong[]{0x0000000000004000UL});
    public static readonly BitSet FOLLOW_LEFTPARANTHESIS_in_ifelse1527 = new BitSet(new ulong[]{0x007C628C88008490UL});
    public static readonly BitSet FOLLOW_ifloop_in_ifelse1536 = new BitSet(new ulong[]{0x0000000000008000UL});
    public static readonly BitSet FOLLOW_RIGHTPARANTHESIS_in_ifelse1542 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_expr1_in_ifloop1563 = new BitSet(new ulong[]{0x007C628C88000492UL});
    public static readonly BitSet FOLLOW_functionreturn_in_ifloop1566 = new BitSet(new ulong[]{0x007C628C88000492UL});
    public static readonly BitSet FOLLOW_41_in_forstatement1585 = new BitSet(new ulong[]{0x0000000000000800UL});
    public static readonly BitSet FOLLOW_LEFTBRACE_in_forstatement1587 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_variable_in_forstatement1593 = new BitSet(new ulong[]{0x0000000000001000UL});
    public static readonly BitSet FOLLOW_POINT_in_forstatement1596 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_int_literal_in_forstatement1602 = new BitSet(new ulong[]{0x0000002000000000UL});
    public static readonly BitSet FOLLOW_37_in_forstatement1605 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_int_literal_in_forstatement1610 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_RIGHTBRACE_in_forstatement1613 = new BitSet(new ulong[]{0x0000000000004000UL});
    public static readonly BitSet FOLLOW_LEFTPARANTHESIS_in_forstatement1615 = new BitSet(new ulong[]{0x007C428488000490UL});
    public static readonly BitSet FOLLOW_forexpr_in_forstatement1620 = new BitSet(new ulong[]{0x007C428488008490UL});
    public static readonly BitSet FOLLOW_RIGHTPARANTHESIS_in_forstatement1625 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_variable_in_functioncall1643 = new BitSet(new ulong[]{0x0000000000000800UL});
    public static readonly BitSet FOLLOW_LEFTBRACE_in_functioncall1648 = new BitSet(new ulong[]{0x0200100000002870UL});
    public static readonly BitSet FOLLOW_var_int_or_double_literal_in_functioncall1653 = new BitSet(new ulong[]{0x0000000040002000UL});
    public static readonly BitSet FOLLOW_string_literal_in_functioncall1659 = new BitSet(new ulong[]{0x0000000040002000UL});
    public static readonly BitSet FOLLOW_30_in_functioncall1664 = new BitSet(new ulong[]{0x0200100000000870UL});
    public static readonly BitSet FOLLOW_var_int_or_double_literal_in_functioncall1669 = new BitSet(new ulong[]{0x0000000040002000UL});
    public static readonly BitSet FOLLOW_string_literal_in_functioncall1675 = new BitSet(new ulong[]{0x0000000040002000UL});
    public static readonly BitSet FOLLOW_RIGHTBRACE_in_functioncall1683 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_END_OF_STATEMENT_in_functioncall1687 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_VARTYPE_in_functiondefination1714 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_variable_in_functiondefination1719 = new BitSet(new ulong[]{0x0000000000000800UL});
    public static readonly BitSet FOLLOW_LEFTBRACE_in_functiondefination1725 = new BitSet(new ulong[]{0x0000000088002080UL});
    public static readonly BitSet FOLLOW_arguments_in_functiondefination1733 = new BitSet(new ulong[]{0x0000000040002000UL});
    public static readonly BitSet FOLLOW_30_in_functiondefination1736 = new BitSet(new ulong[]{0x0000000088000080UL});
    public static readonly BitSet FOLLOW_arguments_in_functiondefination1741 = new BitSet(new ulong[]{0x0000000040002000UL});
    public static readonly BitSet FOLLOW_RIGHTBRACE_in_functiondefination1750 = new BitSet(new ulong[]{0x0000000000004000UL});
    public static readonly BitSet FOLLOW_LEFTPARANTHESIS_in_functiondefination1752 = new BitSet(new ulong[]{0x007C629C88008490UL});
    public static readonly BitSet FOLLOW_assignment_in_functiondefination1756 = new BitSet(new ulong[]{0x007C629C88008490UL});
    public static readonly BitSet FOLLOW_functioncall_in_functiondefination1759 = new BitSet(new ulong[]{0x007C629C88008490UL});
    public static readonly BitSet FOLLOW_scalarvardec_in_functiondefination1763 = new BitSet(new ulong[]{0x007C629C88008490UL});
    public static readonly BitSet FOLLOW_vectorvardec_in_functiondefination1771 = new BitSet(new ulong[]{0x007C629C88008490UL});
    public static readonly BitSet FOLLOW_matrixvardec_in_functiondefination1779 = new BitSet(new ulong[]{0x007C629C88008490UL});
    public static readonly BitSet FOLLOW_deletionofvar_in_functiondefination1787 = new BitSet(new ulong[]{0x007C629C88008490UL});
    public static readonly BitSet FOLLOW_print_in_functiondefination1793 = new BitSet(new ulong[]{0x007C629C88008490UL});
    public static readonly BitSet FOLLOW_ifelse_in_functiondefination1801 = new BitSet(new ulong[]{0x007C629C88008490UL});
    public static readonly BitSet FOLLOW_functionreturn_in_functiondefination1805 = new BitSet(new ulong[]{0x007C629C88008490UL});
    public static readonly BitSet FOLLOW_parallelfor_in_functiondefination1809 = new BitSet(new ulong[]{0x007C629C88008490UL});
    public static readonly BitSet FOLLOW_forstatement_in_functiondefination1813 = new BitSet(new ulong[]{0x007C629C88008490UL});
    public static readonly BitSet FOLLOW_RIGHTPARANTHESIS_in_functiondefination1820 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_42_in_functiondefination1823 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_variable_in_functiondefination1828 = new BitSet(new ulong[]{0x0000000000000800UL});
    public static readonly BitSet FOLLOW_LEFTBRACE_in_functiondefination1834 = new BitSet(new ulong[]{0x0000000088002080UL});
    public static readonly BitSet FOLLOW_arguments_in_functiondefination1843 = new BitSet(new ulong[]{0x0000000040002000UL});
    public static readonly BitSet FOLLOW_30_in_functiondefination1846 = new BitSet(new ulong[]{0x0000000088000080UL});
    public static readonly BitSet FOLLOW_arguments_in_functiondefination1850 = new BitSet(new ulong[]{0x0000000040002000UL});
    public static readonly BitSet FOLLOW_RIGHTBRACE_in_functiondefination1859 = new BitSet(new ulong[]{0x0000000000004000UL});
    public static readonly BitSet FOLLOW_LEFTPARANTHESIS_in_functiondefination1861 = new BitSet(new ulong[]{0x007C629C88008490UL});
    public static readonly BitSet FOLLOW_assignment_in_functiondefination1865 = new BitSet(new ulong[]{0x007C629C88008490UL});
    public static readonly BitSet FOLLOW_functioncall_in_functiondefination1868 = new BitSet(new ulong[]{0x007C629C88008490UL});
    public static readonly BitSet FOLLOW_scalarvardec_in_functiondefination1872 = new BitSet(new ulong[]{0x007C629C88008490UL});
    public static readonly BitSet FOLLOW_vectorvardec_in_functiondefination1880 = new BitSet(new ulong[]{0x007C629C88008490UL});
    public static readonly BitSet FOLLOW_matrixvardec_in_functiondefination1888 = new BitSet(new ulong[]{0x007C629C88008490UL});
    public static readonly BitSet FOLLOW_deletionofvar_in_functiondefination1896 = new BitSet(new ulong[]{0x007C629C88008490UL});
    public static readonly BitSet FOLLOW_print_in_functiondefination1902 = new BitSet(new ulong[]{0x007C629C88008490UL});
    public static readonly BitSet FOLLOW_ifelse_in_functiondefination1910 = new BitSet(new ulong[]{0x007C629C88008490UL});
    public static readonly BitSet FOLLOW_functionreturn_in_functiondefination1914 = new BitSet(new ulong[]{0x007C629C88008490UL});
    public static readonly BitSet FOLLOW_parallelfor_in_functiondefination1918 = new BitSet(new ulong[]{0x007C629C88008490UL});
    public static readonly BitSet FOLLOW_forstatement_in_functiondefination1922 = new BitSet(new ulong[]{0x007C629C88008490UL});
    public static readonly BitSet FOLLOW_RIGHTPARANTHESIS_in_functiondefination1929 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_variable_in_dotproduct1951 = new BitSet(new ulong[]{0x0000080000000000UL});
    public static readonly BitSet FOLLOW_43_in_dotproduct1955 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_variable_in_dotproduct1961 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_44_in_matrixtranspose1980 = new BitSet(new ulong[]{0x0000000000000800UL});
    public static readonly BitSet FOLLOW_LEFTBRACE_in_matrixtranspose1982 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_variable_in_matrixtranspose1984 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_RIGHTBRACE_in_matrixtranspose1987 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_27_in_matrixreference2003 = new BitSet(new ulong[]{0x0000000000800000UL});
    public static readonly BitSet FOLLOW_LESSTHANEXPRESSION_in_matrixreference2005 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_VARTYPE_in_matrixreference2010 = new BitSet(new ulong[]{0x0000000002000000UL});
    public static readonly BitSet FOLLOW_GREATERTHANEXPRESSION_in_matrixreference2012 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_variable_in_matrixreference2016 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_31_in_vectorreference2035 = new BitSet(new ulong[]{0x0000000000800000UL});
    public static readonly BitSet FOLLOW_LESSTHANEXPRESSION_in_vectorreference2037 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_VARTYPE_in_vectorreference2042 = new BitSet(new ulong[]{0x0000000002000000UL});
    public static readonly BitSet FOLLOW_GREATERTHANEXPRESSION_in_vectorreference2044 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_variable_in_vectorreference2048 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_scalarargument_in_arguments2064 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_matrixreference_in_arguments2070 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_vectorreference_in_arguments2076 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_VARTYPE_in_scalarargument2108 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_variable_in_scalarargument2115 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_45_in_functionreturn2142 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_var_int_or_double_literal_in_functionreturn2145 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_END_OF_STATEMENT_in_functionreturn2149 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_46_in_plotfunctions2174 = new BitSet(new ulong[]{0x0000000000000800UL});
    public static readonly BitSet FOLLOW_LEFTBRACE_in_plotfunctions2177 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_int_literal_in_plotfunctions2184 = new BitSet(new ulong[]{0x0000000040000000UL});
    public static readonly BitSet FOLLOW_30_in_plotfunctions2189 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_variable_in_plotfunctions2196 = new BitSet(new ulong[]{0x0000000040000000UL});
    public static readonly BitSet FOLLOW_30_in_plotfunctions2201 = new BitSet(new ulong[]{0x0200100000000870UL});
    public static readonly BitSet FOLLOW_string_literal_in_plotfunctions2208 = new BitSet(new ulong[]{0x0000000040000000UL});
    public static readonly BitSet FOLLOW_30_in_plotfunctions2212 = new BitSet(new ulong[]{0x0003800000000000UL});
    public static readonly BitSet FOLLOW_47_in_plotfunctions2216 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_48_in_plotfunctions2221 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_49_in_plotfunctions2226 = new BitSet(new ulong[]{0x0000000040002000UL});
    public static readonly BitSet FOLLOW_30_in_plotfunctions2229 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_int_literal_in_plotfunctions2235 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_RIGHTBRACE_in_plotfunctions2243 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_END_OF_STATEMENT_in_plotfunctions2244 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_50_in_plotfunctions2250 = new BitSet(new ulong[]{0x0000000000000800UL});
    public static readonly BitSet FOLLOW_LEFTBRACE_in_plotfunctions2253 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_variable_in_plotfunctions2259 = new BitSet(new ulong[]{0x0000000040000000UL});
    public static readonly BitSet FOLLOW_30_in_plotfunctions2264 = new BitSet(new ulong[]{0x0200100000000870UL});
    public static readonly BitSet FOLLOW_string_literal_in_plotfunctions2270 = new BitSet(new ulong[]{0x0000000040000000UL});
    public static readonly BitSet FOLLOW_30_in_plotfunctions2274 = new BitSet(new ulong[]{0x0003800000000000UL});
    public static readonly BitSet FOLLOW_47_in_plotfunctions2278 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_48_in_plotfunctions2283 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_49_in_plotfunctions2288 = new BitSet(new ulong[]{0x0000000040002000UL});
    public static readonly BitSet FOLLOW_30_in_plotfunctions2291 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_int_literal_in_plotfunctions2297 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_RIGHTBRACE_in_plotfunctions2305 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_END_OF_STATEMENT_in_plotfunctions2306 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_51_in_plotfunctions2312 = new BitSet(new ulong[]{0x0000000000000800UL});
    public static readonly BitSet FOLLOW_LEFTBRACE_in_plotfunctions2313 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_RIGHTBRACE_in_plotfunctions2314 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_END_OF_STATEMENT_in_plotfunctions2316 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_52_in_plotfunctions2320 = new BitSet(new ulong[]{0x0000000000000800UL});
    public static readonly BitSet FOLLOW_LEFTBRACE_in_plotfunctions2324 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_double_literal_in_plotfunctions2331 = new BitSet(new ulong[]{0x0000000040002000UL});
    public static readonly BitSet FOLLOW_RIGHTBRACE_in_plotfunctions2336 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_END_OF_STATEMENT_in_plotfunctions2338 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_30_in_plotfunctions2340 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_double_literal_in_plotfunctions2345 = new BitSet(new ulong[]{0x0000000040002000UL});
    public static readonly BitSet FOLLOW_RIGHTBRACE_in_plotfunctions2348 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_END_OF_STATEMENT_in_plotfunctions2349 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_30_in_plotfunctions2351 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_double_literal_in_plotfunctions2356 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_RIGHTBRACE_in_plotfunctions2359 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_END_OF_STATEMENT_in_plotfunctions2361 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_53_in_plotfunctions2366 = new BitSet(new ulong[]{0x0000000000000800UL});
    public static readonly BitSet FOLLOW_LEFTBRACE_in_plotfunctions2370 = new BitSet(new ulong[]{0x0200100000000870UL});
    public static readonly BitSet FOLLOW_string_literal_in_plotfunctions2377 = new BitSet(new ulong[]{0x0000000040002000UL});
    public static readonly BitSet FOLLOW_RIGHTBRACE_in_plotfunctions2382 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_END_OF_STATEMENT_in_plotfunctions2384 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_30_in_plotfunctions2386 = new BitSet(new ulong[]{0x0200100000000870UL});
    public static readonly BitSet FOLLOW_string_literal_in_plotfunctions2391 = new BitSet(new ulong[]{0x0000000040002000UL});
    public static readonly BitSet FOLLOW_RIGHTBRACE_in_plotfunctions2394 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_END_OF_STATEMENT_in_plotfunctions2395 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_30_in_plotfunctions2397 = new BitSet(new ulong[]{0x0200100000000870UL});
    public static readonly BitSet FOLLOW_string_literal_in_plotfunctions2402 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_RIGHTBRACE_in_plotfunctions2405 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_END_OF_STATEMENT_in_plotfunctions2407 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_54_in_plotfunctions2413 = new BitSet(new ulong[]{0x0000000000010000UL});
    public static readonly BitSet FOLLOW_SCALEMODE_in_plotfunctions2416 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_RIGHTBRACE_in_plotfunctions2420 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_END_OF_STATEMENT_in_plotfunctions2422 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_55_in_comment2443 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_VARIABLE_in_comment2448 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_INT_LITERAL_in_comment2455 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_DOUBLE_LITERAL_in_comment2462 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_DOT_in_comment2467 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_27_in_comment2472 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_31_in_comment2477 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_LESSTHANEXPRESSION_in_comment2482 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_GREATERTHANEXPRESSION_in_comment2487 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_VARTYPE_in_comment2492 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_SCALEMODE_in_comment2497 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_STRINGTYPE_in_comment2502 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_ASSIGNMENT_in_comment2507 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_PLUS_in_comment2512 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_MULTIPLY_in_comment2517 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_35_in_comment2522 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_46_in_comment2526 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_50_in_comment2530 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_51_in_comment2534 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_52_in_comment2538 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_53_in_comment2542 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_56_in_comment2546 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_57_in_comment2551 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_LEFTBRACE_in_comment2557 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_RIGHTBRACE_in_comment2562 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_LEFTPARANTHESIS_in_comment2567 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_RIGHTPARANTHESIS_in_comment2572 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_POINT_in_comment2577 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_EQUALITYEXPRESSION_in_comment2582 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_NONEQUALITYEXPRESSION_in_comment2587 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_LESSTHANEQUALTOEXPRESSION_in_comment2592 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_58_in_comment2598 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_32_in_comment2604 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_END_OF_STATEMENT_in_comment2610 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_59_in_comment2616 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_60_in_comment2627 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_61_in_comment2634 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_62_in_comment2641 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_63_in_comment2648 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_64_in_comment2655 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_65_in_comment2663 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_66_in_comment2672 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_28_in_comment2683 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_29_in_comment2692 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_30_in_comment2701 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_47_in_comment2710 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_48_in_comment2719 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_49_in_comment2728 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_42_in_comment2737 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_33_in_comment2746 = new BitSet(new ulong[]{0xFFBFC40BFBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_55_in_comment2766 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_57_in_string_literal2787 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_VARIABLE_in_string_literal2793 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_INT_LITERAL_in_string_literal2800 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_DOUBLE_LITERAL_in_string_literal2807 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_DOT_in_string_literal2812 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_27_in_string_literal2817 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_31_in_string_literal2822 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_LESSTHANEXPRESSION_in_string_literal2827 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_GREATERTHANEXPRESSION_in_string_literal2832 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_VARTYPE_in_string_literal2837 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_SCALEMODE_in_string_literal2842 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_STRINGTYPE_in_string_literal2847 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_ASSIGNMENT_in_string_literal2852 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_32_in_string_literal2857 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_PLUS_in_string_literal2862 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_MULTIPLY_in_string_literal2867 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_46_in_string_literal2872 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_50_in_string_literal2876 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_51_in_string_literal2880 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_52_in_string_literal2884 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_53_in_string_literal2888 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_56_in_string_literal2892 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_LEFTBRACE_in_string_literal2897 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_RIGHTBRACE_in_string_literal2902 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_LEFTPARANTHESIS_in_string_literal2907 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_RIGHTPARANTHESIS_in_string_literal2912 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_POINT_in_string_literal2917 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_EQUALITYEXPRESSION_in_string_literal2922 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_NONEQUALITYEXPRESSION_in_string_literal2927 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_LESSTHANEQUALTOEXPRESSION_in_string_literal2932 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_58_in_string_literal2938 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_60_in_string_literal2949 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_61_in_string_literal2956 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_62_in_string_literal2963 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_63_in_string_literal2970 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_END_OF_STATEMENT_in_string_literal2977 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_64_in_string_literal2984 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_65_in_string_literal2992 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_66_in_string_literal3001 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_59_in_string_literal3013 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_30_in_string_literal3027 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_47_in_string_literal3043 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_48_in_string_literal3061 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_49_in_string_literal3081 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_42_in_string_literal3094 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_33_in_string_literal3105 = new BitSet(new ulong[]{0xFF3FC403CBEFFFF0UL,0x0000000000000007UL});
    public static readonly BitSet FOLLOW_57_in_string_literal3115 = new BitSet(new ulong[]{0x0000000000000002UL});

}
