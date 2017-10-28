using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;

namespace ASF.Business.Business.OrderDetailBusiness
{
    class OrderDetailsBusiness : IOrderDetailsBusiness
    {
        public IList<OrderDetail> All()
        {
            throw new NotImplementedException();
        }

        public void AddList(IList<OrderDetail> entity)
        {
            using (var repo = FachadaDAL.FachadaDAL.OrderDetailDAL())
            {
                repo.BeginTransaction();

                foreach (var _enDetail in entity)
                {


                    repo.Entidad.Create(_enDetail);


                }

                repo.Commit();

            }
        }

        public OrderDetail Add(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public OrderDetail GetByID(OrderDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
