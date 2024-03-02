using Microsoft.EntityFrameworkCore;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Context
{
    public class FunDoContext : DbContext
    {
        public FunDoContext(DbContextOptions options) : base(options) { }

        public DbSet<UserEntity> UserTable { get; set; }

    }
}
