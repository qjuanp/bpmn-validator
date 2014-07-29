using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;
using Q.BPMN.Validator.Models;
using System.Diagnostics;

namespace Q.BPMN.Validator.Test
{
    [TestClass]
    public class ProcessModelTest
    {

        XDocument document = null;
        [TestInitialize]
        public void LoadXDocument()
        {
            document = XDocument.Load(@"..\..\..\..\..\test\inputs\Sample.xpdl");
        }

        [TestMethod]
        public void Load_ProcessModel()
        {
            ProcessModel model = new ProcessModel(document);

            Assert.IsNotNull(model);
        }


        [TestMethod]
        public void Load_ProcessModel_Basic_Data()
        {
            ProcessModel model = new ProcessModel(document);

            Debug.WriteLine(model.ToString());

            Assert.IsTrue(
                        model != null &&
                        !string.IsNullOrEmpty(model.Name) &&
                        !string.IsNullOrEmpty(model.Description) &&
                        !string.IsNullOrEmpty(model.XPDLVersion) &&
                        !string.IsNullOrEmpty(model.Version) &&
                        model.Id != null &&
                        !string.IsNullOrEmpty(model.Author) &&
                        !string.IsNullOrEmpty(model.Contry)
                    );
        }

    }
}
