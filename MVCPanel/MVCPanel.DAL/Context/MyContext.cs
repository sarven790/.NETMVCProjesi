using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCPanel.DAL.Mapping;
using MVCPanel.Entities.Models;

namespace MVCPanel.DAL.Context
{
    public class MyContext : DbContext
    {

        public MyContext() : base("myConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new UserMap());

        }

        public DbSet<User> Users { get; set; }

    }
}
