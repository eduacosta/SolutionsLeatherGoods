using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;

namespace ASF.Business.CategoryBusines
{
    internal class CategoryBusines : ICategoryBusines
    {

        public IList<Category> All()
        {

            using (var repo = FachadaDAL.FachadaDAL.CategoryDAL())
            {
                IList<Category> _liscategory;
                repo.BeginTransaction();
                _liscategory = repo.Entidad.GetAll().Select(c => new Category() { Id = c.Id, Name = c.Name }).ToList();

                repo.Commit();

                return _liscategory;


            }



        }


    }
}
