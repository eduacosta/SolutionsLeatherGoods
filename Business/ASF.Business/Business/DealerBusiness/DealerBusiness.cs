﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using Bitacora;
using DAL;

namespace ASF.Business.DealerBusiness
{
    [ExceptionAspect]
    class DealerBusiness : IDealerBusiness
    {
        

        public IList<Dealer> All()
        {
            using (var repo = FachadaDAL.FachadaDAL.DealerDAL())
            {
                repo.BeginTransaction();
                var _lista = repo.Entidad.GetAll()
                    .Select(c => new Dealer()
                    {
                        Id = c.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Description = c.Description,
                        Category = new Category() { Id = c.Category.Id, Name = c.Category.Name }
                    }).ToList();

                repo.Commit();
                return _lista;

            }
        }

        public Dealer Add(Dealer entity)
        {
            using (var repo = FachadaDAL.FachadaDAL.DealerDAL())
            {
                repo.BeginTransaction();
                entity.ChangedOn = DateTime.Now;
                int _id = (int) repo.Entidad.Create(entity);
                repo.Commit();

                return new Dealer()
                {
                    Id = _id
                };

            }
        }

        public void Edit(Dealer entity)
        {
            using (var repo = FachadaDAL.FachadaDAL.DealerDAL())
            {
                repo.BeginTransaction();
                var _delaer = repo.Entidad.GetById(entity.Id);
                _delaer.Category = entity.Category;
                _delaer.Description = entity.Description;
                _delaer.FirstName = entity.FirstName;
                _delaer.LastName = entity.LastName;
                _delaer.Country = entity.Country;
                _delaer.ChangedOn = DateTime.Now;
                repo.Entidad.Update(_delaer);

                repo.Commit();

            }
        }

        public void Delete(Dealer entity)
        {
            using (var repo = FachadaDAL.FachadaDAL.DealerDAL())
            {
                repo.BeginTransaction();
                repo.Entidad.Delete(entity);
                repo.Commit();

            }
        }

        public Dealer GetByID(Dealer entity)
        {
            using (var repo = FachadaDAL.FachadaDAL.DealerDAL())
            {
                repo.BeginTransaction();
                var _dealer = repo.Entidad.GetAll().Where(c => c.AsPNetUsers == entity.AsPNetUsers)
                    .Select(c => new Dealer()
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Description = c.Description,
                    Category = new Category() {Id = c.Category.Id, Name = c.Category.Name},
                    Country = new Country() { Id= c.Country.Id, Name = c.Country.Name},
                    CountryId = c.Country.Id,
                    CategoryId = c.Category.Id
                    
                }).FirstOrDefault();
                repo.Commit();

                return _dealer;

            }
        }


        public IList<Dealer> DealerXCategory(Category category)
        {

            using (var repo= FachadaDAL.FachadaDAL.DealerDAL())
            {
                
                repo.BeginTransaction();

                var _lista = repo.Entidad.GetAll().Where(c => c.Category == category)
                    .Select(c => new Dealer() {Id = c.Id}).ToList();


                repo.Commit();

                return _lista;


                    


            }


        }

    }
}
