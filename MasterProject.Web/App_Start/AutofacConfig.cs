namespace MasterProject.Web.App_Start
{
    using System.Web.Mvc;
    using Autofac;
    using Autofac.Integration.Mvc;
    using Core;
    using Persistence;

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
            builder.RegisterFilterProvider();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}