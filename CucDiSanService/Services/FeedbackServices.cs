
namespace CucDiSanService.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CucDiSanService.Data.Infrastructure;
    using CucDiSanService.Data.Repositories;
    using CucDiSanService.Models;
    public interface IFeedbackServices
    {
        Feedback Add(Feedback model);

        FeedbackDetail AddDetail(FeedbackDetail model);

        IEnumerable<FeedbackDetail> GetDetailByFeedbackId(int Id);

        void Update(Feedback model);

        void UpdateDetail(FeedbackDetail model);

        void DeleteDetail(int id);

        Feedback Delete(int id);

        IEnumerable<Feedback> GetAll();

        FeedbackView All(string _keyWords, DateTime? _fromDate, DateTime? _toDate, DateTime? _startDate, DateTime? _endDate, bool? _isEnd, bool? _isTrash, int? _pageIndex, int? _pageSize);

        Feedback GetById(int id);
        FeedbackDetail GetDetailById(int id);

        void Save();
    }
    public class FeedbackServices : IFeedbackServices
    {
        private IFeedbackRepository _feedbackRepository;
        private IFeedbackDetailRepository _feedbackDetailRepository;
        private IUnitOfWork _unitOfWork;
        public FeedbackServices(IFeedbackDetailRepository feedbackDetailRepository, IFeedbackRepository feedbackRepository, IUnitOfWork unitOfWork)
        {
            this._feedbackRepository = feedbackRepository;
            this._feedbackDetailRepository = feedbackDetailRepository;
            this._unitOfWork = unitOfWork;
        }

        public Feedback Add(Feedback model)
        {
            return _feedbackRepository.Add(model);
        }
        public FeedbackDetail AddDetail(FeedbackDetail model)
        {
            return _feedbackDetailRepository.Add(model);
        }

        public IEnumerable<FeedbackDetail> GetDetailByFeedbackId(int Id)
        {
            return _feedbackDetailRepository.GetByFeedbackId(Id);
        }
        public void DeleteDetail(int id)
        {
            _feedbackDetailRepository.DeleteMulti(x => x.feedbackId == id);
        }

        public Feedback Delete(int id)
        {
            return _feedbackRepository.Delete(id);
        }
        public FeedbackView All(string _keyWords, DateTime? _fromDate, DateTime? _toDate, DateTime? _startDate, DateTime? _endDate, bool? _isEnd, bool? _isTrash, int? _pageIndex, int? _pageSize)
        {
            checkEnd();
            var enContent = _feedbackRepository.GetAll();
            if (!string.IsNullOrEmpty(_keyWords))
            {
                enContent = enContent.Where(x => x.feedbackName.ToLower().Contains(_keyWords.ToLower().Trim()));
            }
            if (_isTrash.HasValue)
            {
                enContent = enContent.Where(x => x.isTrash == _isTrash);
            }
            if (_isEnd.HasValue)
            {
                enContent = enContent.Where(x => x.isEnd == _isEnd);
            }
            if (_fromDate.HasValue)
            {
                enContent = enContent.Where(x => x.createTime.Date >= _fromDate.Value.Date);
            }
            if (_toDate.HasValue)
            {
                enContent = enContent.Where(x => x.createTime.Date <= _toDate.Value.Date);
            }
            if (_startDate.HasValue)
            {
                enContent = enContent.Where(x => x.startDate.Date == _startDate.Value.Date);
            }
            if (_endDate.HasValue)
            {
                enContent = enContent.Where(x => x.endDate.Date == _endDate.Value.Date);
            }
            enContent = enContent.OrderByDescending(x => x.createTime);
            int totalRecord = enContent.Count();
            if (_pageIndex != null && _pageSize != null)
            {
                enContent = enContent.Skip((_pageIndex.Value - 1) * _pageSize.Value);
            }
            var totalPage = 0;
            if (_pageSize != null)
            {
                totalPage = (int)Math.Ceiling(1.0 * totalRecord / _pageSize.Value);
                enContent = enContent.Take(_pageSize.Value);
            }
            return new FeedbackView { Feedbacks = enContent, Total = totalPage, TotalRecord = totalRecord };
        }

        public Feedback GetById(int id)
        {
            return _feedbackRepository.GetSingleById(id);
        }

        public FeedbackDetail GetDetailById(int id)
        {
            return _feedbackDetailRepository.GetSingleById(id);
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Feedback model)
        {
            _feedbackRepository.Update(model);
        }

        public void UpdateDetail(FeedbackDetail model)
        {
            _feedbackDetailRepository.Update(model);
        }
        public IEnumerable<Feedback> GetAll()
        {
            return _feedbackRepository.GetAll();
        }

        public void checkEnd()
        {
            var entitys = _feedbackRepository.GetAll().ToList();
            foreach (var item in entitys)
            {
                if (item.endDate.Date < DateTime.Now.Date)
                {
                    item.isEnd = true;
                    Update(item);
                    Save();
                }
            }
        }
    }
}
