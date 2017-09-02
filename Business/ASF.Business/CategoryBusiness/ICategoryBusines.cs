using System.Collections.Generic;
using ASF.Entities;

namespace ASF.Business.CategoryBusines
{
    public interface ICategoryBusines
    {
        IList<Category> All();
    }
}