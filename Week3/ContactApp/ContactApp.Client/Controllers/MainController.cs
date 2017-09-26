using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.Client.Controllers
{
    public class MainController : Controller
    {
        public string Index()
        {
            return "We are in main.";
        }
    }
}