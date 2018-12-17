using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CucDiSanVN.Models
{
    public class DongGopYKienModel
    {
        [Required(ErrorMessage = "Bạn chưa nhập họ tên")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập thư điện tử")]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Add { get; set; }

        public string Body { get; set; }

        [Required(ErrorMessage ="Bạn chưa chọn tệp")]
        public string FileAtachment { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập mã bảo mật")]
        public string CaptCha { get; set; }
        public int feedbackId { get; set; }
    }
}