using Application.Common.Extensions;
using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using MediatR;

namespace Application.TodoItems.Query
{
    public record GetTodoItemsQuery(string ListId, int pageNumber, int pageSize) : IRequest<PaginatedList<TodoItem>>;
    public class GetTodoItemsHandler : IRequestHandler<GetTodoItemsQuery, PaginatedList<TodoItem>>
    {
        private readonly IAppDbContext _context;

        public GetTodoItemsHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<TodoItem>> Handle(GetTodoItemsQuery request, CancellationToken cancellationToken)
        {
            var items = await _context.TodoItems.Where(x => x.ListId == request.ListId)
                .ToPaginatedListAsync(request.pageNumber, request.pageSize);
            return items;
        }
    }
}
