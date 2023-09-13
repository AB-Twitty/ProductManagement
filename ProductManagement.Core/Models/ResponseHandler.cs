using System.Net;

namespace ProductManagement.Core.Models
{
	public class ResponseHandler
	{
		public Response<T> Success<T>(T data, string message = null, object meta = null) where T : class
		{
			return new Response<T>
			{
				StatusCode = HttpStatusCode.OK,
				Data = data,
				Message = message == null ? "Successfull Request" : message,
				Meta = meta,
				Succeded = true
			};
		}

		public Response<T> Created<T>(T data, object meta = null) where T : class
		{
			return new Response<T>
			{
				StatusCode = HttpStatusCode.Created,
				Data = data,
				Message = "Created Successfully",
				Meta = meta,
				Succeded = true
			};
		}

		public Response<T> Deleted<T>() where T : class
		{
			return new Response<T>
			{
				StatusCode = HttpStatusCode.OK,
				Message = "Deleted Successfully",
				Succeded = true
			};
		}

		public Response<T> Unauthorized<T>() where T : class
		{
			return new Response<T>
			{
				StatusCode = HttpStatusCode.Unauthorized,
				Message = "Unauthorized",
				Succeded = true
			};
		}

		public Response<T> NotFound<T>(string message = null) where T : class
		{
			return new Response<T>
			{
				StatusCode = HttpStatusCode.NotFound,
				Message = message == null ? "Not Found" : message,
				Succeded = false
			};
		}

		public Response<T> UnprocessableEntity<T>(string message = null) where T : class
		{
			return new Response<T>
			{
				StatusCode = HttpStatusCode.UnprocessableEntity,
				Message = message == null ? "Unprocessable Entity" : message,
				Succeded = false
			};
		}


		public Response<T> BadRequest<T>(string message = null) where T : class
		{
			return new Response<T>
			{
				StatusCode = HttpStatusCode.BadRequest,
				Message = message == null ? "Bad Request" : message,
				Succeded = false
			};
		}
	}
}
