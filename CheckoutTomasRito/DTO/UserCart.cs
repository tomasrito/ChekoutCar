using System;
using System.Collections.Generic;

namespace CheckoutTomasRito.DTO
{
    public class UserCart
    {
        public UserCart(){
            items = new List<CartItem>();
        }
        public int userId { get; set; }
        public List<CartItem> items {get; set;}
    }
}
