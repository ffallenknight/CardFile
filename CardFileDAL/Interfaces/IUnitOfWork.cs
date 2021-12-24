using CardFileDAL.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardFileDAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        AppUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        AppRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}
