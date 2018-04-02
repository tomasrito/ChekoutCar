using System;
using System.Collections.Generic;
using CheckoutTomasRito.DTO;

namespace CheckoutTomasRito.DataAccess.Interfaces
{
    public interface IShoppingCartRepository
    {
        UserCart Get();

        void Save(UserCart userCart);
    }
}
