using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;

namespace ASF.Business.Business.OrderNumberBusiness
{
    internal class OrderNumberBusiness : IOrderNumberBusiness
    {
        public IList<OrderNumber> All()
        {
            throw new NotImplementedException();
        }

        public OrderNumber Add(OrderNumber entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(OrderNumber entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(OrderNumber entity)
        {
            throw new NotImplementedException();
        }

        public OrderNumber GetByID(OrderNumber entity)
        {
            throw new NotImplementedException();
        }

        public OrderNumber GetOrderNumber()
        {
            lock (this)
            {

                OrderNumber _orderNumber;
                using (var repo = FachadaDAL.FachadaDAL.OrderNumberDAL())
                {
                    repo.BeginTransaction(IsolationLevel.Serializable);

                    _orderNumber = repo.Entidad.GetAll().FirstOrDefault();

                    if (_orderNumber == null)
                    {
                        _orderNumber = new OrderNumber(){Number = 1};
                        repo.Entidad.Create(_orderNumber);
                    }
                    else
                    {
                        _orderNumber.Number = _orderNumber.Number + 1;
                        repo.Entidad.Update(_orderNumber);

                    }

                    repo.Commit();
                }

                return _orderNumber;

            }
        }
    }
}
