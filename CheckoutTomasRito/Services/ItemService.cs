using System;
using CheckoutTomasRito.DataAccess.Interfaces;
using CheckoutTomasRito.DataAccess;
using CheckoutTomasRito.DTO;
using CheckoutTomasRito.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

// Main Assumptions:
// Each user can only have on shopping cart

namespace CheckoutTomasRito.Services
{
    public class ItemService : IItemService
    {
        private IRepository<UserCart> _shoppingCartRepo;

        public ItemService(IRepository<UserCart> shoppingCartRepo)
        {
            _shoppingCartRepo = shoppingCartRepo;
        }

        public ItemService() : this(new ShoppingCartRepository()){}

        public UserCart GetShoppingCart()
		{
            return _shoppingCartRepo.Get();
		}

        public void AddItem(int id, int quantity)
        {
            // get current user shopping cart
            var shoppingCart = _shoppingCartRepo.Get();
            var alreadyExists = ValidateEntry(shoppingCart, id);

            if(alreadyExists){
                throw new ArgumentException("The item already exists in the shopping cart");
            }

            shoppingCart.items.Add(new CartItem(){itemId = id, quantity = quantity});
            _shoppingCartRepo.Add(shoppingCart);
        }

        public void ChangeQuantity(int id, int quantity)
        {
			// get current user shopping cart
			var shoppingCart = _shoppingCartRepo.Get();

			var requestedItem = shoppingCart.items.Where(w => w.itemId == id).FirstOrDefault();

            // item doesn't exist -> add it
            if (requestedItem == null)
            {
                AddItem(id, quantity);
            }
            else
            {
                requestedItem.quantity = quantity;
                _shoppingCartRepo.Save(shoppingCart);
            }
        }

        public void RemoveItem(int id)
		{
			// get current user shopping cart
			var shoppingCart = _shoppingCartRepo.Get();

            var exists = ValidateEntry(shoppingCart, id);

            if(exists)
            {
                // remove item from cart
                var removedItem = shoppingCart.items.Where(w => w.itemId != id).ToList();
                shoppingCart.items = removedItem;
                // save new cart
                _shoppingCartRepo.Save(shoppingCart);
            }
            else{
                throw new ArgumentException("The item doesn't exist in the shopping cart");
            }
		}

        public void ClearItems()
        {
			// get current user shopping cart
			var shoppingCart = _shoppingCartRepo.Get();
            _shoppingCartRepo.Delete(shoppingCart);
		}

		private bool ValidateEntry(UserCart shoppingCart, int id)
		{
			return shoppingCart.items.Any(w => w.itemId == id);
		}
    }
}
