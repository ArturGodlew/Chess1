using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;
using System.Configuration;
using Godot.NativeInterop;
using System;
using System.IO;

namespace Chess1
{
	internal static class BoardVisuals
	{
		private static Color _defaultWhite = Color.Color8(0, 0, 0, 255);
		private static Color _defaultBlack = Color.Color8(255, 255, 255, 255);

		private static ConfigFile _config;
		private static ConfigFile Config 
		{ 
			get 
			{
				if (_config is null)
				{
					_config = new ConfigFile();
					_config.Load("Board.cfg");
				}
				return _config;
			} 
		}


		private static string _pieceSetPath;
		public static string PieceSetPath
		{ 
			get { return _pieceSetPath ??= Directory.GetCurrentDirectory() + "/Sprites/" + Config.GetValue("pieces", "set_folder_name"); }
		}

		private static Color? _whitePieceColor;
		public static Color WhitePieceColor
		{
			get { return _whitePieceColor ??= Color.FromString(Config.GetValue("pieces", "w_color").AsString(), _defaultWhite); }
		}

		private static Color? _blackPieceColor;
		public static Color BlackPieceColor
		{
			get { return _blackPieceColor ??= Color.FromString(Config.GetValue("pieces", "b_color").AsString(), _defaultBlack); }
		}

		private static Color? _whiteSquareColor;
		public static Color WhiteSquareColor
		{
			get { 
				GD.Print($"{Config.GetValue("squares", "w_color").AsString()}");
				GD.Print($"{Config.GetValue("squares", "custom").AsBool()}");
				 return _whiteSquareColor ??= Config.GetValue("squares", "custom").AsBool()? Color.FromString(Config.GetValue("squares", "w_color").AsString(), _defaultWhite): WhitePieceColor; }
		}

		private static Color? _blackSquareColor;
		public static Color BlackSquareColor
		{
			get { return _blackSquareColor ??= Config.GetValue("squares", "custom").AsBool() ? Color.FromString(Config.GetValue("squares", "b_color").AsString(), _defaultBlack) : BlackPieceColor; }
		}
	}
}
