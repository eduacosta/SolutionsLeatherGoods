using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;

namespace ASF.Business.Business.LenguajesBusiness
{
    class LenguajeBussinnes : ILenguajeBussinnes
    {
        public IList<Language> ListaLenguajes()
        {

            using (var repo = FachadaDAL.FachadaDAL.LanguegeDAL())
            {
                repo.BeginTransaction();
                var _datos = repo.Entidad.GetAll().Select(c => new Language()
                {
                    Id = c.Id,
                    Name = c.Name,
                    LanguageCulture = c.LanguageCulture


                }).ToList();

                repo.Commit();

                return _datos;


            }



        }




    }
}
