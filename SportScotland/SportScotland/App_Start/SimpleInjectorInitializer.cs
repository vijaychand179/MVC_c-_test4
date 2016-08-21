[assembly: WebActivator.PostApplicationStartMethod(typeof(SportScotland.SimpleInjectorInitializer), "Initialize")]

namespace SportScotland
{
    using System.Reflection;
    using System.Web.Mvc;
    using DL.SportScotland;
    using SimpleInjector;
    using SimpleInjector.Extensions;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            container.Register<IBenificiary, BenificiaryRepository>(Lifestyle.Transient);
            container.Register<IImpact, ImpactRepository>(Lifestyle.Transient);
            container.Register<IImpactRecord, ImpactRecordRepository>(Lifestyle.Transient);
            container.Register<IImpctRecordBeneficiary, ImpctRecordBeneficiaryRepository>(Lifestyle.Transient);
        }
    }
}