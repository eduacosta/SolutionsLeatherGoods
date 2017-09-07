using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Business.CategoryBusines;
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
                    FachadaDAL.FachadaDAL _fachadal = new FachadaDAL.FachadaDAL();
                    var container = new UnityContainer();
                   
                    container.RegisterInstance<FachadaDAL.FachadaDAL>("_fachadal", _fachadal, new TransientLifetimeManager());
                    //.RegisterType(typeof(IUnitOfWork<>), typeof(UnitOfWork<>), new TransientLifetimeManager())
                    container.RegisterType<ICategoryBusines, CategoryBusines.CategoryBusines>(new InjectionConstructor( container.Resolve<FachadaDAL.FachadaDAL>("_fachadal")))

                            
                         


                        ;



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
