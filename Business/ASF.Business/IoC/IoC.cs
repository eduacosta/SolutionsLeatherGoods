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
using ASF.Business.Patrones.TMAñadirAlCarrito;
using ASF.Business.Patrones.TMCart;
using ASF.Business.Patrones.TMConfirmarCompra;
using ASF.Entities;
using DAL;
using Microsoft.Practices.Unity;

namespace ASF.Business.IoC
{
    class IoC
    {
        //TODO sacar el constructor cuando se inyecta la dal
        /// <summary>
        ///     Static constructor for DependencyFactory which will
        ///     initialize the unity container.
        /// </summary>
        static IoC()
        {
            if (Container == null)
            {
                try
                {
                    //FachadaDAL.FachadaDAL _fachadal = new FachadaDAL.FachadaDAL();
                    var container = new UnityContainer();
                   
                    //container.RegisterInstance<FachadaDAL.FachadaDAL>("_fachadal", _fachadal, new TransientLifetimeManager());
                 


                    //container.RegisterType<ICategoryBusiness, CategoryBusines.CategoryBusiness>(
                    //    new InjectionConstructor(container.Resolve<FachadaDAL.FachadaDAL>()));


                    container.RegisterType<ICategoryBusiness, CategoryBusines.CategoryBusiness>();

                    container.RegisterType<IClientBusiness, ClientBusiness.ClientBusiness>();

                    container.RegisterType<IDealerBusiness, DealerBusiness.DealerBusiness>();

                    container.RegisterType<ICountryBusiness, CountryBusiness.CountryBusiness>();

                    container.RegisterType<ILocaleStringResourceBusiness, LocaleStringResourceBusiness>();

                    container.RegisterType<IProductBusiness, ProductBusiness>();

                    container.RegisterType<ICartBusiness, CartBusiness>();

                    container.RegisterType<ICartItemBusiness, CartItemBusiness>();

                    container.RegisterType<IBuscarProductosXCategoria, BuscarProductosXCategoria>();

                    container.RegisterType<ITMAñadirAlCarrito, TMAñadirAlCarrito>();

                    container.RegisterType<ITMConfirmarCompra, TMConfirmarCompra>();

                    container.RegisterType<IOrderBusiness, OrderBusiness>();

                    container.RegisterType<IOrderNumberBusiness, OrderNumberBusiness>();

                    container.RegisterType<IOrderDetailsBusiness, OrderDetailsBusiness>();

                    container.RegisterType<ILenguajeBussinnes, LenguajeBussinnes>();

                    Container = container;
                }


                catch (Exception ex)
                {
                    var me = ex.Message;
                }
            }
        }



        /// <summary>
        ///     Public reference to the unity container which will
        ///     allow the ability to register instrances or take
        ///     other actions on the container.
        /// </summary>
        private static IUnityContainer Container { get; set; }

        /// <summary>
        ///     Resolves the type parameter T to an instance of the appropriate type.
        /// </summary>
        /// <typeparam name="T">Type of object to return</typeparam>
        public static T Resolve<T>()
        {
            var ret = default(T);

            if (Container.IsRegistered(typeof(T)))
            {
                ret = Container.Resolve<T>();
            }

            return ret;
        }
    }



}
