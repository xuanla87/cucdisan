namespace CucDiSanVN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FeedbackDetail")]
    public partial class FeedbackDetail
    {
        public int feedbackDetailId { get; set; }

        public int feedbackId { get; set; }

        [Required]
        [StringLength(150)]
        public string fullName { get; set; }

        [Required]
        [StringLength(150)]
        public string email { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(250)]
        public string address { get; set; }

        [Required]
        [StringLength(250)]
        public string fileAttachment { get; set; }

        [StringLength(1000)]
        public string feedbackContent { get; set; }

        public bool isTrash { get; set; }

        public DateTime createTime { get; set; }

        public bool isApproval { get; set; }
    }
}
