using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project2 {
	/// <summary>
	/// Class to contain a single detailed instance of a sandwich
	/// </summary>
	public class Sandwich {
		/// <summary>
		/// Backing Array containing selected meats
		/// </summary>
		private List<Meat> meats;
		/// <summary>
		/// Backing Array containing selected toppings
		/// </summary>
		private List<Topping> toppings;

		/// <summary>
		/// Size of the sandwich
		/// </summary>
		public Size Size { get; set; }

		/// <summary>
		/// Array containing selected toppings
		/// </summary>
		public List<Topping> Toppings {
			get { return toppings; }
			set {
				toppings = value;
			}
		}

		/// <summary>
		/// Dressing selected
		/// </summary>
		public Dressing Dressing { get; set; }

		/// <summary>
		/// Array containing selected meats
		/// </summary>
		public List<Meat> Meats {
			get { return meats; }
			set {
				meats = value;
			}
		}

		/// <summary>
		/// Cheese Selected
		/// </summary>
		public Cheese Cheese { get; set; }

		/// <summary>
		/// Default Constructor
		/// </summary>
		public Sandwich() { }

		/// <summary>
		/// Parameterized Constructor
		/// </summary>
		/// <param name="_size">Sandwich Size</param>
		/// <param name="_dressing">Sandwich Dressing (or none)</param>
		/// <param name="_toppings">
		/// List containing individual topping selections.  
		/// Note: user can select multiple toppings and can double up toppings by multiple selection.
		/// </param>
		/// <param name="_meats">List containing individual meet selections.</param>
		/// <param name="_cheese">Cheese selected for the sandwich</param>
		public Sandwich( Size _size, Dressing _dressing, List<Topping> _toppings, List<Meat> _meats, Cheese _cheese ) {
			Size = _size;
			Dressing = _dressing;
			Toppings = _toppings;
			Meats = _meats;
			Cheese = _cheese;
		}
		/// <summary>
		/// Calculate the cost for this sandwich based on the options selected
		/// </summary>
		public double CalculateSubTotal() {
			int subSize = (int) Size;
			double subtotal = 0.0;
			subtotal += Utility.GetPrice( Size, Utility.SIZE_INDEX );
			foreach ( Topping aTopping in Toppings ) {
				if ( aTopping.ToString() != "None" ) subtotal += Utility.GetPrice( Size, Utility.TOPPING_INDEX );
			}
			foreach ( Meat aMeat in Meats ) {
				if ( aMeat.ToString() != "None" ) subtotal += Utility.GetPrice( Size, Utility.MEAT_INDEX );
			}
			if ( Cheese.ToString() != "None" ) subtotal += Utility.GetPrice( Size, Utility.CHEESE_INDEX );
			return subtotal;
		}

		/// <summary>
		/// Method to return a string used for formatting
		/// </summary>
		public string Format() { return "{0,-23} {1,8:C}\n"; }

		/// <summary>
		/// Method to prepare a formatted string containing all detail for the sandwich
		/// </summary>
		public override string ToString() {
			string summary = "";
			summary += string.Format( Format(), $"Size: {Size}", Utility.GetPrice( Size, Utility.SIZE_INDEX ) );
			summary += string.Format( Format(), $"Dressing: {Dressing}", 0 );
			foreach ( Topping aTopping in Toppings ) {
				if ( aTopping.ToString() != "None" ) summary += string.Format( Format(), $"Topping: {aTopping.ToString()}", Utility.GetPrice( Size, Utility.TOPPING_INDEX ) );
			}
			foreach ( Meat aMeat in Meats ) {
				if ( aMeat.ToString() != "None" ) summary += String.Format( Format(), $"Meat: {aMeat.ToString()}", Utility.GetPrice( Size, Utility.MEAT_INDEX ) );
			}
			if ( Cheese.ToString() != "None" ) summary += String.Format( Format(), $"Cheese: {Cheese.ToString()}", Utility.GetPrice( Size, Utility.CHEESE_INDEX ) );
			return summary;
		}
	}
}