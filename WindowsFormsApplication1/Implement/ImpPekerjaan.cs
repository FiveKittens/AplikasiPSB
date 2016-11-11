using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace WindowsFormsApplication1.Implement
{
    class ImpPekerjaan : Interface.intPekerjaan
    {
        private string query;
        private Boolean status;
        private MySqlConnection koneksi;
        private MySqlCommand command;

        public ImpPekerjaan()
        {
            koneksi = KoneksiDB.Koneksi.getKoneksi();
        }

        //Insert Data
        public Boolean insertPekerjaan(Entity.EntPekerjaan e)
        {
            status = false;
            try
            {
                query = "INSERT INTO tb_pekerjaan VALUES ('" + e.getKode() + e.getNama() + e.getKeterangan() + "')";
                koneksi.Open();
                command = new MySqlCommand();
                command.Connection = koneksi;
                command.CommandText = query;
                command.ExecuteNonQuery();
                status = true;
                koneksi.Close();
            }
            catch (MySqlException)
            {
                Console.WriteLine("ERROR!!!");
            }
            return status;
        }

        //Update Pekerjaan
        public Boolean updatePekerjaan(Entity.EntPekerjaan e)
        {
            status = false;
            try
            {
                query = "UPDATE tb_pekerjaan SET nama='" + e.getNama() + "', keterangan='" + e.getKeterangan() + "', WHERE id_kerja='" + e.getKode() + "'";
                koneksi.Open();
                command = new MySqlCommand();
                command.Connection = koneksi;
                command.CommandText = query;
                command.ExecuteNonQuery();
                status = true;
                koneksi.Close();
            }
            catch (MySqlException)
            {
                Console.WriteLine("ERROR!!!");
            }
            return status;
        }

        //Hapus Pekerjaan
        public Boolean deletePekerjaan(int kode)
        {
            status = false;
            try
            {
                query = "DELETE tb_pekerjaan WHERE id_kerja=" + kode + "";
                koneksi.Open();
                command = new MySqlCommand();
                command.Connection = koneksi;
                command.CommandText = query;
                command.ExecuteNonQuery();
                status = true;
                koneksi.Close();
            }
            catch (MySqlException)
            {
                Console.WriteLine("ERROR!!!");
            }
            return status;
        }

        //Select Data = untuk menampilkan getData()
        public DataSet getData()
        {
            DataSet ds = new DataSet();
            try
            {
                koneksi.Open();
                command = new MySqlCommand();
                command.Connection = koneksi;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM tb_pekerjaan";
                MySqlDataAdapter mdap = new MySqlDataAdapter(command);
                koneksi.Close();
            }
            catch (MySqlException)
            {
                
            }
            return ds;
        }

        //Buat Kode = membuat kode otomatis di fungsi buatKode()
        public int kodeBaru()
        {
            int kode = 0;
            try
            {
                query = "SELECT MAX(id_kerja) FROM tb_pekerjaan";
                koneksi.Open();
                command = new MySqlCommand();
                command.Connection = koneksi;
                command.CommandText = query;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    kode = reader.GetInt32(0) + 1;
                }
                koneksi.Close();
            }
            catch (MySqlException)
            {
                Console.WriteLine("ERROR!!!");
            }
            return kode;
        }
    }
}
