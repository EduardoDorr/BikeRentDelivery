using Microsoft.EntityFrameworkCore;

using BikeRentDelivery.Common.Models.Pagination;
using BikeRentDelivery.Domain.Users;
using BikeRentDelivery.Infrastructure.Persistence.Contexts;

namespace BikeRentDelivery.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly BikeRentDeliveryDbContext _dbContext;

    public UserRepository(BikeRentDeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PaginationResult<User>> GetAllAsync(int page = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var users = _dbContext.Users.AsQueryable();

        return await users.GetPaged(page, pageSize, cancellationToken);
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users
            .Include(c => c.Rentals)
            .Include(c => c.Notifications)
            .SingleOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public async Task<User?> GetByEmailAndPasswordAsync(string email, string passwordHash, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users.SingleOrDefaultAsync(u => u.Email.Address == email && u.Password.Content == passwordHash);
    }

    public async Task<bool> IsUniqueAsync(string cnpj, string cnh, string email, CancellationToken cancellationToken = default)
    {
        var hasUser =await _dbContext.Users
            .AnyAsync(u => u.Cnpj.Number == cnpj || u.Cnh.Number == cnh|| u.Email.Address == email);

        return !hasUser;
    }

    public void Create(User user)
    {
        _dbContext.Users.Add(user);
    }

    public void Update(User user)
    {
        _dbContext.Users.Update(user);
    }
}