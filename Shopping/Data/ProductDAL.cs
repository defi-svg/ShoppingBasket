using Shopping.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Data
{
    public interface IProductDAL
    {
        List<Product> SelectAllProducts();
    }

    public class ProductDAL:IProductDAL
    {
        /// <summary>
        /// Mocked product data to use for the shopping cart
        /// </summary>
        /// <returns></returns>

        public List<Product> SelectAllProducts()
        {
            List<Product> ListProducts = new List<Product>();
            ListProducts.Add(new Product() { ID = 1, Name = "Butter", Price =0.80M });
            ListProducts.Add(new Product() { ID = 2, Name = "Milk", Price = 1.15m });
            ListProducts.Add(new Product() { ID = 3, Name = "Bread", Price = 1.00M });
            return ListProducts;
        }

    }

}
