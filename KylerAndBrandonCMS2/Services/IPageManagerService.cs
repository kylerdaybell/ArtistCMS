using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KylerAndBrandonCMS2.Models;
using KylerAndBrandonCMS2.ViewModels;

namespace KylerAndBrandonCMS2.Services
{
    public interface IPageManagerService
    {
        IEnumerable<Page> GetPageList();
        bool DeletePage(int id);
        bool AddPage(Page p);
        PageViewModel GetPage(string name);
        bool AddParagraph(ParagraphItem content);
        bool DeleteParagraph(ParagraphItem item);
        bool AddImage(ImageItem content);
        bool DeleteImage(ImageItem item);
        bool DeleteGallaryItem(GallaryItem item);
        bool AddAComment(Comment comment);

        IEnumerable<Comment> GetComments();
    }
}
