namespace CucDiSanVN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserFunction")]
    public partial class UserFunction
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string userName { get; set; }

        public long functionId { get; set; }

        [StringLength(255)]
        public string actionKey { get; set; }
    }
}
