using APIService.DataAccessRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Internals;

namespace APIService.Controllers.Tests
{
    [TestClass()]
    public class APIServiceControllerTests
    {
        [TestMethod()]
        public void ReadJsonFromFileTest_ShouldHaveAllThreeElementsReversed()
        {
            //Pre requisites
            Mock<IDataAccessRepository> _mock = new Mock<IDataAccessRepository>();
            _mock.Setup(m => m.LoadJsonFromFile("A-A-A")).Returns("{\"data\":[\"Fiat\",\"BMW\",\"Ford\"]}");
            APIServiceController _controllerTest = new APIServiceController(_mock.Object);

            //Act
            var actual = _controllerTest.ReadJsonFromFile("A-A-A");
            var expected = "{\"data\":[\"Fiat\",\"BMW\",\"Ford\"]}";

            //Assert
            Assert.AreEqual(actual, expected);

        }

        [TestMethod()]
        public void ReadJsonFromFileTest_ShouldHaveFirstTwoElementsReversed()
        {
            //Pre requisites
            Mock<IDataAccessRepository> _mock = new Mock<IDataAccessRepository>();
            _mock.Setup(m => m.LoadJsonFromFile("A-A")).Returns("{\"data\":[\"BMW\",\"Ford\",\"Fiat\"]}");
            APIServiceController _controllerTest = new APIServiceController(_mock.Object);

            //Act
            var actual = _controllerTest.ReadJsonFromFile("A-A-A");
            var expected = "{\"data\":[\"BMW\",\"Ford\",\"Fiat\"]}";

            //Assert
            Assert.AreEqual(actual, expected);

        }

        [TestMethod()]
        public void ReadJsonFromFileTest_ShouldHaveOriginalData()
        {
            //Pre requisites
            Mock<IDataAccessRepository> _mock = new Mock<IDataAccessRepository>();
            _mock.Setup(m => m.LoadJsonFromFile("A*A")).Returns("{\"data\":[\"Ford\",\"BMW\",\"Fiat\"]}");
            APIServiceController _controllerTest = new APIServiceController(_mock.Object);

            //Act
            var actual = _controllerTest.ReadJsonFromFile("A-A-A");
            var expected = "{\"data\":[\"Ford\",\"BMW\",\"Fiat\"]}";

            //Assert
            Assert.AreEqual(actual, expected);

        }

        [TestMethod()]
        public void ReadJsonFromFileTest_ShouldHaveOriginalDataWIthAnyOtherInput()
        {
            //Pre requisites
            Mock<IDataAccessRepository> _mock = new Mock<IDataAccessRepository>();
            _mock.Setup(m => m.LoadJsonFromFile("Input")).Returns("{\"data\":[\"Ford\",\"BMW\",\"Fiat\"]}");
            APIServiceController _controllerTest = new APIServiceController(_mock.Object);

            //Act
            var actual = _controllerTest.ReadJsonFromFile("A-A-A");
            var expected = "{\"data\":[\"Ford\",\"BMW\",\"Fiat\"]}";

            //Assert
            Assert.AreEqual(actual, expected);

        }
    }
}