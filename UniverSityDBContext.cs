using EF_8_Raw_SQL_Dapper.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_8_Raw_SQL_Dapper
{
    public class UniverSityDBContext : DbContext
    {
        public UniverSityDBContext()
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Student>(entity => {
                entity.ToTable("Students");
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Infra.ConnectionString);
        }

        public DbSet<Student> Students { get; set; }
    }
}
