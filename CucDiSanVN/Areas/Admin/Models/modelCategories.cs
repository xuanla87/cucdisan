using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CucDiSanVN.Areas.Admin.Models
{
    public class modelCategories
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nhập tên chuyên mục!")]
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Img { get; set; }
        public string Note { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public int? ParentId { get; set; }
        public bool IsHome { get; set; }
        public int? No { get; set; }
        public string ParentName { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
    }
}