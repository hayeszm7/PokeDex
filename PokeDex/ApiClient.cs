using PokeDex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PokeDex
{
    public class ApiClient
    {
        public HttpClient Client { get; set; }
        public ApiClient(HttpClient client) 
        {
           this.Client = client;
        }

        public async Task<Pokemon> GetPokemon(string id)

        {
            var response = await Client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{id}");
            var content  = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Pokemon>(content);
        }
    }
}
