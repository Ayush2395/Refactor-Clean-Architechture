using Application.Common.Interfaces;
using Application.Common.Models;
using Application.TodoLists.Commond.CreateTodoList;
using Application.TodoLists.Query.GetTodoList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ApiBaseController
    {
        [HttpGet]
        [Route("GetTodoList")]
        public async Task<ActionResult<PaginatedList<TodoListDto>>> GetTodoList([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            return Ok(await _mediator.Send(new GetTodoListQuery { PageNumber = pageNumber, PageSize = pageSize }));
        }

        [HttpPost]
        [Route("CreateTodoList")]
        public async Task<ActionResult<string>> CreateTodoList([FromBody] CreateTodoListCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
