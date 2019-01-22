namespace CucDiSanService.Data.Repositories
{
    using CucDiSanService.Data.Infrastructure;
    using CucDiSanService.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IVisitorRepository : IRepository<Visitor>
    {
        IEnumerable<Visitor> GetByTime(DateTime _fromDate, DateTime _toDate);
    }
    public class VisitorRepository : Repository<Visitor>, IVisitorRepository
    {
        public VisitorRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Visitor> GetByTime(DateTime _fromDate, DateTime _toDate)
        {
            return this.DbContext.Visitors.Where(x => x.visitTime.Date >= _fromDate.Date && x.visitTime.Date <= _toDate.Date);
        }
    }
}
