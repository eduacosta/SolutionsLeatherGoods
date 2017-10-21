using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Business.Business.LanguajeBusiness;
using ASF.Business.Business.ProductBusiness;
using ASF.Business.CategoryBusines;
using ASF.Business.ClientBusiness;
using ASF.Business.CountryBusiness;
using ASF.Business.DealerBusiness;
using ASF.Business.Patrones;

namespace ASF.Business.FachadaBLL
{
    public class FachadaBLL
    {

        public static ICategoryBusiness CategoryBusiness { get { return IoC.IoC.Resolve<ICategoryBusiness>(); } }

        public static IClientBusiness ClentBusiness { get { return IoC.IoC.Resolve<IClientBusiness>(); } }

        public static ICountryBusiness CountryBusiness { get { return IoC.IoC.Resolve<ICountryBusiness>(); } }

        public static IDealerBusiness DealerBusiness { get { return IoC.IoC.Resolve<IDealerBusiness>(); } }

        public static ILanguajesBusiness LanguajeBusiness { get { return IoC.IoC.Resolve<ILanguajesBusiness>(); } }


        public static IProductBusiness ProductBusiness { get { return IoC.IoC.Resolve<IProductBusiness>(); } }

        public static IBuscarProductosXCategoria BuscarProductosXCategoria { get { return IoC.IoC.Resolve<IBuscarProductosXCategoria>(); } }
    }
}
