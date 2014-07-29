using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Q.BPMN.Validator.Handlers;

namespace Q.BPMN.Validator.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // Build Chain of Responsability objects
            container
                    .RegisterType<Validation, Style0104>("Style0104",
                               new InjectionConstructor(new InjectionParameter<Validation>(null))
                           )
                    .RegisterType<Validation, Style0115>("root",
                               new InjectionConstructor(new ResolvedParameter<Validation>("Style0104"))
                           );


            container.RegisterType<XdplValidator>(new InjectionConstructor(
                    new ResolvedParameter<Validation>("root")
                ));
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}