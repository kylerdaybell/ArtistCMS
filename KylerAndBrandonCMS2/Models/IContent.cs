using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KylerAndBrandonCMS2.Models
{
    public abstract class IContent
    {
        public DateTime time { get; set; }
    }

    public class ParagraphItem : IContent
    {
        public int Id { get; set; }
        public int PageId { get; set; }
        public Page Page {get; set;}
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class ImageItem : IContent
    {
        public int Id { get; set; }
        public int PageId { get; set; }
        public Page Page { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
    }

    public class GallaryItem : IContent
    {
        public int Id { get; set; }
        public int PageId { get; set; }
        public Page Page { get; set; }
        public string Title { get; set; }
        public List<GallaryImage> GallaryImages { get; set; } = new List<GallaryImage>();
    }

    public class GallaryImage
    {
        public int Id { get; set; }
        public int GallaryItemID { get; set; }
        public GallaryItem GallaryItem { get; set; }
        public string Image { get; set; }
    }
}
