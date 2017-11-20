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


     

        public static IUnitOfWork<Category> CategoryDAL()
        {

            return _DAL.Entidades<Category>();
        }

        public static IUnitOfWork<Client> ClientDAL()
        {

            return _DAL.Entidades<Client>();
        }

        public static IUnitOfWork<Country> CountryDAL()
        {

            return _DAL.Entidades<Country>();
        }


        public static IUnitOfWork<Language> LanguegeDAL()
        {

            return _DAL.Entidades<Language>();
        }


        public static IUnitOfWork<LocaleResourceKey> LocaleResourceKeyDAL()
        {

            return _DAL.Entidades<LocaleResourceKey>();
        }


        public static IUnitOfWork<LocaleStringResource> LocaleStringResourceDAL()
        {

            return _DAL.Entidades<LocaleStringResource>();
        }


        public static IUnitOfWork<Dealer> DealerDAL()
        {

            return _DAL.Entidades<Dealer>();
        }


        public static IUnitOfWork<Product> ProductDAL()
        {

            return _DAL.Entidades<Product>();
        }

        public static IUnitOfWork<Cart> CartDAL()
        {

            return _DAL.Entidades<Cart>();
        }

        public static IUnitOfWork<CartItem> CartItemDAL()
        {

            return _DAL.Entidades<CartItem>();
        }

        public static IUnitOfWork<OrderNumber> OrderNumberDAL()
        {

            return _DAL.Entidades<OrderNumber>();
        }

        public static IUnitOfWork<Order> OrderDAL()
        {

            return _DAL.Entidades<Order>();
        }

        public static IUnitOfWork<OrderDetail> OrderDetailDAL()
        {

            return _DAL.Entidades<OrderDetail>();
        }


        
    }
}
