namespace CucDiSanService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Language")]
    public partial class Language
    {
        [Key]
        public int languageId { get; set; }
        public string languageName { get; set; }
        public string languageKey { get; set; }
        public bool isTrash { get; set; }
        public bool isDefault { get; set; }
    }
}
