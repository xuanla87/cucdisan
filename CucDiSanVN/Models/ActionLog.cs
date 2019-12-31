namespace CucDiSanVN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ActionLog")]
    public partial class ActionLog
    {
        public long actionLogId { get; set; }

        public DateTime actionLogTime { get; set; }

        [Required]
        [StringLength(50)]
        public string userName { get; set; }

        [Required]
        [StringLength(50)]
        public string userIp { get; set; }

        public byte actionLogStatus { get; set; }

        public byte actionLogType { get; set; }

        public string actionNote { get; set; }
    }
}
