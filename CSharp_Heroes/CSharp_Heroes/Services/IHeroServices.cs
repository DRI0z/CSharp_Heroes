using CSharp_Heroes.Models;

namespace CSharp_Heroes.Services
{
    public interface IHeroServices
    {
        Task<List<Hero>> GetHeroes();
        Task<Hero> GetHeroById(int heroId);
        Task<Hero> CreateHero(Hero entity); 
        Task<Hero> UpdateHero(Hero entity); 
        Task<string> DeleteHero(int heroId); 
         
    }
}
