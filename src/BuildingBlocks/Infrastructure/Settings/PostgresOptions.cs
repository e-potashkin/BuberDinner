namespace BuildingBlocks.Infrastructure.Settings
{
    public class PostgresOptions
    {
        public string ConnectionString { get; set; }

        public string DefaultSchema { get; set; }

        public int CommandTimeout { get; set; }
    }
}
