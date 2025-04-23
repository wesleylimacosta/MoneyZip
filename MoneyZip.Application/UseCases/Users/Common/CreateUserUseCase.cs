using MoneyZip.Domain;
using MoneyZip.Application.Models;
using MoneyZip.Infrastructure.Interfaces;

namespace MoneyZip.Application.UseCases.Common;

public class CreateUserUseCase
{
    private readonly IUserRepository _userRepository;

    public CreateUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> ExecuteAsync(CreateUserRequest request)
    {
        // Log para depuração
        Console.WriteLine($"UserType recebido: {request.UserType}");

        // Validar o request
        if (string.IsNullOrEmpty(request.UserType))
            throw new ArgumentException("UserType is required.");

        if (string.IsNullOrEmpty(request.Email))
            throw new ArgumentException("Email is required.");

        if (string.IsNullOrEmpty(request.Name))
            throw new ArgumentException("Name is required.");

        if (string.IsNullOrEmpty(request.Password))
            throw new ArgumentException("Password is required.");

        if (request.UserType == "CommonUser" && string.IsNullOrEmpty(request.CPF))
            throw new ArgumentException("CPF is required for CommonUser.");

        if (request.UserType == "MerchantUser" && string.IsNullOrEmpty(request.CNPJ))
            throw new ArgumentException("CNPJ is required for MerchantUser.");

        // Verificar se o e-mail já está em uso
        var existingUser = await _userRepository.GetByEmailAsync(request.Email);
        if (existingUser != null)
            throw new InvalidOperationException("Email is already in use");

        // Criar o usuário com base no tipo
        User user;
        if (request.UserType == "CommonUser")
        {
            user = new CommonUser
            {
                Email = request.Email,
                CPF = request.CPF!,
                Name = request.Name
            };
            user.Wallet = new Wallet
            {
                Id = Guid.NewGuid(),
                Balance = 0,
                Type = WalletType.Common
            };
        }
        else if (request.UserType == "MerchantUser")
        {
            user = new MerchantUser
            {
                Email = request.Email,
                CNPJ = request.CNPJ!,
                Name = request.Name
            };
            user.Wallet = new Wallet
            {
                Id = Guid.NewGuid(),
                Balance = 0,
                Type = WalletType.Merchant
            };
        }
        else
        {
            throw new ArgumentException("Invalid user type. Must be 'CommonUser' or 'MerchantUser'.");
        }

        user.SetPassword(request.Password);

        return await _userRepository.SaveAsync(user);
    }
}