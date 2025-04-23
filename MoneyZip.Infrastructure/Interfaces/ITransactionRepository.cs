using System.Transactions;
using MoneyZip.Domain;

namespace MoneyZip.Repositories;

public interface ITransactionRepository
{
    Task<MoneyTransaction> GetByIdAsync(Guid id);
    Task<MoneyTransaction> Verify(Guid id);
    Task SaveAsync(MoneyTransaction moneyTransaction);    
}