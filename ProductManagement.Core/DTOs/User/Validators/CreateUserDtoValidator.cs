using FluentValidation;

namespace ProductManagement.Core.DTOs.User.Validators
{
	public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
	{
		public CreateUserDtoValidator()
		{
			ApplyValidationRules();
		}

		private void ApplyValidationRules()
		{
			RuleFor(x => x.FirstName)
				.NotEmpty().WithMessage("{PropertyName} can not be empty.")
				.NotNull().WithMessage("{PropertyName} can not be null.")
				.MinimumLength(3).WithMessage("{PropertyName} must exceed {1} charactrs.");

			RuleFor(x => x.LastName)
				.NotEmpty().WithMessage("{PropertyName} can not be empty.")
				.NotNull().WithMessage("{PropertyName} can not be null.")
				.MinimumLength(3).WithMessage("{PropertyName} must exceed {1} charactrs.");

			RuleFor(x => x.UserName)
				.NotEmpty().WithMessage("{PropertyName} can not be empty.")
				.NotNull().WithMessage("{PropertyName} can not be null.")
				.MinimumLength(6).WithMessage("{PropertyName} must exceed {1} charactrs.");

			RuleFor(x => x.Email)
				.NotEmpty().WithMessage("{PropertyName} can not be empty.")
				.NotNull().WithMessage("{PropertyName} can not be null.")
				.EmailAddress();

			RuleFor(x => x.Password)
				.NotEmpty().WithMessage("{PropertyName} can not be empty.")
				.NotNull().WithMessage("{PropertyName} can not be null.")
				.MinimumLength(6).WithMessage("{PropertyName} must exceed {1} charactrs.");

			RuleFor(x => x.ConfirmPassword)
				.NotEmpty().WithMessage("{PropertyName} can not be empty.")
				.NotNull().WithMessage("{PropertyName} can not be null.")
				.Matches(x => x.Password).WithMessage("{1} and {0} must be equal.");
		}
	}
}
