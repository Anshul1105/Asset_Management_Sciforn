using Asset_Management_Sciforn.Data;
using Asset_Management_Sciforn.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Asset_Management_Sciforn.Repository
{
    public class AssetAssignedRepository : IAssetAssignedRepository
    {
        private readonly ApplicationDbContext _db;

        public AssetAssignedRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<AssetAssigned> CreateAsync(AssetAssigned obj)
        {
            await _db.AssetAssigned.AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<AssetAssigned> UpdateAsync(AssetAssigned obj)
        {
            var existing = await _db.AssetAssigned.FirstOrDefaultAsync(a => a.Id == obj.Id);
            if (existing != null)
            {
                existing.AssetId = obj.AssetId;
                existing.EmployeeId = obj.EmployeeId;
                existing.AssignedDate = obj.AssignedDate;

                _db.AssetAssigned.Update(existing);
                await _db.SaveChangesAsync();
                return existing;
            }
            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await _db.AssetAssigned.FirstOrDefaultAsync(a => a.Id == id);
            if (obj != null)
            {
                _db.AssetAssigned.Remove(obj);
                return (await _db.SaveChangesAsync()) > 0;
            }
            return false;
        }

        public async Task<AssetAssigned?> GetAsync(int id)
        {
            return await _db.AssetAssigned
                .Include(a => a.Asset)
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<AssetAssigned>> GetAllAsync()
        {
            return await _db.AssetAssigned
                .Include(a => a.Asset)
                .Include(a => a.Employee)
                .ToListAsync();
        }

        public Task<IEnumerable<AssetAssigned>> SearchAsync(int? employeeId = null, int? assetId = null)
        {
            // var query = _db.AssetAssigned
            //     .Include(a => a.Asset)
            //     .Include(a => a.Employee)
            //     .AsQueryable();
            // if (employeeId.HasValue)
            // {
            //     query = query.Where(a => a.EmployeeId == employeeId.Value);
            // }
            // if (assetId.HasValue)
            // {
            //     query = query.Where(a => a.AssetId == assetId.Value);
            // }
            // return Task.FromResult(query.AsEnumerable());
            throw new NotImplementedException();
        }
    }
}
