using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project2 {
	public static class Utility {
		/// <summary>
		/// Array with current pricing structure
		/// </summary>
		static double[,] prices = { {2.00, 4.00, 6.00 },
									{0.15, 0.25, 0.35 },
									{1.25, 2.00, 2.50 },
									{0.75, 1.10, 1.25 } };
		/// <summary>
		/// Size index to pricing array
		/// </summary>
		public const int SIZE_INDEX = 0;
		/// <summary>
		/// Topping index to pricing array
		/// </summary>
		public const int TOPPING_INDEX = 1;
		/// <summary>
		/// Meat index to pricing array
		/// </summary>
		public const int MEAT_INDEX = 2;
		/// <summary>
		/// Cheese index to pricing array
		/// </summary>
		public const int CHEESE_INDEX = 3;
		public const ConsoleColor ERROR = ConsoleColor.Red;
		public const ConsoleColor TEXT = ConsoleColor.White;
		public const ConsoleColor PROMPT = ConsoleColor.Yellow;
		public const ConsoleColor MENU = ConsoleColor.Cyan;

		static double DELIVERY_FEE = 4.50;


		/// <summary>
		/// Displays the provided text string in the specified color
		/// </summary>
		/// <param name="_msg">Text to display</param>
		/// <param name="_color">Color to display</param>
		/// <param name="_newLine">Include New Line (default true)</param>
		public static void WriteColor( string _msg, ConsoleColor _color, bool _newLine = true ) {
			Console.ForegroundColor = _color;
			Console.Write( _newLine ? _msg + '\n' : _msg );
			Console.ResetColor();
		}
	}
}