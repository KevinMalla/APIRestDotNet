using APIRest.Interfaces;
using APIRest.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace APIRest.Controllers
{
    public class JokeController : ApiController
    {
        private readonly string ChuckApiUrl = "https://api.chucknorris.io/jokes/random";
        private readonly string DadJokeApiUrl = "https://icanhazdadjoke.com/";

        private readonly IJokeDataService _jokeDataService;

        public JokeController(IJokeDataService jokeDataService)
        {
            _jokeDataService = jokeDataService;
        }

        public async Task<IHttpActionResult> Get(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                return await GetRandomJoke();
            }

            if (type.Equals("Chuck", StringComparison.OrdinalIgnoreCase))
            {
                // Si el tipo es "Chuck", obtener un chiste de Chuck Norris
                return await GetChuckNorrisJoke();
            }

            if (type.Equals("Dad", StringComparison.OrdinalIgnoreCase))
            {
                // Si el tipo es "Dad", obtener un chiste de papá
                return await GetDadJoke();
            }

            // Si el tipo no es ni "Chuck" ni "Dad", devolver un error correspondiente
            return BadRequest("El valor del parámetro 'tipo' debe ser 'Chuck' o 'Dad'.");
        }

        private async Task<IHttpActionResult> GetChuckNorrisJoke()
        {
            // Lógica para obtener un chiste de Chuck Norris del API
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(ChuckApiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    ChuckNorrisJoke chuckNorrisJoke = JsonConvert.DeserializeObject<ChuckNorrisJoke>(responseContent);

                    return Ok(chuckNorrisJoke.Value);
                }
                else
                {
                    return InternalServerError(); // Manejar error en la obtención del chiste
                }
            }
        }

        private async Task<IHttpActionResult> GetDadJoke()
        {
            // Lógica para obtener un chiste de papá del API
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                HttpResponseMessage response = await client.GetAsync(DadJokeApiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    DadJoke dadJoke = JsonConvert.DeserializeObject<DadJoke>(responseContent);

                    return Ok(dadJoke.Joke);
                }
                else
                {
                    return InternalServerError(); // Manejar error en la obtención del chiste
                }
            }
        }

        private async Task<IHttpActionResult> GetRandomJoke()
        {
            // Obtener chiste aleatoriamente
            Random random = new Random();

            bool seleccionarChisteDeChuck = random.Next(2) == 0;

            if (seleccionarChisteDeChuck)
            {
                return await GetChuckNorrisJoke();
            }
            else
            {
                return await GetDadJoke();
            }
        }

        public async Task<IHttpActionResult> Post([FromBody] string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return BadRequest("El valor del parámetro texto no puede estar vacío");
            }

            try
            {
                await _jokeDataService.InsertJoke(texto);

                return Ok("Chiste guardado correctamente");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public async Task<IHttpActionResult> Put(int? number, [FromBody] string texto)
        {
            if (!number.HasValue || number == 0)
            {
                return BadRequest("El valor del parámetro texto no puede ser null o 0");
            }

            try
            {
                await _jokeDataService.UpdateJoke(number.Value, texto);

                return Ok("Chiste actualizado correctamente");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public async Task<IHttpActionResult> Delete(int? number)
        {
            // Comprobar valor de number
            if (!number.HasValue || number == 0)
            {
                return BadRequest("El valor del parámetro texto no puede ser null o 0");
            }

            try
            {
                await _jokeDataService.DeleteJoke(number.Value);

                return Ok("Chiste eliminado correctamente");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}