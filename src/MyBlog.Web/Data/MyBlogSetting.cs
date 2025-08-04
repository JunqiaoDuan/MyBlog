namespace MyBlog.Web.Data
{
    public class MyBlogSetting
    {

        public const string MyBlogSettingSectionName = "MyBlogSetting";

        public MyBlogSetting_DataBase DataBase { get; set; } = new MyBlogSetting_DataBase();
        public MyBlogSetting_Azure Azure_KeyVault { get; set; } = new MyBlogSetting_Azure();
    }

    public class MyBlogSetting_DataBase
    {
        public string? DatabaseSource { get; set; }
        public string? LocalDatabaseConn { get; set; }
    }

    public class MyBlogSetting_Azure
    {
        public string Url { get; set; } = "";

        public string Name_SqlServerConn { get; set; } = "";
        public string Name_BlogConn { get; set; } = "";
        public string Name_QueueConn { get; set; } = "";

        public string Name_OpenAIEndpoint { get; set; } = "";
        public string Name_OpenAISecretKey { get; set; } = "";

        public string Name_GeminiSecretKey { get; set; } = "";
    }

}
