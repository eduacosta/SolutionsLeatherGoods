using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASF.Entities;

namespace ASF.UI.WbSite.Models.CustomModel
{
    public class ViewModelCarItem_Order
    {

        public CartItem[] CartItems { get; set; }


        public IList<Order> Order { get; set; }
        



    }
}