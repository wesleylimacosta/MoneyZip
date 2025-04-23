using MoneyZip.Domain;
using MoneyZip.Infrastructure.Interfaces;
using MoneyZip.Infrastructure.Repositories;
using MoneyZip.Repositories;

namespace MoneyZip.Application.UseCases.Common;

public class DeleteUserUseCase
{
    private readonly IUserRepository _userRepository;

    public DeleteUserUseCase(IUserRepository commonUserRepository)
    {
        _userRepository = commonUserRepository;
    }
    
    public string ExecuteAsync(int id)
    {
        var existingUser =  _userRepository.GetByIdAsync(id);
        if (existingUser == null)
            throw new InvalidOperationException("User not found");
        
        _userRepository.DeleteAsync(existingUser.Id);
        
        return "User deleted successfully";
    }
}