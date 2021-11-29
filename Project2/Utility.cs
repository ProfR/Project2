using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project2 {
	/// <summary>
	/// Class containing utility methods and static constants
	/// </summary>
	/// <remarks>
	/// This class contains:
	/// 1. Pricing matrix
	/// 2. Constants for accessing the matrix
	/// 3. A method for capturing pricing from the matrix
	/// 4. Color display constants
	/// 5. Tax Rate
	/// 6. Method to display text in color
	/// 7. Method to generate a menu list, obtain input, validate input
	/// </remarks>
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
		/// <summary>
		/// Color value to display errors
		/// </summary>
		public const ConsoleColor ERROR = ConsoleColor.Red;
		/// <summary>
		/// Color value for generic text
		/// </summary>
		public const ConsoleColor TEXT = ConsoleColor.White;
		/// <summary>
		/// Color value to display prompt after menu list
		/// </summary>
		public const ConsoleColor PROMPT = ConsoleColor.Yellow;
		/// <summary>
		/// Color value to display menu items
		/// </summary>
		public const ConsoleColor MENU = ConsoleColor.Cyan;
		/// <summary>
		/// Color for receipt accents
		/// </summary>
		public const ConsoleColor HEADER = ConsoleColor.Green;

		/// <summary>
		/// Static charge for a delivery order
		/// </summary>
		public const double DELIVERY_FEE = 4.50;
		/// <summary>
		/// Constant value indicating a WriteColor should not start a new line
		/// </summary>
		public const bool SAMELINE = false;
		/// <summary>
		/// Static Tax Rate
		/// </summary>
		public const double TAX_RATE = .08;


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

		/// <summary>
		/// Gets the index to a provided enum list.  Automatically confirms entered value is numeric and in range.
		/// </summary>
		/// <param name="_values">List of string containing the values for the enum</param>
		/// <param name="_intro">string to be presented at the top of the selection list</param>
		/// <param name="_prompt">prompt issued after the selection list is displayed</param>
		/// <returns>int marker corresponding to the the selection made.</returns>
		public static int GetEnumValue( List<string> _values, string _intro, string _prompt ) {
			int choice;
			while ( true ) {
				Utility.WriteColor( _intro, Utility.TEXT );
				for ( int index = 0; index < _values.Count; index++ ) {
					Utility.WriteColor( $"  {index + 1}. {_values[index]}", Utility.MENU );
				}
				Utility.WriteColor( _prompt + " ", Utility.PROMPT, SAMELINE );
				// error trap
				if ( !( int.TryParse( Console.ReadLine(), out choice ) ) ) {
					Utility.WriteColor( $"Please enter a numeric value between 1 and {_values.Count}\n", Utility.ERROR );
					continue;
				}
				if ( choice < 1 || choice > _values.Count ) {
					Utility.WriteColor( $"Please enter a numeric value between 1 and {_values.Count}\n", Utility.ERROR );
					continue;
				}
				break;
			}
			return choice - 1;
		}

		/// <summary>
		/// Utility to obtain an item price for a specific size
		/// </summary>
		/// <param name="_size">Index value to the sub size (based on the size enum)</param>
		/// <param name="_type">Index value to the price row (size, topping, meat, etc.)</param>
		public static double GetPrice( Size _size, int _type ) {
			return prices[_type, (int)_size];
		}
	}
}