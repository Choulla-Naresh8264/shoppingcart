using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public interface IShopingCart
    {
        ShopingCart AddToCart(String title,String quantity,String price);
        List<ShopingCart> getShopingDetail();
        void performCheckOut();
    }
}
