using CSharp_Heroes.Context;
using CSharp_Heroes.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharp_Heroes.Services
{
    public class SchoolServices : ISchoolServices
    {
        public readonly ApplicationDbContext _context;

        public SchoolServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<School> CreateSchool(School entity)
        {
            _context.Set<School>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<School>> GetSchools()
        {
            return await _context.Schools.ToListAsync();
        }
        public async Task<School> GetSchoolById(int schoolId)
        {
            return await _context.Schools.Where(h => h.Id == schoolId).FirstOrDefaultAsync();
        }

        public async Task<School> UpdateSchool(School entity)
        {
            _context.Set<School>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<string> DeleteSchool(int schoolId)
        {
            try
            {
                var entity = await _context.Set<School>().FindAsync(schoolId);
                if (entity == null)
                {
                    throw new Exception($"L'entité {typeof(School).Name} #{schoolId} n'existe pas.");
                }

                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync();

                return $"L'entité {typeof(School).Name} #{schoolId} a bien été supprimé.";
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"L'entité {typeof(School).Name} #{schoolId} n'a pas pu être supprimé.");
            }
        }
    }
}
