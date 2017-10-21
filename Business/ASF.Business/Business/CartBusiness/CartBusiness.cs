using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Business.IABM;
using ASF.Entities;
using DAL;

namespace ASF.Business.Business.CartBusiness
{
    class CartBusiness : ICartBusiness
    {

        private readonly IUnitOfWork<Cart> _cartUnitOfWork;


        public CartBusiness(FachadaDAL.FachadaDAL fachadal)
        {

            _cartUnitOfWork = fachadal.CartDAL();

        }

        public IList<Cart> All()
        {
            throw new NotImplementedException();
        }

        public Cart Add(Cart entity)
        {
            using (var repo = _cartUnitOfWork)
            {
                
                repo.BeginTransaction();
                entity.ChangedOn=DateTime.Now;
                entity.CartDate = DateTime.Now;
                var _id = (int)repo.Entidad.Create(entity);

                return new Cart(){Id = _id};


            }
        }

        public void Edit(Cart entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Cart entity)
        {
            throw new NotImplementedException();
        }

        public Cart GetByID(Cart entity)
        {
            throw new NotImplementedException();
        }
    }
}
