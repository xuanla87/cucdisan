
namespace CucDiSanVN.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    public class modelBanner
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nhập tiêu đề!")]
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Link { get; set; }
        public string Img { get; set; }
        public string BodyContent { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public int? ParentId { get; set; }
        public string ParentName { get; set; }
        public bool IsTrash { get; set; }
        public int IsSort { get; set; }
    }
}