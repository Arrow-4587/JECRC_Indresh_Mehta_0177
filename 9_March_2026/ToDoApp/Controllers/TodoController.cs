using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoDbContext _context;

        public TodoController(TodoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodos()
        {
            return await _context.Todos.ToListAsync();
        }

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetActive()
        {
            return await _context.Todos
                .Where(t => !t.IsCompleted)
                .ToListAsync();
        }

        [HttpGet("completed")]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetCompleted()
        {
            return await _context.Todos
                .Where(t => t.IsCompleted)
                .ToListAsync();
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<TodoItem>>> Search(string query)
        {
            return await _context.Todos
                .Where(t => t.Title.Contains(query))
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> AddTodo(TodoItem todo)
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, TodoItem updated)
        {
            var todo = await _context.Todos.FindAsync(id);

            if (todo == null)
                return NotFound();

            todo.Title = updated.Title;
            todo.IsCompleted = updated.IsCompleted;
            todo.Priority = updated.Priority;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var todo = await _context.Todos.FindAsync(id);

            if (todo == null)
                return NotFound();

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}