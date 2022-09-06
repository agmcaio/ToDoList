using ApiToDoList.Data;
using ApiToDoList.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiToDoList.Controllers
{
    [ApiController] // Informa que está se tratando de uma API
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Get([FromServices] AppDbContext context) // Injeção de dependência
            => Ok(context.ToDos.ToList()); // Retornando uma lista de ToDos

        [HttpGet("/{id:int}")]
        public IActionResult GetById([FromRoute] int id, [FromServices] AppDbContext context)
        {
            var todo = context.ToDos.FirstOrDefault(x => x.Id == id);

            if(todo == null)
                return NotFound();

            return Ok(todo);
        }

        [HttpPost("/")]
        public IActionResult Post([FromBody] ToDoModel toDo, [FromServices] AppDbContext context)
        {
            context.ToDos.Add(toDo);
            context.SaveChanges();

            return Created($"/{toDo.Id}",toDo);
        }

        [HttpPut("/{id:int}")]
        public IActionResult Put(
            [FromRoute] int id, 
            [FromBody] ToDoModel toDo, 
            [FromServices] AppDbContext context)
        {
            // recuperando o item do banco
            var model = context.ToDos.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return NotFound();

            // equiparando os valores do modelo com o que é recebido
            model.Title = toDo.Title;
            model.Done = toDo.Done;

            // atualizando o model
            context.ToDos.Update(model);
            context.SaveChanges();
            return Ok(model);
        }

        [HttpDelete("/{id:int}")]
        public IActionResult Delete([FromRoute] int id, [FromServices] AppDbContext context)
        {
            var model = context.ToDos.FirstOrDefault(x => x.Id == id);

            if (model == null)
                return NotFound();

            context.ToDos.Remove(model);
            context.SaveChanges();
            return Ok(model);
        }
    }
}
