using System;
using System.Linq;
using ASF.Business.FachadaBLL;
using ASF.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASF.Test.TestCategory
{
    [TestClass]
    public class TestCategory
    {
        [TestMethod]
        public void TestDALCAtegory()
        {
            var _datos = FachadaBLL.CategoryBusiness.All().ToList();

        }


        [TestMethod]
        public void TestInsertCategory()
        {
            var _datos = FachadaBLL.CategoryBusiness.Add(new Category(){Name = "Prueba"});

        }

    }
}
