using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASF.Entities;

namespace ASF.UI.WbSite.Models.CustomModel
{
    public class ViewModelCarItem_Order
    {

        public ViewModelCarItem_Order()
        {
            this.CartItems = new List<CartItem>();
            this.Order = new List<Order>();


        }
        
        

        public IList<CartItem> CartItems { get; set; }


        public IList<Order> Order { get; set; }
        



    }
}