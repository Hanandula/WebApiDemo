namespace Repository;
using Contracts;
using Entity;
using System.Collections.Generic;
// contains the main business logic of the system

public class EmployeeRepository : IEmployee
{
    //
    private readonly EmployeeDbContext _dbContext;
    // constructor
    public EmployeeRepository(EmployeeDbContext dbContext)
    {

        _dbContext = dbContext;

    }
    public int Create(Employee employee)
    {
        _dbContext.Employees.Add(employee);
        _dbContext.SaveChanges();
        return employee.id;
    }

    public List<Employee> GetAll()
    {
        return _dbContext.Employees.ToList();
    }

    public async Task<Employee> GetEmployee(int id)
    
        {
            if (_dbContext.Employees == null)
            {
                return null;
            }
            var employee = await _dbContext.Employees.FindAsync(id);

            if (employee == null)
            {
                return null;
            }

            return employee;
        }
     public async Task<int> Delete(int id)
    {
        if (_dbContext.Employees==null)
        {
            return 0;
        }
        var employee = await _dbContext.Employees.FindAsync(id);
        if (employee==null)
        {
            return 0;
        }
        _dbContext.Employees.Remove(employee);
        _dbContext.SaveChanges();
        return employee.id;
    }
    public bool PutEmployee(int id, Employee employee)
    {
        var existing = _dbContext.Employees.Find(id);
        if(id == employee.id)
        {
            existing.fname = employee.fname;
            existing.lname = employee.lname;
            existing.address = employee.address;
            _dbContext.Employees.Update(existing);
            _dbContext.SaveChanges();
            return true;
        }
        return false;
    }
}