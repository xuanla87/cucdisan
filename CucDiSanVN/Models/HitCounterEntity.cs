namespace CucDiSanVN.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HitCounterEntity : DbContext
    {
        public HitCounterEntity()
            : base("name=HitCounterEntity")
        {
        }

        public virtual DbSet<ActionLog> ActionLogs { get; set; }
        public virtual DbSet<CategoryVideo> CategoryVideos { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<ConfigSystem> ConfigSystems { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<FeedbackDetail> FeedbackDetails { get; set; }
        public virtual DbSet<Function> Functions { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<LienKetWeb> LienKetWebs { get; set; }
        public virtual DbSet<Medium> Media { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<SiteMap> SiteMaps { get; set; }
        public virtual DbSet<UserFunction> UserFunctions { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<Visitor> Visitors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
