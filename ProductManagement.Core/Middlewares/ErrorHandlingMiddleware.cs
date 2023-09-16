using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductManagement.Core.Middlewares
{
	public class ErrorHandlingMiddleware
	{
		private readonly RequestDelegate _next;

		public ErrorHandlingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				var response = context.Response;
				response.ContentType = "application/json";
				var responseModel = new Response<string> { Succeded = false };

				switch (ex)
				{
					case UnauthorizedAccessException:
						responseModel.Message = "Unauthorized Access Exception";
						responseModel.StatusCode = HttpStatusCode.Unauthorized;
						response.StatusCode = (int)HttpStatusCode.Unauthorized;
						break;
					case ValidationException validationExcp:
						responseModel.Message = validationExcp.Message ?? "Validation Exception";
						responseModel.Errors = validationExcp.Errors.Select(e => e.PropertyName + " : " + e.ErrorMessage).ToList();
						responseModel.StatusCode = HttpStatusCode.UnprocessableEntity;
						response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
						break;
					case KeyNotFoundException:
						responseModel.Message = "The requested item can not be found.";
						responseModel.StatusCode = HttpStatusCode.BadRequest;
						response.StatusCode = (int)HttpStatusCode.BadRequest;
						break;
					case DbUpdateException:
						responseModel.Message = "The requested item can not be updated.";
						responseModel.StatusCode = HttpStatusCode.BadRequest;
						response.StatusCode = (int)HttpStatusCode.BadRequest;
						break;
					case Exception:
						responseModel.Message = ex.Message ?? "Internal Server Error";
						responseModel.StatusCode = HttpStatusCode.InternalServerError;
						response.StatusCode = (int)HttpStatusCode.InternalServerError;
						break;
					default:
						responseModel.Message = "Unhandled Exception, please contact the application admin.";
						responseModel.StatusCode = HttpStatusCode.InternalServerError;
						response.StatusCode = (int)HttpStatusCode.InternalServerError;
						break;
				}

				await response.WriteAsync(JsonSerializer.Serialize(responseModel));
			}
		}
	}
}
