using CSharp_Heroes.Context;
using CSharp_Heroes.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CSharp_Heroes.Services
{
    public class HeroServices : IHeroServices
    {
        public readonly ApplicationDbContext _context;

        public HeroServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Hero> CreateHero(Hero entity)
        {
            _context.Set<Hero>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Hero>> GetHeroes()
        {
            return await _context.Heroes.ToListAsync();
        }
        public async Task<Hero> GetHeroById(int heroId)
        {
            return await _context.Heroes.Where(h => h.Id == heroId).FirstOrDefaultAsync();
        }

        public async Task<Hero> UpdateHero(Hero entity)
        {           
            _context.Set<Hero>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;            
        }
        public async Task<string> DeleteHero(int heroId)
        {
            try
            {
                var entity = await _context.Set<Hero>().FindAsync(heroId);
                if (entity == null)
                {
                    throw new Exception($"L'entité {typeof(Hero).Name} #{heroId} n'existe pas.");
                }

                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync();

                return $"L'entité {typeof(Hero).Name} #{heroId} a bien été supprimé.";
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"L'entité {typeof(Hero).Name} #{heroId} n'a pas pu être supprimé.");
            }
        }
    }
}
