using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;
using Q.BPMN.Validator.Contexts;
using Q.BPMN.Validator.Handlers;

namespace Q.BPMN.Validator.Test.Handlers
{
    [TestClass]
    public class Style0122Test
    {
        XDocument documentSample4 = null;
        ValidationContext contextSample4 = null;

        XDocument documentSample = null;
        ValidationContext contextSample = null;

        [TestInitialize]
        public void LoadXDocument()
        {
            documentSample4 = XDocument.Load(@"..\..\..\..\..\test\inputs\Sample 4.xpdl");
            contextSample4 = new ValidationContext("Sample4.xpdl", documentSample4);

            documentSample = XDocument.Load(@"..\..\..\..\..\test\inputs\Sample.xpdl");
            contextSample = new ValidationContext("Sample.xpdl", documentSample);
        }


        [TestMethod]
        public void Test_Sample3_With_Errors()
        {
            Style0122 validation = new Style0122(null);

            validation.Validate(contextSample4);

            Assert.IsFalse(contextSample4.IsValid);
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
