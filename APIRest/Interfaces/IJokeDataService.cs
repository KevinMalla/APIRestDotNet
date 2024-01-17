using APIRest.Models;
using System.Threading.Tasks;

namespace APIRest.Interfaces
{
    public interface IJokeDataService
    {
        Task<string> InsertJoke(string jokeBody);

        Task<bool> UpdateJoke(int jokeId, string jokeText);

        Task<bool> DeleteJoke(int jokeId);
    }
}
