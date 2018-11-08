using EnterpriseSolution.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnterpriseSolution.Helper
{
    public class TenantProvider : ITenantProvider
    {
        private static IList<AppTenant> _tenants;

        private AppTenant _tenant;

        public TenantProvider(IHttpContextAccessor accessor, IConfiguration conf)
        {
            if (_tenants == null)
            {
                LoadTenants();
            }

            var host = accessor.HttpContext.Request.Host.Value;
            var tenant = _tenants.FirstOrDefault(t => t.Host.ToLower() == host.ToLower());
            if (tenant != null)
            {
                _tenant = tenant;
            }
        }

        private void LoadTenants()
        {

            _tenants = AppTenant.GetTenants();
        }

        public AppTenant GetTenant()
        {
            return _tenant;
        }
    }
}
