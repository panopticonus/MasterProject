namespace MasterProject.Web.App_Start
{
    using Autofac;
    using Autofac.Integration.Mvc;
    using Core;
    using Core.Interfaces.Managers;
    using Manager;
    using Persistence;
    using System.Web.Mvc;

    public class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<HospitalContext>().As<IHospitalContext>();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterAssemblyTypes(typeof(HospitalContext).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
            builder.RegisterType<HomeManager>().As<IHomeManager>().SingleInstance();
            builder.RegisterType<PatientManager>().As<IPatientManager>().SingleInstance();
            builder.RegisterFilterProvider();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}