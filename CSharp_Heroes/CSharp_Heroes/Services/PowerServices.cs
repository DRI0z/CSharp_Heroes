using CSharp_Heroes.Context;
using CSharp_Heroes.Models;
using CSharp_Heroes.Services;
using Microsoft.EntityFrameworkCore;

namespace CSharp_Poweres.Services
{
    public class PowerServices : IPowerServices
    {
        public readonly ApplicationDbContext _context;

        public PowerServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Power> CreatePower(Power entity)
        {
            _context.Set<Power>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Power>> GetPowers()
        {
            return await _context.Powers.ToListAsync();
        }
        public async Task<Power> GetPowerById(int powerId)
        {
            return await _context.Powers.Where(h => h.Id == powerId).FirstOrDefaultAsync();
        }

        public async Task<Power> UpdatePower(Power entity)
        {
            _context.Set<Power>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<string> DeletePower(int powerId)
        {
            try
            {
                var entity = await _context.Set<Power>().FindAsync(powerId);
                if (entity == null)
                {
                    throw new Exception($"L'entité {typeof(Power).Name} #{powerId} n'existe pas.");
                }

                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync();

                return $"L'entité {typeof(Power).Name} #{powerId} a bien été supprimé.";
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"L'entité {typeof(Power).Name} #{powerId} n'a pas pu être supprimé.");
            }
        }
    }
}
