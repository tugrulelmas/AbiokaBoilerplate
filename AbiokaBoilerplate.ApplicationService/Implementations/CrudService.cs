using AbiokaBoilerplate.ApplicationService.Abstractions;
using AbiokaBoilerplate.ApplicationService.DTOs;
using AbiokaBoilerplate.Infrastructure.Common.Domain;
using System;

namespace AbiokaBoilerplate.ApplicationService.Implementations
{
    public class CrudService<TEntity, TDTO> : ReadService<TEntity, TDTO>, ICrudService<TDTO> where TEntity : class, IEntity where TDTO : DTO
    {
        public CrudService(IRepository<TEntity> repository, IDTOMapper dtoMapper)
            : base(repository, dtoMapper) {
        }

        public virtual void Add(TDTO entity) {
            var domainEntity = (TEntity)dtoMapper.ToDomainObject(entity);
            repository.Add(domainEntity);

            if (domainEntity is IIdEntity<Guid>) {
                entity.Id = ((IIdEntity<Guid>)domainEntity).Id;
            }
        }

        public virtual void Delete(object id) {
            var entity = GetEntity(id);
            repository.Delete(entity);
        }

        public virtual void Update(TDTO entity) {
            var domainEntity = (TEntity)dtoMapper.ToDomainObject(entity);
            repository.Update(domainEntity);
        }
    }
}
