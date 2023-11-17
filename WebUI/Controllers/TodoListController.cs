using Application.Common.Models;
using Application.TodoLists.Query;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ApiBaseController
    {
        [Authorize]
        [HttpGet("GetTodoList")]
        public async Task<ActionResult<PaginatedList<TodoList>>> GetTodoList([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == "sid")?.Value;
            return Ok(await _mediator.Send(new GetTodoListQuery { PageNumber = pageNumber, PageSize = pageSize, UserId = userId }));
        }
    }
}
