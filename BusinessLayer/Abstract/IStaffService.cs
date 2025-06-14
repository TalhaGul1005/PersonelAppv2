﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IStaffService : IGenericService<Staff>
    {
        bool CheckTCNo(long TcNo);
        void Delete(int StaffId);
        bool AddStaff(Staff t, out string m);
    }
}
