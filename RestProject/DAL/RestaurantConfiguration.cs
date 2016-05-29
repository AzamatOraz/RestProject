using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Data.Entity.Infrastructure.Interception;

namespace RestProject.DAL
{
    public class RestaurantConfiguration : DbConfiguration
    {
        public RestaurantConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            DbInterception.Add(new RestaurantInterceptorTransientErrors());
            DbInterception.Add(new RestaurantInterceptorLogging());
        }
    }
}