using Autofac;
using AutoMapper;
using ExaminationSystem.API.Helpers;
using ExaminationSystem.Application.Helpers;
using ExaminationSystem.Application.Mediators;
using ExaminationSystem.Application.Services;
using ExaminationSystem.Domain.Mediators.contract;
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
            //builder.RegisterAssemblyTypes(typeof(IDepartmentService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<DepartmentService>().As<IDepartmentService>().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IChoiceService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();


            builder.RegisterType<DepartmentMediator>().As<IDepartmentMediator>().InstancePerLifetimeScope();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfiles>();
            }).CreateMapper()).As<IMapper>().InstancePerLifetimeScope();

            
        }

    }
}
