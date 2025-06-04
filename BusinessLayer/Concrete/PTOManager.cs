using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;

namespace BusinessLayer.Concrete
{
    public class PTOManager:IPTOService
    {
        private readonly IPTODal _ptoDal;
        private readonly IStaffDal _staffDal;

        public PTOManager (IPTODal ptoDal, IStaffDal staffDal)
        {
            _ptoDal = ptoDal;
            _staffDal = staffDal;
        }
        public bool AddPTO(PTOCreateDto dto, out string m)
        {
            m = "";

            PTO t = new PTO
            {
                StaffId = dto.StaffId,
                StartTime = dto.StartTime,
                FinishTime = dto.FinishTime
            };

            int diff = (t.FinishTime - t.StartTime).Days + 1;
            t.Usedleave = diff;

            var staff = _staffDal.GetById(t.StaffId);

            if (diff < 0)
            {
                m = "Başlangıç bitiş tarihinden küçük olamaz.";
                return false;
            }

            int pto = staff.LastYear + staff.ThisYear;

            if (pto < t.Usedleave) 
            {
                m = "Yıllık izin yetersiz.";
                return false;
            }

            staff.LastYear -= t.Usedleave;
            if(staff.LastYear < 0)
            {
                int diff2 = -staff.LastYear;
                staff.LastYear = 0;
                staff.ThisYear -= diff2;
            }

            _ptoDal.Insert(t);
            _staffDal.Update(staff);

            m = "İzin başarıyla eklendi.";
            return true;

            
        }

        public void Delete(int id)
        {
            var delete = _ptoDal.Find(id);
            var staff = _staffDal.Find(delete.StaffId);
            
            

            if (staff != null)
            {
                staff.ThisYear = staff.ThisYear + delete.Usedleave;
                _ptoDal.Delete(delete);
            }
            

        }

        public List<PTO> GetList()
        {
            return _ptoDal.GetList();
        }

        public void TAdd(PTO t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(PTO t)
        {
            throw new NotImplementedException();
        }

        public PTO TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(PTO t)
        {
            throw new NotImplementedException();
        }

        
    }
}
