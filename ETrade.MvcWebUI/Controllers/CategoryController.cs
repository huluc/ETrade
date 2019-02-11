using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETrade.Interfaces;

namespace ETrade.MvcWebUI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult List(int categoryId=0)
        {
            ViewBag.CurrentCategory = categoryId;
            return PartialView(_categoryService.GetAll());
        }
    }
}