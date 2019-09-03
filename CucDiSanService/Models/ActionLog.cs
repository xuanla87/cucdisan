namespace CucDiSanService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ActionLog")]
    public partial class ActionLog
    {
        [Key]
        public long actionLogId { get; set; }
        public DateTime actionLogTime { get; set; }
        public string userName { get; set; }
        public string userIp { get; set; }
        public Byte actionLogStatus { get; set; }
        public Byte actionLogType { get; set; }
        public string actionNote { get; set; }
    }

    public class ActionLogView
    {
        public int Total { set; get; }
        public int TotalRecord { set; get; }
        public IEnumerable<ActionLog> ActionLogs { set; get; }
    }
}
