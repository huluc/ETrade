using ETrade.BLL.Concrete;
using ETrade.DAL.Concrete.EntityFramework;
using ETrade.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETrade.Interfaces;
using ETrade.MvcWebUI.Controllers.Model;
using ETrade.MvcWebUI.Models;

namespace ETrade.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        //ProductManager _productManager = new ProductManager(new EfProductDal()); // Burada bağımlılık mevcut.

        private IProductService _productService;// Artık ister servis ister bll kullanabiliriz.
                                               
        // Burada Ninject ile Controllerın Constructure ında hangi servis istenirse hangi concrete sınıf dönülecek bunu belirleyeceğiz.
        //Mesela Ninject' e burada ctor da IProductService gönderilirse productManager yolla diyebiliriz. 
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        private int PageSize = 3;
        public ActionResult Index(int page=1)
        {

            List<Product> products = _productService.GetAll();
            return View(new ProductViewModel()
            {
                Products=products.Skip((page-1)*PageSize).Take(PageSize).ToList(),
                PagingInfo = new PagingInfo
                {
                    ItemsPerPage=PageSize,
                    TotalItems=products.Count,
                    CurrentPage=page
                }
            });
        }
    }


}