using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Packaging;
using T3.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS.Data
{
    public class PackageManager : IPackageManager
    {
        SQLiteDataBase _sqlite;

        public PackageManager()
        {
            _sqlite = new SQLiteDataBase();
        }
        public int InsertPackage(string packageName, string packageTitle, string description, string category, string version, int type, string pathSource, string model, int typeFrame, int? createBy)
        {
            string datestr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff");
            // Tham số hoá toàn bộ giá trị chuỗi để chống SQL injection.
            var parameters = new Dictionary<string, object>
            {
                { "@PackageName", packageName },
                { "@PackageTitle", packageTitle },
                { "@Version", version },
                { "@DateCreate", datestr },
                { "@Category", category },
                { "@Type", type },
                { "@Description", description },
                { "@PathSource", pathSource },
                { "@Model", model },
                { "@TypeFrame", typeFrame }
            };
            // Gắn thêm cột audit chuẩn (song song với DateCreate sẵn có).
            var audit = AuditStamp.ForInsert(parameters);
            var str = "INSERT into Packages(PackageName,PackageTitle,Version,DateCreate,Category,Type,Description,PathSource,Model,TypeFrame" + audit.Columns + ") VALUES(@PackageName,@PackageTitle,@Version,@DateCreate,@Category,@Type,@Description,@PathSource,@Model,@TypeFrame" + audit.Values + ")";
            return int.Parse(_sqlite.ExecuteInsert(str, parameters).ToString());
        }
        public int InsertPackageDetails(int packageId, string name,int type, string description,string title,string hashtag, string pathFile,string content)
        {
            var str = "INSERT into PackageDetail(PackageId,Name,Type,Description,Title,Hashtag,PathFile,Content) VALUES(@PackageId,@Name,@Type,@Description,@Title,@Hashtag,@PathFile,@Content)";
            var parameters = new Dictionary<string, object>
            {
                { "@PackageId", packageId },
                { "@Name", name },
                { "@Type", type },
                { "@Description", description },
                { "@Title", title },
                { "@Hashtag", hashtag },
                { "@PathFile", pathFile },
                { "@Content", content }
            };
            return int.Parse(_sqlite.ExecuteInsert(str, parameters).ToString());
        }

        public DataTable Gets()
        {
            var str = "SELECT * from Packages";
            str += " ORDER BY DateCreate DESC";
            return _sqlite.GetDataTable(str);
        }
        public DataTable GetsBy(int type, string version)
        {
            var str = "SELECT * from Packages Where Type = @Type";
            var parameters = new Dictionary<string, object> { { "@Type", type } };
            if (!string.IsNullOrEmpty(version))
            {
                str += " and Version = @Version";
                parameters.Add("@Version", version);
            }
            str += " ORDER BY DateCreate DESC";
            return _sqlite.GetDataTableParam(str, parameters);
        }
        public DataTable GetDetailsBy(int packageId)
        {
            var str = "SELECT * from PackageDetail Where PackageId = @PackageId";
            var parameters = new Dictionary<string, object> { { "@PackageId", packageId } };
            return _sqlite.GetDataTableParam(str, parameters);
        }
        public bool Delete(int packageId)
        {
            var str = "Delete FROM Packages where PackageId = @PackageId";
            var parameters = new Dictionary<string, object> { { "@PackageId", packageId } };
            if (_sqlite.ExecuteNonQuery(str, parameters) > 0)
                return true;
            return false;
        }
        public bool DeletePackageDetailByPackageId(int packageId)
        {
            var str = "Delete FROM PackageDetail where PackageId = @PackageId";
            var parameters = new Dictionary<string, object> { { "@PackageId", packageId } };
            _sqlite.ExecuteNonQuery(str, parameters);
            return true;
        }
        public DataTable GetById(int packageId)
        {
            string query = "SELECT * from Packages where PackageId = @PackageId";
            var parameters = new Dictionary<string, object> { { "@PackageId", packageId } };
            return _sqlite.GetDataTableParam(query, parameters);
        }
        public bool CheckIsExist(string name, string version)
        {
            try
            {
                var parameters = new Dictionary<string, object>
                {
                    { "@PackageName", name },
                    { "@Version", version }
                };
                var table = _sqlite.GetDataTableParam("SELECT * from Packages where PackageName = @PackageName and Version = @Version", parameters);
                if (table != null && table.Rows.Count > 0) return true;
                return false;
            }
            catch (Exception ex)
            {
                Logger.Log("PackageManager.CheckIsExist", ex);
                return false;
            }
        }
    }
}
