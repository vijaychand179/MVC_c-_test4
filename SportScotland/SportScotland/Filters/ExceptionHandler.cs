using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportScotland
{
    /// <summary>
    /// UnHandledException
    /// </summary>
    public class ExceptionHandler : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.IsChildAction && (!filterContext.ExceptionHandled && filterContext.HttpContext.IsCustomErrorEnabled))
            {
                Exception innerException = filterContext.Exception;
                if ((new HttpException(null, innerException).GetHttpCode() == 500))
                {
                    var viewName = "Exception";
                    string controllerName = (string)filterContext.RouteData.Values["controller"];
                    string actionName = (string)filterContext.RouteData.Values["action"];
                    HandleErrorInfo model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

                    // if the request is AJAX return JSON else view.
                    if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    {
                        filterContext.Result = new JsonResult
                        {
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                            Data = new
                            {
                                error = true,
                                message = "Some error occurred while processing your request. Please contact administrator."
                            }
                        };
                    }
                    else
                    {
                        ViewResult result = new ViewResult
                        {
                            ViewName = viewName
                        };
                        filterContext.Result = result;
                    }
                    Logger.WriteLog(actionName, controllerName, innerException);
                    filterContext.ExceptionHandled = true;
                    filterContext.HttpContext.Response.Clear();
                    filterContext.HttpContext.Response.StatusCode = 500;
                    filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                }
            }
        }
    }
}