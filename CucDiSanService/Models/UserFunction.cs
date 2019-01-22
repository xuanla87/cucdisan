namespace CucDiSanService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserFunction")]
    public partial class UserFunction
    {
        [Key]
        public int id { get; set; }
        public string userName { get; set; }
        public int functionId { get; set; }
        public string actionKey { get; set; }
    }
}

