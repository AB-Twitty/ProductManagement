namespace ProductManagement.Domain.MetaData
{
	public static class Router
	{
		public const string Root = "Api";
		public const string Version = "/V1";
		public const string Rule = Root + Version;

		public static class CategoryRouting
		{
			public const string Prefix = Rule + "/Category";
			public const string List = Prefix + "/List";
			public const string GetById = Prefix + "/{id}";
			public const string Create = Prefix + "/Create";
		}
	}
}
