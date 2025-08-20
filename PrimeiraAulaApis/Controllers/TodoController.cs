using Microsoft.AspNetCore.Mvc;

namespace PrimeiraAulaApis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        public TodoController(AppDbContext dbContext) => this.dbContext = dbContext;


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(dbContext.Todos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var todo = dbContext.Todos.Find(id);

            if (todo == null)
                return NotFound();

            return Ok(todo);
        }

        [HttpPost]
        public IActionResult Create(Todo todo)
        {
            dbContext.Todos.Add(todo);
            dbContext.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = todo.Id});
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var todo = dbContext.Todos.Find(id);

            if (todo == null)
                return NotFound();

            dbContext.Todos.Remove(todo);
            dbContext.SaveChanges();

            return NoContent();
        }

        [HttpPut]
        public IActionResult Put(Guid id, Todo todo)
        {
            if (id != todo.Id)
                return BadRequest();

            var existing = dbContext.Todos.Find(id);
            if (todo == null)
                return NotFound();

            dbContext.Entry(existing).CurrentValues.SetValues(todo);
            dbContext.Todos.Update(existing);
            dbContext.SaveChanges();

            return AcceptedAtAction(nameof(Get), new { id = todo.Id });
        }
    }
}
