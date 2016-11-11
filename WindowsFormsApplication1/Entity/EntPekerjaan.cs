using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Entity
{
    class EntPekerjaan
    {
        private int kode;
        private string nama;
        private string keterangan;

        public void setKode(int kode)
        {
            this.kode = kode;
        }
        public int getKode()
        {
            return kode;
        }
        public void setNama(string nama)
        {
            this.nama = nama;
        }
        public string getNama()
        {
            return nama;
        }
        public void setKeterangan(string keterangan)
        {
            this.keterangan = keterangan;
        }
        public string getKeterangan()
        {
            return keterangan;
        }
    }
}
