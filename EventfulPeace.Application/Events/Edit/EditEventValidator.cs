using FluentValidation;

namespace EventfulPeace.Application.Events.Edit;

public class EditEventRequestValidator : AbstractValidator<EditEventRequest>
{
    public EditEventRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.OccursAt).NotEmpty();
    }
}
