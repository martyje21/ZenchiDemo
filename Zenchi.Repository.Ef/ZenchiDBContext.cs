using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Zenchi.Repository.Ef.DataEntities;

namespace Zenchi.Repository.Ef
{
    public class ZenchiDBContext : DbContext
    {
        public ZenchiDBContext() : base("ZenchiDBContext")
        {
        }

        public DbSet<ProjectData> ProjectData { get; set; }
        public DbSet<ProjectItemData> ProjectItemData { get; set; }
        public DbSet<ConfigurationData> ConfigurationData { get; set; }

    }
}
