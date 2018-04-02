using System;
using System.Collections.Generic;
using CheckoutTomasRito.DTO;

namespace CheckoutTomasRito.Services.Interfaces
{
    public interface IItemService
    {
        UserCart GetShoppingCart();

        void AddItem(int id, int quantity);

		void ChangeQuantity(int id, int quantity);

        void RemoveItem(int id);

		void ClearItems();
    }
}
