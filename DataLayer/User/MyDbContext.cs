using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.User
{
    public class MyDbContext : IdentityDbContext<AppUser>
    {
        public MyDbContext() : base("name=DefaultConnection")
        {
            
        }
        // Other part of codes still same 
        // You don't need to add AppUser and AppRole 
        // since automatically added by inheriting form IdentityDbContext<AppUser>
    }
}
