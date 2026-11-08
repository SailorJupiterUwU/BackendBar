using BackendBar.Models;

namespace BackendBar.Interfaces
{
    public interface IUserRepository
    {
        public List<User> getAllUsers();
        public void addUser(User user);
        public User userById(int id);
        public bool deleteUserById(int id);
        public User updateUserById(User user);
    }
}
