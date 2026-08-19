using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS.Data
{
    public interface IPackageManager
    {
        DataTable Gets();
        DataTable GetsBy(int type, string version);
        DataTable GetDetailsBy(int packageId);
        DataTable GetById(int packageId);
        bool Delete(int packageId);
        bool DeletePackageDetailByPackageId(int packageId);
        bool CheckIsExist(string name, string version);
        int InsertPackage(string packageName, string packageTitle, string description, string category, string version, int type, string pathSource, string model, int typeFrame, int? createBy);
        int InsertPackageDetails(int packageId, string name, int type, string description, string title, string hashtag, string pathFile, string content);
    }
}
