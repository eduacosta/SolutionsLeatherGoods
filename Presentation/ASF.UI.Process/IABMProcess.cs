using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;

namespace ASF.UI.Process
{
    public interface IABMProcess<T> where T : EntityBase
    {


       

        IList<T> SelectList();

        T Edit(T entity);


        T GetById(int id);

        T GetById(string id);

        T Remove(T entity);


        T Create(T entity);


    }
}
