namespace CucDiSanService.Data.Repositories
{
    using CucDiSanService.Data.Infrastructure;
    using CucDiSanService.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface ISiteMapRepository : IRepository<SiteMap>
    {
        IEnumerable<SiteMap> GetByParent(int? _id);
    }
    public class SiteMapRepository : Repository<SiteMap>, ISiteMapRepository
    {
        public SiteMapRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<SiteMap> GetByParent(int? _id)
        {
            return this.DbContext.SiteMaps.Where(x => x.parentId == _id);
        }
    }
}
