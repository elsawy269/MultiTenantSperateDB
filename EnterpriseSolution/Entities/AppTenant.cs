using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnterpriseSolution.Entities
{
    public class AppTenant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Host { get; set; }
        public string Theme { get; set; }
        public string DatabaseConnectionString { get; set; }

        public static List<AppTenant> GetTenants()
        {
            return new List<AppTenant>
            {


                new AppTenant  {

                    Id = 2,
                    Name = "Local host",

                    Host = "localhost:30172",
                    DatabaseConnectionString = "Server=(LocalDb)\\MSSQLLocalDB;Database=saaskit-sample-tenant1"

                },

                new AppTenant  {
                    Id = 3,
                    Name = "Customer X",
                    Host = "localhost:3331",
                    DatabaseConnectionString = "Server=(LocalDb)\\MSSQLLocalDB;Database=saaskit-sample-tenant2"

                },

                new AppTenant  {

                    Id = 4,
                    Name = "Customer Y",
                    Host = "localhost:33111",
                    DatabaseConnectionString = "Server=(LocalDb)\\MSSQLLocalDB;Database=saaskit-sample-tenant3"
                }

            };
        }
    }

}
