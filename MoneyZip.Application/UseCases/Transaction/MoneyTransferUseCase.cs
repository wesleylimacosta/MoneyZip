// using MoneyZip.Domain;
// using MoneyZip.Infrastructure.Interfaces;
// using MoneyZip.Application.Services;
// using MoneyZip.Repositories;
//
// namespace MoneyZip.Application.UseCases;
//
// public class MoneyTransferUseCase
// {
//     private readonly IWalletRepository _walletRepository;
//     private readonly ITransactionRepository _transactionRepository;
//     private readonly IAuthorizer _authorizer;
//     private readonly INotifier _notifier;
//
//     public MoneyTransferUseCase(
//         IWalletRepository walletRepository,
//         ITransactionRepository transactionRepository,
//         IAuthorizer authorizer,
//         INotifier notifier)
//     {
//         _walletRepository = walletRepository;
//         _transactionRepository = transactionRepository;
//         _authorizer = authorizer;
//         _notifier = notifier;
//     }
//
//     public async Task<MoneyTransaction> ExecuteAsync(Guid payerWalletId, Guid payeeWalletId, decimal amount)
//     {
//         var payerWallet = await _walletRepository.GetByIdAsync(payerWalletId);
//         if (payerWallet == null)
//             throw new InvalidOperationException("Payer wallet not found");
//
//         var payeeWallet = await _walletRepository.GetByIdAsync(payeeWalletId);
//         if (payeeWallet == null)
//             throw new InvalidOperationException("Payee wallet not found");
//
//         if (payerWallet.Balance < amount)
//             throw new InvalidOperationException("Insufficient balance");
//
//         if (amount <= 0)
//             throw new InvalidOperationException("Amount must be greater than zero");
//
//         bool isAuthorized = await _authorizer.AuthorizeAsync();
//         if (!isAuthorized)
//             throw new InvalidOperationException("Transaction not authorized");
//
//         payerWallet.Balance -= amount;
//         payeeWallet.Balance += amount;
//
//         await _walletRepository.UpdateAsync(payerWallet);
//         await _walletRepository.UpdateAsync(payeeWallet);
//
//         var transaction = new MoneyTransaction
//         {
//             Id = Guid.NewGuid(),
//             PayerWalletId = payerWalletId,
//             PayeeWalletId = payeeWalletId,
//             Amount = amount,
//             ProcessedAt = DateTime.UtcNow
//         };
//
//         await _transactionRepository.SaveAsync(transaction);
//
//         await _notifier.NotifyAsync("Transaction completed successfully");
//
//         return transaction;
//     }
// }