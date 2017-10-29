using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Business.FachadaBLL;
using ASF.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASF.Test.TestOrder
{   
    [TestClass]
    public class TestOrder
    {

        [TestMethod]
        public void TestInsertOrder()
        {

            FachadaBLL.OrderBusiness.Add(new Order()
            {
                Client = new Client() {Id = 2},
                TotalPrice = 100,
                ItemCount = 10,
                State = Status.Reviewed,
                OrderDate = DateTime.Now,
                OrderNumber = 2,
                CreatedOn = DateTime.Now


            });

        }

    }
}
