using BackendBar.Interfaces;
using BackendBar.Models;
namespace BackendBar.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly List<User> _users;

        public UserRepository()
        {
            _users = new List<User>
            {
                new User { Id = 1, Name = "Oskalin Fake", Phone = "0960000222", Email = "oskar.fake@epn.edu.ec" },
                new User { Id = 2, Name = "Jhoel Fake", Phone = "0960000222", Email = "jhoel.fake@epn.edu.ec" },
                new User { Id = 3, Name = "Daniel Real", Phone = "0958872515", Email = "daniel.real@epn.edu.ec" },
            };
        }

        public List<User> getAllUsers()
        {
            return _users;
        }

        public void addUser(User user)
        {
            _users.Add(user);
        }

        public User userById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public bool deleteUserById(int id)
        {
            User user = userById(id);
            if (user != null)
            {
                _users.Remove(user);
                return true;
            }
            return false;
        }

        public User updateUserById(User user)
        {
            User _user = userById(user.Id);
            if (_user != null)
            {
                _user.Name = user.Name;
                _user.Phone = user.Phone;
                _user.Email = user.Email;
                return _user;
            }
            return null;
        }

    }
}
