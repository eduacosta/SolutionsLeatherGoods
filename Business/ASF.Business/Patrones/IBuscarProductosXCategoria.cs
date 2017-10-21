using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ASF.Entities;
using Bitacora;

namespace ASF.Business.Patrones
{
    [ExceptionAspect]
    public abstract class IBuscarProductosXCategoria
    {


        protected abstract IList<Dealer> DealersXCaregoria(Category category);


        protected abstract IList<Product> ListaProductosXDealer(IList<Dealer> dealers);



        public IList<Product> ListaProductosXCategoria(Category category)
        {


            using (var tran = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                var _lista = ListaProductosXDealer(DealersXCaregoria(category));

                tran.Complete();

                return _lista;

            }




        }



    }
}
