using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.Rest;

namespace BusinessLayer.Concrete
{
    public class StaffManager : IStaffService
    {
        IStaffDal _staffDal;

        public StaffManager(IStaffDal staffDal)
        {
            _staffDal = staffDal;
        }

        public bool CheckTCNo(long TcNo)
        {
            return _staffDal.AnyTCNo(TcNo);
        }

        public void Delete(int StaffId)
        {
            var delete = _staffDal.Find(StaffId);
            if (delete != null)
            {
                _staffDal.Delete(delete);
            }
        }

        public List<Staff> GetList()
        {
            return _staffDal.GetList();
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

            _staffDal.Insert(t);
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
