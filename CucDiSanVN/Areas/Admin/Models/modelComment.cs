using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CucDiSanVN.Areas.Admin.Models
{
    public class modelComment
    {
        public int commentId { get; set; }
        public int contentId { get; set; }
        public string contentName { get; set; }
        public string commentFullName { get; set; }
        public string commentEmail { get; set; }
        public string commentPhone { get; set; }
        public DateTime commentTime { get; set; }
        public string commentTitle { get; set; }
        public string commentBody { get; set; }
        public bool isTrash { get; set; }
    }
}