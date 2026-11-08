using BackendBar.Interfaces;
using BackendBar.Models;

namespace BackendBar.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;

        public UserRepository()
        {
            _users = new List<User>
            {
                new User { Id = 1, Name = "Oskalin Fake", Phone = "0960000222", Email = "oskar.fake@epn.edu.ec" },
                new User { Id = 2, Name = "Jhoel Fake", Phone = "0960000222", Email = "jhoel.fake@epn.edu.ec" },
                new User { Id = 3, Name = "Daniel Real", Phone = "0958872515", Email = "daniel.real@epn.edu.ec" },
            };
        }

        public Task<List<User>> getAllUsers()
        {
            return Task.FromResult(_users.ToList());
        }

        public Task<User?> userById(int id)
        {
            return Task.FromResult(_users.FirstOrDefault(u => u.Id == id));
        }

        public Task addUser(User user)
        {
            // En memoria no hay base de datos que genere el Id, así que lo asignamos aquí
            user.Id = _users.Any() ? _users.Max(u => u.Id) + 1 : 1;
            _users.Add(user);
            return Task.CompletedTask;
        }

        public Task<bool> deleteUserById(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return Task.FromResult(false);

            _users.Remove(user);
            return Task.FromResult(true);
        }

        public Task<User?> updateUserById(User user)
        {
            var existing = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existing == null)
                return Task.FromResult<User?>(null);

            existing.Name = user.Name;
            existing.Phone = user.Phone;
            existing.Email = user.Email;
            return Task.FromResult<User?>(existing);
        }
    }
}