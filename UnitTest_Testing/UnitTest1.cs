using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoviProjekat.Data;
using NoviProjekat.Data.EntityModels;
using NoviProjekat.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NoviProjekat.Controllers;
using NoviProjekat.Web.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;


namespace UnitTest_Testing
{
    [TestClass]
    public class HomeControllerTest
    {
        private readonly MyContext _context;
        [TestMethod]
        public void IndexView_NotNull()
        {
           
            HomeController hc = new HomeController(_context);
            Assert.IsNotNull(hc.Index());
        }

        [TestMethod]
        public void ContactView_ViewData()
        {
            HomeController hc = new HomeController(_context);
            ViewResult vr = hc.Contact() as ViewResult;

            Assert.AreEqual(vr.ViewData["Message"], "Your contact page.");
        }


    }
    [TestClass]
    public class NabavkaControllerTest
    {
        private readonly MyContext context;
        [TestMethod]
        public void Nabavka_BrojNabavki() {

      

            NabavkaController pc = new NabavkaController(context);
            ViewResult vr = pc.Index() as ViewResult;
            NabavkaIndexVM model = vr.Model as NabavkaIndexVM;

            Assert.AreEqual(model.rows.Count(),1);

        }
    }
}
