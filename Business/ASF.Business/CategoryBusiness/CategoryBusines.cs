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

        public CategoryBusines(FachadaDAL.FachadaDAL unitOfWorkcategory)
        {

            this._unitOfWorkcategory = unitOfWorkcategory.CategoryDAL();

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

            using (var repo = _unitOfWorkcategory)
            {
                repo.BeginTransaction();
                int _id = (int)repo.Entidad.Create(entity);
                repo.Commit();

                return new Category() { Id = _id };

            }

        }

        public void Edit(Category entity)
        {
            using (var repo = _unitOfWorkcategory)
            {
                repo.BeginTransaction();
                var _category = repo.Entidad.GetById(entity.Id);
                _category.Name = entity.Name;
                repo.Entidad.Update(_category);
                repo.Commit();
            }
        }

        public void Delete(Category entity)
        {
            using (var repo = _unitOfWorkcategory)
            {
                repo.BeginTransaction();
                repo.Entidad.Delete(entity);
                repo.Commit();

            }
        }

        public Category GetByID(Category entity)
        {
            using (var repo = _unitOfWorkcategory)
            {
                repo.BeginTransaction();
                var _category = repo.Entidad.GetAll().Where(c => c.Id == entity.Id).Select(c => new Category()
                {
                    Id = c.Id, 
                    Name = c.Name
                }).FirstOrDefault();
                repo.Commit();

                return _category;

            }

                
        }
    }
}
