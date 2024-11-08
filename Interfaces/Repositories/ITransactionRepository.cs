using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CinemaApp.Models;

namespace CinemaApp.Interfaces.Repositories
{
    public interface ITransactionRepository
    {
        public Task<AsyncVoidMethodBuilder> CreateAsync(Transaction transaction);
    }
}
