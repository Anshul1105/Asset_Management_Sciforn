using Microsoft.EntityFrameworkCore;
using Asset_Management_Sciforn.Data;
using Asset_Management_Sciforn.Repository.IRepository;

namespace Asset_Management_Sciforn.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Employee> CreateAsync(Employee obj)
        {
            await _db.Employee.AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<Employee> UpdateAsync(Employee obj)
        {
            var objFromDb = await _db.Employee.FirstOrDefaultAsync(e => e.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.FullName = obj.FullName;
                objFromDb.Email = obj.Email;
                objFromDb.PhoneNumber = obj.PhoneNumber;
                objFromDb.Department = obj.Department;
                objFromDb.Designation = obj.Designation;
                objFromDb.IsActive = obj.IsActive;

                _db.Employee.Update(objFromDb);
                await _db.SaveChangesAsync();
                return objFromDb;
            }
            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await _db.Employee.FirstOrDefaultAsync(e => e.Id == id);
            if (obj != null)
            {
                obj.IsActive = false;
                _db.Employee.Update(obj);
                // _db.Employee.Remove(obj);
                return (await _db.SaveChangesAsync()) > 0;
            }
            return false;
        }

        public async Task<Employee> GetAsync(int id)
        {
            var obj = await _db.Employee
                                .Include(e => e.AssetAssignments)
                                .FirstOrDefaultAsync(e => e.Id == id);

            return obj ?? new Employee
            {
                FullName = string.Empty,
                Department = string.Empty,
                Email = string.Empty,
                PhoneNumber = string.Empty,
                Designation = string.Empty,
                IsActive = false
            };
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _db.Employee
                            .Where(x => x.IsActive)
                            .Include(e => e.AssetAssignments) 
                            .ToListAsync();
        }
        public async Task<Employee?> GetByEmailAsync(string email)
        {
            return await _db.Employee.FirstOrDefaultAsync(e => e.Email == email);
        }

    }
}
