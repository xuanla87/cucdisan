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
    public interface ICommentServices
    {
        Comment Add(Comment _model);

        void Update(Comment _model);

        Comment Delete(int _id);

        CommentView GetAll(string _keyWords, DateTime? _fromDate, DateTime? _toDate, bool? _isTrash, int? _pageIndex, int? _pageSize);

        IEnumerable<Comment> All();

        IEnumerable<Comment> GetAllByEmail(string _email);

        Comment GetById(int _id);

        void Save();
    }
    public class CommentServices : ICommentServices
    {
        private ICommentRepository _Repository;
        private IUnitOfWork _unitOfWork;
        public CommentServices(ICommentRepository Repository, IUnitOfWork unitOfWork)
        {
            this._Repository = Repository;
            this._unitOfWork = unitOfWork;
        }

        public Comment Add(Comment _model)
        {
            return _Repository.Add(_model);
        }

        public Comment Delete(int _id)
        {
            return _Repository.Delete(_id);
        }

        public IEnumerable<Comment> All()
        {
            return _Repository.GetAll();
        }

        public CommentView GetAll(string _keyWords, DateTime? _fromDate, DateTime? _toDate, bool? _isTrash, int? _pageIndex, int? _pageSize)
        {
            var entitys = _Repository.GetAll();

            if (!string.IsNullOrEmpty(_keyWords))
            {
                entitys = entitys.Where(x => x.commentFullName.ToLower().Contains(_keyWords.ToLower().Trim()) || x.commentEmail.ToLower().Contains(_keyWords.ToLower().Trim()) || x.commentPhone.ToLower().Contains(_keyWords.ToLower().Trim()) || x.commentPhone.ToLower().Contains(_keyWords.ToLower().Trim()) || x.commentBody.ToLower().Contains(_keyWords.ToLower().Trim()));
            }
            if (_fromDate.HasValue)
            {
                entitys = entitys.Where(x => x.commentTime.Date >= _fromDate.Value.Date);
            }
            if (_toDate.HasValue)
            {
                entitys = entitys.Where(x => x.commentTime.Date <= _toDate.Value.Date);
            }
            if (_isTrash.HasValue)
            {
                entitys = entitys.Where(x => x.isTrash == _isTrash);
            }
            entitys = entitys.OrderByDescending(x => x.commentId);
            int totalRecord = entitys.Count();
            if (_pageIndex != null && _pageSize != null)
            {
                entitys = entitys.Skip((_pageIndex.Value - 1) * _pageSize.Value);
            }
            var totalPage = 0;
            if (_pageSize != null)
            {
                totalPage = (int)Math.Ceiling(1.0 * totalRecord / _pageSize.Value);
                entitys = entitys.Take(_pageSize.Value);
            }
            return new CommentView { Comments = entitys, Total = totalPage };
        }

        public IEnumerable<Comment> GetAllByEmail(string _email)
        {
            return _Repository.GetByEmails(_email);
        }

        public Comment GetById(int _id)
        {
            return _Repository.GetSingleById(_id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Comment _model)
        {
            _Repository.Update(_model);
        }
    }
}
