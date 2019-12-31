namespace CucDiSanVN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Video")]
    public partial class Video
    {
        public int videoId { get; set; }

        [Required]
        [StringLength(250)]
        public string videoTitle { get; set; }

        [Required]
        [StringLength(512)]
        public string videoBody { get; set; }

        [StringLength(512)]
        public string videoDecription { get; set; }

        public bool isTrash { get; set; }

        public DateTime createTime { get; set; }

        public DateTime updateTime { get; set; }

        public int languageId { get; set; }

        [StringLength(250)]
        public string thumbnail { get; set; }

        public bool isHome { get; set; }

        public int? parentId { get; set; }
    }
}
