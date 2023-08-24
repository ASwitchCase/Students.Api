using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Api.Settings
{
    public class MongoDbSettings
    {
        private IConfiguration configuration;
        private readonly string ConnectionString;

        public MongoDbSettings(IConfiguration configuration){
            this.configuration = configuration;
            ConnectionString = configuration.GetConnectionString("MyConnString");
        }
        public string GetConnectionString(){
            return ConnectionString;
        }

    }
}