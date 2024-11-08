using System.Runtime.CompilerServices;
using CinemaApp.Infrastructures.Database;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Models;

namespace CinemaApp.Repositories
{
    public class TransactionRepository(ApplicationDBContext applicationDBContext) : ITransactionRepository
    {
        private readonly ApplicationDBContext _applicationDBContext = applicationDBContext;

        public async Task<AsyncVoidMethodBuilder> CreateAsync(Transaction transaction)
        {
            await _applicationDBContext.Transactions.AddAsync(transaction);
            await _applicationDBContext.SaveChangesAsync();

            return AsyncVoidMethodBuilder.Create();
        }
    }
}
