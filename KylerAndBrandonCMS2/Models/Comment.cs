﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KylerAndBrandonCMS2.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Content { get; set; }
    }
}
