using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CheckoutTomasRito.DataAccess.Interfaces;
using CheckoutTomasRito.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CheckoutTomasRito.DataAccess
{
    public class ShoppingCartRepository : IRepository<UserCart>
    {
        // ideally this lives on a login/session service and the system keeps the curren_user_id on a global variable;
        // to be implemented in the future;
        // setting it to 1 for test purposes
        private const int CURRENT_USER_ID = 1;
        public static ShoppingCart usersShoppingCarts = new ShoppingCart();

      
        public void Add(UserCart userCart)
        {
			userCart.userId = CURRENT_USER_ID;
            usersShoppingCarts.shoppingCart.Add(userCart);
        }

        public void Delete(UserCart shoppingCart)
        {
			var clearedShoppingCart = new List<CartItem>();
			shoppingCart.items = clearedShoppingCart;
        }

        public UserCart Get()
        {
            try
            {
                var currentUserCart = usersShoppingCarts.shoppingCart.FirstOrDefault(w => w.userId == CURRENT_USER_ID);

                var returnCar = currentUserCart != null ? currentUserCart : new UserCart();
                return returnCar;
            }
              
            catch(Exception e)
            {
                throw e;
            }

        }

        // TODO:
        // Manage state of entity (created, modified, deleted)
        // so can be directly changed in the DB without a previous check
        public void Save(UserCart userCart){
			try
			{
                userCart.userId = CURRENT_USER_ID;
                var currentUserItems = usersShoppingCarts.shoppingCart.FirstOrDefault(w => w.userId == CURRENT_USER_ID);
				
			    currentUserItems.items = userCart.items;
				
			}
			catch (Exception e)
			{
				throw e;
			}

        }


    }

}