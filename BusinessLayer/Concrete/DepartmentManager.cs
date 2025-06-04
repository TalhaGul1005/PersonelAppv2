using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        IDepartmentDal _departmentDal;
        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }
        public List<Department> GetList()
        {
            return _departmentDal.GetList();
        }

        public void TAdd(Department t)
        {
            _departmentDal.Insert(t);
        }

        public void TDelete(Department t)
        {
            _departmentDal.Delete(t);
        }

        public Department TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Department t)
        {
            _departmentDal.Update(t);
        }
    }
}
