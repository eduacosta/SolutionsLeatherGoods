using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using Bitacora;
using DAL;

namespace ASF.Business.Business.ProductBusiness
{

    [ExceptionAspect]
    class ProductBusiness : IProductBusiness
    {

        public IUnitOfWork<Product> _UnitOfWork;


        public ProductBusiness(FachadaDAL.FachadaDAL fachadaDal)
        {

            _UnitOfWork = fachadaDal.ProductDAL();

        }


        public IList<Product> ListaProductosXDealer(Dealer dealer)
        {

            using (var repo = _UnitOfWork)
            {

                repo.BeginTransaction();
                var _listaproductos = repo.Entidad.GetAll().Where(c => c.Dealer == dealer).Select(c => new Product()
                {

                    Id = c.Id,
                    Description = c.Description,
                    Price = c.Price,
                    Title = c.Title


                })
                    .ToList();


                repo.Commit();

                return _listaproductos;

            }



        }


        public IList<Product> All()
        {
            throw new NotImplementedException();
        }

        public Product Add(Product entity)
        {
            using (var repo = _UnitOfWork)
            {
                repo.BeginTransaction();
                entity.ChangedOn = DateTime.Now;
                int _id = (int)repo.Entidad.Create(entity);
                repo.Commit();

                return new Product()
                {
                    Id = _id
                };

            }
        }

        public void Edit(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product GetByID(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
