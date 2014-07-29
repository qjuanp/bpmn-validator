using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using Q.BPMN.Validator.Handlers;
using Q.BPMN.Validator.Contexts;
using System.Xml.Linq;

namespace Q.BPMN.Validator.Test
{
    [TestClass]
    public class XpdlValidatorTest
    {
        XDocument document = null;
        IUnityContainer container;
        [TestInitialize]
        public void Build_Dependencies()
        {
            container = new UnityContainer();

            // Build Chain of Responsability objects
            container
                     .RegisterType<Validation,Style0104>("Style0104",
                                new InjectionConstructor(new InjectionParameter<Validation>(null))
                            )
                     .RegisterType<Validation, Style0115>("root",
                                new InjectionConstructor(new ResolvedParameter<Validation>("Style0104"))
                            );


            container.RegisterType<XdplValidator>(new InjectionConstructor(
                    new ResolvedParameter<Validation>("root")
                ));
            
            document = XDocument.Load(@"..\..\..\..\..\test\inputs\Sample.xpdl");
        }

        [TestMethod]
        public void Build_Validation_Chain()
        {
            Validation validation = container.Resolve<Validation>("root");
            Assert.IsNotNull(validation);
        }

        [TestMethod]
        public void Build_Validator()
        {
            XdplValidator validator = container.Resolve<XdplValidator>();
            Assert.IsNotNull(validator);
        }

        [TestMethod]
        public void Excecute_validation_without_errors()
        {
            ValidationContext context = null;
            XdplValidator validator = container.Resolve<XdplValidator>();

            context = validator.Validate("test.test", document);

            Assert.IsNotNull(context);
        }
    }
}
