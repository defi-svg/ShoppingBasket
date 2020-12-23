using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Model
{
    public class Basket
    {
       public List<BasketItem> basketItems { get; set; }
    }


    public class BasketItem
    {
        public Product product { get; set; }
        public decimal price { get; set; }
        public int Qt { get; set; }
        public Discount discount { get; set; }
        public bool discountedItem { get; set; }
        public decimal totalPrice { get; set; }
    }
}
