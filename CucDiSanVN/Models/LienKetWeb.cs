namespace CucDiSanVN.Models
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
        [StringLength(250)]
        public string lienKetName { get; set; }

        [Required]
        [StringLength(250)]
        public string lienKetLink { get; set; }

        public bool isTrash { get; set; }

        public int? parentId { get; set; }

        public int isSort { get; set; }
    }
}
