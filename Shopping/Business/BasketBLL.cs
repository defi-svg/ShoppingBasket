using Shopping.Data;
using Shopping.Model;
using Shopping.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping.Business
{
    public class BasketBLL
    {
        List<Product> _products;
        List<Discount> _discounts;
        decimal _totalSum = 0;
        Basket basket;

        /// <summary>
        /// Initialize Basket and List<BasketItem> used for the shopping cart
        /// </summary>
        public BasketBLL()
        {
            this.basket = new Basket();
            this.basket.basketItems = new List<BasketItem>();
        }


        /// <summary>
        /// Depending on the chosen option, call the appropriate calculation
        /// </summary>
        /// <param name="input">1-4</param>
        /// <returns></returns>
        public decimal ShoppingList(int input)
        {
            
            switch (input)
            {
                case 1:
                    AddItem(3, 1);
                    AddItem(1, 1);
                    AddItem(2, 1);
                    FinalSum();
                    Logger.logError("", "");
                    break;
                case 2:
                    AddItem(1, 2);
                    AddItem(3, 2);
                    FinalSum();
                    Logger.logError("", "");
                    break;
                case 3:
                    AddItem(2, 4);
                    FinalSum();
                    Logger.logError("", "");
                    break;
                case 4:
                    AddItem(1, 2);
                    AddItem(3, 1);
                    AddItem(2, 8);
                    FinalSum();
                    Logger.logError("", "");
                    break;
                default:
                    break;
            }
            return _totalSum;
        }


        /// <summary>
        /// Add item to the basket and verify if it have some discount with that
        /// </summary>
        /// <param name="productId">id of the product</param>
        /// <param name="quantity">quantity of the product selected</param>
        private void AddItem(int productId, int quantity)
        {
            //ALL products
            ProductBLL productBLL = new ProductBLL(new ProductDAL());
            _products = productBLL.GetAllProducts();

            //ALL discounts
            DiscountBLL discountBLL = new DiscountBLL(new DiscountDAL());
            _discounts = discountBLL.GetAllDiscounts();

            //Get product by Id
            Product product = _products.FirstOrDefault(a => a.ID == productId);
            //Get discount of the productId
            Discount discount = _discounts.FirstOrDefault(b => b.Product_Id == productId);


            BasketItem b = new BasketItem();
            b.product = product;
            b.discount = discount;
            b.Qt = quantity;
            b.price = b.product.Price;
            b.discountedItem = false; // the current item is not discounted
            b.totalPrice = b.Qt * b.price;

            basket.basketItems.Add(b);

            if (b.discount != null) //if a discount is found
            {
                BasketItem basketItemDiscounted = new BasketItem();
                basketItemDiscounted = CalcDiscount(b.discount, b.Qt); 
                if (basketItemDiscounted != null)
                    basket.basketItems.Add(basketItemDiscounted); //add discounted item
            }

           
        }

        /// <summary>
        /// Calculate if the values get some discount and which discount is
        /// </summary>
        /// <param name="d">discount found</param>
        /// <param name="quantity">quantity of the primary product</param>
        /// <returns></returns>
        private BasketItem CalcDiscount(Discount d, int quantity)
        {
            BasketItem basketItem = new BasketItem();

            if (quantity >= d.Quantity)
            {
                //how many discounted items it has to be added to the basket
                int countItemsDiscounted = Convert.ToInt32(Math.Floor(Convert.ToDecimal(quantity) / Convert.ToDecimal(d.Quantity)));
                //property of the discounted product
                Product p = _products.FirstOrDefault(a => a.ID == d.Product_Id_Discounted);
                if (p != null)
                {
                    //percentage of the discount
                    decimal percentage = (p.Price * Convert.ToDecimal(d.Percentage)) / 100;
                    //final value of the discounted product minus the percentage value
                    decimal discountPriceAddItem = countItemsDiscounted * (p.Price-(p.Price - percentage));

                    basketItem.product = p;
                    basketItem.Qt = countItemsDiscounted;
                    basketItem.price = discountPriceAddItem/ countItemsDiscounted; //price for each discounted item
                    basketItem.totalPrice = discountPriceAddItem;
                    basketItem.discountedItem = true;
                }
                return basketItem;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Calculate the total sum of the shopping cart
        /// </summary>
        private void FinalSum()
        {
            //list of the full priced products
            List<BasketItem> listBasket_FullPrice = basket.basketItems.Where(a => a.discountedItem == false).ToList(); 
            //list of the discounted products
            List<BasketItem> listBasket_DiscountedPrice = (List<BasketItem>)basket.basketItems.Where(a => a.discountedItem == true).ToList();


            foreach(BasketItem bd in listBasket_DiscountedPrice) //verify if the discounted and the full prices are the same item
            {
                BasketItem item = listBasket_FullPrice.FirstOrDefault(b => b.product.ID == bd.product.ID);
                BasketItem discountedItem = new BasketItem();

                if (item != null)
                {
                    discountedItem.product = item.product;
                    discountedItem.Qt = item.Qt;
                    discountedItem.totalPrice=item.totalPrice - bd.totalPrice; //set the total price to be minus the discounted price
                }
                listBasket_FullPrice.Remove(item); //remove from the full price items
                listBasket_FullPrice.Add(discountedItem); //add to the discounted items
            }

            foreach (BasketItem item in listBasket_FullPrice)
            {
                _totalSum += item.totalPrice; 
                Logger.logError("Shopping Cart", $"Product:{item.product.Name} Qt:{item.Qt} Price per product:{item.price} TotalSum:$ {_totalSum:0.00} ");
            }
        }

  
    }
}
