using System.Collections.Generic;
using signformApi.App_Code;
using signformApi.Models;
using System.Data;

namespace signformApi.Models
{
    public class SignoutClass
    {
        public statusModels GetInsertModels(sItemData sItemData, string cuurip)
        {
            database database = new database();
            DataTable mainRows = new DataTable();
            List<dbparam> dbparamlist = new List<dbparam>();
            dbparamlist.Add(new dbparam("@iid", int.Parse(sItemData.items["iid"].ToString().TrimEnd())));
            mainRows = database.checkSelectSql("mssql", "sysstring", "exec web.searchflowform @iid;", dbparamlist);
            switch (mainRows.Rows.Count)
            {
                case 0:
                    return new statusModels() { status = "nodata" };
            }
            dbparamlist.Add(new dbparam("@name", mainRows.Rows[0]["nm"].ToString().TrimEnd()));
            dbparamlist.Add(new dbparam("@note", sItemData.items["note"].ToString().TrimEnd()));
            dbparamlist.Add(new dbparam("@phonesign", "0"));
            if (database.checkActiveSql("mssql", "sysstring", "exec web.signoutflowform @iid,@name,@note,@phonesign;", dbparamlist) != "istrue")
            {
                return new statusModels() { status = "error" };
            }
            return new statusModels() { status = "istrue" };
        }
    }
}