using FrameworkOptionsPatternExample.Config;
using System.Data.Entity;

namespace FrameworkOptionsPatternExample
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
            // Obviously don't just new this up in production
            var config = new XmlConfig();

            this.Database.Connection.ConnectionString = config.ConnectionStringConfiguration.MyDbConnectionString;
        }
    }
}
