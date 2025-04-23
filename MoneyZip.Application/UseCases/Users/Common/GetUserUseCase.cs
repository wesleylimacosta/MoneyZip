using MoneyZip.Domain;
using MoneyZip.Infrastructure.Interfaces;

namespace MoneyZip.Application.UseCases.Users;

public class GetUserUseCase
{
    private readonly IUserRepository _userRepository;

    public GetUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> ExecuteAsync(int id)
    {
        return await _userRepository.GetByIdAsync(id);
    }
}