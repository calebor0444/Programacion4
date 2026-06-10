using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class ContextoBD : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=CALEBPC\SQLEXPRESS;Database=Pruebas;TrustServerCertificate=True;Trusted_Connection=True;");

        }

        public DbSet<Producto> Productos { get; set; }
    }
}

