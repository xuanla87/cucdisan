namespace CucDiSanService.Data.Repositories
{
    using CucDiSanService.Data.Infrastructure;
    using CucDiSanService.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IContentRepository : IRepository<Content>
    {
        Content GetByAlias(string _alias);
    }
    public class ContentRepository : Repository<Content>, IContentRepository
    {
        public ContentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Content GetByAlias(string _alias)
        {
            return this.DbContext.Contents.FirstOrDefault(x => x.contentAlias == _alias && x.isTrash == false);
        }
    }
}
