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



        public IList<LocaleStringResource> GetLenguajesResourceByLanguaje()
        {

            using (var repo = FachadaDAL.FachadaDAL.LocaleStringResourceDAL())
            {
                repo.BeginTransaction();
                var _resource = repo.Entidad.GetAll().Select(c => new LocaleStringResource()
                {

                    Language = new Language()
                    {
                        LanguageCulture = c.Language.LanguageCulture,
                        Name = c.Language.Name
                    },
                    LocaleResourceKey = new LocaleResourceKey()
                    {
                        Name = c.LocaleResourceKey.Name 
                    },
                    ResourceValue = c.ResourceValue


                }).ToList();

                repo.Commit();
                return _resource;

            }



        }


    }
}
