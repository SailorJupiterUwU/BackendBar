using BackendBar.Models;

namespace BackendBar.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> getAllUsers();
        Task addUser(User user);
        Task<User?> userById(int id);
        Task<bool> deleteUserById(int id);
        Task<User?> updateUserById(User user);
    }
}