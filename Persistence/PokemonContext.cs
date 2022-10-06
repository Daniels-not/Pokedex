using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence
{
    public class PokemonContext : DbContext
    {
        public PokemonContext(DbContextOptions<PokemonContext> option) : base(option)
        {

        }

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<PokemonRegion> PokemonRegion { get; set; }
        public DbSet<PokemonTipo> PokemonTipo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region table
            modelBuilder.Entity<Pokemon>().ToTable("Pokemones");
            modelBuilder.Entity<PokemonRegion>().ToTable("RegionPokemones");
            modelBuilder.Entity<PokemonTipo>().ToTable("TipoPokemones");
            #endregion

            #region "Primary key"
            modelBuilder.Entity<PokemonRegion>()
                .HasMany<Pokemon>(region => region.Pokemons)
                .WithOne(pokemon => pokemon.Region)
                .HasForeignKey(pokemon => pokemon.RegionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PokemonTipo>()
                .HasMany<Pokemon>(tipo => tipo.Pokemons)
                .WithOne(pokemon => pokemon.Tipo)
                .HasForeignKey(pokemon => pokemon.TipoId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region "Property Configurations"
                #region "Pokemons"
                modelBuilder.Entity<Pokemon>()
                    .Property(p => p.Name)
                    .IsRequired();
                modelBuilder.Entity<Pokemon>()
                    .Property(p => p.ImagePath)
                    .IsRequired();                
                modelBuilder.Entity<Pokemon>()
                    .Property(p => p.TipoId)
                    .IsRequired();
            #endregion

                #region "Pokemons Regiones"
                modelBuilder.Entity<PokemonRegion>()
                    .Property(pr => pr.NombreRegion)
                    .IsRequired();
            #endregion

                #region "Pokemons Tipo"
                modelBuilder.Entity<PokemonTipo>()
                    .Property(pt => pt.TipoPokemon)
                    .IsRequired();
            #endregion
            #endregion
        }
    }
}
