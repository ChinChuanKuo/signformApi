using System.Collections.Generic;
using signformApi.App_Code;
using System.Data;

namespace signformApi.Models
{
    public class SignClass
    {
        public sItemModels GetSearchModels(sItemData sItemData, string cuurip)
        {
            DataTable mainRows = new DataTable();
            List<dbparam> dbparamlist = new List<dbparam>();
            dbparamlist.Add(new dbparam("@iid", int.Parse(sItemData.items["iid"].ToString().TrimEnd())));
            dbparamlist.Add(new dbparam("@name", sItemData.items["name"].ToString().TrimEnd()));
            Dictionary<string, object> items = new Dictionary<string, object>();
            mainRows = new database().checkSelectSql("mssql", "sysstring", "exec web.searchflowform @iid,@name;", dbparamlist);
            switch (mainRows.Rows.Count)
            {
                case 0:
                    return new sItemModels() { status = "nodata" };
            }
            string note = mainRows.Rows[0]["pnote"].ToString().TrimEnd().Replace("&lt;", "<").Replace("&gt;", ">");
            int firIndex = note.IndexOf("body") + 4;
            items.Add("subject", $"簽核單：{mainRows.Rows[0]["subject"].ToString().TrimEnd()}");
            items.Add("signin", $"簽核時間：{mainRows.Rows[0]["signin"].ToString().TrimEnd()}");
            items.Add("note", note.Substring(firIndex + 1, note.LastIndexOf("body") - firIndex));
            return new sItemModels() { items = items, status = "istrue" };
        }
    }
}