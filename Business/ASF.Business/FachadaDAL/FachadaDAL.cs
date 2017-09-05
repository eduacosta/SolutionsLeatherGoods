using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using DAL;
using DAL.SingletonConexionDB;

namespace ASF.Business.FachadaDAL
{
    internal sealed class FachadaDAL
    {

       

        private static readonly ConfiguracionNHibernate _ConfiguracionNHibernate = new ConfiguracionNHibernate()
        {
            
            NameSpaceEntidades = "ASF.Entities",
            EnsambladoEntidad = "ASF.Entities",
            Conexion = "ConexionLeatherGoods"
        };
        private static readonly DAL.FachadaDAL _DAL = new DAL.FachadaDAL(_ConfiguracionNHibernate);


      

        public  static IUnitOfWork<Category> CategoryDAL()
        {

            return _DAL.Entidades<Category>();
        }

        public static IUnitOfWork<AspNetUserLogins> AspNetUserLoginsDAL()
        {

            return _DAL.Entidades<AspNetUserLogins>();
        }




    }
}
