using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project2 {
	public class Sandwich {
		/// <summary>
		/// Backing Array containing selected meats
		/// </summary>
		private Meat[] meats;
		/// <summary>
		/// Backing Array containing selected toppings
		/// </summary>
		private Topping[] toppings;

		public Sandwich() {}

		/// <summary>
		/// Size of the sandwich
		/// </summary>
		public Size Size {
			get => default;
			set {
			}
		}

		/// <summary>
		/// Array containing selected toppings
		/// </summary>
		public Topping[] Toppings {
			get => default;
			set {
			}
		}

		/// <summary>
		/// Dressing selected
		/// </summary>
		public Dressing Dressing {
			get => default;
			set {
			}
		}

		/// <summary>
		/// Array containing selected meats
		/// </summary>
		public Meat[] Meat {
			get => default;
			set {
			}
		}

		/// <summary>
		/// Cheese Selected
		/// </summary>
		public Cheese Cheese {
			get => default;
			set {
			}
		}

		public void AddMeat( Meat _meat ) {
			throw new System.NotImplementedException();
		}

		public void AddTopping( Topping _topping ) {
			throw new System.NotImplementedException();
		}
	}
}