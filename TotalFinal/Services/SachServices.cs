using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalFinal.Models;
using TotalFinal.Repositories;

namespace TotalFinal.Services
{
    internal class SachServices
    {
        SachRepos _repos = new SachRepos();
        public SachServices()
        {
            _repos = new SachRepos();
        }
        public List<Sach> GetAll()
        {
            return _repos.GetAll(); 
        }
        public string ThemSach(string ma, string ten, DateTime ngay, int sotrang,
            int dongia, Guid idNxb, int trangthai)
        {
            Sach s = new Sach()
            {
                Id = Guid.NewGuid(),
                Ten = ten,
                Ma = ma,
                NgayXuatBan = ngay,
                SoTrang = sotrang,
                DonGia = dongia,
                IdNxb = idNxb,
                TrangThai = trangthai
            };
            if (_repos.AddSach(s))
            {
                return "Thêm thành công";
            }
            else return "Thêm thất bại";
        }
        public string SuaSach(Guid id, string ma, string ten, DateTime ngay, int sotrang,
            int dongia, Guid idNxb, int trangthai)
        {
            Sach s = new Sach()
            {
                Id = id,
                Ten = ten,
                Ma = ma,
                NgayXuatBan = ngay,
                SoTrang = sotrang,
                DonGia = dongia,
                IdNxb = idNxb,
                TrangThai = trangthai
            };
            if (_repos.UpdateSach(s))
            {
                return "Sửa thành công";
            }
            else return "Sửa thất bại";
        }
        public string XoaSach(Guid id)
        {
            if (_repos.DeleteSach(id))
            {
                return "Xóa thành công";
            }
            else return "Xóa thất bại";
        }
        public List<Sach> TimKiem(string search)
        {
            return _repos.GetAll().Where(p=>p.Ten.Contains(search) ||
            p.Ma.Contains(search)).ToList(); // Trong mã hoặc tên có chứa dữ liệu nhập vào
        }
        public List<Guid> GetAllIdNxb()
        {
            NXBRepos nxbRepos = new NXBRepos();
            var nxbs = nxbRepos.GetAll(); // lất tất nhà xuất bản ra
            var allIdNxb = new List<Guid>();     
            foreach(var nxb in nxbs)
            {
                allIdNxb.Add(nxb.Id); // add các id nhà xuất bản vào 
            }
            return allIdNxb;
        }
        public List<int?> GetAllTrangthai()
        {
           
            var sachs = _repos.GetAll(); // lất tất nhà sách ra
            var allTrangthai = new List<int?>();
            foreach (var sach in sachs)
            {
                if(!allTrangthai.Contains(sach.TrangThai))
                allTrangthai.Add(sach.TrangThai); // add các trạng thái chưa có vào trong list
            }
            return allTrangthai;
        }
        public List<Sach> GetSachByTrangThai(int trangthai)
        {
            return _repos.GetAll().Where(p=>p.TrangThai == trangthai).ToList();
        }
    }
}
