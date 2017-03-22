namespace AbiokaBoilerplate.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AbiokaDbContext context;

        public UnitOfWork(AbiokaDbContext context) {
            this.context = context;
        }

        public bool IsInTransaction => context.Database.CurrentTransaction != null;

        public void BeginTransaction() {
            context.Database.BeginTransaction();
        }

        public void Commit() {
            try {
                context.Database.CommitTransaction();
            } catch {
                context.Database.RollbackTransaction();
                throw;
            }
        }

        public void Rollback() {
            context.Database.RollbackTransaction();
        }
    }
}
