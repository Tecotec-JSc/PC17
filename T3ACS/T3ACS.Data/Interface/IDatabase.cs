using System;
using System.Collections.Generic;
using System.Data;

namespace T3ACS.Data
{
    public interface IDataBase
    {
        #region Method
        DataTable TableList();

        DataTable ColumnList(string TableName);

        DataTable ForeignKeyList(string TableName);

        DataTable ViewList();

        bool TableExists(string TableName);

        DateTime GetCurrentDate();

        object ExecuteInsert(string SQL);

        int ExecuteNonQuery(string SQL);
        #endregion

        #region Connection
        string ConnectionString
        {
            get;
            set;
        }
        #endregion

        #region Select
        DataTable GetDataTable(string SQL);
        #endregion
    }
}
