using Autofac;
using ExaminationSystem.Domain.Repositories.contract;
using ExaminationSystem.Domain.Services.contract;
using ExaminationSystem.Infrastructure.Data;
using ExaminationSystem.Infrastructure.Repos;

namespace ExaminationSystem.API
{
    public class AutofacModule:Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(UserRepository<>)).As(typeof(IUserRepository<>)).InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(ICourseService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(ICourseStudentService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(ICourseInstructorService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();

            
        }

    }
}
