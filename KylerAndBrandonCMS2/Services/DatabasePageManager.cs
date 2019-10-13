using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KylerAndBrandonCMS2.Data;
using KylerAndBrandonCMS2.Models;
using KylerAndBrandonCMS2.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace KylerAndBrandonCMS2.Services
{
    public class DatabasePageManager : IPageManagerService
    {
        private readonly CmsContext _context;

        public DatabasePageManager(CmsContext cmsContext)
        {
            _context = cmsContext ?? throw new ArgumentNullException(nameof(cmsContext));
        }

        public bool AddPage(Page page)
        {
            _context.Add(page);
            _context.SaveChangesAsync();
            return true;
        }

        public bool AddParagraph(ParagraphItem content)
        {
            _context.Add(content);
            _context.SaveChangesAsync();
            return true;
        }

        public bool DeletePage(int id)
        {
            DeleteParagraphItem(id);
            DeleteImageItem(id);
            _context.Pages.Remove(_context.Pages.Find(id));
            _context.SaveChangesAsync();
            return true;
        }

        public PageViewModel GetPage(string name)
        {
            var page = _context.Pages
                .Where(p => p.Name.ToUpper() == name.ToUpper())
                .Include(p=>p.ParagraphItems)
                .Include(i=>i.imageItems)
                .Include(p=>p.GallaryItems)
                .ThenInclude(gi=>gi.GallaryImages)
                .FirstOrDefault();

            var pageViewModel = new PageViewModel();
            pageViewModel.Id = page.Id;
            pageViewModel.Name = page.Name;
            pageViewModel.Header = page.Header;
            pageViewModel.Footer = page.Footer;
            pageViewModel.contents = new List<IContent>();

            foreach(var item in page.ParagraphItems)
            {
                pageViewModel.contents.Add(item);
            }
            foreach(var item in page.imageItems)
            {
                pageViewModel.contents.Add(item);
            }
            foreach(var item in page.GallaryItems)
            {
                pageViewModel.contents.Add(item);
            }

            pageViewModel.contents = pageViewModel.contents.OrderBy(i => i.time).Reverse().ToList();

            return pageViewModel;
        }

        public IEnumerable<Page> GetPageList()
        {
            return _context.Pages.ToList();
        }

        public bool DeleteParagraph(ParagraphItem item)
        {
            ParagraphItem item1 =_context.ParagraphItems
                .Where(pi =>  pi.Id == item.Id)
                .FirstOrDefault();

            _context.Remove(item1);

            _context.SaveChanges();

            return true;
        }

        private void DeleteParagraphItem(int pageId)
        {
            _context.ParagraphItems
                .Where(pi => pi.PageId == pageId)
                .ForEachAsync(pi => _context.Remove(pi));
            _context.SaveChangesAsync();
        }

        private void DeleteImageItem(int pageId)
        {
            _context.imageItems
                .Where(pi => pi.PageId == pageId)
                .ForEachAsync(pi => _context.Remove(pi));
            _context.SaveChangesAsync();
        }

        private void DeleteGallaryItems(int pageId)
        {
            _context.GallaryItems
                .Where(pi => pi.PageId == pageId)
                .ForEachAsync(pi => _context.Remove(pi));
            _context.SaveChangesAsync();
        }

        public bool AddImage(ImageItem content)
        {
            _context.Add(content);
            _context.SaveChangesAsync();
            return true;
        }

        public bool DeleteImage(ImageItem item)
        {
            ImageItem item1 = _context.imageItems
                .Where(pi => pi.Id == item.Id)
                .FirstOrDefault();

            _context.Remove(item1);

            _context.SaveChanges();

            return true;
        }

        public bool DeleteGallaryItem(GallaryItem item)
        {
            GallaryItem item1 = _context.GallaryItems
                .Where(pi => pi.Id == item.Id)
                .FirstOrDefault();

            _context.Remove(item1);

            _context.SaveChanges();

            return true;
        }

        public bool AddAComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return true;
        }

        public  IEnumerable<Comment> GetComments()
        {
            List<Comment> comments = _context.Comments.ToList();
            return comments;
        }
    }
}
