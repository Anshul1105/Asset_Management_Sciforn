using Asset_Management_Sciforn.Data;

namespace Asset_Management_Sciforn.Repository.IRepository
{
    public interface IAssetRepository
    {
        Task<Asset> CreateAsync(Asset obj);
        Task<Asset> UpdateAsync(Asset obj);
        Task<bool> DeleteAsync(int id);
        Task<Asset> GetAsync(int id);
        Task<IEnumerable<Asset>> GetAllAsync();
        Task<IEnumerable<Asset>> GetAllAvailableAssetAsync();
        Task<IEnumerable<Asset>> GetFilteredAssetsAsync(string? statusName = null, string? conditionName = null, bool? isSpare = null);
        Task<bool> UpdateAssetStatusAsync(int assetId, string statusName);
    }
}

