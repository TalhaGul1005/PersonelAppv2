using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Data.Entities;

namespace BLL.Dto
{
    public class PTOListDto
    {
        public List<PTO> PTOList { get; set; }
        public List<Staff> StaffList { get; set; }
    }
}
