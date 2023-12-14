using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.DTO;
using TodoApi.Interface;
using TodoApi.Models;

namespace TodoApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context) { 
            this._context = context;
        } 
        public ICollection<User> GetAll()
        {
            return _context.Users.OrderBy(x => x.Id).ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public async Task<dynamic> Create(UserDto userDto) {
            var password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            if(userDto.Password != null)
            {
                return "no password";
            }
            User user = new User
            {
                Userame = userDto.Userame,
                Email= userDto.Email,
                Password= password,
                Todos = null,
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user; 
        }
        public async Task<User> Update(int id,UserDto userDto)
        {
            var oldUser = _context.Users.FirstOrDefault(x => x.Id == id);
            Console.WriteLine(id);
            oldUser.Userame = userDto.Userame;
            oldUser.Password = userDto.Password;
            oldUser.Email = userDto.Email;
            await _context.SaveChangesAsync();
            return oldUser ;
        }
        public async Task<User> Delete(int id)
        {
            User user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            System.Console.WriteLine(user.Todos);
            List<Todo> todoList = await _context.Todos.ToListAsync();
            if (user != null)
            {
               _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
           return user;
        }

        public LoginDto Login(LoginDto login)
        {
            return login;
        }
    }
}
