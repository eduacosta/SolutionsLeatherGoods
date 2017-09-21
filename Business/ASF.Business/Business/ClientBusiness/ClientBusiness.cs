using System;
using System.Collections.Generic;
using System.Linq;
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

        private IUnitOfWork<Client> _unitOfClient;
        public ClientBusiness(FachadaDAL.FachadaDAL fachadal)
        {
            _unitOfClient = fachadal.ClientDAL();

        }


        public IList<Client> All()
        {
            using (var repo = _unitOfClient)
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
            using (var repo = _unitOfClient)
            {
                repo.BeginTransaction();
                int _id = (int)repo.Entidad.Create(entity);
                repo.Commit();

                return new Client() { Id = _id };

            }
        }

        public void Edit(Client entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Client entity)
        {
            using (var repo = _unitOfClient)
            {
                repo.BeginTransaction();
                repo.Entidad.Delete(entity.Id);
                repo.Commit();

            }
        }

        public Client GetByID(Client entity)
        {
            using (var repo = _unitOfClient)
            {
                repo.BeginTransaction();
                var _lista = repo.Entidad.GetAll()
                    .Where(c => c == entity)
                    .Select(c => new Client()
                    {
                        Id = c.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Email = c.Email,
                        Country = new Country() { Id = c.Country.Id, Name = c.Country.Name },
                        City = c.City
                    }).FirstOrDefault();

                repo.Commit();
                return _lista;


            }
        }
    }
}
