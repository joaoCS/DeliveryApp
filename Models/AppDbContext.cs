using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Carne> Carnes { get; set; }
        public DbSet<Guarnicao> Guarnicoes { get; set; }
        public DbSet<Salada> Saladas { get; set; }
    }
}
