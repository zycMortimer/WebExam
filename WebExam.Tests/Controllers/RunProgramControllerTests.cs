using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebExam.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebExam.Controllers.Tests
{
    [TestClass()]
    public class RunProgramControllerTests
    {
        [TestMethod()]
        public void FtoCTest()
        {
            // Arrange
            RunProgramController controller = new RunProgramController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            var result1 = controller.FtoC(null) as ContentResult;
            var result2 = controller.FtoC("2") as ContentResult;
            var result3 = controller.FtoC("A") as ContentResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result1, typeof(ContentResult));
            Assert.IsInstanceOfType(result2, typeof(ContentResult));
            Assert.IsInstanceOfType(result3, typeof(ContentResult));
        }
    }
}