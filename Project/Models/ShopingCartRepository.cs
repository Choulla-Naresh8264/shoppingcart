using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class ShopingCartRepository : IShopingCart
    {
        public ShopingCart AddToCart(String title, String quantity, String price)
        {
            ShopingCart shopingcart = new ShopingCart();

            shopingcart.Title = title;
            shopingcart.Quantity = quantity;
            shopingcart.Price = int.Parse(price) * int.Parse(quantity);

            using(var context = new Database1Entities8())
            {
                context.ShopingCarts.Add(shopingcart);
                context.SaveChanges();
            }

            return shopingcart;
        }

        public List<ShopingCart> getShopingDetail()
        {
            using(var context = new Database1Entities8())
            {
                return context.ShopingCarts.ToList();
            }
        }

        public void performCheckOut()
        {
            using(var context = new Database1Entities8())
            {
                var data = from x in context.ShopingCarts select x;

                foreach (var item in data)
                {
                    var query = context.Products.Find(item.Title);
                    int purchase = query.Purchase;
                    int quantity = int.Parse(item.Quantity);
                    purchase = purchase * quantity;
                    SaledProduct sp = new SaledProduct();
                    sp.Title = item.Title;
                    sp.Sale = item.Price;
                    sp.Purchase = purchase;
                    sp.Profit = item.Price - purchase;
                    sp.Date = System.DateTime.Now;

                    context.SaledProducts.Add(sp);
                }
                context.SaveChanges();

                foreach (var item in data)
                {
                    context.ShopingCarts.Remove(item);
                }
                context.SaveChanges();
            }
        }
    }
}