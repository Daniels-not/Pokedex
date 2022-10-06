using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Application.Repositories;
using Application.Services;
using Persistence;
using Persistence.Models;

namespace Application.Services
{
    public class PokemonServices
    {
        private readonly PokemonRepository pokemonRepository;

        public PokemonServices(PokemonContext pokedata)
        {
            pokemonRepository = new(pokedata);
        }

        private PokemonList PokemonList { get; set; } = new();
        
        // get pokemon 
        public async Task<List<PokemonsModel>> GetPokemon()
        {
            try
            {
                // bring out the pokemon tipo 
                var resultsType = await pokemonRepository.GetPokemonsType();

                // bring out the pokemon region 
                var resultsRegion = await pokemonRepository.GetPokemonsRegion();

                var results = await pokemonRepository.GetPokemons();
                return results.Select(data => new PokemonsModel
                {
                    Id = data.Id,
                    Name = data.Name,
                    ImagePath = data.ImagePath,
                    Region = resultsRegion.Single(dataRegion => dataRegion.Id == data.RegionId).NombreRegion,
                    Tipo1 = resultsType.Single(dataType1 => dataType1.Id == data.TipoId).TipoPokemon.ToString(),
                    Tipo2 = data.Tipo2Id == 0 ? "" :  resultsType.Single(dataType2 => dataType2.Id == data.Tipo2Id).TipoPokemon.ToString(),
                    RegionId = data.RegionId
                }).ToList();
            }
            catch(Exception ex)
            {
                return new List<PokemonsModel>();
            }

        }

        // get pokemon by id

        public async Task<SavePokemon> GetPokemonById(int id)
        {
            try
            {
                // bring out the pokemon tipo 
                var resultsType = await pokemonRepository.GetPokemonsType();

                // bring out the pokemon region 
                var resultsRegion = await pokemonRepository.GetPokemonsRegion();

                var results = await pokemonRepository.GetPokemonsById(id);

                return new SavePokemon
                {
                    Id = results.Id,
                    Name = results.Name,
                    ImagePath = results.ImagePath,
                    Region = resultsRegion.Single(dataRegion => dataRegion.Id == results.RegionId).Id,
                    Tipo1 = resultsType.Single(dataType1 => dataType1.Id == results.TipoId).Id,
                    Tipo2 = resultsType.Single(dataType2 => dataType2.Id == results.Tipo2Id).Id
                };
            }
            catch (Exception ex)
            {
                return new SavePokemon();
            }

        }
        // get pokemon with filter by region and name 
        public async Task<List<PokemonsModel>> GetPokemonFiltered(string pokemonName, int regionId)
        {
            try
            {
                // bring out the pokemon tipo 
                var resultsType = await pokemonRepository.GetPokemonsType();

                // bring out the pokemon region 
                var resultsRegion = await pokemonRepository.GetPokemonsRegion();

                var results = await pokemonRepository.GetPokemons();
                var filterd = results.Select(data => new PokemonsModel
                {
                    Id = data.Id,
                    Name = data.Name,
                    ImagePath = data.ImagePath,
                    Region = resultsRegion.Single(dataRegion => dataRegion.Id == data.RegionId).NombreRegion,
                    Tipo1 = resultsType.Single(dataType1 => dataType1.Id == data.TipoId).TipoPokemon.ToString(),
                    Tipo2 = data.Tipo2Id == 0 ? "" : resultsType.Single(dataType2 => dataType2.Id == data.Tipo2Id).TipoPokemon.ToString(),
                    RegionId = data.RegionId
                }).ToList();

                if(pokemonName != String.Empty)
                {
                    return filterd.Where(pokemon => pokemon.Name.Contains(pokemonName)).ToList();
                } else if (regionId != 0)
                {
                    return filterd.Where(pokemon => pokemon.RegionId == regionId).ToList();
                } else
                {
                    return filterd;
                }
            }
            catch (Exception ex)
            {
                return new List<PokemonsModel>();
            }

        }

        // get pokemon region by id
        public async Task<SavePokemonRegion> GetPokemonRegionById(int id)
        {
            try
            {
                var results = await pokemonRepository.GetPokemonRegionById(id);

                return new SavePokemonRegion
                {
                    Id= results.Id,
                    NombreRegion = results.NombreRegion
                };
            }
            catch (Exception ex)
            {
                return new SavePokemonRegion();
            }

        }

        // get pokemon type by id
        public async Task<SavePokemonType> GetPokemonTypeById(int id)
        {
            try
            {
                var results = await pokemonRepository.GetPokemonTypeById(id);

                return new SavePokemonType
                {
                    Id = results.Id,
                    TipoPokemon = results.TipoPokemon
                };
            }
            catch (Exception ex)
            {
                return new SavePokemonType();
            }

        }

        // get all pokemons regions 
        public async Task<List<Application.Models.PokemonRegion>> GetPokemonRegion()
        {
            try
            {
                var results = await pokemonRepository.GetPokemonsRegion();
                return results.Select(dataRegion => new Application.Models.PokemonRegion
                {
                    Id = dataRegion.Id,
                    NombreRegion = dataRegion.NombreRegion
                }).ToList();

            } catch(Exception ex)
            {
                return new List<Application.Models.PokemonRegion>();
            }
        }

        // get pokemon types 
        public async Task<List<Application.Models.PokemonTipo>> GetPokemonTypes()
        {
            try
            {
                var results = await pokemonRepository.GetPokemonsType();
                return results.Select(dataRegion => new Application.Models.PokemonTipo
                {
                    Id = dataRegion.Id,
                    TipoPokemon = dataRegion.TipoPokemon
                }).ToList();

            }
            catch (Exception ex)
            {
                return new List<Application.Models.PokemonTipo>();
            }
        }

        // create a new pokemon

        public async Task CreatePokemon(Application.Models.SavePokemon pokemon)
        {
            try
            {
                await pokemonRepository.CreateNewPokemon(pokemon);
            } catch (Exception ex)
            {
                throw;
            }
        }

        // create a new pokemon region
        public async Task CreatePokemonRegion(Application.Models.SavePokemonRegion pokemon)
        {
            try
            {
                await pokemonRepository.CreateNewPokemonRegion(pokemon);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // create a new pokemon type
        public async Task CreatePokemonType(Application.Models.SavePokemonType type)
        {
            try
            {
                await pokemonRepository.CreateNewPokemonType(type);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // update pokemon 

        public async Task UpdatePokemon(Application.Models.SavePokemon pokemon)
        {
            try
            {
                await pokemonRepository.UpdatePakemon(pokemon);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // update pokemon region

        public async Task UpdatePokemonRegion(Application.Models.SavePokemonRegion region)
        {
            try
            {
                await pokemonRepository.UpdatePokemonRegion(region);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // update pokemon type

        public async Task UpdatePokemonType(Application.Models.SavePokemonType type)
        {
            try
            {
                await pokemonRepository.UpdatePokemonType(type);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // delete pokemon

        public async Task DeletePokemon(int id)
        {
            try
            {
                var expPokemon = await pokemonRepository.GetPokemonsById(id);

                if(expPokemon != null)
                {
                    await pokemonRepository.DeletePokemon(expPokemon);
                }

            } catch(Exception ex)
            {
                throw;
            }
        }

        // delete pokemon region

        public async Task DeletePokemonRegion(int id)
        {
            try
            {
                var expPokemon = await pokemonRepository.GetPokemonRegionById(id);

                if (expPokemon != null)
                {
                    await pokemonRepository.DeletePokemonRegion(expPokemon);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        // delete pokemon type

        public async Task DeletePokemonType(int id)
        {
            try
            {
                var expPokemon = await pokemonRepository.GetPokemonTypeById(id);

                if (expPokemon != null)
                {
                    await pokemonRepository.DeletePokemonType(expPokemon);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
