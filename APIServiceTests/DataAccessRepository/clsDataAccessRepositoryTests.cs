using Microsoft.VisualStudio.TestTools.UnitTesting;
using APIService.DataAccessRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIService.DataAccessRepository.Tests
{
    [TestClass()]
    public class clsDataAccessRepositoryTests
    {
        [TestMethod()]
        public void LoadJsonFromFileTest()
        {
            clsDataAccessRepository _test = new clsDataAccessRepository();

            _test.LoadJsonFromFile("A-A-A");


            Assert.Fail();
        }
    }
}