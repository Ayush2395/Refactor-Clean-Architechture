using Application.Common.Extensions;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Common.Security;
using MediatR;

namespace Application.TodoLists.Query.GetTodoList
{
    [Authorize(Policy = "CanPurge")]
    public record GetTodoListQuery : IRequest<PaginatedList<TodoListDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetTodoListHandler : IRequestHandler<GetTodoListQuery, PaginatedList<TodoListDto>>
    {
        private readonly IAppDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public GetTodoListHandler(IAppDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<PaginatedList<TodoListDto>> Handle(GetTodoListQuery request, CancellationToken cancellationToken)
        {
            var list = await _context.TodoLists.Where(x => x.UserId == _currentUserService.UserId)
                .Select(rec => new TodoListDto
                {
                    Id = rec.Id,
                    Colour = rec.Colour,
                    Title = rec.Title,
                    Items = rec.Items.Select(item => new TodoItemDto
                    {
                        Title = item.Title!,
                        ItemId = item.Id,
                        Notes = item.Notes!,
                        Priority = item.Priority
                    }).ToList()
                }).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return list;
        }
    }
}
