using DataLayer;
using DataLayer.User;
using SampleProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleProduct.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductRepository productRepository;
        public ProductController(IProductRepository productrepo) 
        {
            this.productRepository = productrepo;
        }

        public ActionResult Login() 
        {
            if (productRepository.registerNewUser("saanatwork3@gmail.com","Saan@1234#"))
            {
                ViewBag.Logintext = "Success";
            }
            else { ViewBag.Logintext = "Failed"; }
            return View();
        }

        // GET: Product
        public ActionResult Index(string q = null)
        {            
            ProductUpdateViewModel vm = new ProductUpdateViewModel();
            try
            {
                vm.CategoryList = productRepository.GetCategories();
                vm.CurrencyList = productRepository.GetCurrencies();
                vm.UnitList = productRepository.GetUnits();
                if (q != null && !string.IsNullOrEmpty(q))
                    vm.product = productRepository.GetProduct(int.Parse(q));
                else
                    vm.product = new Product();
            }
            catch { }            
            return View(vm);
        }
        [HttpPost]
        public ActionResult Index(ProductUpdateViewModel vm) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (productRepository.UpdateProduct(vm.product))
                    {
                        return RedirectToAction("DashBoard");
                    }
                    else
                    {
                        ViewBag.sucMsg = "";
                        ViewBag.errMsg = "Failed to update product details";
                    }
                }
                else 
                {
                    vm = new ProductUpdateViewModel();
                    vm.CategoryList = productRepository.GetCategories();
                    vm.CurrencyList = productRepository.GetCurrencies();
                    vm.UnitList = productRepository.GetUnits();
                }
            }
            catch { }
            return View(vm);
        }
        public ActionResult DashBoard(string q=null) 
        {
            List<Product> ProductList=new List<Product>();
            try
            {
                if (q != null && !string.IsNullOrEmpty(q))
                    ProductList = productRepository.SearchProduct(q);
                else
                    ProductList = productRepository.GetProducts();
            }
            catch { }
            return View(ProductList);
        }
        [HttpPost]
        public ActionResult DeleteProduct(string q = null)
        {
            try
            {
                if (q != null && !string.IsNullOrEmpty(q))
                    productRepository.DeleteProduct(int.Parse(q));
            }
            catch { }
            return RedirectToAction("DashBoard");
        }

        public ActionResult Trial() 
        {
            try 
            {
                //throw new Exception("This is an error");
                TrialException ex=new TrialException("This is an trial error");
                throw ex;
            } 
            catch (Exception ex)
            {
                ViewBag.NewException = ex.Message;
            }            
            return View();
        }
    }
}