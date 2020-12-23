using Shopping.Data;
using Shopping.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Business
{
    public class DiscountBLL
    {
        public IDiscountDAL discountDAL;

        public DiscountBLL (IDiscountDAL discountDAL)
        {
            this.discountDAL = discountDAL;
        }
        public List<Discount> GetAllDiscounts()
        {
            return discountDAL.SelectAllDiscounts();
        }
    }
}
