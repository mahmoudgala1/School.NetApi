namespace School.Data.AppMetaData;
public static class Router
{
    public const string Root = "Api";
    public const string Version = "V1";
    public const string Rule = $"{Root}/{Version}/";
    public const string SingleRoute = "{id}";

    public static class StudentRouting
    {
        public const string Prefix = $"{Rule}Student/";
        public const string List = $"{Prefix}List";
        public const string GetById = $"{Prefix}{SingleRoute}";
        public const string Add = $"{Prefix}AddStudent";
        public const string Edit = $"{Prefix}EditStudent";
        public const string Delete = $"{Prefix}{SingleRoute}";
    }
}
