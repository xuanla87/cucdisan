namespace CucDiSanService.Data.Repositories
{
    using CucDiSanService.Data.Infrastructure;
    using CucDiSanService.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface ICommentRepository : IRepository<Comment>
    {
        IEnumerable<Comment> GetByEmails(string _email);
    }
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Comment> GetByEmails(string _email)
        {
            return this.DbContext.Comments.Where(x => x.commentEmail == _email);
        }
    }
}
