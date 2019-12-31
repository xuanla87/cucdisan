namespace CucDiSanVN.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Function")]
    public partial class Function
    {
        public long functionId { get; set; }

        [Required]
        [StringLength(255)]
        public string functionName { get; set; }

        [Required]
        [StringLength(255)]
        public string functionUrl { get; set; }
    }
}
