using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View("Result", new Result { Controller = nameof(HomeController), Action = nameof(Index)});
        }
        //использование  значений сегментов ЮРЛ а именно id
        public ViewResult CustomVariable()
        {
            Result r = new Result { Controller = nameof(HomeController), Action = nameof(CustomVariable) };
            r.Data["Id"] = RouteData.Values["id"] ?? "Nullina";
            return View("Result", r);
        }
        //второй вариант использование переменной URl
        //public ViewResult CustomVariable(string Id)
        //{
        //    Result r = new Result { Controller = nameof(HomeController), Action = nameof(CustomVariable) };
        //    r.Data["Id"] = Id;
        //    return View("Result", r);
        //}
    }
}
