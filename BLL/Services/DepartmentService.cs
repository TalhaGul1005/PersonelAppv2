using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Data.Entities;
using BLL.Repo;

namespace BLL.Services
{
    public class DepartmentService 
    {
        private readonly DepartmentRepository _department;
        public DepartmentService(DepartmentRepository department)
        {
            _department = department;
        }
        public List<Department> GetList()
        {
            return _department.GetList();
        }

        public void TAdd(Department t)
        {
            _department.Insert(t);
        }

        public void TDelete(Department t)
        {
            _department.Delete(t);
        }

        public Department TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Department t)
        {
            _department.Update(t);
        }
    }
}
