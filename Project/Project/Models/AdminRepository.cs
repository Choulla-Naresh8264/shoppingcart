using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class AdminRepository : IAdmin
    {
        public Boolean loginAdmin(String name, String password)
        {
            using(var context = new Database1Entities8())
            {
                var query = context.Admins.Find(name);

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

        public List<Product> getProduct(String category)
        {
            using (var context = new Database1Entities8())
            {
                return context.Products.Where(x => x.Category.Equals(category)).ToList();
            }
        }

        public Product edit(String title)
        {
            using (var context = new Database1Entities8())
            {
                return context.Products.Find(title);
            }
        }

        public void update(Product product)
        {
            using (var context = new Database1Entities8())
            {
                context.Entry(product).State = System.Data.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void delete(String title)
        {
            using (var context = new Database1Entities8())
            {
                Product product = context.Products.Find(title);
                String pictures = product.Pictures;
                context.Products.Remove(product);
                context.SaveChanges();

                String[] files = pictures.Split(';');

                foreach (var file in files)
                {
                    System.IO.File.Delete(@"C:\Users\Asad\Desktop\Project\Project\Files\" + file);
                }
            }
        }

        public void addProduct(String title, String price, String purchase, String company, String category, String files)
        {
            using (var context = new Database1Entities8())
            {
                Product product = new Product();

                product.Title = title;
                product.Price = int.Parse(price);
                product.Purchase = int.Parse(purchase);
                product.Company = company;
                product.Category = category;
                product.Pictures = files;

                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void reports()
        {
            using (var context = new Database1Entities8())
            {
                /*var query = from c in context.SaledProducts
                            group c by new {c.Date.Month} into grouped
                            select new
                            {
                                date = grouped.Select(y => y.Date),
                                //sale = grouped.Sum(y => y.Sale),
                                profit = grouped.Sum(y => y.Profit)
                            };*/
                var query = context.SaledProducts
               .GroupBy(x => new { Month = x.Date.Month })
                .Select(x => new { Value = x.Count() });
                foreach (var q in query)
                {
                    String val = q.Value.ToString();
                    //String month = q.date.ToString();
                    //String clicks = q.profit.ToString();
                }
            }

        }
    }
}