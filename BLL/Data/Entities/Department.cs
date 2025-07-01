using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Data.Entities;

namespace BLL.Data.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentUnitId { get; set; }
        public Department? ParentUnit { get; set; }
        public EnumDepartment EnumDepartment { get; set; }
        public ICollection<Department> Children { get; set; }
    }
}
