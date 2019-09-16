using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using S3.Northwind.ValidationWebService;

namespace S3.Northwind.ValidationWebServiceTest
{
    [TestClass]
    public class TextWebServiceTest
    {
        [TestMethod]
        public void ContainsProfanity_ReturnsTrue()
        {
            //Arrange
            bool expected = true;
            bool actual;
            string text = "ass";
            TextWebService textWebService = new TextWebService();

            //Act
            actual = textWebService.ContainsProfanity(text);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckForProfanity_ReturnsExpectedValues()
        {
            //Arrange
            (string returnText, bool containsProfanity) expected = ("***", true);
            (string returnText, bool containsProfanity) actual;
            string text = "ass";
            TextWebService textWebService = new TextWebService();

            //Act
            actual = textWebService.CheckForProfanity(text);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
