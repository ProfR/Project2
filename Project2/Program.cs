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
		static Size size;
		static Dressing dressing;
		static Cheese cheese;
		static List<Topping> toppings;
		static List<Meat> meats;

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
				Utility.WriteColor( "  ==> Order set as pickup ", Utility.MENU );
				isDelivery = false;
			} else {
				Utility.WriteColor( "  ==> Order set as delivery ", Utility.MENU );
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
			Utility.WriteColor( $"\n ==> Now entering selections for Sandwich #{_count}\n", Utility.PROMPT );

			meats = new List<Meat>();
			toppings = new List<Topping>();
			
			size = (Size)GetSandwichSize();
			dressing = (Dressing)GetDressing();
			GetToppings();
			GetMeats();
			cheese = (Cheese)GetCheese();


			//Console.WriteLine( $"{size}" );
			Sandwich aSandwich = new Sandwich(size, dressing, toppings, meats, cheese);
			sandwiches.Add( aSandwich );
			Console.WriteLine();
			Utility.WriteColor( aSandwich.ToString(), Utility.MENU );
			Utility.WriteColor( string.Format( "{0,20}, {1,8:C}", "  == SUBTOTAL ==>", aSandwich.CalculateSubTotal() ), Utility.PROMPT );
			//Utility.WriteColor( $"The total for this sandwich is { aSandwich.CalculateSubTotal():C}", Utility.MENU );
		}

		public static int GetSandwichSize() {
			List<string> sizes = new List<string>();
			foreach ( Size value in Enum.GetValues( typeof( Size ) ) ) sizes.Add( value.ToString() );
			return Utility.GetEnumValue( sizes, "\nSelect a sandwich size: ", "Enter the selection for the desired sandwich size: " );

		}

		public static int GetDressing() {
			List<string> dressings = new List<string>();
			foreach ( Dressing value in Enum.GetValues( typeof( Dressing ) ) ) dressings.Add( value.ToString() );
			return Utility.GetEnumValue( dressings, "\nSelect a dressing: ", "Enter the selection for the desired dressing: " );
		}

		public static int GetCheese() {
			List<string> cheeses = new List<string>();
			foreach ( Cheese value in Enum.GetValues( typeof( Cheese ) ) ) cheeses.Add( value.ToString() );
			return Utility.GetEnumValue( cheeses, "\nSelect a cheese: ", "Enter the selection for the desired cheese: " );
		}

		public static void GetMeats() {
			List<string> choices = new List<string>();
			foreach ( Meat value in Enum.GetValues( typeof( Meat ) ) ) choices.Add( value.ToString() );
			while(true) {
				Meat aMeat =  (Meat) Utility.GetEnumValue ( choices, "\nSelect a meat: ", "Enter the selection for the desired meat: ");
				meats.Add( aMeat );
				Utility.WriteColor( "\n ==> Do you want to add another (or duplicate) meat to this sandwich? (y/n) ", Utility.PROMPT, SAMELINE );
				char orderDone = Console.ReadLine()[0];
				if ( char.ToUpper( orderDone ) != 'Y' ) break;
			}
		}
		public static void GetToppings() {
			List<string> choices = new List<string>();
			foreach ( Topping value in Enum.GetValues( typeof( Topping ) ) ) choices.Add( value.ToString() );
			while ( true ) {
				Topping aTopping =  (Topping) Utility.GetEnumValue ( choices, "\nSelect a topping: ", "Enter the selection for the desired topping: ");
				toppings.Add( aTopping );
				Utility.WriteColor( "\n ==> Do you want to add another (or duplicate) topping to this sandwich? (y/n) ", Utility.PROMPT, SAMELINE );
				char orderDone = Console.ReadLine()[0];
				if ( char.ToUpper( orderDone ) != 'Y' ) break;
			}
		}

		public static void CreateReceipt() {
			Console.WriteLine( "DONE" );
		}

	}
}
