
namespace CucDiSanService.Data.Repositories
{
    using CucDiSanService.Data.Infrastructure;
    using CucDiSanService.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface ILanguageRepository : IRepository<Language>
    {
        Language GetByKey(string _key);
    }
    public class LanguageRepository : Repository<Language>, ILanguageRepository
    {
        public LanguageRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public Language GetByKey(string _key)
        {
            return this.DbContext.Languages.FirstOrDefault(x => x.languageKey == _key);
        }
    }
}
