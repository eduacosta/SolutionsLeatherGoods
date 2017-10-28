using ASF.Entities;

namespace ASF.Business.Business.OrderNumberBusiness
{
    public interface IOrderNumberBusiness : IABM.IABM<OrderNumber>
    {
        OrderNumber GetOrderNumber();

    }
}