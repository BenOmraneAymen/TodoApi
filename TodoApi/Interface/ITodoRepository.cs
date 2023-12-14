using TodoApi.DTO;
using TodoApi.Models;

namespace TodoApi.Interface
{
    public interface ITodoRepository
    {
        ICollection<Todo> GetAllTodos();
        Todo GetById(int id);
        Task<Todo> Create(TodoDto todo);
        Todo Update(int id,TodoDto todo);
        Todo Delete(int id);

    }
}
