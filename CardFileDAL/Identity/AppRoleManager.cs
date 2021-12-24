using CardFileDAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardFileDAL.Identity
{
    public class AppRoleManager : RoleManager<Role>
    {
        public AppRoleManager(RoleStore<Role> store)
                    : base(store)
        { }
    }
}
