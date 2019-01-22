namespace CucDiSanService.Data.Repositories
{
    using CucDiSanService.Data.Infrastructure;
    using CucDiSanService.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IMediaRepository : IRepository<Media>
    {
        Media GetByName(string _name);
    }
    public class MediaRepository : Repository<Media>, IMediaRepository
    {
        public MediaRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Media GetByName(string _name)
        {
            return this.DbContext.Medias.FirstOrDefault(x => x.mediaName == _name);
        }
    }
}
