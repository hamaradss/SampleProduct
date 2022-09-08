using DataLayer.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Host.SystemWeb;
using System.Web;
using System.Web.Mvc;
using System.Web.Http.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
//using System.Web;

namespace DataLayer
{
    public class ProductRepository : IProductRepository
    {
        public bool registerNewUser(string emailid,string password) 
        {
            var user = new AppUser { UserName = emailid, Email = emailid };
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();
            //userManager.CreateAsync
            var result = userManager.Create(user, password);
            if (result.Succeeded) 
            { 
                return true; 
            } 
            else 
            { 
                return false; 
            }
        }
        public bool createRole(string roleName) 
        {
            var roleManager = HttpContext.Current.GetOwinContext().GetUserManager<RoleManager<AppRole>>();

            if (!roleManager.RoleExists(roleName))
                if (roleManager.Create(new AppRole(roleName)).Succeeded) 
                { 
                    return true; 
                }

            return false;
        }
        public bool Login(string username,string password) 
        {
            bool result = false;
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();
            var authManager = HttpContext.Current.GetOwinContext().Authentication;
            List<AppUser> users = userManager.Users.ToList();
            AppUser user = userManager.Find(username, password);
            if (user != null)
            {
                var ident = userManager.CreateIdentity(user,
                    DefaultAuthenticationTypes.ApplicationCookie);
                //use the instance that has been created. 
                authManager.SignIn(
                    new AuthenticationProperties { IsPersistent = false }, ident);
                return true;
            }


            return result;
        }
        public Product GetProduct(int productID)
        {
            using (SampleEntities context = new SampleEntities())
            {
                return context.SearchProduct(productID, "").FirstOrDefault();
            }
        }
        public List<Product> GetProducts()
        {
            using (SampleEntities context = new SampleEntities())
            {
                return context.Products.ToList();
            }
        }
        public List<Category> GetCategories()
        {
            
            using (SampleEntities context = new SampleEntities())
            {
                return context.Categories.ToList();
            }
        }
        public List<Currency> GetCurrencies()
        {
            using (SampleEntities context = new SampleEntities())
            {
                return context.Currencies.ToList();
            }
        }
        public List<Unit> GetUnits()
        {
            using (SampleEntities context = new SampleEntities())
            {
                return context.Units.ToList();
            }
        }
        public List<Product> SearchProduct(string searchText)
        {
            using (SampleEntities context = new SampleEntities())
            {
                return context.SearchProduct(0, searchText).ToList();
            }
        }
        public bool DeleteProduct(int productID)
        {
            try
            {
                using (SampleEntities context = new SampleEntities())
                {
                    deleteProduct_Result pr = context.deleteProduct(productID).FirstOrDefault();
                    return (bool)pr.IsSuccess;
                }
            }
            catch { return false; }
        }
        public bool UpdateProduct(Product product)
        {
            try
            {
                using (SampleEntities context = new SampleEntities())
                {
                    setProduct_Result pr = context.setProduct(
                        product.ID, product.ProductName, product.Price,
                        product.Category, product.Currency, product.Unit, product.Qty).FirstOrDefault();
                    return (bool)pr.IsSuccess;
                }
            }
            catch { return false; }
        }
        
    }
}
