using CardFileDAL.Context;
using CardFileDAL.Entities;
using CardFileDAL.Identity;
using CardFileDAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardFileDAL.Repositories
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        private UserContext db;

        private AppUserManager userManager;
        private AppRoleManager roleManager;
        private IClientManager clientManager;

        public IdentityUnitOfWork(string connectionString)
        {
            db = new UserContext(connectionString);
            userManager = new AppUserManager(new UserStore<AppUser>(db));
            roleManager = new AppRoleManager(new RoleStore<Role>(db));
            clientManager = new ClientManager(db);
        }

        public AppUserManager UserManager
        {
            get { return userManager; }
        }

        public IClientManager ClientManager
        {
            get { return clientManager; }
        }

        public AppRoleManager RoleManager
        {
            get { return roleManager; }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    userManager.Dispose();
                    roleManager.Dispose();
                    clientManager.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
