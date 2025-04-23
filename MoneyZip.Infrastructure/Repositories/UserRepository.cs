using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoneyZip.Infrastructure.Data;
using MoneyZip.Infrastructure.Interfaces;
using MoneyZip.Domain;

namespace MoneyZip.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly MoneyZipDbContext _context;
    private readonly ILogger<UserRepository> _logger;

    public UserRepository(MoneyZipDbContext context, ILogger<UserRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        _logger.LogInformation("Getting user by ID: {Id}", id);
        return await _context.Users
            .Include(u => u.Wallet)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        _logger.LogInformation("Getting user by email: {Email}", email);
        return await _context.Users
            .Include(u => u.Wallet)
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Users
            .Include(u => u.Wallet)
            .ToListAsync();
    }

    public async Task<User> SaveAsync(User user)
    {
        _logger.LogInformation("Saving user: {Email}", user.Email);
        user.CreatedAt = DateTime.UtcNow;
        user.UpdatedAt = DateTime.UtcNow;

        await _context.Users.AddAsync(user);
        try
        {
            await _context.SaveChangesAsync();
            _logger.LogInformation("User saved successfully: {Email}", user.Email);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error saving user: {Email}", user.Email);
            throw;
        }

        return user;
    }

    public async Task<User> UpdateAsync(User user)
    {
        _logger.LogInformation("Updating user: {Email}", user.Email);
        user.UpdatedAt = DateTime.UtcNow;

        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task DeleteAsync(int id)
    {
        _logger.LogInformation("Deleting user with ID: {Id}", id);
        var user = await GetByIdAsync(id);
        if (user == null)
            throw new InvalidOperationException("User not found");

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}