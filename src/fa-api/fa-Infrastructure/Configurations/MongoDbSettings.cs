using System;

namespace faApi.Infrastructure.Configurations
{
    public class MongoDbSettings
    {
        public required string ConnectionString { get; set; }

        public required string DatabaseName { get; set; }
    }
}