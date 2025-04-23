using MoneyZip.Domain;

namespace MoneyZip.Repositories;

public interface IWalletRepository
{
    Task<Wallet> GetByGuidAsync(Guid walletId);
    Task<Wallet> SaveAsync(Guid walletId);
    Task<Wallet> UpdateAsync(Wallet wallet);
}