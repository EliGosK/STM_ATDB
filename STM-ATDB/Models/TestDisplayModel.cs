using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DisplayDetail.Models
{
    public class TestDisplayModel
    {
        public class ModelClass
        {
            public string[] SelectedColumns { get; set; }
        }
    }

    public partial class DisplayModel
    {
        public string str { get; set; }
    }
}