using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Data.Entities;
using BLL.Dto;
using BLL.Repo;

namespace BLL.Services
{
    public class PTOService
    {
        private readonly PTORepository _pto;
        private readonly StaffRepository _staff;

        public PTOService (PTORepository pto, StaffRepository staff)
        {
            _pto = pto;
            _staff = staff;
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

            var staff = _staff.GetById(t.StaffId);

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

            _pto.Insert(t);
            _staff.Update(staff);

            m = "İzin başarıyla eklendi.";
            return true;

            
        }

        public void Delete(int id)
        {
            var delete = _pto.Find(id);
            var staff = _staff.Find(delete.StaffId);
            
            

            if (staff != null)
            {
                staff.ThisYear = staff.ThisYear + delete.Usedleave;
                _pto.Delete(delete);
            }
            

        }

        public List<PTO> GetList()
        {
            return _pto.GetList();
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
