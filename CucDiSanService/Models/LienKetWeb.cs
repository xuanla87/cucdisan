namespace CucDiSanService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LienKetWeb")]
    public partial class LienKetWeb
    {
        [Key]
        public int lienKetId { get; set; }

        [Required]
        [StringLength(256)]
        [Display(Name = "Tiều đề")]
        public string lienKetName { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Link")]
        public string lienKetLink { get; set; }

        public bool isTrash { get; set; }

        public int? parentId { get; set; }

        [Display(Name = "Thứ tự")]
        public int isSort { get; set; }
    }

    public class LienKetWebView
    {
        public int Total { get; set; }
        public int TotalRecord { get; set; }
        public IEnumerable<LienKetWeb> LienKetWebs { get; set; }
    }
}
