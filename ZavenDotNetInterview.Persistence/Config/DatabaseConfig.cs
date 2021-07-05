namespace ZavenDotNetInterview.Persistence.Config
{
    public class DatabaseConfig
    {
        public string ConnectionString { get; protected set; }

        protected DatabaseConfig()
        { }
        
        public DatabaseConfig(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}