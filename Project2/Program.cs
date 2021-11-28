using System;
using System.Collections.Generic;


namespace Project2 {
	class Program {
		/// <summary>
		/// List containing sandwich objects
		/// </summary>
		static List<Sandwich> sandwiches = new List<Sandwich>();
		private static bool isDelivery;
		const bool SAMELINE = false;
		static string customerName;

		static void Main( string[] args ) {
			Welcome();
			StartOrder();
			TakeOrder();
			CreateReceipt();
		}

		/// <summary>
		/// Displays Welcome message and requests customer name
		/// </summary>
		public static void Welcome() {
			Console.Clear();
			Utility.WriteColor( "==> Welcome to T-Squared! <==", Utility.PROMPT );
			Utility.WriteColor( "==> " + DateTime.Now, Utility.TEXT );
			Utility.WriteColor( "==> ===================== <==\n", Utility.PROMPT );
		}

		/// <summary>
		/// Asks for Name and Delivery Action
		/// </summary>
		public static void StartOrder() {
			Utility.WriteColor( "Please Enter the customer's first name ==> ", Utility.PROMPT, SAMELINE );
			customerName = Console.ReadLine();
			if ( string.IsNullOrWhiteSpace( customerName ) ) customerName = "Unknown";
			Utility.WriteColor( "Is this a delivery order? (y/n) ==> ", Utility.PROMPT, SAMELINE );
			char deliveryTest = Console.ReadLine()[0];
			if ( char.ToUpper(deliveryTest) != 'Y') {
				Utility.WriteColor( "  ==> Invalid Entry -- Order set as pickup ", Utility.ERROR );
				isDelivery = false;
			} else {
				isDelivery = true;
			}

		}

		public static void TakeOrder() {
			int sandwichCount = 0;


			do {
				sandwichCount++;
				// get an order here
				GetSandwich( sandwichCount );
				Utility.WriteColor( " ==> Do you want to add another sandwich to this order? (y/n) ", Utility.PROMPT, SAMELINE );
				char orderDone = Console.ReadLine()[0];
				if ( char.ToUpper( orderDone ) != 'Y' ) break;
			} while ( true );

		}

		public static void GetSandwich ( int _count ) {
			Utility.WriteColor( $" ==> Now entering selections for Sandwich #{_count}\n", Utility.PROMPT );

			Sandwich aSandwich = new Sandwich();
			sandwiches.Add( aSandwich );
			
		}

		public static void CreateReceipt() {
			Console.WriteLine( "DONE" );
		}
	}
}
