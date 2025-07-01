using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Data.Entities;
using BLL.Repo;

namespace BLL.Services
{
    public class StaffService 
    {
        private readonly StaffRepository _staff;

        public StaffService(StaffRepository staff)
        {
            _staff = staff;
        }

        public bool CheckTCNo(long TcNo)
        {
            return _staff.AnyTCNo(TcNo);
        }

        public void Delete(int StaffId)
        {
            var delete = _staff.Find(StaffId);
            if (delete != null)
            {
                _staff.Delete(delete);
            }
        }

        public List<Staff> GetList()
        {
            return _staff.GetList();
        }

        public bool AddStaff(Staff t, out string m)
        {
            m = "";
            if (CheckTCNo(t.TCNo)) 
            {
                m = "Aynı TC sisteme kayıtlı.";
                return false; ;
            }
                

            int diff = DateOnly.FromDateTime(DateTime.Today).Year - t.StartTime.Year;
            if (diff < 0)
            {
                m = "Başlangıç tarihi bugünden büyük olamaz. ";
                return false;
            }
            else if (diff == 0)
            {
                t.LastYear = 0;
                t.ThisYear = 0;
            }
            else if (diff >= 1 && diff <= 9)
            {
                t.LastYear = 0;
                t.ThisYear = 20;
            }
            else
            {
                t.LastYear = 0;
                t.ThisYear = 30;
            }

            _staff.Insert(t);
            m = "Kişi başarıyla eklendi.";
            return true;

        }

        public void TDelete(Staff t)
        {
            throw new NotImplementedException();
        }

        public Staff TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Staff t)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Staff t)
        {
            throw new NotImplementedException();
        }
    }
}
