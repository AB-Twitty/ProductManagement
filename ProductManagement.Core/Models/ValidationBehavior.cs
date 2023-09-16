using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace ProductManagement.Core.Models
{
	public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	where TRequest : IRequest<TResponse>
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public ValidationBehavior(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			var failures = new List<ValidationFailure>();

			// Validate inner properties
			var propertyFailures = await ValidateInnerProperties(request);
			failures.AddRange(propertyFailures);

			if (failures.Any())
			{
				throw new ValidationException(failures.Select(x => x.PropertyName + " : " + x.ErrorMessage).FirstOrDefault(), failures);
			}

			return await next();
		}

		private async Task<List<ValidationFailure>> ValidateInnerProperties(TRequest request)
		{
			var failures = new List<ValidationFailure>();

			var properties = typeof(TRequest).GetProperties().Where(p => p.GetValue(request) != null);
			foreach (var property in properties)
			{
				var (validator, validationContext) = GetValidatorForType(request, property);
				if (validator == null) continue;
				var result = await validator.ValidateAsync(validationContext);
				failures.AddRange(result.Errors);
			}

			return failures;
		}

		private (IValidator, IValidationContext) GetValidatorForType(TRequest request, PropertyInfo property)
		{
			var propertyType = property.PropertyType;

			var contextType = typeof(ValidationContext<>).MakeGenericType(propertyType);
			var validationContext = (IValidationContext)Activator.CreateInstance(contextType, property.GetValue(request));

			var validator = (IValidator)_httpContextAccessor.HttpContext.RequestServices
				.GetService(typeof(IValidator<>).MakeGenericType(propertyType));
			//var validator = (IValidator)Activator.CreateInstance(serviceValidator.GetType());
			return (validator, validationContext);
		}
	}
}

