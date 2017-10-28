using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.Entities.DTO
{
    public class CartItemDTO 
    {

        public IList<CartItem> ListaCartItem { get; set; }

        public Client Client { get; set; }

    }
}
