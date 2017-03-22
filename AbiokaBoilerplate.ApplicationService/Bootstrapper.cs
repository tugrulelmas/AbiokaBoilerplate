using AbiokaBoilerplate.ApplicationService.Abstractions;
using AbiokaBoilerplate.ApplicationService.DTOs;
using AbiokaBoilerplate.ApplicationService.Implementations;
using AbiokaBoilerplate.ApplicationService.Interceptors;
using AbiokaBoilerplate.ApplicationService.Messaging;
using AbiokaBoilerplate.ApplicationService.Validation;
using AbiokaBoilerplate.Domain;
using AbiokaBoilerplate.Infrastructure.Common.IoC;

namespace AbiokaBoilerplate.ApplicationService
{
    public class Bootstrapper
    {
        public static void Initialise() {
            Data.Bootstrapper.Initialise();
            DependencyContainer.Container
                .RegisterServices<IService, IService>()
                //.RegisterService<ICrudService<RoleDTO>, CrudService<Role, RoleDTO>>()
                //.RegisterService<IReadService<LoginAttemptDTO>, ReadService<LoginAttempt, LoginAttemptDTO>>()
                // TODO: uncomment
                //.RegisterWithBase(typeof(ICustomValidator<>), typeof(CustomValidator<>))
                .Register<ICustomValidator<RegisterUserRequest>, AddUserRequestValidator>()
                //.RegisterWithBase(typeof(IEventHandler<>), typeof(RoleAddedToUserHandler))
                .Register<IServiceInterceptor, RoleValidationInterceptor>()
                .Register<IServiceInterceptor, DataValidationInterceptor>()
                .Register<IHttpClient, CustomHttpClient>(isFallback: true)
                .Register<IDTOMapper, DTOMapper>(isFallback: true)
                //.Register<IUserService, UserService_>()
                ;
        }
    }
}
