
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Contracts;
using Entity;
namespace Repository;



    public class DepartmentRepository: IDepartment
    { 
    private readonly EmployeeDbContext _dbContext;
    // constructor
    public DepartmentRepository(EmployeeDbContext dbContext)
    {

        _dbContext = dbContext;

    }
    public int Create(Department department)
    {
        _dbContext.Departments.Add(department);
        _dbContext.SaveChanges();
        return department.id;
    }

    public List<Department> GetAll()
    {
        return _dbContext.Departments.ToList();
    }

    public async Task<Department> GetDepartment(int id)

    {
        if (_dbContext.Departments == null)
        {
            return null;
        }
        var department = await _dbContext.Departments.FindAsync(id);

        if (department == null)
        {
            return null;
        }

        return department;
    }
    public async Task<int> Delete(int id)
    {
        if (_dbContext.Departments == null)
        {
            return 0;
        }
        var department = await _dbContext.Departments.FindAsync(id);
        if (department == null)
        {
            return 0;
        }
        _dbContext.Departments.Remove(department);
        _dbContext.SaveChanges();
        return department.id;
    }
    public bool PutDepartment(int id, Department department)
    {
        var existing = _dbContext.Departments.Find(id);
        if (id == department.id)
        {
            existing.name = department.name;
            _dbContext.Departments.Update(existing);
            _dbContext.SaveChanges();
            return true;
        }
        return false;
    }
}

