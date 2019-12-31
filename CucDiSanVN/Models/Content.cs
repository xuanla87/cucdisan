namespace CucDiSanVN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Content")]
    public partial class Content
    {
        public int contentId { get; set; }

        [Required]
        [StringLength(255)]
        public string contentName { get; set; }

        [Required]
        [StringLength(255)]
        public string contentAlias { get; set; }

        public string contentBody { get; set; }

        [StringLength(255)]
        public string contentTitle { get; set; }

        [StringLength(255)]
        public string contentKeywords { get; set; }

        [StringLength(255)]
        public string contentDescription { get; set; }

        public DateTime createTime { get; set; }

        public DateTime updateTime { get; set; }

        public int? parentId { get; set; }

        [StringLength(255)]
        public string contentThumbnail { get; set; }

        [Required]
        [StringLength(50)]
        public string contentKey { get; set; }

        public bool isTrash { get; set; }

        public int? isSort { get; set; }

        public int languageId { get; set; }

        public string note { get; set; }

        public int? isView { get; set; }

        [StringLength(50)]
        public string no { get; set; }

        public bool? isHome { get; set; }

        public bool? isNew { get; set; }

        public DateTime? ngayBanHanh { get; set; }

        [StringLength(250)]
        public string tacGia { get; set; }
    }
}
