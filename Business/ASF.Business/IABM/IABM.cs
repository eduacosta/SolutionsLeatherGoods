using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;

namespace ASF.Business.IABM
{
    public interface IABM<T> where T : EntityBase
    {
        IList<T> All();

        T Add(T entity);

        void Edit(T entity);

        void Delete(T entity);

        T GetByID(T entity);


    }
}
