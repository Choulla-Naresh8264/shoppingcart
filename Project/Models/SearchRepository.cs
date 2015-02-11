using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class SearchRepository : ISearch
    {
        public List<Product> getProductsByTitle(String title)
        {
            using (var context = new Database1Entities8())
            {
                return context.Products.Where(x => x.Title.Equals(title)).ToList();
            }
        }

        public List<Product> getProductsByRange(int start, int end)
        {
            using (var context = new Database1Entities8())
            {
                return context.Products.Where(x => x.Price >= start && x.Price <= end).ToList();
            }
        }

        public List<Product> getProductsByCompany(String company)
        {
            using (var context = new Database1Entities8())
            {
                return context.Products.Where(x => x.Company.Equals(company)).ToList();
            }
        }
    }
}