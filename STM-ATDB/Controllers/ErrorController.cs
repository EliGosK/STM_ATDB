using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STM.ATDB.MvcWeb.Controllers
{
    
    public class ErrorController : Controller
    {
        // GET: Error
        [Route("{statusCode}")]
        public ActionResult Index(int statusCode)
        {
            HandleErrorInfo eInfo= null;
            if (TempData["HandleErrorModel"] != null)
            {
                eInfo = TempData["HandleErrorModel"] as HandleErrorInfo;
            }
            Response.TrySkipIisCustomErrors = true;
            if (eInfo != null)
            {
                return View(statusCode.ToString(), eInfo);
            }
            else
            {
                return View(statusCode.ToString());
            }
        }


    }
}