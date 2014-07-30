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
                    .RegisterType<Validation, BPMN0102>("BPMN0102",
                               new InjectionConstructor(new InjectionParameter<Validation>(null))
                           )
                    .RegisterType<Validation, Style0123>("Style0123",
                               new InjectionConstructor(new ResolvedParameter<Validation>("BPMN0102"))
                           )
                    .RegisterType<Validation, Style0122>("Style0122",
                               new InjectionConstructor(new ResolvedParameter<Validation>("Style0123"))
                           )
                    .RegisterType<Validation, Style0115>("Style0115",
                               new InjectionConstructor(new ResolvedParameter<Validation>("Style0122"))
                           )
                    .RegisterType<Validation, Style0104>("root",
                               new InjectionConstructor(new ResolvedParameter<Validation>("Style0115"))
                           );


            container.RegisterType<XdplValidator>(new InjectionConstructor(
                    new ResolvedParameter<Validation>("root")
                ));
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}