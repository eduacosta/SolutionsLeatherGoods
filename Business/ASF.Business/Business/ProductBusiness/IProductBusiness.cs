﻿using System.Collections.Generic;
using ASF.Business.IABM;
using ASF.Entities;

namespace ASF.Business.Business.ProductBusiness
{
    public interface IProductBusiness : IABM<Product>
    {
        IList<Product> ListaProductosXDealer(Dealer dealer);

        IList<Product> ListaProductosXListaDealer(IList<Dealer> dealer);

        IList<Product> ListaProductosXNombre(string nombre);

        IList<Product> ListaProductosXBuscador(string nombre);
    }
}