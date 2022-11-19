using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bilheteira;

namespace WebBilheteira.Data
{
    public class WebBilheteiraContext : DbContext
    {
        public WebBilheteiraContext (DbContextOptions<WebBilheteiraContext> options)
            : base(options)
        {
        }

        public DbSet<Bilheteira.TipoEspetaculo> TipoEspetaculo { get; set; }

        public DbSet<Bilheteira.Espetaculo> Espetaculo { get; set; }

        public DbSet<Bilheteira.Sala> Sala { get; set; }

        public DbSet<Bilheteira.Bilhete> Bilhete { get; set; }

        public DbSet<Bilheteira.Utilizador> Utilizador { get; set; }

        public DbSet<Bilheteira.Venda> Venda { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoEspetaculo>().HasData(
                new TipoEspetaculo() { Id = 1, Tipo = "Musical" },
                new TipoEspetaculo() { Id = 2, Tipo = "Teatro" }
                );
            modelBuilder.Entity<Espetaculo>().HasData(
                new Espetaculo() { Id = 1, Name = "Lago dos cisnes", TipoEspetaculoId = 1 },
                new Espetaculo() { Id = 2, Name = "Fantas da opera", TipoEspetaculoId = 1 },
                new Espetaculo() { Id = 3, Name = "Fanoches", TipoEspetaculoId = 2 },
                new Espetaculo() { Id = 4, Name = "Princepesinho", TipoEspetaculoId = 2 }
                );
            modelBuilder.Entity<Sala>().HasData(
               new Sala() { Id = 1, Nome = "Cineteatro", NumLugares = 50, Endereco = "Porto" },
               new Sala() { Id = 2, Nome = "Batalha", NumLugares = 40, Endereco = "Porto" },
               new Sala() { Id = 3, Nome = "Circo", NumLugares = 50, Endereco = "Braga" },
               new Sala() { Id = 4, Nome = "Mamede", NumLugares = 30, Endereco = "Guimaraes" }
               );
            modelBuilder.Entity<Utilizador>().HasData(
               new Utilizador() { Id = 1, Name = "ze Pintas", UserName = "zepin" },
               new Utilizador() { Id = 2, Name = "Maria Calas Pintas", UserName = "macalas" },
               new Utilizador() { Id = 3, Name = "Jose oliveira", UserName = "zeo" },
               new Utilizador() { Id = 4, Name = "jonana souzas", UserName = "jasou" }
               );
            modelBuilder.Entity<Bilhete>().HasData(
               new Bilhete() { Id = 1, EspetaculoId = 1, SalaId = 2, DataEspetaculo = DateTime.Now, NumBilhetes = 20, Preco = 50 },
               new Bilhete() { Id = 2, EspetaculoId = 2, SalaId = 1, DataEspetaculo = DateTime.Now, NumBilhetes = 30, Preco = 40 },
               new Bilhete() { Id = 3, EspetaculoId = 3, SalaId = 4, DataEspetaculo = DateTime.Now, NumBilhetes = 60, Preco = 30 },
               new Bilhete() { Id = 4, EspetaculoId = 3, SalaId = 3, DataEspetaculo = DateTime.Now, NumBilhetes = 70, Preco = 70 }
               );
            modelBuilder.Entity<Venda>().HasData(
               new Venda() { Id = 1, UtilizadorID = 1, BilheteId = 1 },
               new Venda() { Id = 2, UtilizadorID = 2, BilheteId = 1 },
               new Venda() { Id = 3, UtilizadorID = 3, BilheteId = 2 },
               new Venda() { Id = 4, UtilizadorID = 4, BilheteId = 3 }
               );

            base.OnModelCreating(modelBuilder);
        }
    }
}
