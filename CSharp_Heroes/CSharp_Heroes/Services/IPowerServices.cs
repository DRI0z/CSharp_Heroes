using CSharp_Heroes.Models;

namespace CSharp_Poweres.Services
{
    public interface IPowerServices 
    {
        Task<List<Power>> GetPowers();
        Task<Power> GetPowerById(int powerId);
        Task<Power> CreatePower(Power entity);
        Task<Power> UpdatePower(Power entity);
        Task<string> DeletePower(int powerId);
    }
}
