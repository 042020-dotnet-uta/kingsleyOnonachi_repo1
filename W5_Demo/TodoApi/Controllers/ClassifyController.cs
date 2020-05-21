using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassifyController : ControllerBase
    {
        private readonly TodoContext _context;

        public ClassifyController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Classify
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassifyTodoItem>>> GetClassifyTodos()
        {
            return await _context.ClassifyTodos.ToListAsync();
        }

        // GET: api/Classify/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassifyTodoItem>> GetClassifyTodoItem(long id)
        {
            var classifyTodoItem = await _context.ClassifyTodos.FindAsync(id);

            if (classifyTodoItem == null)
            {
                return NotFound();
            }

            return classifyTodoItem;
        }

        // PUT: api/Classify/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassifyTodoItem(long id, ClassifyTodoItem classifyTodoItem)
        {
            if (id != classifyTodoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(classifyTodoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassifyTodoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Classify
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ClassifyTodoItem>> PostClassifyTodoItem(ClassifyTodoItem classifyTodoItem)
        {
            _context.ClassifyTodos.Add(classifyTodoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassifyTodoItem", new { id = classifyTodoItem.Id }, classifyTodoItem);
        }

        // DELETE: api/Classify/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClassifyTodoItem>> DeleteClassifyTodoItem(long id)
        {
            var classifyTodoItem = await _context.ClassifyTodos.FindAsync(id);
            if (classifyTodoItem == null)
            {
                return NotFound();
            }

            _context.ClassifyTodos.Remove(classifyTodoItem);
            await _context.SaveChangesAsync();

            return classifyTodoItem;
        }

        private bool ClassifyTodoItemExists(long id)
        {
            return _context.ClassifyTodos.Any(e => e.Id == id);
        }
    }
}
