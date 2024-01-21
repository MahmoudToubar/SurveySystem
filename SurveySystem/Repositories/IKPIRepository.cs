using SurveySystem.Models;

namespace SurveySystem.Repositories
{
    public interface IKPIRepository
    {
        Task<IEnumerable<TblKPI>> GetAllAsync();

        Task<TblKPI?> GetAsync(int id);

        Task<TblKPI> AddAsync(TblKPI kpi);

        Task<TblKPI?> UpdateAsync(TblKPI kpi);

        Task<TblKPI?> DeleteAsync(int id);
    }
}
