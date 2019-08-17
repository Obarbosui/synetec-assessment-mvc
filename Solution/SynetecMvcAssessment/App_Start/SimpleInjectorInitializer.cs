[assembly: WebActivator.PostApplicationStartMethod(typeof(InterviewTestTemplatev2.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace InterviewTestTemplatev2.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;
    using InterviewTestTemplatev2.Data;
    using InterviewTestTemplatev2.Helpers.Controllers;
    using InterviewTestTemplatev2.Repositories;
    using InterviewTestTemplatev2.Services;
    using InterviewTestTemplatev2.Services.Repostiories;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            var lifestyle = Lifestyle.Scoped;
            
            InitializeContainer(container, lifestyle);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container, Lifestyle lifestyle)
        {
            //register dbcontext
            container.Register<MvcInterviewV3Entities1>(() => new MvcInterviewV3Entities1(), Lifestyle.Singleton);

            //register repositories
            container.Register<IHrEmployeesRepository, HrEmployeesRepository>(lifestyle);
            container.Register<IHrDepartmentRepository, HrDepartmentRepository>(lifestyle);

            //register services
            container.Register<IHrEmployeesService, HrEmployeesService>(lifestyle);
            container.Register<IHrDepartmentService, HrDepartmentService>(lifestyle);
            container.Register<IBonusPoolService, BonusPoolService>(lifestyle);

            //register helpers
            container.Register<IBonusPoolControllerHelper, BonusPoolControllerHelper>(lifestyle);
        }
    }
}