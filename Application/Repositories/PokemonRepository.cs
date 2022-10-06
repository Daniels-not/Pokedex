using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories
{
    public class PokemonRepository
    {
        private readonly PokemonContext pokemonContext;

        public PokemonRepository(PokemonContext pk)
        {
            pokemonContext = pk;
        }

        // return a list of pokemons 
        public async Task<List<Pokemon>> GetPokemons()
        {
            return await pokemonContext.Set<Pokemon>().ToListAsync();
        }

        // return a list of pokemon types
        public async Task<List<PokemonTipo>> GetPokemonsType()
        {
            return await pokemonContext.Set<PokemonTipo>().ToListAsync();
        }

        // return a list of pokemon region
        public async Task<List<PokemonRegion>> GetPokemonsRegion()
        {
            return await pokemonContext.Set<PokemonRegion>().ToListAsync();
        }

        //get pokemon by id
        public async Task<Pokemon> GetPokemonsById(int id)
        {
            return await pokemonContext.Set<Pokemon>().FindAsync(id);
        }

        // get pokemon region by id
        public async Task<PokemonRegion> GetPokemonRegionById(int id)
        {
            return await pokemonContext.Set<PokemonRegion>().FindAsync(id);
        }

        //get pokemon type by id 
        public async Task<PokemonTipo> GetPokemonTypeById(int id)
        {
            return await pokemonContext.Set<PokemonTipo>().FindAsync(id);
        }

        // create a new pokemon

        public async Task CreateNewPokemon(Application.Models.SavePokemon pokemon)
        {
            try
            {
                await pokemonContext.Set<Pokemon>().AddAsync(new Pokemon
                {
                    Id = pokemon.Id,
                    Name = pokemon.Name,
                    ImagePath = pokemon.ImagePath,
                    RegionId = pokemon.Region,
                    TipoId = pokemon.Tipo1,
                    Tipo2Id = pokemon.Tipo2
                });
                await pokemonContext.SaveChangesAsync();
            } catch(Exception ex)
            {
                throw;
            }
        }

        // create new pokemon region
        public async Task CreateNewPokemonRegion(Application.Models.SavePokemonRegion region)
        {
            try
            {
                await pokemonContext.Set<PokemonRegion>().AddAsync(new PokemonRegion
                {
                    NombreRegion = region.NombreRegion,
                });
                await pokemonContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // create new pokemon type
        public async Task CreateNewPokemonType(Application.Models.SavePokemonType type)
        {
            try
            {
                await pokemonContext.Set<PokemonTipo>().AddAsync(new PokemonTipo
                {
                    Id = type.Id,
                    TipoPokemon = type.TipoPokemon
                });
                await pokemonContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // update pokemon

        public async Task UpdatePakemon(Application.Models.SavePokemon pokemon)
        {
            try
            {
                pokemonContext.Entry(new Pokemon
                {
                    Id = pokemon.Id,
                    Name = pokemon.Name,
                    ImagePath = pokemon.ImagePath,
                    RegionId = pokemon.Region,
                    TipoId = pokemon.Tipo1,
                    Tipo2Id = pokemon.Tipo2
                }).State = EntityState.Modified;

                await pokemonContext.SaveChangesAsync();
            } catch(Exception ex)
            {
                throw;
            }
        }

        //update pokemon region

        public async Task UpdatePokemonRegion(Application.Models.SavePokemonRegion regions)
        {
            try
            {
                pokemonContext.Entry(new PokemonRegion
                {
                    Id = regions.Id,
                    NombreRegion = regions.NombreRegion
                }).State = EntityState.Modified;
                await pokemonContext.SaveChangesAsync();
            } catch (Exception ex)
            {
                throw;
            }
        }

        //update pokemon region

        public async Task UpdatePokemonType(Application.Models.SavePokemonType type)
        {
            try
            {
                pokemonContext.Entry(new PokemonTipo
                {
                    Id = type.Id,
                    TipoPokemon = type.TipoPokemon
                }).State = EntityState.Modified;
                await pokemonContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        //delete pokemon

        public async Task DeletePokemon(Pokemon pokemon)
        {
            try
            {
                pokemonContext.Set<Pokemon>().Remove(pokemon);
                await pokemonContext.SaveChangesAsync();
            } catch(Exception ex)
            {
                throw;
            }
        }

        //delete pokemon region

        public async Task DeletePokemonRegion(PokemonRegion region)
        {
            try
            {
                pokemonContext.Set<PokemonRegion>().Remove(region);
                await pokemonContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //delete pokemon type

        public async Task DeletePokemonType(PokemonTipo type)
        {
            try
            {
                pokemonContext.Set<PokemonTipo>().Remove(type);
                await pokemonContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
