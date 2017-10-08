using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ASF.Entities;

namespace ASF.UI.WbSite.Controllers
{
    public interface IABMControlador<T> where T : EntityBase

    {
        ActionResult Index();

        ActionResult Edit(object id);

        [HttpPost]
        ActionResult Edit(T entity);

        ActionResult Create();

        [HttpPost]
        ActionResult Create(T entity);

        ActionResult Delete(object id);

        [HttpPost]
        ActionResult Delete(T entity);


    }
}
