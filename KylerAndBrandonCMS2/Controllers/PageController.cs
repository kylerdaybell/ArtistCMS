using KylerAndBrandonCMS2.Models;
using KylerAndBrandonCMS2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KylerAndBrandonCMS2.Controllers
{
    public class PageController : Controller
    {

        private readonly IPageManagerService _pageManagerService;

        public PageController(IPageManagerService PageManagerService)
        {
            _pageManagerService = PageManagerService;
        }
        public async Task<IActionResult> Index(string permalink)
        {
            
            var page = _pageManagerService.GetPage(permalink);
            ViewData["permalink"] = permalink;
            return View(page);
        }
    }
}
