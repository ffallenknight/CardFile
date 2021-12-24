using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardFileDAL.Entities
{
    public class AppUser:IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}
