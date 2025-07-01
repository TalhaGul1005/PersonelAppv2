using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dto
{
    public class PTOCreateDto
    {
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public int StaffId { get; set; }
    }
}
