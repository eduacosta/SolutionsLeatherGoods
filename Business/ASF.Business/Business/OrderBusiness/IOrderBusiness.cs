using System.Collections.Generic;
using ASF.Entities;

namespace ASF.Business.Business.OrderBusiness
{
    public interface IOrderBusiness : IABM.IABM<Order>
    {
        IList<Order> OrdernesXCliente(Client client);
    }
}