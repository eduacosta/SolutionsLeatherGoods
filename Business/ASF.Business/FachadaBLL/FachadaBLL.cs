using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Business.CategoryBusines;

namespace ASF.Business.FachadaBLL
{
    public class FachadaBLL
    {

        public static ICategoryBusines BusinessCategoryBusines { get { return IoC.IoC.Resolve<ICategoryBusines>(); } }


    }
}
