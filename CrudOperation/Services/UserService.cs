using CrudOperation.Models.Domain;
using Newtonsoft.Json;

namespace CrudOperation.Services
{
    public class UserService
    {
        private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files", "users.json");

        public List<User> GetAllUsers()
        {
            var users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(_filePath));
            return users ?? new List<User>();
        }

        public User GetUserById(int id)
        {
            var users = GetAllUsers();
            return users.FirstOrDefault(u => u.Id == id);
        }

        public void AddUser(User user)
        {
            var users = GetAllUsers();
            user.Id = users.Any() ? users.Max(u => u.Id) + 1 : 1;
            user.CreatedDate = DateTime.UtcNow;
            users.Add(user);
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(users, Formatting.Indented));
        }

        public void UpdateUser(int id, string username, string text)
        {
            var users = GetAllUsers();
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.Username = username;
                user.Text = text;
                File.WriteAllText(_filePath, JsonConvert.SerializeObject(users, Formatting.Indented));
            }
        }

        public void DeleteUser(int id)
        {
            var users = GetAllUsers();
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                users.Remove(user);
                File.WriteAllText(_filePath, JsonConvert.SerializeObject(users, Formatting.Indented));
            }
        }
    }
}