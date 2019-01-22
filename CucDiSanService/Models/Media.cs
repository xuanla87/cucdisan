namespace CucDiSanService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Media")]
    public partial class Media
    {
        [Key]
        public int mediaId { get; set; }
        public long contentId { get; set; }
        public string mediaName { get; set; }
        public string mediaNote { get; set; }
        public string mediaContent { get; set; }
    }
}
