using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;

namespace ASF.Business.Patrones.TMConfirmarCompra
{
    public class TMConfirmarCompra : ITMConfirmarCompra
    {
        protected override OrderNumber GenerarOrderNumber()
        {
            return FachadaBLL.FachadaBLL.OrderNumberBusiness.GetOrderNumber();
        }

        protected override Order GenerarOrden(Order order)
        {
            return FachadaBLL.FachadaBLL.OrderBusiness.Add(order);
        }

        protected override void GenerarOrderDetails(IList<OrderDetail> orderDetails)
        {
            FachadaBLL.FachadaBLL.OrderDetailsBusiness.AddList(orderDetails);
        }

        protected override Client ClientXAspUser(Client client)
        {
            return FachadaBLL.FachadaBLL.ClentBusiness.GetByID(client);
        }
    }
}
