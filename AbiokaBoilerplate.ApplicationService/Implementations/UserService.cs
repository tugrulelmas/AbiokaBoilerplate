﻿using AbiokaBoilerplate.ApplicationService.Abstractions;
using AbiokaBoilerplate.ApplicationService.DTOs;
using AbiokaBoilerplate.ApplicationService.Messaging;
using AbiokaBoilerplate.Domain;
using AbiokaBoilerplate.Domain.Repositories;
using AbiokaBoilerplate.Infrastructure.Common.Authentication;
using AbiokaBoilerplate.Infrastructure.Common.Helper;
using System;
using System.Collections.Generic;
using AbiokaBoilerplate.Infrastructure.Common.Domain;

namespace AbiokaBoilerplate.ApplicationService.Implementations
{
    public class UserService : ReadService<User, UserDTO>, IUserService
    {
        private readonly IUserSecurityRepository userSecurityRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IAbiokaToken abiokaToken;
        private readonly ICurrentContext currentContext;

        public UserService(IUserRepository repository, IUserSecurityRepository userSecurityRepository, IRoleRepository roleRepository, IAbiokaToken abiokaToken, ICurrentContext currentContext, IDTOMapper dtoMapper)
            : base(repository, dtoMapper) {
            this.userSecurityRepository = userSecurityRepository;
            this.roleRepository = roleRepository;
            this.abiokaToken = abiokaToken;
            this.currentContext = currentContext;
        }

        public AddUserResponse Add(AddUserRequest request) {
            var roles = dtoMapper.ToDomainObjects<Role>(request.Roles);
            var userSecurity = new UserSecurity (
                Guid.Empty,
                request.Email,
                AuthProvider.Local,
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                string.Empty,
                request.Password,
                request.Language ?? currentContext.Current.Principal.Language,
                request.Name,
                request.Surname,
                request.Picture,
                request.Gender,
                false,
                roles
            );

            userSecurityRepository.Add(userSecurity);

            return new AddUserResponse {
                Email = userSecurity.Email,
                Id = userSecurity.Id,
                Roles = request.Roles
            };
        }

        public AddUserResponse Register(RegisterUserRequest request) {
            var userRole = roleRepository.GetByName("User");
            request.Roles = new List<RoleDTO> { new RoleDTO { Id = userRole.Id, Name = userRole.Name } };

            return Add(request);
        }

        public void Update(UserDTO entity) {
            var dbUser = GetEntity(entity.Id);
            var user = dtoMapper.ToDomainObject<User>(entity);
            dbUser.Update(user);
            repository.Update(dbUser);
        }

        public void Delete(Guid id) {
            var entity = GetEntity(id);
            repository.Delete(entity);
        }

        public int Count() => ((IUserRepository)repository).Count();

        public string ChangePassword(ChangePasswordRequest request) {
            var user = userSecurityRepository.FindById(currentContext.Current.Principal.Id);
            user.ChangePassword(request.OldPassword, request.NewPassword);
            user.CreateToken(abiokaToken, Guid.NewGuid().ToString());
            userSecurityRepository.Update(user);

            return user.Token;
        }

        public void ChangeLanguage(string language) {
            var user = repository.FindById(currentContext.Current.Principal.Id);
            user.ChangeLanguage(language);
            repository.Update(user);
        }
    }
}
