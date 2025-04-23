using MoneyZip.Domain;
using MoneyZip.Application.Models;
using MoneyZip.Infrastructure.Interfaces;
using MoneyZip.Repositories;

namespace MoneyZip.Application.UseCases.Common;

public class UpdateUserUseCase
{
    private readonly IUserRepository _userRepository;
    
    public UpdateUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<User> ExecuteAsync(UpdateUserRequest request)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email);
        if (existingUser == null)
            throw new InvalidOperationException("User not found");
        
        return await _userRepository.UpdateAsync(existingUser);
    }

}