using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        private string keterangan;
        private Entity.EntPekerjaan pekerjaan;
        private Implement.ImpPekerjaan impKerja;
        private DataSet data;
        private int i;

        public void aktifkanTeks(Boolean status)
        {
            txtNama.Enabled = status;
            txtKeterangan.Enabled = status;
        }

        public void aktifkanButton(Boolean status)
        {
            btnTambah.Enabled = status;
            btnUbah.Enabled = status;
            btnHapus.Enabled = status;
            btnSimpan.Enabled = status;
            btnFirst.Enabled = status;
            btnPrev.Enabled = status;
            btnNext.Enabled = status;
            btnLast.Enabled = status;
            if(status == true)
            {
                btnKeluar.Text = "Keluar";
            }
            else
            {
                btnKeluar.Text = "Batal";
            }
        }

        public void tampilData()
        {
            DataSet data = impKerja.getData();
            dgvPekerjaan.DataSource = data;
            dgvPekerjaan.DataMember = "tb_pekerjaan";
        }

        public void aturDataGrid()
        {
            dgvPekerjaan.Columns[0].HeaderText = "KODE";
            dgvPekerjaan.Columns[1].HeaderText = "PEKERJAAN";
            dgvPekerjaan.Columns[2].HeaderText = "KETERANGAN";
            dgvPekerjaan.Columns[0].Width = 50;
            dgvPekerjaan.Columns[1].Width = 150;
            dgvPekerjaan.Columns[2].Width = 300;
        }

        public Form2()
        {
            pekerjaan = new Entity.EntPekerjaan();
            impKerja = new Implement.ImpPekerjaan();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            aktifkanTeks(false);
            aktifkanButton(true);
            tampilData();
            lblStatus.Text = "Data ke : 1";
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            aktifkanButton(false);
            aktifkanTeks(true);

            keterangan = "INSERT";
            txtKode.Text = impKerja.kodeBaru().ToString();
            txtNama.Text = "";
            txtKeterangan.Text = "";
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            aktifkanButton(false);
            aktifkanTeks(true);

            keterangan = "UPDATE";
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            pekerjaan.setKode(Convert.ToInt32(txtKode.Text));
            pekerjaan.setNama(txtNama.Text);
            pekerjaan.setKeterangan(txtKeterangan.Text);

            if(keterangan == "INSERT")
            {
                impKerja.insertPekerjaan(pekerjaan);
            }
            else
            {
                impKerja.updatePekerjaan(pekerjaan);
            }
            tampilData();
            aktifkanButton(true);
            aktifkanTeks(false);
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Apakah yakin data ini akan dihapus ?", "Informasi");
            impKerja.deletePekerjaan(Convert.ToInt32(txtKode.Text));
            tampilData();
        }

        private void dgvPekerjaan_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtKode.Text = dgvPekerjaan.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNama.Text = dgvPekerjaan.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtKeterangan.Text = dgvPekerjaan.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            if (btnKeluar.Text == "Batal")
            {
                tampilData();
                aktifkanButton(true);
                aktifkanTeks(false);
            }
            else
            {
                Dispose();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if(data.Tables[0].Rows.Count > 0)
            {
                dgvPekerjaan.Rows[i].Selected = false;
                i = 0;
                txtKode.Text = data.Tables[0].Rows[i][0].ToString();
                txtNama.Text = data.Tables[0].Rows[i][1].ToString();
                txtKeterangan.Text = data.Tables[0].Rows[i][2].ToString();
                dgvPekerjaan.Rows[i].Selected = true;
                lblStatus.Text = "Data ke : " + (i + 1);
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            dgvPekerjaan.Rows[i].Selected = false;
            i = data.Tables[0].Rows.Count - 1;
            txtKode.Text = data.Tables[0].Rows[i][0].ToString();
            txtNama.Text = data.Tables[0].Rows[i][1].ToString();
            txtKeterangan.Text = data.Tables[0].Rows[i][2].ToString();
            dgvPekerjaan.Rows[i].Selected = true;
            lblStatus.Text = "Data ke : " + (i + 1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (i < data.Tables[0].Rows.Count - 1)
            {
                dgvPekerjaan.Rows[i].Selected = false;
                i++;
                txtKode.Text = data.Tables[0].Rows[i][0].ToString();
                txtNama.Text = data.Tables[0].Rows[i][1].ToString();
                txtKeterangan.Text = data.Tables[0].Rows[i][2].ToString();
                dgvPekerjaan.Rows[i].Selected = true;
                lblStatus.Text = "Data ke : " + (i + 1);
            }
            else
            {
                MessageBox.Show("No record to see more");
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (i == data.Tables[0].Rows.Count - 1 || i != 0)
            {
                dgvPekerjaan.Rows[i].Selected = false;
                i--;
                txtKode.Text = data.Tables[0].Rows[i][0].ToString();
                txtNama.Text = data.Tables[0].Rows[i][1].ToString();
                txtKeterangan.Text = data.Tables[0].Rows[i][2].ToString();
                dgvPekerjaan.Rows[i].Selected = true;
                lblStatus.Text = "Data ke : " + (i + 1);
            }
            else
            {
                MessageBox.Show("No record to see more");
            }
        }
    }
}
