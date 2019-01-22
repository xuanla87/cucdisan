namespace CucDiSanService.Data.Repositories
{
    using CucDiSanService.Data.Infrastructure;
    using CucDiSanService.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IActionLogRepository : IRepository<ActionLog>
    {
        IEnumerable<ActionLog> GetByUserName(string _userName);
    }
    public class ActionLogRepository : Repository<ActionLog>, IActionLogRepository
    {
        public ActionLogRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<ActionLog> GetByUserName(string _userName)
        {
            return this.DbContext.ActionLogs.Where(x => x.userName == _userName);
        }
    }
}
