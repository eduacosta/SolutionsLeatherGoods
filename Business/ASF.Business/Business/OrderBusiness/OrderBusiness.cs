using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;

namespace ASF.Business.Business.OrderBusiness
{
    class OrderBusiness : IOrderBusiness
    {
        public IList<Order> All()
        {
            throw new NotImplementedException();
        }

        public Order Add(Order entity)
        {
            using (var repo = FachadaDAL.FachadaDAL.OrderDAL())
            {
                
                repo.BeginTransaction();
                var _id = (int)repo.Entidad.Create(entity);
                repo.Commit();

                return new Order()
                {
                    Id = _id
                };


            }
        }

        public void Edit(Order entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public Order GetByID(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
