using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using DAL;

namespace ASF.Business.Business.ProductBusiness
{
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


    }
}
