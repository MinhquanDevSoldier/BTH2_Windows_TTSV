using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace BTH_Windows_TTSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbTrinhdo.Items.Add("Tiến sĩ");
            cbTrinhdo.Items.Add("Thạc sĩ");
            cbTrinhdo.Items.Add("Cao Đẳng");
            cbTrinhdo.Items.Add("Đại học");

            cbChucvu.Items.Add("Giám đốc");
            cbChucvu.Items.Add("P.Giám đốc");
            cbChucvu.Items.Add("Trưởng Phòng");
            cbChucvu.Items.Add("Phó phòng");
            cbChucvu.Items.Add("Nhân viên");

            cbPhongban.Items.Add("Giám đốc");
            cbPhongban.Items.Add("Tổ chức");
            cbPhongban.Items.Add("Kinh doanh");
            cbPhongban.Items.Add("kỹ thuật");
            Taomoi();
            LoadThongtin();
        }
        public void LoadThongtin()
        {
            string[] temp, rows;
            temp = File.ReadAllLines(Application.StartupPath + "./Nhanvien.txt");
            for (int i = 0; i < temp.Length; i++)
            {
                rows = temp[i].Split('|');
                ListViewItem item = new ListViewItem(rows[0], i);
                item.SubItems.Add(rows[1]);
                item.SubItems.Add(rows[2]);
                item.SubItems.Add(rows[3]);
                item.SubItems.Add(rows[4]);
                item.SubItems.Add(rows[5]);
                listViewNhanVien.Items.Add(item);
            }

        }
        private void btnTaomoi_Click(object sender, EventArgs e)
        {
            Taomoi();
        }
        public void Taomoi()
        {
            txtMaNV.Text = null;
            txtHovaTen.Text = null;
            dtpNgaysinh.Text = DateTime.Now.ToShortDateString();
            cbTrinhdo.Text = null;
            cbPhongban.Text = null;
            cbChucvu.Text = null;
            txtMaNV.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text != "" && txtHovaTen.Text != "")
            {
                ListViewItem item = new ListViewItem(txtMaNV.Text);
                item.SubItems.Add(txtHovaTen.Text);
                item.SubItems.Add(dtpNgaysinh.Text);
                item.SubItems.Add(cbTrinhdo.Text);
                item.SubItems.Add(cbChucvu.Text);
                item.SubItems.Add(cbPhongban.Text);
                listViewNhanVien.Items.Add(item);
            }
            else
            {
                MessageBox.Show("Hãy kiểm tra thông tin nhập ...", "Lưu ý", MessageBoxButtons.OK);
            }


        }

        private void btnGhitep_Click(object sender, EventArgs e)
        {
            Ghitep();
        }
        public void Ghitep()
        {
            string[] temp = new string[listViewNhanVien.Items.Count];

            for (int i = 0; i < listViewNhanVien.Items.Count; i++)
                temp[i] = listViewNhanVien.Items[i].SubItems[0].Text + "|" +
                         listViewNhanVien.Items[i].SubItems[1].Text + "|" +
                          listViewNhanVien.Items[i].SubItems[2].Text + "|" +
                          listViewNhanVien.Items[i].SubItems[3].Text + "|" +
                          listViewNhanVien.Items[i].SubItems[4].Text + "|" +
                          listViewNhanVien.Items[i].SubItems[5].Text;
            File.WriteAllLines(Application.StartupPath + "/.../.../Nhanvien.txt", temp);

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Taomoi();
        }
    }
}
