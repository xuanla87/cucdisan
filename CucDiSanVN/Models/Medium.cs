namespace CucDiSanVN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Medium
    {
        [Key]
        public long mediaId { get; set; }

        public long contentId { get; set; }

        [StringLength(255)]
        public string mediaName { get; set; }

        [StringLength(512)]
        public string mediaNote { get; set; }

        public string mediaContent { get; set; }
    }
}
