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

                
                entity.CreatedOn = DateTime.Now;

                CartItem _cartItem = repo.Entidad.GetAll()
                    .Where(c => c.Cart.Cookie == entity.Cart.Cookie && c.Product == entity.Product)
                    .Select(c => new CartItem() {Id = c.Id, Quantity = c.Quantity}).FirstOrDefault();
               
                if (_cartItem == null)
                {
                    repo.BeginTransaction();
                   
                    var _id = (int)repo.Entidad.Create(entity);
                    repo.Commit();
                    _cartItem = new CartItem(){Id = _id};
                    

                }
                else
                {
                    _cartItem.Quantity = _cartItem.Quantity + 1;
                    Edit(_cartItem);
                }



                


                return _cartItem;
               




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
