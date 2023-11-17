using Application.Common.Models;
using Application.TodoItems.Query;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ApiBaseController
    {
        [HttpGet("GetTodoItems")]
        public async Task<ActionResult<PaginatedList<TodoItem>>> GetTodoItems([FromQuery] int pagenumber, [FromQuery] int pageSize, [FromQuery] string listId)
        {
            return Ok(await _mediator.Send(new GetTodoItemsQuery(listId, pagenumber, pageSize)));
        }
    }
}
