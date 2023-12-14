using TodoApi.DTO;
using TodoApi.Models;

namespace TodoApi.Interface
{
    public interface IUserRepository
    {
        LoginDto Login(LoginDto login);
        ICollection<User> GetAll();
        User GetUserById(int id);
        Task<dynamic> Create(UserDto userDto);
        Task<User> Update(int id,UserDto userDto);
        Task<User> Delete(int id);
    }
}
