using MoneyZip.Domain;

namespace MoneyZip.Infrastructure.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetByEmailAsync(string email);
    Task<User> SaveAsync(User user);
    Task<User?> UpdateAsync(User? user);
    Task DeleteAsync(int id);
    Task<List<User>> GetAllAsync();
}