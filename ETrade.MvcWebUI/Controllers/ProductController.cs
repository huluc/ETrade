using ETrade.BLL.Concrete;
using ETrade.DAL.Concrete.EntityFramework;
using ETrade.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETrade.Interfaces;

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

        public ActionResult Index()
        {
            List<Product> products =  _productService.GetAll();
            return View(products);
        }
    }
}