using AlmoxarifadoDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data
{
    public  class ContextSQL : DbContext 
    {

        public ContextSQL(DbContextOptions<ContextSQL> options) : base(options)
        {   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da chave primária para a entidade Grupo
            modelBuilder.Entity<Grupo>().HasKey(g => g.ID_GRU);
        }


        public DbSet<Grupo> Grupo { get; set; }
    }
}
