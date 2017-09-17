using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Business.CategoryBusines;
using ASF.Business.ClientBusiness;

namespace ASF.Business.FachadaBLL
{
    public class FachadaBLL
    {

        public static ICategoryBusiness CategoryBusiness { get { return IoC.IoC.Resolve<ICategoryBusiness>(); } }

        public static IClientBusiness ClentBusiness { get { return IoC.IoC.Resolve<IClientBusiness>(); } }
    }
}
