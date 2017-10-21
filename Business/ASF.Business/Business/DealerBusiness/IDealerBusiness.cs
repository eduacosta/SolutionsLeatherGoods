using System.Collections.Generic;
using ASF.Business.IABM;
using ASF.Entities;

namespace ASF.Business.DealerBusiness
{
    public interface IDealerBusiness : IABM<Dealer>
    {
        IList<Dealer> DealerXCategory(Category category);
    }
}