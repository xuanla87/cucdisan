﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CucDiSanVN.Areas.Admin.Models
{
    public class modelDuThaoVanBanPhapLuat
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nhập tiêu đề!")]
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Img { get; set; }
        public string Note { get; set; }
        public string BodyContent { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public int? ParentId { get; set; }
        public string ParentName { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string CreateTime { get; set; }
        public int Sort { get; set; }
        public string TacGia { get; set; }
        public bool Approval { get; set; }

    }
}