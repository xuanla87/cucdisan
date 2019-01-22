namespace CucDiSanService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SiteMap")]
    public partial class SiteMap
    {
        [Key]
        public int siteMapId { get; set; }
        public int? parentId { get; set; }
        public string siteMapName { get; set; }
        public string siteMapUrl { get; set; }
        public int languageId { get; set; }
    }
}

