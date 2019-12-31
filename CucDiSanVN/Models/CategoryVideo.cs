namespace CucDiSanVN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CategoryVideo")]
    public partial class CategoryVideo
    {
        [Key]
        public int categoryId { get; set; }

        [Required]
        [StringLength(150)]
        public string categoryName { get; set; }

        public int? parentId { get; set; }

        public bool isTrash { get; set; }

        public byte isSort { get; set; }
    }
}
