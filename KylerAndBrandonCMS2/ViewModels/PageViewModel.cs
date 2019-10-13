using KylerAndBrandonCMS2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KylerAndBrandonCMS2.ViewModels
{
    public class PageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
        public List<IContent> contents { get; set; }
    }
}
