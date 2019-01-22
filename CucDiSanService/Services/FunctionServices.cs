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

    public interface IFunctionServices
    {
        Function Add(Function _model);

        void Update(Function _model);

        Function Delete(int _id);

        IEnumerable<Function> GetAll();

        Function GetByName(string _name);

        Function GetById(int _id);

        void Save();
    }
    public class FunctionServices : IFunctionServices
    {
        private IFunctionRepository _Repository;
        private IUnitOfWork _unitOfWork;
        public FunctionServices(IFunctionRepository Repository, IUnitOfWork unitOfWork)
        {
            this._Repository = Repository;
            this._unitOfWork = unitOfWork;
        }

        public Function Add(Function _model)
        {
            return _Repository.Add(_model);
        }

        public Function Delete(int _id)
        {
            return _Repository.Delete(_id);
        }

        public IEnumerable<Function> GetAll()
        {
            return _Repository.GetAll();
        }

        public Function GetByName(string _name)
        {
            return _Repository.GetByName(_name);
        }

        public Function GetById(int _id)
        {
            return _Repository.GetSingleById(_id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Function _model)
        {
            _Repository.Update(_model);
        }
    }
}
