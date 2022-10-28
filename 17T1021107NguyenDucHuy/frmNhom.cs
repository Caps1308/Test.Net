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
    
    public partial class Nhóm : Form
    {
        NhomViewModel nhomViewModel;
        public Nhóm()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Vui Long nhap day du thong tin: ");
            }

            else if (nhomViewModel == null)
            {
                Nhom p = new Nhom()
                {
                    TenNhom = textBox1.Text

                };

                var db = new AppModel();
                db.Nhoms.Add(p);
                db.SaveChanges();
                DialogResult = DialogResult.OK;
            }
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
