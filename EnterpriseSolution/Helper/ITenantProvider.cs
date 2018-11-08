using EnterpriseSolution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnterpriseSolution.Helper
{
   public interface ITenantProvider
    {
        AppTenant GetTenant();
    }
}
