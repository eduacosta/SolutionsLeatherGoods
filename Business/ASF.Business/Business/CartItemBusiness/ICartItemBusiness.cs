using System.Collections.Generic;
using ASF.Business.IABM;
using ASF.Entities;

namespace ASF.Business.Business.CartItemBusiness
{
    public interface ICartItemBusiness : IABM<CartItem>
    {

        IList<CartItem> ListaCarritoXCookie(string cookie);
    }
}