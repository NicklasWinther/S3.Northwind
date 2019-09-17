using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using S3.Northwind.Entities;

namespace S3.Northwind.ValidationWebServiceTest
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void Order_IncorrectDateThrowsException()
        {
            //Arrange
            Order order = new Order();

            //Act
            Action act = () => order.ShippedDate = DateTime.Today.AddDays(5);

            //Assert
            Assert.ThrowsException<ArgumentException>(act);
        }

    }
}
