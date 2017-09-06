using System;
using ClassSchedule2._0.Models.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassSchedule2._0.Tests
{
    [TestClass]
    public class ClassTest
    {
        [TestMethod]
        public void CreateTest()
        {
            ClassService cs = new ClassService();

            Assert.AreEqual("Math", cs.CreateClass("Math"));
        }
    }
}
