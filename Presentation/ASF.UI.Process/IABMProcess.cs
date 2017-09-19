using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;

namespace ASF.UI.Process
{
    public interface IABMProcess<T> where T : EntityBase
    {

        IList<T> SelectList();

        T EditCategory(T entity);


        T GetById(int id);

        T RemoveCategory(T entity);


        T CreateCategory(T entity);


    }
}
