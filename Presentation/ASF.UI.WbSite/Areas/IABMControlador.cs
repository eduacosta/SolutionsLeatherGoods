using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ASF.Entities;

namespace ASF.UI.WbSite.Areas
{
    public interface IABMControlador<T> where T : EntityBase

    {
        ActionResult ListEntity();

        ActionResult EditEntity(int id);

        ActionResult EditEntity(T entity);

        ActionResult CreateEntity();

        ActionResult CreateEntity(T entity);

        ActionResult DeleteEntity(int id);

        ActionResult DeleteEntity(T entity);


    }
}
