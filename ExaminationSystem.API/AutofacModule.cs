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
            builder.RegisterAssemblyTypes(typeof(IChoiceService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<ChoiceService>().As<IChoiceService>().InstancePerLifetimeScope();
            builder.RegisterType<ChoiceMediator>().As<IChoiceMediator>().InstancePerLifetimeScope();

            builder.RegisterType<DepartmentService>().As<IDepartmentService>().InstancePerLifetimeScope();
            builder.RegisterType<DepartmentMediator>().As<IDepartmentMediator>().InstancePerLifetimeScope();

            builder.RegisterType<AuthService>().As<IAuthService>().InstancePerLifetimeScope();
            builder.RegisterType<AuthMediator>().As<IAuthMediator>().InstancePerLifetimeScope();

            builder.RegisterType<CourseService>().As<ICourseService>().InstancePerLifetimeScope();
            builder.RegisterType<CourseInstructorService>().As<ICourseInstructorService>().InstancePerLifetimeScope();
            builder.RegisterType<CourseStudentService>().As<ICourseStudentService>().InstancePerLifetimeScope();
            builder.RegisterType<CourseMediator>().As<ICourseMediator>().InstancePerLifetimeScope();


            builder.RegisterType<ExamService>().As<IExamService>().InstancePerLifetimeScope();
            builder.RegisterType<ExamQuestionService>().As<IExamQuestionService>().InstancePerLifetimeScope();
            builder.RegisterType<ExamStudentService>().As<IExamStudentService>().InstancePerLifetimeScope();
            builder.RegisterType<ExamMediator>().As<IExamMediator>().InstancePerLifetimeScope();


            builder.RegisterType<QuestionService>().As<IQuestionService>().InstancePerLifetimeScope();
            builder.RegisterType<QuestionMediator>().As<IQuestionMediator>().InstancePerLifetimeScope();


            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfiles>();
            }).CreateMapper()).As<IMapper>().InstancePerLifetimeScope();

            
        }

    }
}
