
using ConsoleUserCrud.Models;

namespace ConsoleUserCrud.Services;

public interface IUserServices
{
    void CreateUser(User user);
    User GetUserById(int userId);
    void PrintUser(User user);
    User[] GetAllUsers();
    void UpdateUser(User user);
    void DeleteUser(int id);
}
