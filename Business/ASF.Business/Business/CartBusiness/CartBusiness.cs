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

       

        public IList<Cart> All()
        {
            throw new NotImplementedException();
        }


        private Cart CartXCookie(string cookie)
        {
            using (var repo = FachadaDAL.FachadaDAL.CartDAL())
            {
                repo.BeginTransaction();

                Cart _cart = repo.Entidad.GetAll().Where(c => c.Cookie == cookie)
                    .Select(c => new Cart() { Id = c.Id, Cookie = c.Cookie }).FirstOrDefault();


                repo.Commit();

                return _cart;

            }



        }


        public Cart Add(Cart entity)
        {

            Cart _cart = CartXCookie(entity.Cookie);

            if (_cart == null)
            {
                using (var repo = FachadaDAL.FachadaDAL.CartDAL())
                {

                    repo.BeginTransaction();
                    entity.CreatedOn = DateTime.Now;
                    entity.CartDate = DateTime.Now;
                    var _id = (int)repo.Entidad.Create(entity);
                    _cart = new Cart() { Id = _id, Cookie = entity.Cookie };
                    repo.Commit();

                }
            }


            return _cart;

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
