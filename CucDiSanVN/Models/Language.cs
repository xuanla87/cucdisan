namespace CucDiSanVN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Language")]
    public partial class Language
    {
        public int languageId { get; set; }

        [Required]
        [StringLength(255)]
        public string languageName { get; set; }

        [Required]
        [StringLength(50)]
        public string languageKey { get; set; }

        public bool isTrash { get; set; }

        public bool isDefault { get; set; }
    }
}
