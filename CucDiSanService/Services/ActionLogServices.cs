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

    public interface IActionLogServices
    {
        ActionLog Add(ActionLog _model);

        void Update(ActionLog _model);

        ActionLog Delete(int _id);

        IEnumerable<ActionLog> GetAll();

        ActionLogView GetaAdmin(DateTime? _fromDate, DateTime? _toDate, int? _pageIndex, int? _pageSize);

        IEnumerable<ActionLog> GetAllByUserName(string _userName);

        IEnumerable<ActionLog> GetAllByTime(DateTime _fromDate, DateTime _toDate);

        ActionLog GetById(int _id);

        void Save();
    }
    public class ActionLogServices : IActionLogServices
    {
        private IActionLogRepository _Repository;
        private IUnitOfWork _unitOfWork;
        public ActionLogServices(IActionLogRepository Repository, IUnitOfWork unitOfWork)
        {
            this._Repository = Repository;
            this._unitOfWork = unitOfWork;
        }

        public ActionLog Add(ActionLog _model)
        {
            return _Repository.Add(_model);
        }

        public ActionLog Delete(int _id)
        {
            return _Repository.Delete(_id);
        }

        public IEnumerable<ActionLog> GetAll()
        {
            return _Repository.GetAll();
        }

        public IEnumerable<ActionLog> GetAllByUserName(string _userName)
        {
            return _Repository.GetByUserName(_userName);
        }
        public ActionLogView GetaAdmin(DateTime? _fromDate, DateTime? _toDate, int? _pageIndex, int? _pageSize)
        {
            var enContent = _Repository.GetAll();
            if (_fromDate.HasValue)
            {
                enContent = enContent.Where(x => x.actionLogTime >= _fromDate.Value.Date);
            }
            if (_toDate.HasValue)
            {
                enContent = enContent.Where(x => x.actionLogTime <= _toDate.Value.Date);
            }
            enContent = enContent.OrderByDescending(x => x.actionLogTime);
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
            return new ActionLogView {  ActionLogs = enContent, Total = totalPage, TotalRecord = totalRecord };
        }

        public IEnumerable<ActionLog> GetAllByTime(DateTime _fromDate, DateTime _toDate)
        {
            return _Repository.GetMulti(x => x.actionLogTime.Date >= _fromDate.Date && x.actionLogTime.Date <= _toDate.Date);
        }
        public ActionLog GetById(int _id)
        {
            return _Repository.GetSingleById(_id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ActionLog _model)
        {
            _Repository.Update(_model);
        }
    }
}
