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
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public partial class TetlLexer : Lexer {
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, T__15=16, T__16=17, 
		T__17=18, T__18=19, T__19=20, T__20=21, WHILE=22, IF=23, ELSE=24, BOOL_OPERATOR=25, 
		INTEGER=26, FLOAT=27, STRING=28, BOOL=29, NULL=30, COMMENT=31, LINE_COMMENT=32, 
		LINE_BREAK=33, WS=34, IDENTIFIER=35;
	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "T__12", "T__13", "T__14", "T__15", "T__16", 
		"T__17", "T__18", "T__19", "T__20", "WHILE", "IF", "ELSE", "BOOL_OPERATOR", 
		"INTEGER", "FLOAT", "STRING", "BOOL", "NULL", "COMMENT", "LINE_COMMENT", 
		"LINE_BREAK", "WS", "IDENTIFIER"
	};


	public TetlLexer(ICharStream input)
		: base(input)
	{
		_interp = new LexerATNSimulator(this,_ATN);
	}

	private static readonly string[] _LiteralNames = {
		null, "';'", "'('", "')'", "'{'", "'}'", "'='", "','", "'['", "']'", "'!'", 
		"'*'", "'/'", "'%'", "'+'", "'-'", "'=='", "'!='", "'>'", "'<'", "'>='", 
		"'<='", null, null, null, null, null, null, null, null, "'null'", null, 
		null, "'\n'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, null, "WHILE", "IF", 
		"ELSE", "BOOL_OPERATOR", "INTEGER", "FLOAT", "STRING", "BOOL", "NULL", 
		"COMMENT", "LINE_COMMENT", "LINE_BREAK", "WS", "IDENTIFIER"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[System.Obsolete("Use Vocabulary instead.")]
	public static readonly string[] tokenNames = GenerateTokenNames(DefaultVocabulary, _SymbolicNames.Length);

	private static string[] GenerateTokenNames(IVocabulary vocabulary, int length) {
		string[] tokenNames = new string[length];
		for (int i = 0; i < tokenNames.Length; i++) {
			tokenNames[i] = vocabulary.GetLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = vocabulary.GetSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}

		return tokenNames;
	}

	[System.Obsolete("Use IRecognizer.Vocabulary instead.")]
	public override string[] TokenNames
	{
		get
		{
			return tokenNames;
		}
	}

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Tetl.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public static readonly string _serializedATN =
		"\x3\xAF6F\x8320\x479D\xB75C\x4880\x1605\x191C\xAB37\x2%\x105\b\x1\x4\x2"+
		"\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t\a\x4\b\t\b\x4"+
		"\t\t\t\x4\n\t\n\x4\v\t\v\x4\f\t\f\x4\r\t\r\x4\xE\t\xE\x4\xF\t\xF\x4\x10"+
		"\t\x10\x4\x11\t\x11\x4\x12\t\x12\x4\x13\t\x13\x4\x14\t\x14\x4\x15\t\x15"+
		"\x4\x16\t\x16\x4\x17\t\x17\x4\x18\t\x18\x4\x19\t\x19\x4\x1A\t\x1A\x4\x1B"+
		"\t\x1B\x4\x1C\t\x1C\x4\x1D\t\x1D\x4\x1E\t\x1E\x4\x1F\t\x1F\x4 \t \x4!"+
		"\t!\x4\"\t\"\x4#\t#\x4$\t$\x3\x2\x3\x2\x3\x3\x3\x3\x3\x4\x3\x4\x3\x5\x3"+
		"\x5\x3\x6\x3\x6\x3\a\x3\a\x3\b\x3\b\x3\t\x3\t\x3\n\x3\n\x3\v\x3\v\x3\f"+
		"\x3\f\x3\r\x3\r\x3\xE\x3\xE\x3\xF\x3\xF\x3\x10\x3\x10\x3\x11\x3\x11\x3"+
		"\x11\x3\x12\x3\x12\x3\x12\x3\x13\x3\x13\x3\x14\x3\x14\x3\x15\x3\x15\x3"+
		"\x15\x3\x16\x3\x16\x3\x16\x3\x17\x3\x17\x3\x17\x3\x17\x3\x17\x3\x17\x3"+
		"\x17\x3\x17\x3\x17\x3\x17\x5\x17\x82\n\x17\x3\x18\x3\x18\x3\x18\x3\x18"+
		"\x3\x18\x3\x18\x3\x18\x3\x18\x3\x18\x3\x18\x3\x18\x3\x18\x3\x18\x3\x18"+
		"\x3\x18\x3\x18\x3\x18\x5\x18\x95\n\x18\x3\x19\x3\x19\x3\x19\x3\x19\x3"+
		"\x19\x3\x19\x3\x19\x3\x19\x3\x19\x3\x19\x3\x19\x3\x19\x5\x19\xA3\n\x19"+
		"\x3\x1A\x3\x1A\x3\x1A\x3\x1A\x5\x1A\xA9\n\x1A\x3\x1B\x6\x1B\xAC\n\x1B"+
		"\r\x1B\xE\x1B\xAD\x3\x1C\x6\x1C\xB1\n\x1C\r\x1C\xE\x1C\xB2\x3\x1C\x3\x1C"+
		"\x6\x1C\xB7\n\x1C\r\x1C\xE\x1C\xB8\x3\x1D\x3\x1D\a\x1D\xBD\n\x1D\f\x1D"+
		"\xE\x1D\xC0\v\x1D\x3\x1D\x3\x1D\x3\x1D\a\x1D\xC5\n\x1D\f\x1D\xE\x1D\xC8"+
		"\v\x1D\x3\x1D\x5\x1D\xCB\n\x1D\x3\x1E\x3\x1E\x3\x1E\x3\x1E\x3\x1E\x3\x1E"+
		"\x3\x1E\x3\x1E\x3\x1E\x5\x1E\xD6\n\x1E\x3\x1F\x3\x1F\x3\x1F\x3\x1F\x3"+
		"\x1F\x3 \x3 \x3 \x3 \a \xE1\n \f \xE \xE4\v \x3 \x3 \x3 \x3 \x3 \x3!\x3"+
		"!\x3!\x3!\a!\xEF\n!\f!\xE!\xF2\v!\x3!\x3!\x3\"\x3\"\x3#\x6#\xF9\n#\r#"+
		"\xE#\xFA\x3#\x3#\x3$\x3$\a$\x101\n$\f$\xE$\x104\v$\x3\xE2\x2\x2%\x3\x2"+
		"\x3\x5\x2\x4\a\x2\x5\t\x2\x6\v\x2\a\r\x2\b\xF\x2\t\x11\x2\n\x13\x2\v\x15"+
		"\x2\f\x17\x2\r\x19\x2\xE\x1B\x2\xF\x1D\x2\x10\x1F\x2\x11!\x2\x12#\x2\x13"+
		"%\x2\x14\'\x2\x15)\x2\x16+\x2\x17-\x2\x18/\x2\x19\x31\x2\x1A\x33\x2\x1B"+
		"\x35\x2\x1C\x37\x2\x1D\x39\x2\x1E;\x2\x1F=\x2 ?\x2!\x41\x2\"\x43\x2#\x45"+
		"\x2$G\x2%\x3\x2\t\x3\x2\x32;\x3\x2$$\x3\x2))\x4\x2\f\f\xF\xF\x5\x2\v\f"+
		"\xF\xF\"\"\x5\x2\x43\\\x61\x61\x63|\x6\x2\x32;\x43\\\x61\x61\x63|\x113"+
		"\x2\x3\x3\x2\x2\x2\x2\x5\x3\x2\x2\x2\x2\a\x3\x2\x2\x2\x2\t\x3\x2\x2\x2"+
		"\x2\v\x3\x2\x2\x2\x2\r\x3\x2\x2\x2\x2\xF\x3\x2\x2\x2\x2\x11\x3\x2\x2\x2"+
		"\x2\x13\x3\x2\x2\x2\x2\x15\x3\x2\x2\x2\x2\x17\x3\x2\x2\x2\x2\x19\x3\x2"+
		"\x2\x2\x2\x1B\x3\x2\x2\x2\x2\x1D\x3\x2\x2\x2\x2\x1F\x3\x2\x2\x2\x2!\x3"+
		"\x2\x2\x2\x2#\x3\x2\x2\x2\x2%\x3\x2\x2\x2\x2\'\x3\x2\x2\x2\x2)\x3\x2\x2"+
		"\x2\x2+\x3\x2\x2\x2\x2-\x3\x2\x2\x2\x2/\x3\x2\x2\x2\x2\x31\x3\x2\x2\x2"+
		"\x2\x33\x3\x2\x2\x2\x2\x35\x3\x2\x2\x2\x2\x37\x3\x2\x2\x2\x2\x39\x3\x2"+
		"\x2\x2\x2;\x3\x2\x2\x2\x2=\x3\x2\x2\x2\x2?\x3\x2\x2\x2\x2\x41\x3\x2\x2"+
		"\x2\x2\x43\x3\x2\x2\x2\x2\x45\x3\x2\x2\x2\x2G\x3\x2\x2\x2\x3I\x3\x2\x2"+
		"\x2\x5K\x3\x2\x2\x2\aM\x3\x2\x2\x2\tO\x3\x2\x2\x2\vQ\x3\x2\x2\x2\rS\x3"+
		"\x2\x2\x2\xFU\x3\x2\x2\x2\x11W\x3\x2\x2\x2\x13Y\x3\x2\x2\x2\x15[\x3\x2"+
		"\x2\x2\x17]\x3\x2\x2\x2\x19_\x3\x2\x2\x2\x1B\x61\x3\x2\x2\x2\x1D\x63\x3"+
		"\x2\x2\x2\x1F\x65\x3\x2\x2\x2!g\x3\x2\x2\x2#j\x3\x2\x2\x2%m\x3\x2\x2\x2"+
		"\'o\x3\x2\x2\x2)q\x3\x2\x2\x2+t\x3\x2\x2\x2-\x81\x3\x2\x2\x2/\x94\x3\x2"+
		"\x2\x2\x31\xA2\x3\x2\x2\x2\x33\xA8\x3\x2\x2\x2\x35\xAB\x3\x2\x2\x2\x37"+
		"\xB0\x3\x2\x2\x2\x39\xCA\x3\x2\x2\x2;\xD5\x3\x2\x2\x2=\xD7\x3\x2\x2\x2"+
		"?\xDC\x3\x2\x2\x2\x41\xEA\x3\x2\x2\x2\x43\xF5\x3\x2\x2\x2\x45\xF8\x3\x2"+
		"\x2\x2G\xFE\x3\x2\x2\x2IJ\a=\x2\x2J\x4\x3\x2\x2\x2KL\a*\x2\x2L\x6\x3\x2"+
		"\x2\x2MN\a+\x2\x2N\b\x3\x2\x2\x2OP\a}\x2\x2P\n\x3\x2\x2\x2QR\a\x7F\x2"+
		"\x2R\f\x3\x2\x2\x2ST\a?\x2\x2T\xE\x3\x2\x2\x2UV\a.\x2\x2V\x10\x3\x2\x2"+
		"\x2WX\a]\x2\x2X\x12\x3\x2\x2\x2YZ\a_\x2\x2Z\x14\x3\x2\x2\x2[\\\a#\x2\x2"+
		"\\\x16\x3\x2\x2\x2]^\a,\x2\x2^\x18\x3\x2\x2\x2_`\a\x31\x2\x2`\x1A\x3\x2"+
		"\x2\x2\x61\x62\a\'\x2\x2\x62\x1C\x3\x2\x2\x2\x63\x64\a-\x2\x2\x64\x1E"+
		"\x3\x2\x2\x2\x65\x66\a/\x2\x2\x66 \x3\x2\x2\x2gh\a?\x2\x2hi\a?\x2\x2i"+
		"\"\x3\x2\x2\x2jk\a#\x2\x2kl\a?\x2\x2l$\x3\x2\x2\x2mn\a@\x2\x2n&\x3\x2"+
		"\x2\x2op\a>\x2\x2p(\x3\x2\x2\x2qr\a@\x2\x2rs\a?\x2\x2s*\x3\x2\x2\x2tu"+
		"\a>\x2\x2uv\a?\x2\x2v,\x3\x2\x2\x2wx\ay\x2\x2xy\aj\x2\x2yz\ak\x2\x2z{"+
		"\an\x2\x2{\x82\ag\x2\x2|}\aw\x2\x2}~\ap\x2\x2~\x7F\av\x2\x2\x7F\x80\a"+
		"k\x2\x2\x80\x82\an\x2\x2\x81w\x3\x2\x2\x2\x81|\x3\x2\x2\x2\x82.\x3\x2"+
		"\x2\x2\x83\x84\ak\x2\x2\x84\x95\ah\x2\x2\x85\x86\ag\x2\x2\x86\x87\a|\x2"+
		"\x2\x87\x88\av\x2\x2\x88\x89\aP\x2\x2\x89\x8A\ag\x2\x2\x8A\x8B\a|\x2\x2"+
		"\x8B\x8C\a\x66\x2\x2\x8C\x8D\aO\x2\x2\x8D\x8E\a\x63\x2\x2\x8E\x8F\ap\x2"+
		"\x2\x8F\x90\aO\x2\x2\x90\x91\ag\x2\x2\x91\x92\ai\x2\x2\x92\x93\aJ\x2\x2"+
		"\x93\x95\ag\x2\x2\x94\x83\x3\x2\x2\x2\x94\x85\x3\x2\x2\x2\x95\x30\x3\x2"+
		"\x2\x2\x96\x97\ag\x2\x2\x97\x98\an\x2\x2\x98\x99\au\x2\x2\x99\xA3\ag\x2"+
		"\x2\x9A\x9B\am\x2\x2\x9B\x9C\a\xFE\x2\x2\x9C\x9D\an\x2\x2\x9D\x9E\a\xF8"+
		"\x2\x2\x9E\x9F\ap\x2\x2\x9F\xA0\a\x64\x2\x2\xA0\xA1\ag\x2\x2\xA1\xA3\a"+
		"p\x2\x2\xA2\x96\x3\x2\x2\x2\xA2\x9A\x3\x2\x2\x2\xA3\x32\x3\x2\x2\x2\xA4"+
		"\xA5\a(\x2\x2\xA5\xA9\a(\x2\x2\xA6\xA7\a~\x2\x2\xA7\xA9\a~\x2\x2\xA8\xA4"+
		"\x3\x2\x2\x2\xA8\xA6\x3\x2\x2\x2\xA9\x34\x3\x2\x2\x2\xAA\xAC\t\x2\x2\x2"+
		"\xAB\xAA\x3\x2\x2\x2\xAC\xAD\x3\x2\x2\x2\xAD\xAB\x3\x2\x2\x2\xAD\xAE\x3"+
		"\x2\x2\x2\xAE\x36\x3\x2\x2\x2\xAF\xB1\t\x2\x2\x2\xB0\xAF\x3\x2\x2\x2\xB1"+
		"\xB2\x3\x2\x2\x2\xB2\xB0\x3\x2\x2\x2\xB2\xB3\x3\x2\x2\x2\xB3\xB4\x3\x2"+
		"\x2\x2\xB4\xB6\a\x30\x2\x2\xB5\xB7\t\x2\x2\x2\xB6\xB5\x3\x2\x2\x2\xB7"+
		"\xB8\x3\x2\x2\x2\xB8\xB6\x3\x2\x2\x2\xB8\xB9\x3\x2\x2\x2\xB9\x38\x3\x2"+
		"\x2\x2\xBA\xBE\a$\x2\x2\xBB\xBD\n\x3\x2\x2\xBC\xBB\x3\x2\x2\x2\xBD\xC0"+
		"\x3\x2\x2\x2\xBE\xBC\x3\x2\x2\x2\xBE\xBF\x3\x2\x2\x2\xBF\xC1\x3\x2\x2"+
		"\x2\xC0\xBE\x3\x2\x2\x2\xC1\xCB\a$\x2\x2\xC2\xC6\a)\x2\x2\xC3\xC5\n\x4"+
		"\x2\x2\xC4\xC3\x3\x2\x2\x2\xC5\xC8\x3\x2\x2\x2\xC6\xC4\x3\x2\x2\x2\xC6"+
		"\xC7\x3\x2\x2\x2\xC7\xC9\x3\x2\x2\x2\xC8\xC6\x3\x2\x2\x2\xC9\xCB\a)\x2"+
		"\x2\xCA\xBA\x3\x2\x2\x2\xCA\xC2\x3\x2\x2\x2\xCB:\x3\x2\x2\x2\xCC\xCD\a"+
		"v\x2\x2\xCD\xCE\at\x2\x2\xCE\xCF\aw\x2\x2\xCF\xD6\ag\x2\x2\xD0\xD1\ah"+
		"\x2\x2\xD1\xD2\a\x63\x2\x2\xD2\xD3\an\x2\x2\xD3\xD4\au\x2\x2\xD4\xD6\a"+
		"g\x2\x2\xD5\xCC\x3\x2\x2\x2\xD5\xD0\x3\x2\x2\x2\xD6<\x3\x2\x2\x2\xD7\xD8"+
		"\ap\x2\x2\xD8\xD9\aw\x2\x2\xD9\xDA\an\x2\x2\xDA\xDB\an\x2\x2\xDB>\x3\x2"+
		"\x2\x2\xDC\xDD\a@\x2\x2\xDD\xDE\a,\x2\x2\xDE\xE2\x3\x2\x2\x2\xDF\xE1\v"+
		"\x2\x2\x2\xE0\xDF\x3\x2\x2\x2\xE1\xE4\x3\x2\x2\x2\xE2\xE3\x3\x2\x2\x2"+
		"\xE2\xE0\x3\x2\x2\x2\xE3\xE5\x3\x2\x2\x2\xE4\xE2\x3\x2\x2\x2\xE5\xE6\a"+
		",\x2\x2\xE6\xE7\a>\x2\x2\xE7\xE8\x3\x2\x2\x2\xE8\xE9\b \x2\x2\xE9@\x3"+
		"\x2\x2\x2\xEA\xEB\a@\x2\x2\xEB\xEC\a@\x2\x2\xEC\xF0\x3\x2\x2\x2\xED\xEF"+
		"\n\x5\x2\x2\xEE\xED\x3\x2\x2\x2\xEF\xF2\x3\x2\x2\x2\xF0\xEE\x3\x2\x2\x2"+
		"\xF0\xF1\x3\x2\x2\x2\xF1\xF3\x3\x2\x2\x2\xF2\xF0\x3\x2\x2\x2\xF3\xF4\b"+
		"!\x2\x2\xF4\x42\x3\x2\x2\x2\xF5\xF6\a\f\x2\x2\xF6\x44\x3\x2\x2\x2\xF7"+
		"\xF9\t\x6\x2\x2\xF8\xF7\x3\x2\x2\x2\xF9\xFA\x3\x2\x2\x2\xFA\xF8\x3\x2"+
		"\x2\x2\xFA\xFB\x3\x2\x2\x2\xFB\xFC\x3\x2\x2\x2\xFC\xFD\b#\x2\x2\xFD\x46"+
		"\x3\x2\x2\x2\xFE\x102\t\a\x2\x2\xFF\x101\t\b\x2\x2\x100\xFF\x3\x2\x2\x2"+
		"\x101\x104\x3\x2\x2\x2\x102\x100\x3\x2\x2\x2\x102\x103\x3\x2\x2\x2\x103"+
		"H\x3\x2\x2\x2\x104\x102\x3\x2\x2\x2\x12\x2\x81\x94\xA2\xA8\xAD\xB2\xB8"+
		"\xBE\xC6\xCA\xD5\xE2\xF0\xFA\x102\x3\b\x2\x2";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
} // namespace Tetl.Content
