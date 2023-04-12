using ExampleCompanyApp.Core.UnitOfWorks;

namespace ExampleCompanyApp.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ExampleCompanyDbContext _context;

        public UnitOfWork(ExampleCompanyDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
