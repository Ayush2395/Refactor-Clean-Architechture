using Application.Common.Interfaces;
using Application.Common.Security;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.TodoLists.Commond.CreateTodoList
{
    [Authorize(Policy = "CanPurge")]
    public record CreateTodoListCommand : IRequest<string>
    {
        public string? Title { get; set; }
    }
    public class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, string>
    {
        private readonly ILogger<CreateTodoListCommandHandler> _logger;
        private readonly IAppDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public CreateTodoListCommandHandler(ILogger<CreateTodoListCommandHandler> logger, IAppDbContext context, ICurrentUserService currentUserService)
        {
            _logger = logger;
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new TodoList
                {
                    Title = request.Title,
                    UserId = _currentUserService.UserId!
                };
                await _context.TodoLists.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return entity.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
