using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalFinal.Models;

namespace TotalFinal.Repositories
{
    internal class SachRepos
    {
        FINALASS_FPOLY_NET_JAVA_SM22_BL2Context _context = new FINALASS_FPOLY_NET_JAVA_SM22_BL2Context();
        public SachRepos()
        {
            _context = new FINALASS_FPOLY_NET_JAVA_SM22_BL2Context();
        }
        public List<Sach> GetAll()
        {
            return _context.Saches.ToList();    
        }
        public bool AddSach(Sach sach)
        {
            try
            {
                _context.Saches.Add(sach); // add vào DBSet
                _context.SaveChanges(); // Lưu lại thay đổi trên db
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateSach(Sach sach)
        {
            // Tìm ra quyển sách cần sửa đã
            var updateItem = _context.Saches.Find(sach.Id); // chỉ dùng cho khóa chính
            try
            {
                updateItem.Ten = sach.Ten;
                updateItem.SoTrang = sach.SoTrang;
                updateItem.NgayXuatBan = sach.NgayXuatBan;
                _context.Saches.Update(updateItem); // Sửa đối tượng
                _context.SaveChanges(); // Lưu lại thay đổi trên db
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteSach(Guid id)
        {
            var sach = _context.Saches.Find(id);
            try
            {
                _context.Saches.Remove(sach);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
