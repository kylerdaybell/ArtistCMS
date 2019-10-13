using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KylerAndBrandonCMS2.Models;
using KylerAndBrandonCMS2.Services;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace KylerAndBrandonCMS2.Controllers
{
    public class AdminController:Controller
    {
        private readonly IPageManagerService _pageManagerService;

        public AdminController(IPageManagerService PageManagerService)
        {
           _pageManagerService = PageManagerService;
        }

        [Authorize(Policy = MyIdentityData.CMSPolicy_Modify)]
        public async Task<IActionResult> PagesManager()
        {
            var items =  _pageManagerService.GetPageList();

            return View(items);
        }
        
        public IActionResult error()
        {
            return View();
        }

        [Authorize(Policy = MyIdentityData.CMSPolicy_Add)]
        public IActionResult DeletePage(int? id)
        {
            if(id == null)
            {
                return View("error");
            }
            else
            {
                if (_pageManagerService.DeletePage((int)id)) {
                    return View("PagesManager", _pageManagerService.GetPageList());
                }
                return View("error");
            }
        }

        [Authorize(Policy = MyIdentityData.CMSPolicy_Add)]
        public IActionResult AddPage()
        {
            return View();
        }

        public IActionResult AddPageConfirmed([Bind("Id,Name,Header,Footer")]Page page)
        {
            if (_pageManagerService.AddPage(page))
            {
                return View("PagesManager", _pageManagerService.GetPageList());
            }
            return View("error");
        }

        [HttpGet("[controller]/[action]/{pagename}")]
        public async Task<IActionResult> EditPage(string pagename)
        {
            var page = _pageManagerService.GetPage(pagename);

            return View(page);
        }

        //this works
        [Authorize(Policy = MyIdentityData.CMSPolicy_Modify)]
        public async Task<IActionResult> AddParagraph([Bind("Title,Content,PageId")]ParagraphItem paragraph)
        {
            paragraph.time = DateTime.Now;
           
            _pageManagerService.AddParagraph(paragraph);


            var items = _pageManagerService.GetPageList();
            return View("PagesManager",items);
        }

        [Authorize(Policy = MyIdentityData.CMSPolicy_Modify)]
        public async Task<IActionResult> DeleteParagraph([Bind("PageId,Id")]ParagraphItem paragraph)
        {
            _pageManagerService.DeleteParagraph(paragraph);


            var items = _pageManagerService.GetPageList();
            return View("PagesManager", items);
        }

        [Authorize(Policy = MyIdentityData.CMSPolicy_Modify)]
        public async Task<IActionResult> AddImage ([Bind("Title, Image, PageId")]ImageItem imagething, IFormFile Image)
        {
            imagething.time = DateTime.Now;

            if(Image != null)
            {
                var stream = new MemoryStream();
                await Image.CopyToAsync(stream);
                var streamArray = stream.ToArray();
                var to64 = Convert.ToBase64String(streamArray);
                imagething.Image = to64;
            }

            _pageManagerService.AddImage(imagething);

            var items = _pageManagerService.GetPageList();
            return View("PagesManager", items);
        }

        [Authorize(Policy = MyIdentityData.CMSPolicy_Modify)]
        public async Task<IActionResult> DeleteImage([Bind("PageId,Id")]ImageItem imagething)
        {
            _pageManagerService.DeleteImage(imagething);


            var items = _pageManagerService.GetPageList();
            return View("PagesManager", items);
        }

        [Authorize(Policy = MyIdentityData.CMSPolicy_Modify)]
        public async Task<IActionResult> DeleteGallary([Bind("PageId, Id")]GallaryItem gallaryItem)
        {
            _pageManagerService.DeleteGallaryItem(gallaryItem);

            var items = _pageManagerService.GetPageList();
            return View("PagesManager", items);
        }

        [Authorize(Policy = MyIdentityData.CMSPolicy_Modify)]
        public async Task<IActionResult> DeleteGallaryImage([Bind("Id")]GallaryImage gallaryImage)
        {


            return View("EditPage");
        }
    }
}
