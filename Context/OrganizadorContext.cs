using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using desafio_api_payment.Models;

namespace desafio_api_payment.Context
{
    public class OrganizadorContext : DbContext
    {
        public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options)
        {

        }

        public DbSet<Item> Itens { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }


         protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Venda>(table =>
            {
                table.HasKey(e => e.Id);
                table
                    .HasMany(e => e.Itens)
                    .WithOne()
                    .HasForeignKey(c => c.VendaId);
            });

            builder.Entity<Item>(table =>
            {
                table.HasKey(e => e.Id);
            });

        }

    }


}