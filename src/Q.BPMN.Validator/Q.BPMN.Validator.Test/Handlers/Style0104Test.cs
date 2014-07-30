using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;
using Q.BPMN.Validator.Contexts;
using Q.BPMN.Validator.Handlers;

namespace Q.BPMN.Validator.Test.Handlers
{
    [TestClass]
    public class Style0104Test
    {
        XDocument documentSample3 = null;
        ValidationContext contextSample3 = null;

        XDocument documentSample = null;
        ValidationContext contextSample = null;

        [TestInitialize]
        public void LoadXDocument()
        {
            documentSample3 = XDocument.Load(@"..\..\..\..\..\test\inputs\Sample 3.xpdl");
            contextSample3 = new ValidationContext("Sample3.xpdl", documentSample3);

            documentSample = XDocument.Load(@"..\..\..\..\..\test\inputs\Sample.xpdl");
            contextSample = new ValidationContext("Sample.xpdl", documentSample);
        }


        [TestMethod]
        public void Test_Sample3_With_Errors()
        {
            Style0104 validation = new Style0104(null);

            validation.Validate(contextSample3);

            Assert.IsFalse(contextSample3.IsValid);
        }

        [TestMethod]
        public void Test_Sample_With_No_Errors()
        {
            Style0104 validation = new Style0104(null);

            validation.Validate(contextSample);

            Assert.IsTrue(contextSample.IsValid);
        }
    }
}
