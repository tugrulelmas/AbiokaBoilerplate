using AbiokaBoilerplate.Infrastructure.Common.Domain;

namespace AbiokaBoilerplate.Domain.Repositories
{
    public interface ILoginAttemptRepository : IReadOnlyRepository<LoginAttempt>
    {
        /// <summary>
        /// Adds the specified login attempt.
        /// </summary>
        /// <param name="loginAttempt">The login attempt.</param>
        void Add(LoginAttempt loginAttempt);
    }
}
