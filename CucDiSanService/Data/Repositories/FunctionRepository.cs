namespace CucDiSanService.Data.Repositories
{
    using CucDiSanService.Data.Infrastructure;
    using CucDiSanService.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IFunctionRepository : IRepository<Function>
    {
        Function GetByName(string _name);
    }
    public class FunctionRepository : Repository<Function>, IFunctionRepository
    {
        public FunctionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Function GetByName(string _name)
        {
            return this.DbContext.Functions.FirstOrDefault(x => x.functionName == _name);
        }
    }
}
