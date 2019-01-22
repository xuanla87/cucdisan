namespace CucDiSanService.Data.Repositories
{
    using CucDiSanService.Data.Infrastructure;
    using CucDiSanService.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IVideoRepository : IRepository<Video>
    {
        IEnumerable<Video> GetByTitle(string title);
    }
    public class VideoRepository: Repository<Video>, IVideoRepository
    {
        public VideoRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<Video> GetByTitle(string title)
        {
            return this.DbContext.Videos.Where(x => x.videoTitle == title && x.isTrash == false);
        }
    }

    public interface ICategoryVideoRepository : IRepository<CategoryVideo>
    {
        IEnumerable<CategoryVideo> GetByParent(int? Id);
    }
    public class CategoryVideoRepository : Repository<CategoryVideo>, ICategoryVideoRepository
    {
        public CategoryVideoRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<CategoryVideo> GetByParent(int? Id)
        {
            return this.DbContext.CategoryVideos.Where(x => x.parentId == Id && x.isTrash == false);
        }
    }
}
