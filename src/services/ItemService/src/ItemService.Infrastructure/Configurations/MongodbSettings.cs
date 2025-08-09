using System;

namespace ItemService.Infrastructure.Configurations
{
    public class MongodbSettings
    {
        public required string ConnectionString { get; set; } 

        public required string DatabaseName { get; set; } 
        
        public required string CollectionName { get; set; } 
    }
}