using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Data.Entities
{
    
    public class PTO
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public int Usedleave { get; set; }
        public int StaffId { get; set; }
        public Staff Staff { get; set; }

    }
}
