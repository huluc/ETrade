using System.Web.Mvc;
using ETrade.Entity.Concrete;
using ETrade.Interfaces;

namespace ETrade.MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductService _productService;

        public CartController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult AddToCart(int productId) //formdan post edilen veriyi 'productId' map eder.
        {
            Product product = _productService.GetById(productId);

            Cart cart = (Cart)Session["cart"]; //if the cart doesn't exist in the session. We created it. Otherwise We increased quantity of the added product in the cart. 
            if (cart == null)
            {
                cart = new Cart();
                Session["cart"] = cart;
            }

            cart.AddToCart(product, 1);
            return View("Index", cart);
        }

        public ActionResult RemoveFromCart(int productId)
        {
            Product product = _productService.GetById(productId);
            Cart cart = (Cart) Session["Cart"];
            cart.RemoveFromCart(product);
            return View("Index", cart);
        }
    }
}