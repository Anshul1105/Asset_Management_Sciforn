using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asset_Management_Sciforn.Data
{
    public interface IAssetStatusRepository
    {
        Task<AssetStatus?> GetByIdAsync(int id);
        Task<IEnumerable<AssetStatus>> GetAllAsync();
    }
}
