using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmsApi.DataModel.Models
{
    public static class Policies
    {
        public static AuthorizationPolicy CountryManagerPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                                                   .RequireRole(UserRoles.CountryManager)
                                                   .Build();
        }
        public static AuthorizationPolicy SuperManagerPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                                                   .RequireRole(UserRoles.SuperManager)
                                                   .Build();
        }
        public static AuthorizationPolicy ManagerPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                                                   .RequireRole(UserRoles.Manager)
                                                   .Build();
        }

        public static AuthorizationPolicy EmployeePolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                                                   .RequireRole(UserRoles.Employee)
                                                   .Build();
        }
    }
}
