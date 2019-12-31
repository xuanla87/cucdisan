namespace CucDiSanVN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        public int feedbackId { get; set; }

        [Required]
        [StringLength(1000)]
        public string feedbackName { get; set; }

        [StringLength(2000)]
        public string feedbackNote { get; set; }

        public string feedbackBody { get; set; }

        public DateTime createTime { get; set; }

        public DateTime updateTime { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public bool isTrash { get; set; }

        public bool isEnd { get; set; }
    }
}
