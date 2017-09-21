using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using DAL;

namespace ASF.Business.Business.LanguajeBusiness
{
    class LanguajesBusiness : ILanguajesBusiness
    {

        private readonly IUnitOfWork<LocaleStringResource> _unitOfWorkLocaleStringResource;

        public LanguajesBusiness(FachadaDAL.FachadaDAL fachadaDal)
        {

            this._unitOfWorkLocaleStringResource = fachadaDal.LocaleStringResourceDAL();

        }

        public IDictionary<LocaleResourceKey, string> GetLenguajesResourceByLanguaje(Language language)
        {

            using (var repo = _unitOfWorkLocaleStringResource)
            {
                repo.BeginTransaction();
                var _resource = repo.Entidad.GetAll().Where(c => c.Language == language).Select(c => new LocaleStringResource()
                {

                    Id = c.Id,
                    ResourceValue = c.ResourceValue,
                    LocaleResourceKey = new LocaleResourceKey()
                    {
                        Name = c.LocaleResourceKey.Name,
                        Notes = c.LocaleResourceKey.Notes

                    }
                   

                }).ToDictionary(c => c.LocaleResourceKey, f => f.ResourceValue);

                repo.Commit();
                return _resource;

            }



        }


    }
}
