// using Dapper;
// using Asset_Management_Sciforn.Data;
// using Asset_Management_Sciforn.Repository.IRepository;
// using System.Data;

// namespace Asset_Management_Sciforn.Repository
// {
//     public class DapperAssetAssignedQueries : IAssetAssignedQueries
//     {
//         private readonly IDbConnection db;
//         private readonly IWebHostEnvironment webHostEnvironment;

//         public DapperAssetAssignedQueries(IDbConnection db)
//         {
//             this.db = db;
//             this.webHostEnvironment = webHostEnvironment;
//         }

//         public async Task<int> GetTotalAssetsAsync()
//         {
//             var sql = @"SELECT COUNT(*) FROM Asset;";
//             return await db.ExecuteScalarAsync<int>(sql);
//         }

//         public async Task<IEnumerable<Asset>> GetAssetsByTypeAsync(string type)
//         {
//             var sql = @"SELECT * FROM Asset WHERE AssetType = @Type;";
//             return await db.QueryAsync<Asset>(sql, new { Type = type });
//         }

//         public async Task<IEnumerable<Asset>> GetAssignedAssetsAsync()
//         {
//             var sql = @"SELECT a.* 
//                         FROM Asset a
//                         INNER JOIN AssetAssigned aa ON a.Id = aa.AssetId;";
//             return await db.QueryAsync<Asset>(sql);
//         }

//         public async Task<IEnumerable<Asset>> GetAvailableAssetsAsync()
//         {
//             var sql = @"SELECT * FROM Asset WHERE AssetStatusId = 
//                        (SELECT Id FROM AssetStatus WHERE StatusName = 'Available');";
//             return await db.QueryAsync<Asset>(sql);
//         }

//         public async Task<IEnumerable<Asset>> GetUnderRepairAssetsAsync()
//         {
//             var sql = @"SELECT * FROM Asset WHERE AssetStatusId = 
//                        (SELECT Id FROM AssetStatus WHERE StatusName = 'Under Repair');";
//             return await db.QueryAsync<Asset>(sql);
//         }

//         public async Task<IEnumerable<Asset>> GetRetiredAssetsAsync()
//         {
//             var sql = @"SELECT * FROM Asset WHERE AssetStatusId = 
//                        (SELECT Id FROM AssetStatus WHERE StatusName = 'Retired');";
//             return await db.QueryAsync<Asset>(sql);
//         }

//         public async Task<IEnumerable<Asset>> GetSpareAssetsAsync()
//         {
//             var sql = @"SELECT * FROM Asset WHERE IsSpare = 1;";
//             return await db.QueryAsync<Asset>(sql);
//         }
//     }
// }
