using MoneyZip.Domain;
using MoneyZip.Repositories;

namespace MoneyZip.UseCases;

public class CreateWalletUseCase
{
    private readonly IWalletRepository _walletRepository;
    
    public CreateWalletUseCase(IWalletRepository walletRepository)
    {
        _walletRepository = walletRepository;
    }
}