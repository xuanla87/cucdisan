namespace CucDiSanService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        [Key]
        public int menuId { get; set; }
        public int? parentId { get; set; }
        public string menuName { get; set; }
        public string menuUrl { get; set; }
        public string isIcon { get; set; }
        public string isTaget { get; set; }
        public bool isTrash { get; set; }
        public int isSort { get; set; }
        public int languageId { get; set; }
    }
    public class MenuView
    {
        public int Total { set; get; }
        public IEnumerable<Menu> Menus { set; get; }
    }
}
