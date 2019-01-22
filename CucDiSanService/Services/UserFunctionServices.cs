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

    public interface IUserFunctionServices
    {
        UserFunction Add(UserFunction _model);

        void Update(UserFunction _model);

        UserFunction Delete(int _id);

        IEnumerable<UserFunction> GetAll();

        IEnumerable<UserFunction> GetByUserName(string _userName);

        UserFunction GetById(int _id);

        void Save();
    }
    public class UserFunctionServices : IUserFunctionServices
    {
        private IUserFunctionRepository _Repository;
        private IUnitOfWork _unitOfWork;
        public UserFunctionServices(IUserFunctionRepository Repository, IUnitOfWork unitOfWork)
        {
            this._Repository = Repository;
            this._unitOfWork = unitOfWork;
        }

        public UserFunction Add(UserFunction _model)
        {
            return _Repository.Add(_model);
        }

        public UserFunction Delete(int _id)
        {
            return _Repository.Delete(_id);
        }

        public IEnumerable<UserFunction> GetAll()
        {
            return _Repository.GetAll();
        }

        public IEnumerable<UserFunction> GetByUserName(string _userName)
        {
            return _Repository.GetByUserName(_userName);
        }

        public UserFunction GetById(int _id)
        {
            return _Repository.GetSingleById(_id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(UserFunction _model)
        {
            _Repository.Update(_model);
        }
    }
}
