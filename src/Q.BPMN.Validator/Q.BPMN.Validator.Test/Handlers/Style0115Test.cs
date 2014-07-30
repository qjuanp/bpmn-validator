using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;
using Q.BPMN.Validator.Contexts;
using Q.BPMN.Validator.Handlers;

namespace Q.BPMN.Validator.Test.Handlers
{
    [TestClass]
    public class Style0115Test
    {
        XDocument documentSample1 = null;
        ValidationContext contextSample1 = null;

        XDocument documentSample = null;
        ValidationContext contextSample = null;

        [TestInitialize]
        public void LoadXDocument()
        {
            documentSample1 = XDocument.Load(@"..\..\..\..\..\test\inputs\Sample 1.xpdl");
            contextSample1 = new ValidationContext("Sample3.xpdl", documentSample1);

            documentSample = XDocument.Load(@"..\..\..\..\..\test\inputs\Sample.xpdl");
            contextSample = new ValidationContext("Sample.xpdl", documentSample);
        }


        [TestMethod]
        public void Test_Sample3_With_Errors()
        {
            Style0115 validation = new Style0115(null);

            validation.Validate(contextSample1);

            Assert.IsFalse(contextSample1.IsValid);
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
