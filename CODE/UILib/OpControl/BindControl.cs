using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ORG.UILib.Controls;
using System.Data;

namespace ORG.UILib.OpControl
{
    public abstract class BindControl
    {
        public static void BindComboBox(ComboBoxEx cbb,DataTable dt,string selectedvalue)
        {
            DataRow dr = dt.NewRow();
            dr["DICTNAME"] = "请选择...";
            dr["DICTID"] = "";
            dt.Rows.Add(dr);
             
            cbb.DataSource = dt;
            cbb.DisplayMember = "DICTNAME";
            cbb.ValueMember = "DICTID";
            cbb.SelectedValue = selectedvalue;
        }
    }
}
