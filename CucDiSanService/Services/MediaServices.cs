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

    public interface IMediaServices
    {
        Media Add(Media _model);

        void Update(Media _model);

        Media Delete(int _id);

        IEnumerable<Media> GetAll();

        Media GetByName(string _name);

        Media GetById(int _id);

        void Save();
    }
    public class MediaServices : IMediaServices
    {
        private IMediaRepository _Repository;
        private IUnitOfWork _unitOfWork;
        public MediaServices(IMediaRepository Repository, IUnitOfWork unitOfWork)
        {
            this._Repository = Repository;
            this._unitOfWork = unitOfWork;
        }

        public Media Add(Media _model)
        {
            return _Repository.Add(_model);
        }

        public Media Delete(int _id)
        {
            return _Repository.Delete(_id);
        }

        public IEnumerable<Media> GetAll()
        {
            return _Repository.GetAll();
        }

        public Media GetByName(string _name)
        {
            return _Repository.GetByName(_name);
        }

        public Media GetById(int _id)
        {
            return _Repository.GetSingleById(_id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Media _model)
        {
            _Repository.Update(_model);
        }
    }
}
