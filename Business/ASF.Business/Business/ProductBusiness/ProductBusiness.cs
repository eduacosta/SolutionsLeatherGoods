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
                    Title = c.Title,
                    Image = c.Image


                })
                    .ToList();


                repo.Commit();

                return _listaproductos;

            }



        }

        public IList<Product> ListaProductosXListaDealer(IList<Dealer> dealer)
        {
            using (var repo= _UnitOfWork)
            {
                repo.BeginTransaction();
                var lista = repo.Entidad.GetAll().Where(f => dealer.Contains(f.Dealer)).Select(c => new Product()
                    {

                        Id = c.Id,
                        Description = c.Description,
                        Price = c.Price,
                        Title = c.Title,
                        Image = c.Image,
                        Dealer = new Dealer()
                        {
                            Id = c.Dealer.Id,
                            Description = c.Dealer.Description,
                            FirstName = c.Dealer.FirstName

                        }


                    })
                    .ToList();


                repo.Commit();

                return lista;




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
            using (var repo = _UnitOfWork)
            {
                repo.BeginTransaction();
                var _product = repo.Entidad.GetById(entity.Id);
                if (entity.Image != null)
                {
                    _product.Image = entity.Image;
                }
                _product.Title = entity.Title;
                _product.Description = entity.Description;
                _product.Price = entity.Price;
                _product.ChangedBy = entity.ChangedBy;
                _product.ChangedOn = DateTime.Now;

                repo.Entidad.Update(_product);

                repo.Commit();




            }
        }

        public void Delete(Product entity)
        {
            using (var repo = _UnitOfWork)
            {
                repo.BeginTransaction();
                repo.Entidad.Delete(entity.Id);
                repo.Commit();

            }
        }

        public Product GetByID(Product entity)
        {
            using (var repo = _UnitOfWork)
            {

                repo.BeginTransaction();
                var _listaproductos = repo.Entidad.GetAll().Where(c => c == entity).Select(c => new Product()
                    {

                        Id = c.Id,
                        Description = c.Description,
                        Price = c.Price,
                        Title = c.Title,
                        Image = c.Image


                    })
                    .FirstOrDefault();


                repo.Commit();

                return _listaproductos;

            }
        }
    }
}
