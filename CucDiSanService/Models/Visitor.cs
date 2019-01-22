namespace CucDiSanService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Visitor")]
    public partial class Visitor
    {
        [Key]
        public int id { get; set; }
        public DateTime visitTime { get; set; }
        public string visitIp { get; set; }
        public string visitBrowser { get; set; }
        public string visitPage { get; set; }
    }
}

