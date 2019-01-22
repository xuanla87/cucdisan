namespace CucDiSanService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Function")]
    public partial class Function
    {
        [Key]
        public int functionId { get; set; }
        public string functionName { get; set; }
        public string functionUrl { get; set; }
    }
}
