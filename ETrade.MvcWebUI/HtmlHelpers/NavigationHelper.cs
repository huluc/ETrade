using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ETrade.MvcWebUI.HtmlHelpers
{
    public static class NavigationHelper
    {
        public static string IsSelected(this HtmlHelper helper, string controller, string action)
        {
            string currentAction = (string)helper.ViewContext.RouteData.Values["action"];
            string currentController = (string)helper.ViewContext.RouteData.Values["controller"];
          
            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ? "active" : String.Empty;
        }
    }
}