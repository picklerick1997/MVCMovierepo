﻿using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // Get: /HelloWorld/
        
        public IActionResult Index()
        {
            return View();
        }

        // GET: /HelloWorld/Welcome/
        // REquires using System.Text.Encodings.Web;

        public IActionResult Welcome(string name, int numTimes = 1)
        {

            ViewData["Message"] = "Hello " + numTimes + " " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}
