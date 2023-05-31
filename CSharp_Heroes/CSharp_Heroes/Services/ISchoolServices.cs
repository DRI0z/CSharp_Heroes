using CSharp_Heroes.Models;

namespace CSharp_Heroes.Services
{
    public interface ISchoolServices
    {
        Task<List<School>> GetSchools();
        Task<School> GetSchoolById(int schoolId);
        Task<School> CreateSchool(School entity);
        Task<School> UpdateSchool(School entity);
        Task<string> DeleteSchool(int schoolId);
    }
}
