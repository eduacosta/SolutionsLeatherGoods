using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using Bitacora;
using DAL;

namespace ASF.Business.CountryBusiness
{
    [ExceptionAspect]
    class CountryBusiness : ICountryBusiness
    {

        private IUnitOfWork<Country> _unitOfWorkCountry;
        public CountryBusiness(FachadaDAL.FachadaDAL fachadadal)
        {

            this._unitOfWorkCountry = fachadadal.CountryDAL();
        }

        public IList<Country> All()
        {
            using (var repo = _unitOfWorkCountry)
            {
                repo.BeginTransaction();
                var _lista = repo.Entidad.GetAll().Select(c => new Country() { Id = c.Id, Name = c.Name }).ToList();
                repo.Commit();
                return _lista;

            }
        }

        public Country Add(Country entity)
        {
            using (var repo = _unitOfWorkCountry)
            {
                repo.BeginTransaction();
                entity.CreatedOn = DateTime.Now;               
                int _id = (int)repo.Entidad.Create(entity);
                repo.Commit();

                return new Country()
                {
                    Id = _id
                };

            }
        }

        public void Edit(Country entity)
        {
            using (var repo = _unitOfWorkCountry)
            {
                repo.BeginTransaction();
                var _country = repo.Entidad.GetById(entity.Id);
                _country.Name = entity.Name;
                _country.ChangedOn = DateTime.Now;
                _country.ChangedBy = entity.ChangedBy;

                repo.Entidad.Update(_country);

                repo.Commit();
 
            }
        }

        public void Delete(Country entity)
        {
            using (var repo = _unitOfWorkCountry)
            {
                repo.BeginTransaction();
                repo.Entidad.Delete(entity.Id);
                repo.Commit();
            }
        }

        public Country GetByID(Country entity)
        {
            using (var repo = _unitOfWorkCountry)
            {
                repo.BeginTransaction();
                var _country = repo.Entidad.GetAll().Where(c => c.Id == entity.Id).Select(c => new Country()
                {
                    Id = c.Id,
                    Name = c.Name


                }).FirstOrDefault();

                repo.Commit();

                return _country;

            }
        }
    }
}
