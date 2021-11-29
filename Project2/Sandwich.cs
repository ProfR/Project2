using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project2 {
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
				meats = value; }
		}

		/// <summary>
		/// Cheese Selected
		/// </summary>
		public Cheese Cheese { get; set; }

		public Sandwich() { }

		public Sandwich( Size _size, Dressing _dressing, List<Topping> _toppings, List<Meat> _meats, Cheese _cheese ) {
			Size = _size;
			Dressing = _dressing;
			Toppings = _toppings;
			Meats = _meats;
			Cheese = _cheese;
		}
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

		public string Format() { return "{0,-23} {1,8:C}\n"; }

		public override string ToString() {
			string summary = "";
			summary += string.Format( Format(), $"Size: {Size}", Utility.GetPrice( Size, Utility.SIZE_INDEX ) );
			summary += string.Format( Format(), $"Dressing: {Dressing}", 0 );
			foreach (Topping aTopping in Toppings) {
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