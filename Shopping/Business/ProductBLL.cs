using Shopping.Data;
using Shopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopping.Business
{
    public class ProductBLL
    {
        public IProductDAL productDAL;

        public ProductBLL(IProductDAL productDAL)
        {
            this.productDAL = productDAL;
        }

        public List<Product> GetAllProducts()
        {
            return productDAL.SelectAllProducts();
        }


       

    }
}
