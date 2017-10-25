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
       

        public IList<CartItem> All()
        {
            throw new NotImplementedException();
        }


        private CartItem CartItemXCookie_Product(CartItem cartItem)
        {
            using (var repo = FachadaDAL.FachadaDAL.CartItemDAL())
            {
                repo.BeginTransaction();
                var _cartitem = repo.Entidad.GetAll()
                    .Where(c => c.Cart.Cookie == cartItem.Cart.Cookie && c.Product == cartItem.Product)
                    .Select(c => new CartItem() { Id = c.Id, Quantity = c.Quantity }).FirstOrDefault();


                repo.Commit();

                return _cartitem;

            }


        }

        public CartItem Add(CartItem entity)
        {




            CartItem _cartItem = CartItemXCookie_Product(entity);

            if (_cartItem == null)
            {
                using (var repo = FachadaDAL.FachadaDAL.CartItemDAL())
                {

                    repo.BeginTransaction();
                    entity.CreatedOn = DateTime.Now;
                    var _id = (int)repo.Entidad.Create(entity);
                    _cartItem = new CartItem() { Id = _id };
                    repo.Commit();

                }
            }
            else
            {
                _cartItem.Quantity = _cartItem.Quantity + 1;
                Edit(_cartItem);
            }






            return _cartItem;






        }

        public void Edit(CartItem entity)
        {
            using (var repo = FachadaDAL.FachadaDAL.CartItemDAL())
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
