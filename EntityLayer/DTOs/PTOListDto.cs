﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace EntityLayer.DTOs
{
    public class PTOListDto
    {
        public List<PTO> PTOList { get; set; }
        public List<Staff> StaffList { get; set; }
    }
}
