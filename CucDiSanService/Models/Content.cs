namespace CucDiSanService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Content")]
    public partial class Content
    {
        [Key]
        public int contentId { get; set; }
        public string contentName { get; set; }
        public string contentAlias { get; set; }
        public string contentBody { get; set; }
        public string contentTitle { get; set; }
        public string contentKeywords { get; set; }
        public string contentDescription { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
        public int? parentId { get; set; }
        public string contentThumbnail { get; set; }
        public string contentKey { get; set; }
        public bool isTrash { get; set; }
        public int isSort { get; set; }
        public int languageId { get; set; }
        public string note { get; set; }
        public int? isView { get; set; }
        public string no { get; set; }
        public bool? isHome { get; set; }
        public bool? isNew { get; set; }
        public DateTime? ngayBanHanh { get; set; }
        public string tacGia { get; set; }
    }
    [Table("Contact")]
    public partial class Contact
    {
        [Key]
        public int contactId { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập họ tên")]
        public string contactFullName { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập thư điện tử")]
        public string contactEmail { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập tiêu đề")]
        public string contactTitle { get; set; }
        public string contactBody { get; set; }
        public bool isTrash { get; set; }
        public DateTime createTime { get; set; }
    }

    public class ContentView
    {
        public int Total { set; get; }
        public int TotalRecord { set; get; }
        public IEnumerable<Content> Contents { set; get; }
    }

    public class DropdownModel
    {
        public string Text { set; get; }
        public int Value { set; get; }
        public bool IsSelect { get; set; }
    }
}
