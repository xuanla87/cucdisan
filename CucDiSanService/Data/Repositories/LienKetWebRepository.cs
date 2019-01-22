namespace CucDiSanService.Data.Repositories
{
    using CucDiSanService.Data.Infrastructure;
    using CucDiSanService.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface ILienKetWebRepository : IRepository<LienKetWeb>
    {
        IEnumerable<LienKetWeb> GetByTitle(string title);
    }
    public class LienKetWebRepository : Repository<LienKetWeb>, ILienKetWebRepository
    {
        public LienKetWebRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<LienKetWeb> GetByTitle(string title)
        {
            return this.DbContext.LienKetWebs.Where(x => x.lienKetName == title && x.isTrash == false);
        }
    }
}
