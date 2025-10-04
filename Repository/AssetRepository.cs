using Microsoft.EntityFrameworkCore;
using Asset_Management_Sciforn.Data;
using Asset_Management_Sciforn.Repository.IRepository;

namespace Asset_Management_Sciforn.Repository
{
    public class AssetRepository : IAssetRepository
    {
        private readonly ApplicationDbContext _db;

        public AssetRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Asset> CreateAsync(Asset obj)
        {
            await _db.Asset.AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<Asset> UpdateAsync(Asset obj)
        {
            var objFromDb = await _db.Asset.FirstOrDefaultAsync(a => a.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.AssetType = obj.AssetType;
                objFromDb.MakeModel = obj.MakeModel;
                objFromDb.SerialNumber = obj.SerialNumber;
                objFromDb.PurchaseDate = obj.PurchaseDate;
                objFromDb.WarrantyExpiryDate = obj.WarrantyExpiryDate;
                objFromDb.AssetConditionId = obj.AssetConditionId;
                objFromDb.AssetStatusId = obj.AssetStatusId;
                objFromDb.IsSpare = obj.IsSpare;
                objFromDb.Specifications = obj.Specifications;

                _db.Asset.Update(objFromDb);
                await _db.SaveChangesAsync();
                return objFromDb;
            }
            return obj; // return original object if not found
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await _db.Asset.FirstOrDefaultAsync(a => a.Id == id);
            if (obj != null)
            {
                _db.Asset.Remove(obj);
                return (await _db.SaveChangesAsync()) > 0;
            }
            return false;
        }

        public async Task<Asset> GetAsync(int id)
        {
            var obj = await _db.Asset
                            .Include(a => a.AssetCondition)
                            .Include(a => a.AssetStatus)
                            .Include(a => a.AssetAssignments)
                            .FirstOrDefaultAsync(a => a.Id == id);

            return obj ?? new Asset(); // Return new instance if not found
        }

        public async Task<IEnumerable<Asset>> GetAllAsync()
        {
            return await _db.Asset
                            .Include(a => a.AssetCondition)
                            .Include(a => a.AssetStatus)
                            .Include(a => a.AssetAssignments)
                            .ToListAsync();
        }
    }
}
