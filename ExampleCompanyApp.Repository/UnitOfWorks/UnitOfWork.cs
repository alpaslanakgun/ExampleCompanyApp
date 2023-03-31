using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleCompanyApp.Core.UnitOfWorks;
using Microsoft.Data.SqlClient;

namespace ExampleCompanyApp.Repository.UnitOfWorks
{
    public class UnitOfWork:IUnitOfWork
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
