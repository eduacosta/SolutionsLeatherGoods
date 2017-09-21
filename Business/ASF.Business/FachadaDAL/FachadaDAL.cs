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


     

        public  IUnitOfWork<Category> CategoryDAL()
        {

            return _DAL.Entidades<Category>();
        }

        public IUnitOfWork<Client> ClientDAL()
        {

            return _DAL.Entidades<Client>();
        }

        public IUnitOfWork<Country> CountryDAL()
        {

            return _DAL.Entidades<Country>();
        }


        public IUnitOfWork<Language> LanguegeDAL()
        {

            return _DAL.Entidades<Language>();
        }


        public IUnitOfWork<LocaleResourceKey> LocaleResourceKeyDAL()
        {

            return _DAL.Entidades<LocaleResourceKey>();
        }


        public IUnitOfWork<LocaleStringResource> LocaleStringResourceDAL()
        {

            return _DAL.Entidades<LocaleStringResource>();
        }


        public IUnitOfWork<Dealer> DealerDAL()
        {

            return _DAL.Entidades<Dealer>();
        }

     



    }
}
