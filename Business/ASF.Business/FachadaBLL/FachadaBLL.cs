﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Business.Business.CartBusiness;
using ASF.Business.Business.CartItemBusiness;
using ASF.Business.Business.LanguajeBusiness;
using ASF.Business.Business.LenguajesBusiness;
using ASF.Business.Business.OrderBusiness;
using ASF.Business.Business.OrderDetailBusiness;
using ASF.Business.Business.OrderNumberBusiness;
using ASF.Business.Business.ProductBusiness;
using ASF.Business.CategoryBusines;
using ASF.Business.ClientBusiness;
using ASF.Business.CountryBusiness;
using ASF.Business.DealerBusiness;
using ASF.Business.Patrones;
using ASF.Business.Patrones.TMCart;
using ASF.Business.Patrones.TMConfirmarCompra;

namespace ASF.Business.FachadaBLL
{
    public class FachadaBLL
    {

        public static ICategoryBusiness CategoryBusiness { get { return IoC.IoC.Resolve<ICategoryBusiness>(); } }

        public static IClientBusiness ClentBusiness { get { return IoC.IoC.Resolve<IClientBusiness>(); } }

        public static ICountryBusiness CountryBusiness { get { return IoC.IoC.Resolve<ICountryBusiness>(); } }

        public static IDealerBusiness DealerBusiness { get { return IoC.IoC.Resolve<IDealerBusiness>(); } }

        public static ILocaleStringResourceBusiness LocaleStringResourceBusiness { get { return IoC.IoC.Resolve<ILocaleStringResourceBusiness>(); } }

        public static ILenguajeBussinnes LenguajeBusiness { get { return IoC.IoC.Resolve<ILenguajeBussinnes>(); } }


        public static IProductBusiness ProductBusiness { get { return IoC.IoC.Resolve<IProductBusiness>(); } }

        public static IBuscarProductosXCategoria BuscarProductosXCategoria { get { return IoC.IoC.Resolve<IBuscarProductosXCategoria>(); } }
        public static ITMAñadirAlCarrito AñadirProductosAlCarrito { get { return IoC.IoC.Resolve<ITMAñadirAlCarrito>(); } }

        public static ITMConfirmarCompra ConfirmarCompra { get { return IoC.IoC.Resolve<ITMConfirmarCompra>(); } }

        public static ICartBusiness CartBusiness { get { return IoC.IoC.Resolve<ICartBusiness>(); } }

        public static ICartItemBusiness CartItemBusiness { get { return IoC.IoC.Resolve<ICartItemBusiness>(); } }

        public static IOrderNumberBusiness OrderNumberBusiness { get { return IoC.IoC.Resolve<IOrderNumberBusiness>(); } }

        public static IOrderBusiness OrderBusiness { get { return IoC.IoC.Resolve<IOrderBusiness>(); } }

        public static IOrderDetailsBusiness OrderDetailsBusiness { get { return IoC.IoC.Resolve<IOrderDetailsBusiness>(); } }

    }
}
