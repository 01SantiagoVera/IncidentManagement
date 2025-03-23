using System.Data.Entity;
using IncidentManagement.Data.Context;

namespace IncidentManagement.Web
{
    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<IncidentContext>());
            using (var context = new IncidentContext())
            {
                context.Database.Initialize(force: false);
            }
        }
    }
} 