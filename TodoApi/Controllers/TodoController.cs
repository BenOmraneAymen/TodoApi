using Microsoft.AspNetCore.Mvc;
using TodoApi.DTO;
using TodoApi.Interface;
using TodoApi.Models;


namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;
        public TodoController(ITodoRepository todoRepository ) {
            this._todoRepository = todoRepository;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            var response = _todoRepository.GetAllTodos();
            if(response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var response = _todoRepository.GetById(id);
            if(response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post(TodoDto todo)
        {
            var response = await _todoRepository.Create(todo);
            if(response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,TodoDto todo)
        {
            var response = _todoRepository.Update(id, todo);
            if(response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = _todoRepository.Delete(id);
            if(response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

    }
}
