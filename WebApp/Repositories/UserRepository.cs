using WebApp.Interfaces.Repositories;
using WebApp.Models;

namespace WebApp.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    public User? Get(string email)
    {
        return _context.Users.SingleOrDefault(x => x.Email == email);
    }

    public User? Get(int id)
    {
        return _context.Users.SingleOrDefault(x => x.Id == id);
    }

    public User Create(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var userToBeDeleted = Get(id);
        if (userToBeDeleted != null)
        {
            _context.Users.Remove(userToBeDeleted);
            _context.SaveChanges();
        }
    }
}