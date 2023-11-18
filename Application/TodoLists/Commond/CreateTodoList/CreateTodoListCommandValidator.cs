using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.TodoLists.Commond.CreateTodoList
{
    public class CreateTodoListCommandValidator : AbstractValidator<CreateTodoListCommand>
    {
        private readonly IAppDbContext _context;

        public CreateTodoListCommandValidator(IAppDbContext context)
        {
            _context = context;
            RuleFor(v => v.Title)
                .NotEmpty()
                .MaximumLength(200)
                .WithMessage("Title can't be more than 200 character.")
                .MustAsync(BeUniqueTitle).WithMessage("The specified title is already exist.");
        }

        public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
        {
            return await _context.TodoLists
                .AllAsync(x => x.Title != title, cancellationToken: cancellationToken);
        }
    }
}
