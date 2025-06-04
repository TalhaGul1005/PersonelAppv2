using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using EntityLayer.DTOs;

namespace BusinessLayer.Abstract
{
     public interface IPTOService : IGenericService<PTO>
    {
        bool AddPTO(PTOCreateDto dto,out string m);
        void Delete (int id);
    }
}
