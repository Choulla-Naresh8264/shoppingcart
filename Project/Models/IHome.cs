using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public interface IHome
    {
        List<Product> getProducts(String category);
        Boolean loginUser(String name, String password);
        Boolean signupUser(String name, Customer customer);
        Product getProduct(String title);
        Customer getCustomer(String name);
    }
}
