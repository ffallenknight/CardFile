using CardFileDAL.Context;
using CardFileDAL.Entities;
using CardFileDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardFileDAL.Repositories
{
    public class ClientManager : IClientManager
    {
        public UserContext Database { get; set; }
        public ClientManager(UserContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
