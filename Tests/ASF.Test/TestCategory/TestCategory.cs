using System;
using System.Linq;
using ASF.Business.FachadaBLL;
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
    }
}
