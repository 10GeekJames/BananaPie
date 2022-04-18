using Autofac;

namespace BananaPie.Core
{
    public class BananaPieUsersCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           
            //builder.RegisterType<ILogger>().As<Serilog.ILogger>().InstancePerLifetimeScope();
            /* builder.RegisterType<ToDoItemSearchService>()
                .As<IToDoItemSearchService>().InstancePerLifetimeScope(); */
        }
    }
}
