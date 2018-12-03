using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Task04_UserEntityHandler
{
    class UserContext : DbContext
    {
        public UserContext() : base("name=Model1Container")
        {

        }

        public virtual DbSet<User> Users { get; set; }
    }
}
