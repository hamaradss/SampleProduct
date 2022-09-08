using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IProductRepository
    {
        bool registerNewUser(string emailid, string password);
        bool createRole(string roleName);
        bool Login(string username, string password);
        Product GetProduct(int productID);
        List<Product> GetProducts();
        List<Category> GetCategories();
        List<Currency> GetCurrencies();
        List<Unit> GetUnits();
        List<Product> SearchProduct(string searchText);
        bool DeleteProduct(int productID);
        bool UpdateProduct(Product product);
    }
}
