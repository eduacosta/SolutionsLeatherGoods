using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Business.CategoryBusines;
using Microsoft.Practices.Unity;

namespace ASF.Business.IoC
{
    class IoC
    {

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



                    var container = new UnityContainer()

                        .RegisterType<ICategoryBusines, CategoryBusines.CategoryBusines>();
                       




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
