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

        public IList<Order> OrdernesXCliente(Client client)
        {

            Client _client = FachadaBLL.FachadaBLL.ClentBusiness.GetByID(client);

            using (var repo = FachadaDAL.FachadaDAL.OrderDAL())
            {

                repo.BeginTransaction();
                var _order = repo.Entidad.GetAll().Where(f => f.Client == _client).Select(c => new Order()
                {

                    ItemCount = c.ItemCount,
                    State = c.State,
                    OrderDate = c.OrderDate,
                    TotalPrice = c.TotalPrice,
                    OrderDetail = new List<OrderDetail>(c.OrderDetail.Select(f => new OrderDetail()
                    {
                        Product = f.Product,
                        Price = f.Price,
                        Quantity = f.Quantity


                    }))


                }).ToList();

                repo.Commit();


                return _order;





            }
            


        }

        public Order Add(Order entity)
        {
            using (var repo = FachadaDAL.FachadaDAL.OrderDAL())
            {
                
                repo.BeginTransaction();
                int _id = (int)repo.Entidad.Create(entity);
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
