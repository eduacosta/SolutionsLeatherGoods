﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using Bitacora;
using DAL;

namespace ASF.Business.CategoryBusines
{
    [ExceptionAspect]
    internal class CategoryBusiness : ICategoryBusiness
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

        public Category Add(Category entity)
        {

            using (var repo = FachadaDAL.FachadaDAL.CategoryDAL())

            {
                repo.BeginTransaction();
                entity.CreatedOn = DateTime.Now;
                int _id = (int)repo.Entidad.Create(entity);
                repo.Commit();

                return new Category() { Id = _id };

            }



        }

        public void Edit(Category entity)
        {
            using (var repo = FachadaDAL.FachadaDAL.CategoryDAL())
            {
                repo.BeginTransaction();
                var _category = repo.Entidad.GetById(entity.Id);
                _category.Name = entity.Name;
                _category.ChangedOn = DateTime.Now;
                _category.ChangedBy = entity.ChangedBy;
                repo.Entidad.Update(_category);
                repo.Commit();
            }
        }

        public void Delete(Category entity)
        {
            using (var repo = FachadaDAL.FachadaDAL.CategoryDAL())
            {
                repo.BeginTransaction();
                repo.Entidad.Delete(entity.Id);
                repo.Commit();

            }
        }

        public Category GetByID(Category entity)
        {
            using (var repo = FachadaDAL.FachadaDAL.CategoryDAL())
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
