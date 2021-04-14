namespace Arvan.Try.SimplaeApi.Api
{
    public class DatabaseOptions
    {
        public string Host { get; set; }

        public string Port { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public string ConnectionString =>
            $"mongodb://{User}:{Password}@{Host}:{Port}";
    }
}