using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using S3.Northwind.ValidationWebService;

namespace S3.Northwind.ValidationWebServiceTest
{
    [TestClass]
    public class ExchangeRatesWebServiceTest
    {
        [TestMethod]
        public void GetCurrencies_CorrectUrl()
        {
            //Arrange
            ExchangeRatesWebService exchangeRatesWebService = new ExchangeRatesWebService();
            double actualExchangeRate;

            //Act
            actualExchangeRate = exchangeRatesWebService.GetCurrencies().Rates.DKK;

            //Assert
            Assert.IsTrue(actualExchangeRate > 0);
        }

        [TestMethod]
        public void GetCurrencies_IncorrectUrl()
        {
            //Arrange
            ExchangeRatesWebService exchangeRatesWebService = new ExchangeRatesWebService();

            //Act
            Action act = () => exchangeRatesWebService.GetCurrencies("a6h5j2kvg1v");

            //Assert
            Assert.ThrowsException<AggregateException>(act);
        }
    }
}
