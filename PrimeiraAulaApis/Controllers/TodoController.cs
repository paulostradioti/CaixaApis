using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PrimeiraAulaApis.Logic.Service;

namespace PrimeiraAulaApis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService service;
        public TodoController(ITodoService service) => this.service = service;


        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await service.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await service.GetById(id));

        [HttpPost]
        public async Task<IActionResult> Add(Todo todo)
        {
            var entity = await service.Add(todo);
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await service.Delete(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Guid id, Todo todo)
        {
            await service.Replace(id, todo);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(Guid id, JsonPatchDocument<Todo> patch)
        {
            var updated = new Todo();
            patch.ApplyTo(updated);

            await service.Update(id, updated);
            return NoContent();
        }
    }
}
