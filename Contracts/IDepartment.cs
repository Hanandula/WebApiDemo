using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDepartment
    {
       
            public int Create(Department department);
            public List<Department> GetAll();
            public Task<int> Delete(int id);

            public Task<Department> GetDepartment(int id);
            public bool PutDepartment(int id, Department department);
        }
    }

