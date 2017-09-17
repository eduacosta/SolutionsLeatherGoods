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
            throw new NotImplementedException();
        }

        public void Edit(Country entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Country entity)
        {
            throw new NotImplementedException();
        }

        public Country GetByID(Country entity)
        {
            throw new NotImplementedException();
        }
    }
}
