namespace CucDiSanService.Data.Repositories
{
    using CucDiSanService.Data.Infrastructure;
    using CucDiSanService.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IFeedbackRepository : IRepository<Feedback>
    {
        IEnumerable<Feedback> GetByName(string name);
    }
    public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<Feedback> GetByName(string name)
        {
            return this.DbContext.Feedbacks.Where(x => x.feedbackName.ToLower().Contains(name.ToLower()) && x.isTrash == false);
        }
    }

    public interface IFeedbackDetailRepository : IRepository<FeedbackDetail>
    {
        IEnumerable<FeedbackDetail> GetByFeedbackId(int Id);
    }
    public class FeedbackDetailRepository : Repository<FeedbackDetail>, IFeedbackDetailRepository
    {
        public FeedbackDetailRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public IEnumerable<FeedbackDetail> GetByFeedbackId(int Id)
        {
            return this.DbContext.FeedbackDetails.Where(x => x.feedbackId == Id);
        }
    }
}
