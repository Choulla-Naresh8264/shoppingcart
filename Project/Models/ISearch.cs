using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public interface ISearch
    {
        List<Product> getProductsByTitle(String title);
        List<Product> getProductsByRange(int start, int end);
        List<Product> getProductsByCompany(String company);
    }
}
