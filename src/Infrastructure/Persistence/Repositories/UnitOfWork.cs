using Core.Domain.Core;
using Microsoft.EntityFrameworkCore.Storage;
using Persistence.Data.Contexts;
using Persistence.Extensions;
using System.Data;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BaseDbContext _context;
        private IDbContextTransaction _transaction;
        private string _transactionKey;

        public UnitOfWork(BaseDbContext context)
        {
            _context = context;
        }

        public bool HasTransaction => _transaction != null;
        public IDbTransaction Transaction => HasTransaction ? _transaction.GetDbTransaction() : null;


        public async Task BeginTransactionAsync(string transactionKey)
        {
            try
            {
                _transaction ??= await _context.Database.BeginTransactionAsync();

                if (string.IsNullOrWhiteSpace(_transactionKey))
                    _transactionKey = transactionKey;
            }
            catch (Exception e)
            {
                throw e.Handle();
            }
        }

        public async Task RollbackTransactionAsync()
        {
            try
            {
                await _transaction.RollbackAsync();
            }
            catch (Exception e)
            {
                throw e.Handle();
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                var result = await _context.SaveChangesAsync();

                _context.DetachedAll();

                return result;
            }
            catch (Exception e)
            {
                throw e.Handle();
            }
        }

        public async Task TransactionCommitAsync(string transactionKey)
        {
            try
            {
                if (transactionKey != _transactionKey) return;

                await SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            catch (Exception e)
            {
                throw e.Handle();
            }
        }
    }
}
