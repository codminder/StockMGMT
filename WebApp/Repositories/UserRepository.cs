using WebApp.Interfaces.Repositories;
using WebApp.Models;

namespace WebAppnt.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    public User? GetByEmail(string email)
    {
        return _context.Users.SingleOrDefault(x => x.Email == email);
    }

    public User? GetById(int id)
    {
        return _context.Users.SingleOrDefault(x => x.Id == id);
    }

    public User CreateUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    public void UpdateUser(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var userToBeDeleted = GetById(id);
        if (userToBeDeleted != null)
        {
            _context.Users.Remove(userToBeDeleted);
            _context.SaveChanges();
        }
    }
}