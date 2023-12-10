using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalFinal.Models;

namespace TotalFinal.Repositories
{
    internal class NXBRepos
    {
        FINALASS_FPOLY_NET_JAVA_SM22_BL2Context _context = new FINALASS_FPOLY_NET_JAVA_SM22_BL2Context();
        public NXBRepos()
        {
            _context = new FINALASS_FPOLY_NET_JAVA_SM22_BL2Context();
        }
        public List<Nxb> GetAll()
        {
            return _context.Nxbs.ToList();
        }
        public bool AddNxb(Nxb nxb)
        {
            try
            {
                _context.Nxbs.Add(nxb); // add vào DBSet
                _context.SaveChanges(); // Lưu lại thay đổi trên db
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateNxb(Nxb nxb)
        {
            // Tìm ra quyển sách cần sửa đã
            var updateItem = _context.Nxbs.Find(nxb.Id); // chỉ dùng cho khóa chính
            try
            {
                ///
                _context.SaveChanges(); // Lưu lại thay đổi trên db
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteNxb(Nxb nxb)
        {
            try
            {
                _context.Nxbs.Remove(nxb);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
