// using System.Transactions;
// using MoneyZip.Domain;
// using MoneyZip.Repositories;
// using MoneyZip.Services;
// using MoneyZip.UseCases;
// using Moq;
// using Xunit;
//
// namespace MoneyZip.Tests;
//
// public class MoneyTransferTests
// {
//     private readonly Mock<Authorizer> _authorizerMock = new();
//     private readonly Mock<Notifier> _notifierMock = new();
//     private readonly Mock<ITransactionRepository> _transactionRepositoryMock = new();
//     private readonly Mock<IWalletRepository> _walletRepositoryMock = new();
//     private readonly MoneyTransferUseCase _moneyTransferUseCase;
//
//     public MoneyTransferTests()
//     {
//         _moneyTransferUseCase = new MoneyTransferUseCase(
//             _transactionRepositoryMock.Object,
//             _walletRepositoryMock.Object,
//             _authorizerMock.Object,
//             _notifierMock.Object);
//     }
//
//     [Fact]
//     public async Task ExecuteAsync_Should_TransferMoney_And_UpdateBalances_When_Authorized()
//     {
//         // Arrange
//         var payerWallet = new Wallet { Id = Guid.NewGuid(), UserId = 1, Balance = 100m };
//         var payeeWallet = new Wallet { Id = Guid.NewGuid(), UserId = 2, Balance = 100m };
//         decimal transferAmount = 40m;
//
//         // Configura os mocks
//         _walletRepositoryMock.Setup(x => x.GetByGuidAsync(payerWallet.Id)).ReturnsAsync(payerWallet);
//         _walletRepositoryMock.Setup(x => x.GetByGuidAsync(payeeWallet.Id)).ReturnsAsync(payeeWallet);
//         _authorizerMock.Setup(x => x.Authorize()).Returns(true);
//         _notifierMock.Setup(x => x.Notify(It.IsAny<string>())).Verifiable();
//
//         // Act
//         await _moneyTransferUseCase.ExecuteAsync(payerWallet.Id, payeeWallet.Id, transferAmount);
//
//         // Assert
//         // Verifica se a transação foi criada
//         _transactionRepositoryMock.Verify(
//             x => x.SaveAsync(It.Is<MoneyTransaction>(
//                 t => t.PayerWalletId == payerWallet.Id &&
//                      t.PayeeWalletId == payeeWallet.Id &&
//                      t.Amount == transferAmount)),
//             Times.Once());
//         // Verifica se os saldos foram atualizados
//         _walletRepositoryMock.Verify(
//             x => x.UpdateAsync(It.Is<Wallet>(
//                 w => w.Id == payerWallet.Id && w.Balance == 60m)),
//             Times.Once());
//
//         _walletRepositoryMock.Verify(
//             x => x.UpdateAsync(It.Is<Wallet>(
//                 w => w.Id == payeeWallet.Id && w.Balance == 140m)),
//             Times.Once());
//
//         // Verifica se a notificação foi enviada
//         _notifierMock.Verify(
//             x => x.Notify(It.Is<string>(msg => msg == "Transaction completed successfully")),
//             Times.Once());
//     }
//
// }