using System.Collections.Generic;
using ASF.Entities;

namespace ASF.Business.Business.OrderDetailBusiness
{
    public interface IOrderDetailsBusiness : IABM.IABM<OrderDetail>
    {
       void AddList(IList<OrderDetail> entity);
    }
}