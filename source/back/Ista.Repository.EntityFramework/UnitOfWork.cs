using Aeon.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Ista.Repository.EntityFramework
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly AppContext _dbContext;

        public UnitOfWork(AppContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        async Task<bool> IUnitOfWork.Commit()
        {
            return (await this._dbContext.SaveChangesAsync()) > 0;
        }

        Task IUnitOfWork.Rollback()
        {
            return Task.CompletedTask;
        }

        void IDisposable.Dispose() => this._dbContext.Dispose();
    }
}
