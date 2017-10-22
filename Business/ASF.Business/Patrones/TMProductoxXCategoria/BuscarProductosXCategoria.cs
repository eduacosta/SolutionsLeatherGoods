using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;

namespace ASF.Business.Patrones
{
    class BuscarProductosXCategoria : IBuscarProductosXCategoria
    {
        protected override IList<Dealer> DealersXCaregoria(Category category)
        {
            return FachadaBLL.FachadaBLL.DealerBusiness.DealerXCategory(category);
        }

        protected override IList<Product> ListaProductosXDealer(IList<Dealer> dealers)
        {
            return FachadaBLL.FachadaBLL.ProductBusiness.ListaProductosXListaDealer(dealers);
        }
    }
}
