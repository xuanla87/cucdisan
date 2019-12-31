namespace CucDiSanVN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        public int commentId { get; set; }

        public int contentId { get; set; }

        [StringLength(50)]
        public string commentFullName { get; set; }

        [StringLength(50)]
        public string commentEmail { get; set; }

        [StringLength(50)]
        public string commentPhone { get; set; }

        public DateTime commentTime { get; set; }

        [StringLength(255)]
        public string commentTitle { get; set; }

        public string commentBody { get; set; }

        public bool isTrash { get; set; }
    }
}
