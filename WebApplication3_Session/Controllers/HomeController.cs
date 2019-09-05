using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3_Session.Models;

namespace WebApplication3_Session.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult InsertSession(string value)
        {
            HttpContext.Session.SetString("value", value);
            ViewData["msg"] = "Stored in Session";
            return View("Index");
        }
        public IActionResult ReadSession()
        {
            //HttpContext.Request
            //HttpContext.Response
            var session = HttpContext.Session.GetString("value");
            if (session == null)
                ViewData["msg"] = "No Session or expired";
            else
                ViewData["msg"] = session;
            return View("Index");

            //Important note: please remove a unusec variable or clear whole session memory when you do not need immidiately
            //هروقت حافظه سیششن را نخواستید ، سریع حافظه خالی بفرمایید
            //HttpContext.Session.Remove("value");
            //HttpContext.Session.Clear();
        }

    }
}
