using NeemDataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeemDataAccess.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployee();

        Employee GetEmployeeByID(int employeeId);

        void InsertEmployee(Employee employee);

        void DeleteEmployee(int employeeID);

        void UpdateEmployee(Employee employee);

        void Save();
    }
}
