using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class HomeRepository : IHome
    {
        public List<Product> getProducts(String category)
        {
            using (var context = new Database1Entities8())
            {
                if (category == null)
                {
                    return context.Products.Where(x => x.Category.Equals("Clothes")).ToList();
                }
                else
                {
                    return context.Products.Where(x => x.Category.Equals(category)).ToList();
                }
            }
        }

        public Boolean loginUser(String name, String password)
        {
            using (var context = new Database1Entities8())
            {
                var query = context.Customers.Find(name);

                if (query != null && query.Password.Equals(password))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Boolean signupUser(String name, Customer customer)
        {
            using (var context = new Database1Entities8())
            {
                var query = context.Customers.Find(name);

                if (query == null)
                {
                    context.Customers.Add(customer);
                    context.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Product getProduct(String title)
        {
            using (var context = new Database1Entities8())
            {
                return context.Products.Find(title);
            }
        }

        public Customer getCustomer(String name)
        {
            using (var context = new Database1Entities8())
            {
                return context.Customers.Find(name);
            }
        }
    }
}