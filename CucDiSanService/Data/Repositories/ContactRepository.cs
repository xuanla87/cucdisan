namespace CucDiSanService.Data.Repositories
{
    using CucDiSanService.Data.Infrastructure;
    using CucDiSanService.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IContactRepository : IRepository<Contact>
    {
        IEnumerable<Contact> GetByEmails(string _email);
    }
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Contact> GetByEmails(string _email)
        {
            return this.DbContext.Contacts.Where(x => x.contactEmail == _email);
        }
    }
}
