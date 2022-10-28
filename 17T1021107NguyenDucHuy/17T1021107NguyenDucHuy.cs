using _17T1021107NguyenDucHuy.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _17T1021107NguyenDucHuy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadNhom();
        }

        void loadNhom()
        {

            var db = new AppModel();
            var ls = db.Nhoms.Where(e => e.MaNhom == e.MaNhom).Select(e => new NhomViewModel
            {
                MaNhom = e.MaNhom,
                TenNhom = e.TenNhom
            }).ToList();
            nhomBindingSource.DataSource = ls;
            dataGridView1.DataSource = nhomBindingSource;
        }

        void LoadDanhBa(long IDDanhBa)
        {
            var db = new AppModel();
            var ls = db.DanhBas.Where(a => a.MaNhom == IDDanhBa).Select(a => new DanhBaViewModel()
            {
                MaLienLac = a.MaLienLac,
                TenLienLac = a.TenLienLac,
                Email = a.Email,
                SoDienThoai = a.SoDienThoai,
                MaNhom = a.MaNhom
            }).ToList();
            danhBaBindingSource.DataSource = ls;
            dataGridView2.DataSource = danhBaBindingSource;
        }


        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataGridView1.Rows[e.RowIndex];
                var db = new AppModel();
                foreach (Nhom item in db.Nhoms)
                {
                    if (item.TenNhom == row.Cells["tenNhomDataGridViewTextBoxColumn"].Value.ToString())
                    {
                        LoadDanhBa(item.MaNhom);
                    }
                }
            }
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridView2.Rows[e.RowIndex];
            var db = new AppModel();

            foreach (DanhBa item in db.DanhBas)
            {
                if (item.TenLienLac == row.Cells["tenLienLacDataGridViewTextBoxColumn"].Value.ToString())
                {
                    lblTenLienLac.Visible = true;
                    lblTenLienLac.Text = item.TenLienLac;
                    lblDiaChi.Visible = true;
                    lblDiaChi.Text = item.DiaChi;
                    lblEmail.Visible = true;
                    lblEmail.Text = item.Email;
                    lblSDT.Visible = true;
                    lblSDT.Text = item.SoDienThoai;
                }
            }
        }

        private void btnThemNhom_Click(object sender, EventArgs e)
        {
            var f = new Nhóm();

            if (f.ShowDialog() == DialogResult.OK)
            {
                loadNhom();
            }
        }

        private void btnXoaNhom_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban co chac la muon xoa khong?", "Thong bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                var p = nhomBindingSource.Current as NhomViewModel;
                if (p != null)
                {
                    var db = new AppModel();
                    var lh = db.Nhoms.Where(t => t.MaNhom == p.MaNhom).FirstOrDefault();
                    db.Nhoms.Remove(lh);
                    db.SaveChanges();
                    loadNhom();
                }
            }
        }

        private void btnThemLienLac_Click(object sender, EventArgs e)
        {
            var f = new frmDanhBa();
            var a = nhomBindingSource.Current as NhomViewModel;
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadDanhBa(a.MaNhom);
            }
        }

        private void btnXoaLienLac_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban co chac la muon xoa khong?", "Thong bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                var p = danhBaBindingSource.Current as DanhBaViewModel;

                var a = danhBaBindingSource.Current as DanhBaViewModel;
                if (p != null)
                {
                    var db = new AppModel();
                    var lh = db.DanhBas.Where(t => t.MaLienLac == p.MaLienLac).FirstOrDefault();
                    db.DanhBas.Remove(lh);
                    db.SaveChanges();
                    LoadDanhBa(a.MaNhom);
                }
            }
        }
    }
}
