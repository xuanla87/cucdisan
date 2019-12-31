namespace CucDiSanVN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contact")]
    public partial class Contact
    {
        public int contactId { get; set; }

        [Required]
        [StringLength(250)]
        public string contactFullName { get; set; }

        [Required]
        [StringLength(250)]
        public string contactEmail { get; set; }

        [Required]
        [StringLength(500)]
        public string contactTitle { get; set; }

        public string contactBody { get; set; }

        public bool isTrash { get; set; }

        public DateTime createTime { get; set; }
    }
}
