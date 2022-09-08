using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleProduct.Models
{
    public class ProductUpdateViewModel
    {
        public List<Category> CategoryList { get; set; }
        public List<Currency> CurrencyList { get; set; }
        public List<Unit> UnitList { get; set; }
        public Product product { get; set; }
    }
}