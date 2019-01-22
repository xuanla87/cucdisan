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

    public interface IVisitorServices
    {
        Visitor Add(Visitor _model);

        void Update(Visitor _model);

        Visitor Delete(int _id);

        IEnumerable<Visitor> GetAll();

        IEnumerable<Visitor> GetByUserName(DateTime _fromDate, DateTime _toDate);

        Visitor GetById(int _id);

        void Save();
    }
    public class VisitorServices : IVisitorServices
    {
        private IVisitorRepository _Repository;
        private IUnitOfWork _unitOfWork;
        public VisitorServices(IVisitorRepository Repository, IUnitOfWork unitOfWork)
        {
            this._Repository = Repository;
            this._unitOfWork = unitOfWork;
        }

        public Visitor Add(Visitor _model)
        {
            return _Repository.Add(_model);
        }

        public Visitor Delete(int _id)
        {
            return _Repository.Delete(_id);
        }

        public IEnumerable<Visitor> GetAll()
        {
            return _Repository.GetAll();
        }

        public IEnumerable<Visitor> GetByUserName(DateTime _fromDate, DateTime _toDate)
        {
            return _Repository.GetByTime(_fromDate, _toDate);
        }

        public Visitor GetById(int _id)
        {
            return _Repository.GetSingleById(_id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Visitor _model)
        {
            _Repository.Update(_model);
        }
    }
}
