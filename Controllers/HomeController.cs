using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("/")]
        public IActionResult Get([FromServices] AppDbContext context)
        {
            return Ok(context.Todos.ToList());
        }

        [HttpGet]
        [Route("/{id:int}")]
        public IActionResult GetById(
            [FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            var todo = context.Todos.FirstOrDefault(x => x.Id == id);

            if (todo == null)
                return NotFound();

            return Ok(todo);
        }

        [HttpPost]
        [Route("/")]
        public IActionResult Post(
            [FromBody] TodoModel todo,
            [FromServices] AppDbContext context)
        {
            context.Todos.Add(todo);
            context.SaveChanges();

            return Created($"{todo.Id}", todo);
        }

        [HttpPut]
        [Route("/{id:int}")]
        public IActionResult Put(
            [FromRoute] int id,
            [FromBody] TodoModel todo,
            [FromServices] AppDbContext context)
        {
            var todoToBeUpdated = context.Todos.FirstOrDefault(x => x.Id == id);

            if (todoToBeUpdated == null)
                return NotFound();

            todoToBeUpdated.Title = todo.Title;
            todoToBeUpdated.Done = todo.Done;

            context.Todos.Update(todoToBeUpdated);
            context.SaveChanges();

            return Ok(todoToBeUpdated);
        }

        [HttpDelete]
        [Route("/{id:int}")]
        public IActionResult Delete(
            [FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            var todoToBeDeleted = context.Todos.FirstOrDefault(x => x.Id == id);

            if (todoToBeDeleted == null)
                return NotFound();

            context.Todos.Remove(todoToBeDeleted);
            context.SaveChanges();

            return Ok(todoToBeDeleted);
        }

    }
}