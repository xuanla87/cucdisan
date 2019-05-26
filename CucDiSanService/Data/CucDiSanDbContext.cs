
namespace CucDiSanService.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity.EntityFramework;
    using CucDiSanService.Models;
    public class CucDiSanDbContext : DbContext
    {
        public CucDiSanDbContext() : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<ActionLog> ActionLogs { set; get; }
        public DbSet<Comment> Comments { set; get; }
        public DbSet<ConfigSystem> ConfigSystems { set; get; }
        public DbSet<Content> Contents { set; get; }
        public DbSet<Function> Functions { set; get; }
        public DbSet<Language> Languages { set; get; }
        public DbSet<Media> Medias { set; get; }
        public DbSet<Menu> Menus { set; get; }
        public DbSet<SiteMap> SiteMaps { set; get; }
        public DbSet<UserFunction> UserFunctions { set; get; }
        public DbSet<Visitor> Visitors { set; get; }
        public DbSet<Video> Videos { set; get; }
        public DbSet<CategoryVideo> CategoryVideos { set; get; }
        public DbSet<Feedback> Feedbacks { set; get; }
        public DbSet<FeedbackDetail> FeedbackDetails { set; get; }
        public DbSet<Contact> Contacts { set; get; }
        public DbSet<LienKetWeb> LienKetWebs { set; get; }
        public static CucDiSanDbContext Create()
        {
            return new CucDiSanDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder builder)
        {

        }
    }
}
