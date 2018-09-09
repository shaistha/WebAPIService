using Microsoft.VisualStudio.TestTools.UnitTesting;
using APIService.DataAccessRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MVCClient.Models;
using Newtonsoft.Json.Linq;

namespace APIService.DataAccessRepository.Tests
{
    [TestClass()]
    public class clsDataAccessRepositoryTests
    {
        [TestMethod()]
        public void LoadJsonFromFileTest_ShouldReturnReverseOfAllElements()
        {
            //set up prerequisites
            clsDataAccessRepository _repositoryTest = new clsDataAccessRepository();

            JsonSerializer serializer = new JsonSerializer();
            //Act
            var actual = _repositoryTest.LoadJsonFromFile("A-A-A");
            var expected  = "{\"data\":[\"Fiat\",\"BMW\",\"Ford\"]}";
            //Assert
            Assert.AreEqual(actual,expected);
        }
       

        [TestMethod()]
        public void LoadJsonFromFileTest_ShouldReturnReverseOfFirstTwoElements()
        {
            //set up prerequisites
            clsDataAccessRepository _repositoryTest = new clsDataAccessRepository();

            //Act
            string actual = _repositoryTest.LoadJsonFromFile("A-A");
            var expected = "{\"data\":[\"BMW\",\"Ford\",\"Fiat\"]}";
            //Assert

            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void LoadJsonFromFileTest_ShouldReturnOriginalData()
        {
            //set up prerequisites
            clsDataAccessRepository _repositoryTest = new clsDataAccessRepository();

            //Act
            string actual = _repositoryTest.LoadJsonFromFile("A*A");
            var expected = "{\"data\":[\"Ford\",\"BMW\",\"Fiat\"]}";

            //Assert
            Assert.AreEqual(actual, expected);
        }
    }
}