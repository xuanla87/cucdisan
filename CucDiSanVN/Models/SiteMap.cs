namespace CucDiSanVN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SiteMap")]
    public partial class SiteMap
    {
        public int siteMapId { get; set; }

        [Required]
        [StringLength(255)]
        public string siteMapName { get; set; }

        [Required]
        [StringLength(255)]
        public string siteMapUrl { get; set; }

        public int? parentId { get; set; }

        public int languageId { get; set; }
    }
}
