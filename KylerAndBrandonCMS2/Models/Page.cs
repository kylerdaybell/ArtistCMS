using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KylerAndBrandonCMS2.Models
{
    public class Page
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
        public List<ParagraphItem> ParagraphItems { get; set; } = new List<ParagraphItem>();
        public List<ImageItem> imageItems { get; set; } = new List<ImageItem>();
        public List<GallaryItem> GallaryItems { get; set; } = new List<GallaryItem>();
    }
}
