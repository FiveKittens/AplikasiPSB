using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Interface
{
    interface intPekerjaan
    {
        Boolean insertPekerjaan(Entity.EntPekerjaan e);
        Boolean updatePekerjaan(Entity.EntPekerjaan e);
        Boolean deletePekerjaan(int kode);
        int kodeBaru();
        DataSet getData();
    }
}
