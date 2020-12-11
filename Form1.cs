using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChgSqlServerToMySql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sqlStr = SqlTextBox.Text;
            var mySqlStr = GetMySqlStr(sqlStr);
            MySqlTextBox.Text = mySqlStr;
        }

        private string GetMySqlStr(string SqlStr)
        {
            var mySqlStr = string.Empty;
            if (SqlStr.Contains("--增"))
            {
                var sqlList = new List<string>();
                var count = Regex.Matches(SqlStr, "--增").Count;
                var oldIndex = 0;
                if (count>1)
                {
                    for (int i = 0; i < count; i++)
                    {
                        var newIndex = SqlStr.IndexOf("--增");
                        if (newIndex <= 0) newIndex = SqlStr.IndexOf("--增", oldIndex + 1);
                        if (i == (count - 1))
                        {
                            sqlList.Add(SqlStr.Substring(oldIndex));
                        }
                        else
                        {
                            sqlList.Add(SqlStr.Substring(oldIndex, newIndex-oldIndex));
                        }
                        oldIndex = newIndex;
                    }
                }
                else
                {
                    sqlList.Add(SqlStr);
                }

                foreach (var sql in sqlList)
                {
                    if (sql.Contains("--增"))
                    {
                        var str = Regex.Split(sql, "--\r\n").Where(t => t.Length > 0).ToList();
                        mySqlStr += str[0].Replace("--增", "-- 增") + "--\r\n";
                        mySqlStr += ChgSql2MySql(str[1]);
                    }
                    else
                    {
                        mySqlStr += ChgSql2MySql(sql);
                    }
                }
            }
            else
            {
                mySqlStr = ChgSql2MySql(SqlStr);
            }

            return mySqlStr;
        }

        private string ChgSql2MySql(string SqlStr)
        {
            var mySqlStr = string.Empty;
            var sqlList = Regex.Split(SqlStr, "if not exists", RegexOptions.IgnoreCase).Where(t => t.Length > 0).ToList();
            foreach (var sql in sqlList)
            {
                var partList = Regex.Split(sql.Replace("dbo.","").Replace("\r\n", "\n"), "\n");
                mySqlStr += partList[1].Replace("insert ", "INSERT INTO ") + "\r\n";

                var index = partList[2].LastIndexOf(')');
                partList[2] = partList[2].Remove(index, partList[2].Length - index);
                partList[2] = partList[2].Insert(index, "\r\nFROM DUAL WHERE NOT EXISTS " + partList[0] + ";");
                mySqlStr += partList[2].ReplaceIngoreCase("  values(", "SELECT ").ReplaceIngoreCase("values(", "SELECT ")
                    .ReplaceIngoreCase("values (", "SELECT ") + "\r\n";
            }
            return mySqlStr;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(MySqlTextBox.Text);
        }

    }

    public static class replaceStr
    {
        public static string ReplaceIngoreCase(this string str, string OldValue, string NewValue)
        {
            return Regex.Replace(str, Regex.Escape(OldValue), NewValue, RegexOptions.IgnoreCase);
        }
    }
}
