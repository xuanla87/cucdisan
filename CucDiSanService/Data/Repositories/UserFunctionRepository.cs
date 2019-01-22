namespace CucDiSanService.Data.Repositories
{
    using CucDiSanService.Data.Infrastructure;
    using CucDiSanService.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IUserFunctionRepository : IRepository<UserFunction>
    {
        IEnumerable<UserFunction> GetByUserName(string _userName);
    }
    public class UserFunctionRepository : Repository<UserFunction>, IUserFunctionRepository
    {
        public UserFunctionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<UserFunction> GetByUserName(string _userName)
        {
            return this.DbContext.UserFunctions.Where(x => x.userName == _userName);
        }
    }
}
