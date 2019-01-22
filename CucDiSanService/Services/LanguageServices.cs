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

    public interface ILanguageServices
    {
        Language Add(Language _model);

        void Update(Language _model);

        Language Delete(int _id);

        IEnumerable<Language> GetAll();

        Language GetByKey(string _key);

        Language GetById(int _id);

        string GetNameById(int _id);

        void Save();
    }
    public class LanguageServices : ILanguageServices
    {
        private ILanguageRepository _Repository;
        private IUnitOfWork _unitOfWork;
        public LanguageServices(ILanguageRepository Repository, IUnitOfWork unitOfWork)
        {
            this._Repository = Repository;
            this._unitOfWork = unitOfWork;
        }

        public Language Add(Language _model)
        {
            return _Repository.Add(_model);
        }

        public Language Delete(int _id)
        {
            return _Repository.Delete(_id);
        }

        public IEnumerable<Language> GetAll()
        {
            return _Repository.GetAll();
        }

        public Language GetByKey(string _key)
        {
            return _Repository.GetByKey(_key);
        }

        public Language GetById(int _id)
        {
            return _Repository.GetSingleById(_id);
        }

        public string GetNameById(int _id)
        {
            if (_id > 0)
            {
                var entity = _Repository.GetSingleById(_id);
                if (entity != null && entity.languageName != null) return entity.languageName;
                else return null;
            }
            else return null;
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Language _model)
        {
            _Repository.Update(_model);
        }
    }
}
