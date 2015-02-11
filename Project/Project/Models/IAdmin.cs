using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public interface IAdmin
    {
        Boolean loginAdmin(String name,String password);
        List<Product> getProduct(String category);
        Product edit(String title);
        void update(Product product);
        void delete(String title);
        void addProduct(String title,String price,String purchase,String company,String category,String files);
        void reports();
    }
}
