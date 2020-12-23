using Shopping.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data
{
    public interface IDiscountDAL
    {
        List<Discount> SelectAllDiscounts();
    }

    public class DiscountDAL: IDiscountDAL
    {
        /// <summary>
        /// Mocked discount data to use for the shopping cart
        /// </summary>
        /// <returns>list of discounted items</returns>
        public List<Discount> SelectAllDiscounts()
        {
            List<Discount> ListDiscounts = new List<Discount>();
            ListDiscounts.Add(new Discount() { ID = 1, Product_Id = 1, Product_Id_Discounted = 3, Quantity = 2, Percentage = 50 });
            ListDiscounts.Add(new Discount() { ID = 2, Product_Id = 2, Product_Id_Discounted = 2, Quantity = 3, Percentage = 100 });
            return ListDiscounts;
        }
    }
}
