using NeemDataAccess.Interfaces;
using NeemDataModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeemDataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {
        private readonly NeemDBContext dbContext;

        public EmployeeRepository(NeemDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void DeleteEmployee(int employeeID)
        {
            var contact = dbContext.Employees.Find(employeeID);
            dbContext.Employees.Remove(contact);
        }


        public IEnumerable<Employee> GetEmployee()
        {
            return dbContext.Employees.ToList();
        }

        public Employee GetEmployeeByID(int employeeId)
        {
            return dbContext.Employees.Find(employeeId);
        }

        public void InsertEmployee(Employee employee)
        {
            dbContext.Employees.Add(employee);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            dbContext.Entry(employee).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
