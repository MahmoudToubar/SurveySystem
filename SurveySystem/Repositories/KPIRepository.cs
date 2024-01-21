using Microsoft.EntityFrameworkCore;
using SurveySystem.Data;
using SurveySystem.Models;

namespace SurveySystem.Repositories
{
    public class KPIRepository : IKPIRepository
    {
        private readonly KPI_DbContext kpiDbContext;

        public KPIRepository(KPI_DbContext kpiDbContext) 
        {
            this.kpiDbContext = kpiDbContext;
        }
        public async Task<TblKPI> AddAsync(TblKPI kpi)
        {
            await kpiDbContext.TblKPI.AddAsync(kpi);
            await kpiDbContext.SaveChangesAsync();

            return kpi;
        }

        public async Task<TblKPI?> DeleteAsync(int id)
        {
            var existingKpi = await kpiDbContext.TblKPI.FindAsync(id);

            if (existingKpi != null)
            {
                kpiDbContext.TblKPI.Remove(existingKpi);
                await kpiDbContext.SaveChangesAsync();
                return existingKpi;
            }

            return null;
        }

        public async Task<IEnumerable<TblKPI>> GetAllAsync()
        {
            return await kpiDbContext.TblKPI.ToListAsync();
        }

        public Task<TblKPI?> GetAsync(int id)
        {
            return kpiDbContext.TblKPI.FirstOrDefaultAsync(x => x.KPIDNum == id);
        }

        public async Task<TblKPI?> UpdateAsync(TblKPI kpi)
        {
            var existingKpi = await kpiDbContext.TblKPI.FindAsync(kpi.KPIDNum);

            if (existingKpi != null)
            {
                existingKpi.KPIDescription = kpi.KPIDescription;
                existingKpi.DepNo = kpi.DepNo;
                existingKpi.TargetedValue = kpi.TargetedValue;
                existingKpi.MeasurementUnit = kpi.MeasurementUnit;

                await kpiDbContext.SaveChangesAsync();

                return existingKpi;
            }

            return null;
        }
    }
}
