using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IPTODal:IGenericDal<PTO>
    {
        PTO Find(int id);
        void Delete(PTO p);
    }
}
