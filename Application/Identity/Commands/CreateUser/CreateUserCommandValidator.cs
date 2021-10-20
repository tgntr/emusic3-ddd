namespace SimpleMusicStore.Application.Identity.Commands.CreateUser
{
    using FluentValidation;

    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            this.RuleFor(u => u.Email)
                .MinimumLength(UserConstants.MinEmailLength)
                .MaximumLength(UserConstants.MaxEmailLength)
                .EmailAddress()
                .NotEmpty();

            this.RuleFor(u => u.Password)
                .MaximumLength(UserConstants.MaxNameLength)
                .NotEmpty();

            this.RuleFor(u => u.Name)
                .MinimumLength(UserConstants.MinNameLength)
                .MaximumLength(UserConstants.MaxNameLength)
                .NotEmpty();

            this.RuleFor(u => u.PhoneNumber)
                .MinimumLength(UserConstants.MinPhoneNumberLength)
                .MaximumLength(UserConstants.MaxPhoneNumberLength)
                .Matches(UserConstants.PhoneNumberRegularExpression)
                .NotEmpty();
        }
    }
}
