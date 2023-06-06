using FinalTest.SharedLayer.Core.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest.SharedLayer.Data.Transaction
{
    public interface IUnitOfWork : IDisposable
    {
        int Save();
        Task<OperationResult> Commit();
        void Rollback();
        IDbContextTransaction BeginTransaction();
        Task<int> SaveAsync();
    }
}
