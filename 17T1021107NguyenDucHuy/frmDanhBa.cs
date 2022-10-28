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
    public partial class frmDanhBa : Form
    {
        DanhBaViewModel danhBaViewModel;

        public frmDanhBa()
        {
            InitializeComponent();
            napNhom();
        }

        void napNhom()
        {
            //var d = DataGridView1.
            var db = new AppModel();
            var ls = db.Nhoms.ToList();
            txtTenNhom.DataSource = ls;
            txtTenNhom.DisplayMember = "TenNhom";
        }

        public Nhom selectedDanhBa
        {
            get
            {
                return txtTenNhom.SelectedItem as Nhom;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {


            if (txtTenLienLac.Text == "" || txtTenNhom.Text == "" || txtSoDienThoai.Text == "" || txtEmail.Text == "" || txtDiaChi.Text == "")
            {
                MessageBox.Show("Vui Long nhap day du thong tin: ");
            }

            else if (System.Text.RegularExpressions.Regex.IsMatch(txtSoDienThoai.Text, "[^0-9]"))
            {
                MessageBox.Show("Vui long nhap dung dinh dang so dien thoai.");
                txtSoDienThoai.Text = txtSoDienThoai.Text.Remove(txtSoDienThoai.Text.Length - 1);
            }


            else if (danhBaViewModel == null)
            {
                DanhBa p = new DanhBa()
                {
                    TenLienLac = txtTenLienLac.Text,
                    Email = txtEmail.Text,
                    SoDienThoai = txtSoDienThoai.Text,
                    DiaChi = txtDiaChi.Text,
                    MaNhom = selectedDanhBa.MaNhom

                };

                var db = new AppModel();
                db.DanhBas.Add(p);
                db.SaveChanges();
                DialogResult = DialogResult.OK;
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
