using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using DAL;

namespace ASF.Business.Business.CartItemBusiness
{
    class CartItemBusiness : ICartItemBusiness
    {
        private readonly IUnitOfWork<CartItem> _unitOfWork;


        public CartItemBusiness(FachadaDAL.FachadaDAL fachadaDal)
        {
            this._unitOfWork = fachadaDal.CartItemDAL();
        }


        public IList<CartItem> All()
        {
            throw new NotImplementedException();
        }

        public CartItem Add(CartItem entity)
        {
            using (var repo = _unitOfWork)
            {

                repo.BeginTransaction();
                entity.CreatedOn = DateTime.Now;

                if (repo.Entidad.GetAll().Any(c => c.Cart.Cookie == entity.Cart.Cookie && c.Product == entity.Product))
                {

                    var _entidad = repo.Entidad.GetById(entity.Id);
                    int _cantidad = _entidad.Quantity + 1;
                    _entidad.Quantity = _cantidad;
                    Edit(entity);


                }

                var _id = (int)repo.Entidad.Create(entity);


                repo.Commit();

                return new CartItem(){Id = _id};




            }
        }

        public void Edit(CartItem entity)
        {
            using (var repo = _unitOfWork)
            {
                repo.BeginTransaction();
                var _entidad = repo.Entidad.GetById(entity.Id);
                _entidad.Quantity = entity.Quantity;
                _entidad.ChangedOn = DateTime.Now;
                repo.Entidad.Update(_entidad);

                repo.Commit();


            }
        }

        public void Delete(CartItem entity)
        {
            throw new NotImplementedException();
        }

        public CartItem GetByID(CartItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
