using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using DAL;

namespace ASF.Business.CategoryBusines
{
    internal class CategoryBusines : ICategoryBusines
    {
        private readonly IUnitOfWork<Category> _unitOfWorkcategory;

        public CategoryBusines(IUnitOfWork<Category> unitOfWorkcategory)
        {

            this._unitOfWorkcategory = unitOfWorkcategory;

        }

        public IList<Category> All()
        {

            using (var repo = _unitOfWorkcategory)
            {
                IList<Category> _liscategory;
                repo.BeginTransaction();
                _liscategory = repo.Entidad.GetAll().Select(c => new Category() { Id = c.Id, Name = c.Name }).ToList();
                repo.Commit();

                return _liscategory;


            }


        }

        public Category Add(Category entity)
        {

            using (var repo = this._unitOfWorkcategory)
            {
                repo.BeginTransaction();
                int _id = (int)repo.Entidad.Create(entity);
                repo.Commit();

                return new Category() { Id = _id };

            }

        }

        public void Edit(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public Category GetByID(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
