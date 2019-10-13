using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KylerAndBrandonCMS2.Models;
using KylerAndBrandonCMS2.Services;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace KylerAndBrandonCMS2.Controllers
{
    public class StatusCodeController : Controller
    {
        public IActionResult Error(int? statusCode = null)
        {
            if (statusCode == 404)
                return View("Status404");
            else
                return View("StatusError");
        }
    }
}
