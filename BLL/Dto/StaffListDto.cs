using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Data.Entities;

namespace BLL.Dto
{
    public class StaffListDto
    {
        public int Id;

        public List<Staff> StaffList { get; set; }
        public List<Department> DepartmentList { get; set; }
    }
}
