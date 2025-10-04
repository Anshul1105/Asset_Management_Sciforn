using Asset_Management_Sciforn.Data;

namespace Asset_Management_Sciforn.Repository.IRepository
{
    public interface IAssetAssignedRepository
    {
        // EF Core CRUD
        Task<AssetAssigned> CreateAsync(AssetAssigned obj);
        Task<AssetAssigned> UpdateAsync(AssetAssigned obj);
        Task<bool> DeleteAsync(int id);
        Task<AssetAssigned?> GetAsync(int id);
        Task<IEnumerable<AssetAssigned>> GetAllAsync();
    }

    public interface IAssetAssignedQueries
    {
        // Dapper Filters / Reporting
        Task<int> GetTotalAssetsAsync();
        Task<IEnumerable<Asset>> GetAssetsByTypeAsync(string type);
        Task<IEnumerable<Asset>> GetAssignedAssetsAsync();
        Task<IEnumerable<Asset>> GetAvailableAssetsAsync();
        Task<IEnumerable<Asset>> GetUnderRepairAssetsAsync();
        Task<IEnumerable<Asset>> GetRetiredAssetsAsync();
        Task<IEnumerable<Asset>> GetSpareAssetsAsync();
    }
}
