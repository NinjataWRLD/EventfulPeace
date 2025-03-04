using FluentValidation;

namespace EventfulPeace.Application.Events.Create;

public class CreateEventRequestValidator : AbstractValidator<CreateEventRequest>
{
    public CreateEventRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.OccursAt).NotEmpty();
    }
}
