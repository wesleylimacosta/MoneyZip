using MoneyZip.Domain;
using MoneyZip.Infrastructure.Interfaces;
using MoneyZip.Repositories;

namespace MoneyZip.Application.UseCases.Common;

public class ListUsersUseCase
{
    private readonly IUserRepository _userRepository;

    public ListUsersUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<User>> ExecuteAsync()
    {
        return await _userRepository.GetAllAsync();
    }
}