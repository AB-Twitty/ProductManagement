using FluentValidation;
using ProductManagement.Service.Services.Abstracts;

namespace ProductManagement.Core.DTOs.Category.Validators
{
	public class CategoryCreateDtoValidator : AbstractValidator<CategoryCreateDto>
	{
		private readonly ICategoryService _categoryService;

		public CategoryCreateDtoValidator(ICategoryService categoryService)
		{
			_categoryService = categoryService;

			ApplyValidationRules();
			ApplyCustomValidationRules();
		}

		private void ApplyValidationRules()
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("{PropertyName} can not be empty.")
				.NotNull().WithMessage("{PropertyName} can bot be null.");

			RuleFor(x => x.Description)
				.NotEmpty().WithMessage("{PropertyName} can not be empty.")
				.NotNull().WithMessage("{PropertyName} can bot be null.");
		}

		private void ApplyCustomValidationRules()
		{
			RuleFor(x => x.Name)
				.MustAsync(async (Key, CancellationToken) =>
				{
					return !await _categoryService.IsNameExist(Key);
				}).WithMessage("{PropertyValue} already exists.");
		}
	}
}
