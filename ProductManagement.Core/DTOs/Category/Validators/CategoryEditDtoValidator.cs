using FluentValidation;
using ProductManagement.Service.Services.Abstracts;

namespace ProductManagement.Core.DTOs.Category.Validators
{

	public class CategoryEditDtoValidator : AbstractValidator<CategoryEditDto>
	{
		private readonly ICategoryService _categoryService;

		public CategoryEditDtoValidator(ICategoryService categoryService)
		{
			_categoryService = categoryService;

			ApplyValidationRules();
			ApplyCustomValidationRules();
		}

		private void ApplyValidationRules()
		{
			RuleFor(x => x.Id)
				.NotNull().WithMessage("{PropertyName} can bot be null.")
				.NotEmpty().WithMessage("{PropertyName} can not be empty.");

			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("{PropertyName} can not be empty.")
				.NotNull().WithMessage("{PropertyName} can bot be null.");

			RuleFor(x => x.Description)
				.NotEmpty().WithMessage("{PropertyName} can not be empty.")
				.NotNull().WithMessage("{PropertyName} can bot be null.");

			RuleFor(x => x.IsActive)
				.NotNull().WithMessage("{PropertyName} can bot be null.");
		}

		private void ApplyCustomValidationRules()
		{
			RuleFor(x => x.Name)
				.MustAsync(async (Model, Key, CancellationToken) =>
				{
					return !await _categoryService.IsNameExistExcludeSelf(Key, Model.Id);
				}).WithMessage("{PropertyValue} already exists.");
		}
	}
}
