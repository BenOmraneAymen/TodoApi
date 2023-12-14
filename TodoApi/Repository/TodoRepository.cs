using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.DTO;
using TodoApi.Interface;
using TodoApi.Models;

namespace TodoApi.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _context;
        public TodoRepository(DataContext context) {
            this._context = context;
        }

        public ICollection<Todo> GetAllTodos()
        {
            return _context.Todos.ToList();
        }

        public Todo GetById(int id)
        {
            return _context.Todos.SingleOrDefault(t => t.Id == id);
        }

        public async Task<Todo> Create(TodoDto todoDto)
        {
            List<Label> labels= new List<Label>();
            User user = await _context.Users.SingleOrDefaultAsync(u => u.Id == todoDto.UserId);
            foreach(int LabelId in todoDto.LabelIds)
            {
                Label label = await _context.Labels.SingleOrDefaultAsync(u => u.Id == LabelId);
                labels.Add(label);
            }
            Console.WriteLine(user);
            Todo todo = new Todo
            {
                Title= todoDto.Title,
                Description= todoDto.Description,
                UserId = todoDto.UserId,
                User = user,
                Labels= labels
            };
           _context.Todos.Add(todo);
            return todo;
        }

        public Todo Update(int id,TodoDto todo)
        {
            Todo oldTodo = _context.Todos.SingleOrDefault(t => t.Id == id);
            if(oldTodo != null)
            {
                oldTodo.Title = todo.Title;
                oldTodo.Description = todo.Description;
                _context.SaveChanges();
                return oldTodo;
            }
            return null;
        }

        public Todo Delete(int id)
        {
            Todo oldTodo = _context.Todos.SingleOrDefault(t => t.Id == id);
            if(oldTodo != null)
            { 
            _context.Todos.Remove(GetById(id));
            _context.SaveChanges();
            return oldTodo;
            }
            return null;
        }


    }
}
