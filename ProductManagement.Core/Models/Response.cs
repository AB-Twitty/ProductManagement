using System.Collections.Generic;
using System.Net;

namespace ProductManagement.Core.Models
{
	public class Response<T> where T : class
	{
		public Response()
		{

		}

		public Response(T data, string message = null)
		{
			Data = data;
			Message = message;
			Succeded = true;
		}

		public Response(string message, bool succeded = true)
		{
			Message = message;
			Succeded = succeded;
		}

		public HttpStatusCode StatusCode { get; set; }
		public object Meta { get; set; }
		public string Message { get; set; }
		public bool Succeded { get; set; }
		public T Data { get; set; }
		public List<string> Errors { get; set; }
	}
}
