using Asset_Management_Sciforn.Data;

namespace Asset_Management_Sciforn.Repository.IRepository
{
    public interface IEmployeeRepository
    {
        Task<Employee> CreateAsync(Employee obj);
        Task<Employee> UpdateAsync(Employee obj);
        Task<bool> DeleteAsync(int id);
        Task<Employee> GetAsync(int id);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByEmailAsync(string email);

    }
}

