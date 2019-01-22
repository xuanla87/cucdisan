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
