using Application.Common.Extensions;
using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.TodoLists.Query
{
    public record GetTodoListQuery : IRequest<PaginatedList<TodoList>>
    {
        [JsonIgnore]
        public string? UserId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetTodoListHandler : IRequestHandler<GetTodoListQuery, PaginatedList<TodoList>>
    {
        private readonly IAppDbContext _context;

        public GetTodoListHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<TodoList>> Handle(GetTodoListQuery request, CancellationToken cancellationToken)
        {
            var list = await _context.TodoLists.Where(x => x.UserId == request.UserId)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return list;
        }
    }
}
