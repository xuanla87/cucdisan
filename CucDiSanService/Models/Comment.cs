
namespace CucDiSanService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        [Key]
        public int commentId { get; set; }
        public int contentId { get; set; }
        public string commentFullName { get; set; }
        public string commentEmail { get; set; }
        public string commentPhone { get; set; }
        public DateTime commentTime { get; set; }
        public string commentTitle { get; set; }
        public string commentBody { get; set; }
        public bool isTrash { get; set; }
    }

    public class CommentView
    {
        public int Total { set; get; }
        public IEnumerable<Comment> Comments { set; get; }
    }

    public class ContactView
    {
        public int Total { set; get; }
        public IEnumerable<Contact> Contacts { set; get; }
    }
}
