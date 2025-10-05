using Microsoft.EntityFrameworkCore;
using Asset_Management_Sciforn.Data;
using Asset_Management_Sciforn.Repository.IRepository;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;

namespace Asset_Management_Sciforn.Repository
{
    public class AssetRepository : IAssetRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IDbConnection db;

        private readonly IWebHostEnvironment webHostEnvironment;

        public AssetRepository(ApplicationDbContext _db, IDbConnection db, IWebHostEnvironment webHostEnvironment)
        {
            this._db = _db;
            this.db = db;
            this.webHostEnvironment = webHostEnvironment;

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
            return obj;
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

            return obj ?? new Asset();
        }

        public async Task<IEnumerable<Asset>> GetAllAsync()
        {
            return await _db.Asset
                            .Include(a => a.AssetCondition)
                            .Include(a => a.AssetStatus)
                            .Include(a => a.AssetAssignments)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Asset>> GetFilteredAssetsAsync(string? statusName = null, string? conditionName = null, bool? isSpare = null)
        {
            string sql = @"
                            SELECT *
                            FROM Asset a
                            WHERE 
                                (@statusName IS NULL OR a.AssetStatusId IN (SELECT Id FROM AssetStatus WHERE StatusName = @statusName))
                                AND (@conditionName IS NULL OR a.AssetConditionId IN (SELECT Id FROM AssetCondition WHERE ConditionName = @conditionName))
                                AND (@isSpare IS NULL OR a.IsSpare = @isSpare)
                            ";

            var assets = await db.QueryAsync<Asset>(
                sql,
                new { statusName, conditionName, isSpare }
            );

            return assets;
        }

        public async Task<IEnumerable<Asset>> GetAllAvailableAssetAsync()
        {
            string sql = @"
                            SELECT a.*
                            FROM Asset a
                            INNER JOIN AssetStatus s ON a.AssetStatusId = s.Id
                            WHERE s.StatusName = 'Available'
                        ";

            return await db.QueryAsync<Asset>(sql);

        }

        public async Task<bool> UpdateAssetStatusAsync(int assetId, string statusName)
        {

            string sql = @"
                            UPDATE a
                            SET a.AssetStatusId = s.Id
                            FROM Asset a
                            INNER JOIN AssetStatus s ON s.StatusName = @statusName
                            WHERE a.Id = @assetId
                        ";

            int rows = await db.ExecuteAsync(sql, new { assetId, statusName });
            return rows > 0;
        }
    }
}
