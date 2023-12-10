using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TotalFinal.Models;
using TotalFinal.Services;

namespace TotalFinal.Views
{
    public partial class MainProgram : Form
    {
        SachServices _services = new SachServices();
        Guid selectedID;
        public MainProgram()
        {
            InitializeComponent();
        }
        public void LoadDataToGridView(List<Sach> sachs)
        {
            dtg_Show.Rows.Clear();  // Xóa hết dữ liệu cũ để load lại
            dtg_Show.ColumnCount = 9;
            dtg_Show.Columns[0].HeaderText = "Số thứ tự";
            dtg_Show.Columns[1].HeaderText = "ID";
            dtg_Show.Columns[2].HeaderText = "Mã";
            dtg_Show.Columns[3].HeaderText = "Tên";
            dtg_Show.Columns[4].HeaderText = "Ngày xuất bản";
            dtg_Show.Columns[5].HeaderText = "Số trang";
            dtg_Show.Columns[6].HeaderText = "Đơn giá";
            dtg_Show.Columns[7].HeaderText = "Nhà xuất bản";
            dtg_Show.Columns[8].HeaderText = "Trạng thái";
            // Ẩn 1 cột đi - Cột ID không hiển thị
            dtg_Show.Columns[1].Visible = false;
            // Thêm dữ liệu vào gridView => Thêm từng Người yêu cũ từ List vào trong gridview
            // Tạo 1 thuộc tính tăng dân để làm số thứ tự
            int stt = 1;
            foreach (Sach s in sachs)
            {
                dtg_Show.Rows.Add(stt++, s.Id, s.Ma, s.Ten, s.NgayXuatBan, s.SoTrang,
                    s.DonGia, s.IdNxb, s.TrangThai);
                // Sau mỗi lần add thì stt tự + lên 1 đơn vị
            }
        }

        private void MainProgram_Load(object sender, EventArgs e)
        {
            LoadDataToGridView(_services.GetAll());
            LoadToCBB();
        }

        private void dtg_Show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Nếu dòng mình chọn không vượt quá khung 
            {
                DataGridViewRow row = dtg_Show.Rows[e.RowIndex]; // Lấy ra dòng mà mình chọn
                tbt_ID.Text = row.Cells[1].Value.ToString(); tbt_ID.Enabled = false; // Ẩn cột ID ko cho sửa
                tbt_Ma.Text = row.Cells[2].Value.ToString();
                tbt_Ten.Text = row.Cells[3].Value.ToString();
                dtp_NXB.Value = DateTime.Parse(row.Cells[4].Value.ToString());
                tbt_Sotrang.Text = row.Cells[5].Value.ToString();
                tbt_Dongia.Text = row.Cells[6].Value.ToString();
                if (row.Cells[7].Value != null)
                {
                    cbb_NXB.Text = row.Cells[7].Value.ToString();
                }
                else cbb_NXB.Text = "Không có";
                tbt_TT.Text = row.Cells[8].Value.ToString();
                // Gán ID được chọn cho biến để lấy id cần sửa /xóa
                selectedID = Guid.Parse(row.Cells[1].Value.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e) // Clear form
        {
            foreach (dynamic control in groupBox1.Controls)
            {
                if (control is TextBox) control.Text = "";
                else if (control is ComboBox) control.Text = "";
                else if (control is DateTimePicker) control.Text = "";
            }
        }
        public void LoadToCBB()
        {
            // Cbb nhà xuất bản
            var idNxb = _services.GetAllIdNxb();
            foreach (var id in idNxb)
            {
                cbb_NXB.Items.Add(id.ToString());
            }
            // cbb Lọc trạng thái
            var trangthais = _services.GetAllTrangthai();
            foreach (var id in trangthais)
            {
                cbb_loc.Items.Add(id.ToString());
            }
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (!Validate()) // Nếu kiểm tra các phần cần nhập không đúng
            {
                return;
            }
            string ma = tbt_Ma.Text;
            string ten = tbt_Ten.Text;
            DateTime ngay = dtp_NXB.Value;
            int sotrang = Convert.ToInt32(tbt_Sotrang.Text);
            int dongia = Convert.ToInt32(tbt_Dongia.Text);
            Guid idNxB = Guid.Parse(cbb_NXB.SelectedItem.ToString());
            int trangthai = Convert.ToInt32(tbt_TT.Text);
            string message = _services.ThemSach(ma, ten, ngay, sotrang, dongia, idNxB, trangthai);
            MessageBox.Show(message);
            LoadDataToGridView(_services.GetAll());
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string ma = tbt_Ma.Text;
            string ten = tbt_Ten.Text;
            DateTime ngay = dtp_NXB.Value;
            int sotrang = Convert.ToInt32(tbt_Sotrang.Text);
            int dongia = Convert.ToInt32(tbt_Dongia.Text);
            Guid idNxB = Guid.Parse(cbb_NXB.SelectedItem.ToString());
            int trangthai = Convert.ToInt32(tbt_TT.Text);
            string message = _services.SuaSach(selectedID, ma, ten, ngay, sotrang, dongia, idNxB, trangthai);
            MessageBox.Show(message);
            LoadDataToGridView(_services.GetAll());
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_services.XoaSach(selectedID));
            LoadDataToGridView(_services.GetAll());
        }

        private void tbt_Tim_TextChanged(object sender, EventArgs e)
        {
            var dataSearch = _services.TimKiem(tbt_Tim.Text);

            LoadDataToGridView(dataSearch);
        }

        private void cbb_loc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int trangthai = Convert.ToInt32(cbb_loc.SelectedItem.ToString());
            var dataLoc = _services.GetSachByTrangThai(trangthai);
            LoadDataToGridView(dataLoc);
        }
        public bool Validate()
        {
            // if (tbt_Dongia.Text == "") MessageBox.Show("Thiếu data");
            foreach (dynamic control in groupBox1.Controls)
            {
                if (control is TextBox && control.Text == "" && control.Name != "tbt_ID")
                {
                    MessageBox.Show("Hãy điền hết thông tin trong textBox"); return false;
                }
                else if (control is ComboBox && control.SelectedIndex < 0)
                {
                    MessageBox.Show("Hãy Chọn id Sách"); return false;
                }  
            }
            return true;
        }
    }
}
