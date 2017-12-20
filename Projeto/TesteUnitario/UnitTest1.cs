using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projeto;

namespace TesteUnitario
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var controller = GetPrincipalController(new InMemoryContactRepository());
            var proj


            // Act
            ViewResult result = controller.Index();
            // Assert
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
