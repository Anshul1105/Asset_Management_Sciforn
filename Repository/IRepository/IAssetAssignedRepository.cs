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
        Task<IEnumerable<AssetAssigned>> SearchAsync(int? employeeId = null, int? assetId = null);
    }

}
