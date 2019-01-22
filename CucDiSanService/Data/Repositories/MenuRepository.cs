namespace CucDiSanService.Data.Repositories
{
    using CucDiSanService.Data.Infrastructure;
    using CucDiSanService.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IMenuRepository : IRepository<Menu>
    {
        IEnumerable<Menu> GetByParent(int? _id);
    }
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        public MenuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Menu> GetByParent(int? _id)
        {
            return this.DbContext.Menus.Where(x => x.parentId == _id);
        }
    }
}
