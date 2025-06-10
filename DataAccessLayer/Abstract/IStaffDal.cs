using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using EntityLayer.DTOs;

namespace DataAccessLayer.Abstract
{
    public interface IStaffDal:IGenericDal<Staff>
    {
        bool AnyTCNo(long TCNo);
        Staff GetById(int id);
        void Delete(Staff s);
        Staff Find(int id);

    }
}
