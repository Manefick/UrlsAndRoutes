using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
    public class CustomerController : Controller
    {
        public ViewResult Index()
        {
            return View("Result", new Result {Controller = nameof(CustomerController), Action = nameof(Index) });
        }
        public ViewResult List(string id)
        {
            Result re = new Result { Action = nameof(List), Controller = nameof(CustomerController) };
            re.Data["id"] = id ?? "Nothing";
            re.Data["cathall"] = RouteData.Values["catchAll"];
            return View("Result", re);
        }
    }
}
