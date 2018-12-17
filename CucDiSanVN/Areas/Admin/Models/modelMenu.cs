using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CucDiSanVN.Areas.Admin.Models
{
    public class modelMenu
    {
        public int menuId { get; set; }
        public int? parentId { get; set; }
        public string parentName { get; set; }
        [Required]
        public string menuName { get; set; }
        public string menuUrl { get; set; }
        public string isIcon { get; set; }
        public string isTaget { get; set; }
        public bool isTrash { get; set; }
        public int isSort { get; set; }
        public int languageId { get; set; }
    }
}