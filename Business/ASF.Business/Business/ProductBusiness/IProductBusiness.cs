using System.Collections.Generic;
using ASF.Entities;

namespace ASF.Business.Business.ProductBusiness
{
    public interface IProductBusiness
    {
        IList<Product> ListaProductosXDealer(Dealer dealer);
    }
}