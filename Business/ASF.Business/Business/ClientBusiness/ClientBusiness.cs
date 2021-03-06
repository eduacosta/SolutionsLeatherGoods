﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using Bitacora;
using DAL;

namespace ASF.Business.ClientBusiness
{
    [ExceptionAspect]
    class ClientBusiness : IClientBusiness
    {

       

        public IList<Client> All()
        {
            using (var repo = FachadaDAL.FachadaDAL.ClientDAL())
            {
                repo.BeginTransaction();
                var _lista = repo.Entidad.GetAll()
                    .Select(c => new Client()
                    {
                        Id = c.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Email = c.Email,
                        Country = new Country() { Id = c.Country.Id, Name = c.Country.Name },
                        City = c.City
                    }).ToList();

                repo.Commit();
                return _lista;


            }
        }

        public Client Add(Client entity)
        {
            using (var repo = FachadaDAL.FachadaDAL.ClientDAL())
            {
                repo.BeginTransaction();
                int _id = (int)repo.Entidad.Create(entity);
                repo.Commit();

                return new Client() { Id = _id };

            }
        }

        public void Edit(Client entity)
        {
            using (var repo = FachadaDAL.FachadaDAL.ClientDAL())
            {
                
                repo.BeginTransaction();
                var _client = repo.Entidad.GetById(entity.Id);
                _client.ChangedOn = DateTime.Now;
                _client.ChangedBy = entity.ChangedBy;
                _client.FirstName = entity.FirstName;
                _client.LastName = entity.LastName;
                _client.Country = entity.Country;
                _client.City = entity.City;
               

                repo.Entidad.Update(_client);

                repo.Commit();
                


            }
        }

        public void Delete(Client entity)
        {
            using (var repo = FachadaDAL.FachadaDAL.ClientDAL())
            {
                repo.BeginTransaction();
                repo.Entidad.Delete(entity.Id);
                repo.Commit();

            }
        }

        public Client GetByID(Client entity)
        {
            using (var repo = FachadaDAL.FachadaDAL.ClientDAL())
            {
                repo.BeginTransaction();
                var _lista = repo.Entidad.GetAll()
                    .Where(c => c.AspNetUsers == entity.AspNetUsers)
                    .Select(c => new Client()
                    {
                        Id = c.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Email = c.Email,
                        //Country = new Country() { Id = c.Country.Id, Name = c.Country.Name },
                        City = c.City,
                        CountryID = c.Country.Id
                    }).FirstOrDefault();

                repo.Commit();
                return _lista;


            }
        }
    }
}
