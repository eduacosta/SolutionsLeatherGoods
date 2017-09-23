using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using DAL;

namespace ASF.Business.Business.AspNetUserBusiness
{
    class AspNetUserBusiness : IAspNetUserBusiness
    {

        private IUnitOfWork<AspNetUsers> _unitOfWorkaspnetuser;
        public AspNetUserBusiness(FachadaDAL.FachadaDAL fachadaDal)
        {

            this._unitOfWorkaspnetuser = fachadaDal.AspNetUsersDAL();


        }


        public AspNetUsers LogIn(AspNetUsers aspNetUsers)
        {
            using (var repo = _unitOfWorkaspnetuser)
            {
                repo.BeginTransaction();

                var _user = repo.Entidad.GetAll()
                    .Where(c => c.UserName == aspNetUsers.UserName && c.PasswordHash == aspNetUsers.PasswordHash)
                    .Select(c => new AspNetUsers() {Id = c.Id, UserName = c.UserName}).FirstOrDefault();

                repo.Commit();
                return _user;


            }



        }




    }
}
