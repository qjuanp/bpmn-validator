using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;
using Q.BPMN.Validator.Contexts;
using Q.BPMN.Validator.Handlers;

namespace Q.BPMN.Validator.Test.Handlers
{
    [TestClass]
    public class BPMN0102Test
    {
        XDocument documentSample2 = null;
        ValidationContext contextSample2 = null;

        XDocument documentSample = null;
        ValidationContext contextSample = null;

        [TestInitialize]
        public void LoadXDocument()
        {
            documentSample2 = XDocument.Load(@"..\..\..\..\..\test\inputs\Sample 2.xpdl");
            contextSample2 = new ValidationContext("Sample4.xpdl", documentSample2);

            documentSample = XDocument.Load(@"..\..\..\..\..\test\inputs\Sample.xpdl");
            contextSample = new ValidationContext("Sample.xpdl", documentSample);
        }


        [TestMethod]
        public void Test_Sample2_With_Errors()
        {
            BPMN0102 validation = new BPMN0102(null);

            validation.Validate(contextSample2);

            Assert.IsFalse(contextSample2.IsValid);
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
