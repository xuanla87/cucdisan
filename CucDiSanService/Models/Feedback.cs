namespace CucDiSanService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("Feedback")]
    public class Feedback
    {
        [Key]
        public int feedbackId { get; set; }
        public string feedbackName { get; set; }
        public string feedbackNote { get; set; }
        public string feedbackBody { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public bool isTrash { get; set; }
        public bool isEnd { get; set; }
    }

    public class FeedbackModel
    {
        public int feedbackId { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập tiêu đề!")]
        public string feedbackName { get; set; }
        public string feedbackNote { get; set; }
        public string feedbackBody { get; set; }
        public DateTime createTime { get; set; }
        public DateTime updateTime { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập ngày bắt đầu!")]
        public string startDate { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập ngày kết thúc!")]
        public string endDate { get; set; }
        public bool isTrash { get; set; }
        public bool isEnd { get; set; }
    }


    [Table("FeedbackDetail")]
    public class FeedbackDetail
    {
        [Key]
        public int feedbackDetailId { get; set; }
        public int feedbackId { get; set; }
        [Required]
        public string fullName { get; set; }
        [Required]
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        [Required]
        public string fileAttachment { get; set; }
        public string feedbackContent { get; set; }
        public DateTime createTime { get; set; }
        public bool isTrash { get; set; }
        public bool isApproval { get; set; }
    }
}
