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
    public class HomeController : Controller
    {
        private readonly IPageManagerService _pageManagerService;

        public HomeController(IPageManagerService PageManagerService)
        {
            _pageManagerService = PageManagerService;
        }
        public IActionResult Index()
        {
            var Pictureclient = new WebClient();
            string getpicuture = "https://api.nasa.gov/planetary/apod?api_key=fYm3sy9sQlsNtpWFawKu1jQPCFBYMK0GNER5pSuO";
            var response = Pictureclient.DownloadString(getpicuture);
            var pictureurl = JObject.Parse(response);
            ViewData["PictureURL"] = pictureurl["hdurl"];

            var Pages = _pageManagerService.GetPageList();
            return View(Pages);
        }

        public IActionResult Login()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Comment()
        {
            IEnumerable<Comment> comments = _pageManagerService.GetComments();

            return View(comments);
        }
        public IActionResult AddComment([Bind("Content")]Comment comment)
        {
            if(User.Identity.Name != null)
            {
                comment.User = User.Identity.Name;

                _pageManagerService.AddAComment(comment);

            }
            IEnumerable<Comment> comments = _pageManagerService.GetComments();

            return View("Comment",comments);
        }

        public IActionResult Register()
        {
            return View();
        }


    }
}
