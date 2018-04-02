using System;
using System.Collections.Generic;

namespace CheckoutTomasRito.DTO
{

    public class ShoppingCart
    {
		public ShoppingCart()
		{
            shoppingCart = new List<UserCart>();
	    }

        public List<UserCart> shoppingCart { get; set; }
    }
}
