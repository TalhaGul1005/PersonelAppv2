using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Data.Entities
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(10000000000, 99999999999)]
        public long TCNo { get; set; }
        public string Name { get; set; }
        public string SirName { get; set; }
        public DateOnly StartTime  { get; set; }
        public int LastYear { get; set; }
        public int ThisYear { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
