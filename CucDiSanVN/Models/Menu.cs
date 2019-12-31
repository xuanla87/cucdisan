namespace CucDiSanVN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        public int menuId { get; set; }

        public int? parentId { get; set; }

        [Required]
        [StringLength(255)]
        public string menuName { get; set; }

        [StringLength(255)]
        public string menuUrl { get; set; }

        [StringLength(255)]
        public string isIcon { get; set; }

        [StringLength(255)]
        public string isTaget { get; set; }

        public bool isTrash { get; set; }

        public int isSort { get; set; }

        public int languageId { get; set; }
    }
}
