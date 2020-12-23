using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Model
{
    public class Discount
    {
        public int ID { get; set; }
        public int Product_Id { get; set; }
        public int Product_Id_Discounted { get; set; }
        public int Percentage { get; set; }
        public int Quantity { get; set; }
    }
}
