using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Logger của lớp UI nay chỉ là wrapper mỏng, uỷ quyền cho logger dùng chung ở T3.Configuration.
// Giữ nguyên chữ ký Log(string) để các nơi đang gọi Logger.Log(...) không phải sửa,
// đồng thời bảo đảm toàn ứng dụng ghi vào CÙNG một file qua CÙNG một lock.
public static class Logger
{
    public static void Log(string msg)
    {
        T3.Configuration.Logger.Log(msg);
    }
}