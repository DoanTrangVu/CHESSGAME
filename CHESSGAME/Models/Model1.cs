using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CHESSGAME.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=ManageUserDB")
        {
        }

        public virtual DbSet<ManageUser> ManageUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ManageUser>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<ManageUser>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
