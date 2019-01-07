using System.Collections.Generic;
using ETrade.Entity.Concrete;
using ETrade.MvcWebUI.Models;

namespace ETrade.MvcWebUI.Controllers.Model
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
        }

        public List<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }

}