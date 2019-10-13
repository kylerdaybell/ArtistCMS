using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KylerAndBrandonCMS2.Models;
using KylerAndBrandonCMS2.ViewModels;

namespace KylerAndBrandonCMS2.Services
{
    public class DummyPageManagerService : IPageManagerService
    {
        public List<Page> dummypages;
        public DummyPageManagerService()
        {
            dummypages = new List<Page>();
            Page page = new Page();
            page.Id = 1;
            page.Name = "Kyler";


            ParagraphItem p = new ParagraphItem();

            p.PageId = page.Id;

            p.Id = 1;

            p.time = DateTime.Now;

            p.Title = " A Whole New World";

            p.Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut" +
                " labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ";


            page.ParagraphItems.Add(p);

            dummypages.Add(page);
        }
        public bool DeletePage(int id)
        {
            var dummypages2 = new List<Page>(); 

            foreach (var thing in dummypages)
            {              
                if(thing.Id != id)
                {
                    dummypages2.Add(thing);
                }
                
            }
            dummypages = dummypages2;
            return true;
        }

        public IEnumerable<Page> GetPageList()
        {

            return dummypages.ToArray();
        }

        public bool AddPage(Page p)
        {
            dummypages.Add(p);
            return true;
        }

        public Page GetPage(string name)
        {
            foreach(var thing in dummypages)
            {
                if (thing.Name.ToLower() == name.ToLower())
                {
                    return thing;
                }
            }
            return null;
        }

        public bool AddParagraph(ParagraphItem content)
        {
            foreach(var thing in dummypages)
            {
                if(content.PageId == thing.Id)
                {
                    thing.ParagraphItems.Add(content);
                }
            }

            return true;
        }

        public bool DeleteParagraph(ParagraphItem item)
        {
            throw new NotImplementedException();
        }

        PageViewModel IPageManagerService.GetPage(string name)
        {
            throw new NotImplementedException();
        }

        public bool AddImage(ImageItem content)
        {
            throw new NotImplementedException();
        }

        public bool DeleteImage(ImageItem item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteGallaryItem(GallaryItem item)
        {
            throw new NotImplementedException();
        }

        public bool AddAComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetComments()
        {
            throw new NotImplementedException();
        }
    }
}
