using System;
namespace CheckoutTomasRito.DTO
{
    public class Item
    {
        public int itemId { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int discount { get; set; }
    }
}
