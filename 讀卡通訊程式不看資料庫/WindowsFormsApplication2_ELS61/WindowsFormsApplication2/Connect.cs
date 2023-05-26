using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    //定義外部定義
    class Connect
    {
        //SQL資料庫

        static SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlDataBase"].ConnectionString);

        static SqlDataAdapter ODA;

        /// <summary>
        /// Statement形式
        /// </summary>
        public enum StatementWay
        {
            WH_VARH,
            MeterTou1,
            MeterTou2,
            MeterTou3,
            SelectMeterID
        }

        /// <summary>
        /// 執行資料選擇語法
        /// </summary>
        /// <param name="statement">資料庫指令</param>
        /// <returns></returns>
        public static DataSet DBSetExecute(string statement)
        {
            try
            {
                DataSet ds = new DataSet();
                ODA = new SqlDataAdapter(statement, Conn);
                ODA.Fill(ds, "Data");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 執行資料選擇語法
        /// </summary>
        /// <param name="statement">資料庫指令</param>
        /// <returns></returns>
        public static DataTable DBTableExecute(string statement)
        {
            try
            {
                DataTable dt = new DataTable();
                ODA = new SqlDataAdapter(statement, Conn);
                ODA.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 判斷資料表內是否有該值
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="Column"></param>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public static bool SearchExist(String Table, String Column, String Condition)
        {
            DataTable Temp = Search(Table, Column, Condition);
            if (Temp.Rows.Count > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 判斷資料表內是否有該值
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="Column"></param>
        /// <param name="Condition"></param>
        /// <returns></returns>
        public static bool SearchExist(String Table, String Column, String ConditionColumn, String Condition)
        {
            DataTable Temp = Search(Table, Column, ConditionColumn, Condition);
            if (Temp.Rows.Count > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 資料表查詢功能
        /// </summary>
        /// <param name="Table">資料表名稱</param>
        /// <returns></returns>
        public static DataTable Search(String Table)
        {
            try
            {
                DataTable dt = new DataTable();
                ODA = new SqlDataAdapter("SELECT * FROM " + Table, Conn);
                ODA.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 資料表查詢功能
        /// </summary>
        /// <param name="Column">要找的欄位名稱</param>
        /// <param name="Table">資料表名稱</param>
        /// <returns></returns>
        public static DataTable Search(String Table, String Column)
        {
            try
            {
                DataTable dt = new DataTable();
                ODA = new SqlDataAdapter("SELECT " + Column + " FROM " + Table, Conn);
                ODA.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable Search_Order(String Table, String Column, String Order)
        {
            try
            {
                DataTable dt = new DataTable();
                ODA = new SqlDataAdapter("SELECT " + Column + " FROM " + Table + " Order by " + Order, Conn);
                ODA.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 資料表查詢功能
        /// </summary>
        /// <param name="Column">要找的欄位名稱</param>
        /// <param name="Table">資料表名稱</param>
        /// <returns></returns>
        public static DataTable Search(String Table, String[] Column)
        {
            try
            {
                string Statement = "SELECT ";
                foreach (string s in Column)
                    Statement += s + ",";
                Statement = Statement.Remove(Statement.Length - 1);
                Statement += " FROM " + Table;
                DataTable dt = new DataTable();
                ODA = new SqlDataAdapter(Statement, Conn);
                ODA.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 資料表查詢功能
        /// </summary>
        /// <param name="Column">要找的欄位名稱</param>
        /// <param name="Table">資料表名稱</param>
        /// <param name="Condition">收尋條件</param>
        /// <returns></returns>
        public static DataTable Search(String Table, String Column, String Condition)
        {
            try
            {
                DataTable dt = new DataTable();
                ODA = new SqlDataAdapter("SELECT " + Column + " FROM " + Table + " WHERE " + Condition, Conn);
                ODA.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 資料表查詢功能
        /// </summary>
        /// <param name="Column">要找的欄位名稱</param>
        /// <param name="Table">資料表名稱</param>
        /// <param name="ConditionColumn">收尋欄位</param>
        /// <param name="Condition">收尋條件</param>
        /// <returns></returns>
        public static DataTable Search(String Table, String Column, String ConditionColumn, String Condition)
        {
            try
            {
                DataTable dt = new DataTable();
                ODA = new SqlDataAdapter("SELECT " + Column + " FROM " + Table + " WHERE " + ConditionColumn + " = '" + Condition + "'", Conn);
                ODA.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 資料表查詢功能
        /// </summary>
        /// <param name="Column">要找的欄位名稱</param>
        /// <param name="Table">資料表名稱</param>
        /// <returns></returns>
        public static DataTable Search(String Table, String[] Column, String[] Condition)
        {
            try
            {
                string Statement = "SELECT ";
                foreach (string s in Column)
                    Statement += s + ",";
                Statement = Statement.Remove(Statement.Length - 1);
                Statement += " FROM " + Table + " WHERE ";
                foreach (string s in Condition)
                    Statement += s + ",";
                Statement = Statement.Remove(Statement.Length - 1);
                DataTable dt = new DataTable();
                ODA = new SqlDataAdapter(Statement, Conn);
                ODA.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 資料表查詢功能(需要用到其他SQL語句時)
        /// </summary>
        /// <param name="Table">資料表名稱</param>
        /// <param name="Extra">其他語句</param>
        /// <returns></returns>
        public static DataTable SearchExtraCondition(String Table,String Extra)
        {
            try
            {
                DataTable dt = new DataTable();
                ODA = new SqlDataAdapter("SELECT * FROM " + Table + " " + Extra, Conn);
                ODA.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 資料表查詢功能(需要用到其他SQL語句時)
        /// </summary>
        /// <param name="Column">要找的欄位名稱</param>
        /// <param name="Table">資料表名稱</param>
        /// <param name="Extra">其他語句</param>
        /// <returns></returns>
        public static DataTable SearchExtraCondition(String Table,String Column, String Extra)
        {
            try
            {
                DataTable dt = new DataTable();
                ODA = new SqlDataAdapter("SELECT " + Column + " FROM " + Table + " " + Extra, Conn);
                ODA.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 資料表查詢功能(需要用到其他SQL語句時)
        /// </summary>
        /// <param name="Column">要找的欄位名稱</param>
        /// <param name="Table">資料表名稱</param>
        /// <param name="Extra">其他語句</param>
        /// <returns></returns>
        public static DataTable SearchExtraCondition(String Table,String[] Column, String Extra)
        {
            try
            {
                string Statement = "SELECT ";
                foreach (string s in Column)
                    Statement += s + ",";
                Statement = Statement.Remove(Statement.Length - 1);
                Statement += " FROM " + Table + " " + Extra;
                DataTable dt = new DataTable();
                ODA = new SqlDataAdapter(Statement, Conn);
                ODA.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 複製表格的內容到另一表格
        /// </summary>
        /// <param name="CopyTable">複製來源資料</param>
        /// <param name="CoverTable">欲覆蓋資料</param>
        public static void CopyTable(string CopyTable,string CoverTable)
        {
            string Statement = "INSERT INTO " + CoverTable + " SELECT * FROM " + CopyTable;
            ExCmd(Statement);
        }

        /// <summary>
        /// 回傳資料表內含資料數
        /// </summary>
        /// <param name="Table"></param>
        /// <returns></returns>
        public static int TableCount(string Table)
        {
            return (int)ExCmdExecuteScalar("SELECT COUNT (*) FROM "+Table);
        }

        /// <summary>
        /// 查詢兩表單當中一樣/不一樣的資料
        /// </summary>
        /// <param name="ColumnA">被比對欄位</param>
        /// <param name="ColumnB">比對欄位</param>
        /// <param name="TableA">被比對表格</param>
        /// <param name="TableB">比對表格B</param>
        /// <param name="Type">為true則比對一樣的值，不然就比對不一樣的值</param>
        /// <returns></returns>
        public static DataTable SearchInTable(String ColumnA, String ColumnB, String TableA, String TableB,bool Type)
        {
            try
            {
                DataTable dt = new DataTable();
                if(Type)
                    ODA = new SqlDataAdapter("SELECT * FROM " + TableA + " WHERE " + ColumnA + " IN (Select " + ColumnB + " FROM " + TableB + " ) ORDER BY " + ColumnA + " ASC", Conn);
                else
                    ODA = new SqlDataAdapter("SELECT * FROM " + TableA + " WHERE " + ColumnA + " NOT IN (Select " + ColumnB + " FROM " + TableB + " ) ORDER BY " + ColumnA + " ASC", Conn);
                ODA.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 新增資料庫資料，注意欄位數要和資料數一致
        /// </summary>
        /// <param name="Table">資料表</param>
        /// <param name="Colnum">欄位</param>
        /// <param name="Data">新增的資料</param>
        public static void Insert(string Table, string[] Colnum, ListBox Data)
        {
            string Statement = "INSERT INTO " + Table + "(";
            foreach (string s in Colnum)
                Statement += s + ",";
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += ") VALUES( ";
            foreach (object o in Data.Items)
            {
                string s = o.ToString();

                if (s == "")
                    Statement += "NULL,";
                else
                    Statement += "'" + s + "',";
            }
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += ")";
            ExCmd(Statement);
        }

        /// <summary>
        /// 新增資料庫資料，注意欄位數要和資料數一致
        /// </summary>
        /// <param name="Table">資料表</param>
        /// <param name="Colnum">欄位</param>
        /// <param name="Data">新增的資料</param>
        public static void Insert(string Table, string[] Colnum, string[] Data,byte[] Byte_Data)
        {
            string Statement = "INSERT INTO " + Table + "(";
            foreach (string s in Colnum)
                Statement += s + ",";
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += ") VALUES( ";
            foreach (string s in Data)
                if (s == "")
                    Statement += "NULL,";
                else
                    Statement += "'" + s + "',";
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += ",0x";
            if (Byte_Data.Length == 0)
            {
                Statement += "NULL,";
            }
            else
            {
                foreach (byte b in Byte_Data)
                {
                    if (b < 0x10)
                        Statement += "0" + Convert.ToString(b, 16).ToString();
                    else
                        Statement += Convert.ToString(b, 16).ToString();
                }
            }
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += ")";
            ExCmd(Statement);
        }

        /// <summary>
        /// 新增資料庫資料，注意欄位數要和資料數一致
        /// </summary>
        /// <param name="Table">資料表</param>
        /// <param name="Colnum">欄位</param>
        /// <param name="Data">新增的資料</param>
        public static void Insert(string Table, string[] Colnum, string[] Data)
        {
            string Statement = "INSERT INTO " + Table + "(";
            foreach (string s in Colnum)
                Statement += s + ",";
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += ") VALUES( ";
            foreach (string s in Data)
                if(s == "")
                    Statement += "NULL,";
                else
                    Statement += "'" + s + "',";
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += ")";
            ExCmd(Statement);
        }

        /// <summary>
        /// 新增資料庫資料，注意欄位數要和資料數一致
        /// </summary>
        /// <param name="Table">資料表</param>
        /// <param name="Colnum">欄位</param>
        /// <param name="Data">新增的資料</param>
        public static void Insert(string Table, string[] Colnum, double[] Data)
        {
            string Statement = "INSERT INTO " + Table + "(";
            foreach (string s in Colnum)
                Statement += s + ",";
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += ") VALUES( ";
            foreach (double s in Data)
                if (s.ToString() == "")
                    Statement += "NULL,";
                else
                    Statement += "'" + s + "',";
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += ")";
            ExCmd(Statement);
        }

        /// <summary>
        /// 新增資料庫資料，注意欄位數要和資料數一致
        /// </summary>
        /// <param name="Table">資料表</param>
        /// <param name="Colnum">欄位</param>
        /// <param name="Number">新增的資料序號</param>
        /// <param name="Data">新增的資料</param>
        public static void Insert(string Table, string[] Colnum, int Number, string[] Data)
        {
            string Statement = "INSERT INTO " + Table + "(";
            foreach (string s in Colnum)
                Statement += s + ",";
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += ") VALUES( ";

            if (Number.ToString() == "")
                Statement += "NULL,";
            else
                Statement += "'" + Number + "',";

            foreach (string s in Data)
                if (s == "")
                    Statement += "NULL,";
                else
                    Statement += "'" + s + "',";
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += ")";
            ExCmd(Statement);
        }

        /// <summary>
        /// 新增資料庫資料
        /// </summary>
        /// <param name="Table">資料表</param>
        /// <param name="Colnum">欄位</param>
        /// <param name="LoginPassword">登入操作軟體密碼</param>
        /// <param name="PermissionCode">權限編碼</param>
        public static void Insert(string Table, string[] Colnum, string LoginPassword, int PermissionCode)
        {
            string Statement = "INSERT INTO " + Table + "(";
            foreach (string s in Colnum)
                Statement += s + ",";
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += ") VALUES( ";

            if (LoginPassword.ToString() == "")
                Statement += "NULL,";
            else
                Statement += "'" + LoginPassword + "',";

            if (PermissionCode.ToString() == "")
                Statement += "NULL,";
            else
                Statement += "'" + PermissionCode + "',";
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += ")";
            ExCmd(Statement);
        }

        /// <summary>
        /// 新增資料庫資料，建立預設值專用
        /// </summary>
        /// <param name="Table">資料表</param>
        /// <param name="Colnum">欄位</param>
        /// <param name="Number">編號</param>
        /// <param name="MeterID">登入電表ID</param>
        /// <param name="MeterPassword">登入電表密碼</param>
        public static void Insert(string Table, string[] Colnum, int Number, string MeterID, string[] MeterPassword)
        {
            string Statement = "INSERT INTO " + Table + "(";
            foreach (string s in Colnum)
                Statement += s + ",";
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += ") VALUES( ";

            if (Number.ToString() == "")
                Statement += "NULL,";
            else
                Statement += "'" + Number + "',";

            if (MeterID == "")
                Statement += "NULL,";
            else
                Statement += "'" + MeterID + "',";

            foreach (string s in MeterPassword) 
            {
                if (s == "")
                    Statement += "NULL,";
                else
                    Statement += "'" + s + "',";
            }
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += ")";
            ExCmd(Statement);
        }

        /// <summary>
        /// 新增資料庫資料，注意欄位數要和資料數一致
        /// </summary>
        /// <param name="Table">資料表</param>
        /// <param name="Colnum">欄位</param>
        /// <param name="Data">新增的資料</param>
        public static void Insert(string Table, string Colnum, string Data)
        {
            string Statement = "INSERT INTO " + Table + "(";
            Statement += Colnum + ",";
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += ") VALUES( ";
            if (Data == "")
                Statement += "NULL,";
            else
                Statement += "'" + Data + "',";
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += ")";
            ExCmd(Statement);
        }

        /// <summary>
        /// 修改資料庫資料
        /// </summary>
        /// <param name="Table">欲修改資料表</param>
        /// <param name="Colnum">欲修改欄位</param>
        /// <param name="Data">欲修改資料</param>
        public static void Edit(string Table, string Colnum, int[] Data)
        {
            string Statement = "UPDATE " + Table + " SET ";
            for (int i = 0; i < Colnum.Length; i++)
                if (Data[i].ToString() == "")
                    Statement += Colnum + " =  NULL,";
                else
                    Statement += Colnum + " = '" + Data[i] + "',";
            Statement = Statement.Remove(Statement.Length - 1);
            ExCmd(Statement);
        }

        /// <summary>
        /// 修改資料庫資料
        /// </summary>
        /// <param name="Table">欲修改資料表</param>
        /// <param name="Colnum">欲修改欄位</param>
        /// <param name="Data">欲修改資料</param>
        public static void Edit(string Table, string[] Colnum, int[] Data)
        {
            string Statement = "UPDATE " + Table + " SET ";
            for (int i = 0; i < Colnum.Length; i++)
                if (Data[i].ToString() == "")
                    Statement += Colnum[i] + " =  NULL,";
                else
                    Statement += Colnum[i] + " = '" + Data[i] + "',";
            Statement = Statement.Remove(Statement.Length - 1);
            ExCmd(Statement);
        }

        /// <summary>
        /// 修改資料庫資料
        /// </summary>
        /// <param name="Table">欲修改資料表</param>
        /// <param name="Colnum">欲修改欄位</param>
        /// <param name="Data">欲修改資料</param>
        public static void Edit(string Table, string[] Colnum, string[] Data)
        {
            string Statement = "UPDATE " + Table + " SET ";
            for (int i = 0; i < Colnum.Length; i++)
                if (Data[i] == "")
                    Statement += Colnum[i] + " =  NULL,";
                else
                    Statement += Colnum[i] + " = '" + Data[i] + "',";
            Statement = Statement.Remove(Statement.Length - 1);
            ExCmd(Statement);
        }

        /// <summary>
        /// 修改資料庫資料
        /// </summary>
        /// <param name="Table">欲修改資料表</param>
        /// <param name="Colnum">欲修改欄位</param>
        /// <param name="Data">欲修改資料</param>
        public static void Edit(string Table, string[] Colnum, double[] Data)
        {
            string Statement = "UPDATE " + Table + " SET ";
            for (int i = 0; i < Colnum.Length; i++)
                if (Data[i].ToString() == "")
                    Statement += Colnum[i] + " =  NULL,";
                else
                    Statement += Colnum[i] + " = '" + Data[i] + "',";
            Statement = Statement.Remove(Statement.Length - 1);
            ExCmd(Statement);
        }

        /// <summary>
        /// 修改資料庫資料
        /// </summary>
        /// <param name="Table">欲修改資料表</param>
        /// <param name="Colnum">欲修改欄位</param>
        /// <param name="Data">欲修改資料</param>
        /// <param name="Condision">判斷條件</param>
        /// <param name="CondisionColumn">判斷條件欄位</param>
        public static void Edit(string Table, string[] Colnum, string[] Data, string[] Condision, string[] CondisionColumn)
        {
            string Statement = "UPDATE " + Table + " SET ";
            for (int i = 0; i < Colnum.Length ; i++)
                if (Data[i] == "")
                    Statement += Colnum[i] + " =  NULL,";
                else
                    Statement += Colnum[i] + " = '" + Data[i] + "',";
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += " WHERE ";
            for (int i = 0; i < CondisionColumn.Length; i++)
                Statement += CondisionColumn[i] + " = '" + Condision[i] + "',AND";
            Statement = Statement.Remove(Statement.Length - 4);
            ExCmd(Statement);
        }

        public static void Edit(string Table, string[] Colnum, string[] Data, string Condision, string CondisionColumn)
        {
            string Statement = "UPDATE " + Table + " SET ";
            for (int i = 0; i < Colnum.Length; i++)
                if (Data[i] == "")
                    Statement += Colnum[i] + " =  NULL,";
                else
                    Statement += Colnum[i] + " = '" + Data[i] + "',";
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += " WHERE ";
            Statement += CondisionColumn + " = '" + Condision + "',AND";
            Statement = Statement.Remove(Statement.Length - 4);
            ExCmd(Statement);
        }

        public static void Edit(string Table, string Colnum, string Data, string Condision, string CondisionColumn)
        {
            string Statement = "UPDATE " + Table + " SET ";
            
                if (Data == "")
                    Statement += Colnum + " =  NULL,";
                else
                    Statement += Colnum + " = '" + Data + "',";
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += " WHERE ";
            
                Statement += CondisionColumn + " = '" + Condision + "',AND";
            Statement = Statement.Remove(Statement.Length - 4);
            ExCmd(Statement);
        }
        public static void Edit2(string Table, string Colnum, string Data, string Condision, string CondisionColumn)
        {
            string Statement = "UPDATE " + Table + " SET ";

            if (Data == "")
                Statement += Colnum + " =  NULL,";
            else
                Statement += Colnum + " = " + Data + ",";
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += " WHERE ";

            Statement += CondisionColumn + " = '" + Condision + "',AND";
            Statement = Statement.Remove(Statement.Length - 4);
            ExCmd(Statement);
        }

        public static void Edit(string Table, string Colnum, int Data, string Condision, string CondisionColumn)
        {
            string Statement = "UPDATE " + Table + " SET ";
                if (Data.ToString() == "")
                    Statement += Colnum + " =  NULL,";
                else
                    Statement += Colnum + " = '" + Data + "',";
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += " WHERE ";
                Statement += CondisionColumn + " = '" + Condision + "',AND";
            Statement = Statement.Remove(Statement.Length - 4);
            ExCmd(Statement);
        }
        public static void Edit(string Table, string Colnum, string Data, string CondisionColumn)
        {
            string Statement = "UPDATE " + Table + " SET ";
            if (Data.ToString() == "")
                Statement += Colnum + " =  NULL,";
            else
                Statement += Colnum + " = '" + Data + "',";
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += " WHERE ";
            Statement += CondisionColumn + "',AND";
            Statement = Statement.Remove(Statement.Length - 5);
            ExCmd(Statement);
           
        }
        public static void Edit(string Table, string Colnum, byte Data, string Condision, string CondisionColumn)
        {
            string Statement = "UPDATE " + Table + " SET ";
            if (Data.ToString() == "")
                Statement += Colnum + " =  NULL,";
            else
                Statement += Colnum + " = '" + Data + "',";
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += " WHERE ";
            Statement += CondisionColumn + " = '" + Condision + "',AND";
            Statement = Statement.Remove(Statement.Length - 4);
            ExCmd(Statement);
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="Table">資料表</param>
        /// <param name="Condision">判斷刪除的內容</param>
        /// <param name="CondisionColumn">判斷的欄位</param>
        public static void Delete(string Table, string CondisionColumn, string Condision)
        {
            string Statement = "DELETE FROM " + Table + " WHERE " + CondisionColumn + "='" + Condision + "'";
            ExCmd(Statement);            
        }

        /// <summary>
        /// 刪除指定的一列資料(可加萬用字元
        /// </summary>
        /// <param name="Table">資料表</param>
        /// <param name="Condision">判斷刪除的內容</param>
        /// <param name="CondisionColumn">判斷的欄位</param>
        public static void DeleteRow(string Table, string Condision, string CondisionColumn)
        {
            string Statement = "DELETE FROM " + Table + " WHERE " + CondisionColumn + " like'" + Condision + "'";
            ExCmd(Statement);
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="Table">資料表</param>
        /// <param name="Condision">判斷刪除的內容</param>
        /// <param name="CondisionColumn">判斷的欄位</param>
        public static void Delete(string Table, string[] Condision, string[] CondisionColumn)
        {
            string Statement = "DELETE FROM " + Table + " WHERE ";
            for (int i = 0; i < CondisionColumn.Length; i++)
                Statement += CondisionColumn[i] + " = '" + Condision[i] + "',AND";
            Statement = Statement.Remove(Statement.Length - 4);            
            ExCmd(Statement);
        }

        public static void DeleteSpec(string Table, string CondisionColumn)
        {
            string Statement = "DELETE FROM " + Table + " WHERE " + CondisionColumn;
            ExCmd(Statement);
        }

        /// <summary>
        /// 執行SQLCommand
        /// </summary>
        /// <param name="Statement"></param>
        public static void ExCmd(string Statement)
        {
            try
            {
                Conn.Open();
                SqlCommand cmd = new SqlCommand(Statement, Conn);
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 執行SQL語法並回傳第一個值。通常用於COUNT判斷式
        /// </summary>
        /// <param name="Statement"></param>
        /// <returns></returns>
        private static object ExCmdExecuteScalar(string Statement)
        {
            try
            {
                Conn.Open();
                SqlCommand cmd = new SqlCommand(Statement, Conn);
                object a = cmd.ExecuteScalar();
                Conn.Close();
                return a;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 檢查Table是否存在在Database中
        /// </summary> 
        /// <param name="TableName">Table名稱</param>
        /// <returns>存在回傳True，否則回傳Fales</returns>
        public static bool DBExistTable(string TableName)
        {
            DataTable tem = new DataTable();
            ODA = new SqlDataAdapter("select count(*) from sysobjects where name='" + TableName+"'", Conn);
            ODA.Fill(tem);
            if (tem.Rows[0][0].ToString() == "1")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 檢查Table裡的Column，是否名稱和Database的欄位重複
        /// </summary>
        /// <param name="TableName">Table名稱</param>
        /// <param name="ColumnName">Column名稱</param>
        /// <param name="SearchColumnName">搜尋Column資料行名稱</param>
        /// <returns>存在回傳True，否則回傳Fales</returns>
        public static bool DBExistColumn(String TableName, String ColumnName, String SearchColumnName)
        {
            Conn.Open();
            SqlCommand command = new SqlCommand("select " + ColumnName + " from " + TableName, Conn);
            SqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                if (dr[0].ToString() == SearchColumnName)
                {
                    dr.Close();
                    Conn.Close();
                    return true;
                }
            }
            dr.Close();
            Conn.Close();
            return false;
        }

        /// <summary>
        /// 將Table裡的Column全行數值顯示在listBox元件上
        /// </summary>
        /// <param name="TableName">Table名稱</param>
        /// <param name="ColumnName">Column名稱</param>
        /// <param name="ListBox">要顯示的listbox元件集合</param>
        public static void AddColumnData_To_ListBox(String TableName, String ColumnName, List<ListBox> ListBox)
        {
            Conn.Open();
            SqlCommand command = new SqlCommand("select " + ColumnName + " from " + TableName, Conn);
            SqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                for(int i = 0; i < ListBox.Count; i++)
                    ListBox[i].Items.Add(dr[0].ToString());
            }
            Conn.Close();
        }

        /// <summary>
        /// 將Table裡的Column全行數值顯示在listBox元件上
        /// </summary>
        /// <param name="TableName">Table名稱</param>
        /// <param name="ColumnName">Column名稱</param>
        /// <param name="ListBox">要顯示的listbox元件</param>
        public static void AddColumnData_To_ListBox(String TableName, String ColumnName, ListBox ListBox)
        {
            Conn.Open();
            SqlCommand command = new SqlCommand("select " + ColumnName + " from " + TableName, Conn);
            SqlDataReader dr = command.ExecuteReader();

            ListBox.Items.Clear();
            while (dr.Read())
                ListBox.Items.Add(dr[0].ToString());
            Conn.Close();
        }

        /// <summary>
        /// 將Table裡的Column全行數值顯示在ComboBox元件上
        /// </summary>
        /// <param name="TableName">Table名稱</param>
        /// <param name="ColumnName">Column名稱</param>
        /// <param name="ListBox">要顯示的CheckBox元件</param>
        public static void AddColumnData_To_ComboBox(String TableName, String ColumnName, ComboBox ComboBox)
        {
            ComboBox.Items.Clear();
            Conn.Open();
            SqlCommand command = new SqlCommand("select " + ColumnName + " from " + TableName, Conn);
            SqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
                ComboBox.Items.Add(dr[0].ToString());

            dr.Close();
            dr.Dispose();
            Conn.Close();

            if (ComboBox.Items.Count != 0)
                ComboBox.Text = ComboBox.Items[0].ToString();
        }

        /// <summary>
        /// 將資料表搜尋到的Table相關名稱顯示在ComboBox元件上
        /// </summary>
        /// <param name="TableName">Table名稱</param>
        /// <param name="ColumnName">Column名稱</param>
        /// <param name="ListBox">要顯示的CheckBox元件</param>
        public static void AddColumnData_To_ComboBox(String TableName, int CutLength, ComboBox ComboBox)
        {
            ComboBox.Items.Clear();
            string[] list = Connect.Search_Table(TableName + "%");
            for (int i = 0; i < list.Length; i++)
            {
                string strtemp = list[i].Remove(0, CutLength);
                ComboBox.Items.Add(strtemp);
            }
            if (ComboBox.Items.Count != 0)
                ComboBox.Text = ComboBox.Items[0].ToString();
        }

        /// <summary>
        /// 將Table裡的Column全行數值存在string陣列並返回
        /// </summary>
        /// <param name="TableName">Table名稱</param>
        /// <param name="ColumnName">Column名稱</param>
        /// <returns>string陣列</returns>
        public static string[] AddColumnData_To_String(String TableName, String ColumnName)
        {
            string[] s = new string[FindRowNumber(TableName)];
            int i = 0;
            Conn.Open();
            SqlCommand command = new SqlCommand("select " + ColumnName + " from " + TableName, Conn);
            SqlDataReader dr = command.ExecuteReader();
            
            while (dr.Read())
            {
                s[i] = dr[0].ToString();
                i++;
            }
            Conn.Close();
            return s;
        }

        public static string[] Search_Table(string Table_name)
        {
            DataTable tem = new DataTable();
            ODA = new SqlDataAdapter("select name from sysobjects where name LIKE '" + Table_name + "'", Conn);
            ODA.Fill(tem);
            string[] RetTemp = new string[tem.Rows.Count];
            for (int i = 0; i < tem.Rows.Count; i++)
                RetTemp[i] = tem.Rows[i][0].ToString();
            return RetTemp;
        }

        /// <summary>
        /// 創建資料表
        /// </summary>
        /// <param name="Table">資料表名稱</param>
        /// <param name="Datacolumn">欄位(附帶條件)</param>
        public static void CreateTable(string Table,string[] Datacolumn)
        {
            string Statement = "CREATE TABLE "+Table +" (";
            foreach (string S in Datacolumn)
                Statement += S + ",";
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += ")";
            ExCmd(Statement);
        }

        /// <summary>
        /// 刪除資料表
        /// </summary>
        /// <param name="Table">資料表名稱</param>
        public static void DropTable(string Table)
        {
            if (!DBExistTable(Table))
                return;

            string Statement = "DROP TABLE " + Table;
            ExCmd(Statement);
        }

        /// <summary>
        /// 關閉連線。通常於意外結束連線程序時使用
        /// </summary>
        public static void CloseConnect()
        {
            Conn.Close();
        }

        /// <summary>
        /// 清除表格內資料
        /// </summary>
        /// <param name="Table">表格名稱</param>
        public static void ClearTable(string Table)
        {
            string Statement = "DELETE FROM " + Table;
            ExCmd(Statement);
        }

        /// <summary>
        /// 檔案匯入資料表。請注意檔案格式是否符合資料表欄位
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="FilePath"></param>
        public static void BULK_INSERT(string Table, string FilePath)
        {
            string Statement = "BULK INSERT " + Table + " FROM '" + FilePath + "' WITH (FIELDTERMINATOR=',')";
            ExCmd(Statement);        
        }

        /// <summary>
        /// 收尋資料表，但只回傳第一個值
        /// </summary>
        /// <param name="Column">欄位名</param>
        /// <param name="Table">表格</param>
        /// <param name="Condition">條件</param>
        /// <returns></returns>
        public static string Search_One(String Column, String Table, String Condition)
        {
            DataTable T = Search(Table, Column, Condition);
            return T.Rows[0][0].ToString();
        }

        /// <summary>
        /// 檢查資料庫，若沒有的話則建構一個資料庫
        /// </summary>
        public static void Try_And_Set_DataBase()
        {
            //Check為連結到Master(系統預設資料庫)的連線字串
            SqlConnection tempConn = new SqlConnection(ConfigurationManager.ConnectionStrings["Check"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Select count(*) From ..Sysdatabases where Name='" + Conn.Database + "'", tempConn);
            tempConn.Open();
            int i = (int)cmd.ExecuteScalar();
            tempConn.Close();

            if (i != 1)
            {
                MessageBox.Show("Database not exist, try to create");

                tempConn.Open();
                #region 建立資料庫時必須確定mdf和ldf記錄檔不存在，避免重複儲存mdf和ldf檔案的錯誤
                if (System.IO.File.Exists("C:\\Program Files\\Microsoft SQL Server\\MSSQL10.DASSQL\\MSSQL\\Data\\DASMeterManagement.mdf"))
                {
                    System.IO.File.Delete("C:\\Program Files\\Microsoft SQL Server\\MSSQL10.DASSQL\\MSSQL\\Data\\DASMeterManagement.mdf");
                }
                if (System.IO.File.Exists("C:\\Program Files\\Microsoft SQL Server\\MSSQL10.DASSQL\\MSSQL\\Data\\DASMeterManagement_log.ldf"))
                {
                    System.IO.File.Delete("C:\\Program Files\\Microsoft SQL Server\\MSSQL10.DASSQL\\MSSQL\\Data\\DASMeterManagement_log.ldf");
                }
                if (System.IO.File.Exists("C:\\Program Files\\Microsoft SQL Server\\MSSQL.1\\MSSQL\\Data\\DASMeterManagement.mdf"))
                {
                    System.IO.File.Delete("C:\\Program Files\\Microsoft SQL Server\\MSSQL.1\\MSSQL\\Data\\DASMeterManagement.mdf");
                }
                if (System.IO.File.Exists("C:\\Program Files\\Microsoft SQL Server\\MSSQL.1\\MSSQL\\Data\\DASMeterManagement_log.ldf"))
                {
                    System.IO.File.Delete("C:\\Program Files\\Microsoft SQL Server\\MSSQL.1\\MSSQL\\Data\\DASMeterManagement_log.ldf");
                }
                #endregion

                cmd = new SqlCommand("CREATE DATABASE \"" + Conn.Database + "\"", tempConn);
                cmd.ExecuteNonQuery();
                tempConn.Close();

                MessageBox.Show("Database create finish");
            }
        }

        /// <summary>
        /// 判斷目前資料表裡有幾列資料
        /// </summary>
        /// <param name="Table">資料表名稱</param>
        public static int FindRowNumber(String Table)
        {
            try
            {
                DataTable dt = new DataTable();
                ODA = new SqlDataAdapter("SELECT * FROM " + Table, Conn);
                ODA.Fill(dt);
                return dt.Rows.Count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 增加一列有Menu名稱的資料表資料
        /// </summary>
        /// <param name="Table">資料表名稱</param>
        /// <param name="Column">資料欄位</param>
        /// <param name="Table_No">資料編號欄位</param>
        /// <param name="Num">資料編號</param>
        public static void Insert_Menu_Table(String Table, String[] Column, string Table_No, int Num)
        {
            string Statement = "INSERT INTO " + Table + "(";
            foreach (string s in Column)
                Statement += s + ",";
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += ") VALUES( ";
            Statement += "'" + Table_No + "',";
            Statement += "'" + Num + "',";
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += ")";
            Connect.ExCmd(Statement);
        }

        /// <summary>
        /// 增加一列有Menu名稱的資料表資料
        /// </summary>
        /// <param name="Table">資料表名稱</param>
        /// <param name="Column">資料欄位</param>
        /// <param name="Table_No">資料編號欄位</param>
        /// <param name="Num">資料編號</param>
        /// <param name="Name">資料名稱</param>
        public static void Insert_Menu_Table(String Table, String[] Column, string Table_No, int Num, string Name)
        {
            string Statement = "INSERT INTO " + Table + "(";
            foreach (string s in Column)
                Statement += s + ",";
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += ") VALUES( ";
            Statement += "'" + Table_No + "',";
            Statement += "'" + Num + "',";
            Statement += "'" + Name + "',";
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += ")";
            Connect.ExCmd(Statement);
        }

        /// <summary>
        /// 增加一列有Menu名稱的資料表資料
        /// </summary>
        /// <param name="Table">資料表名稱</param>
        /// <param name="Column">資料欄位</param>
        /// <param name="Table_No">資料編號欄位</param>
        /// <param name="Num">資料編號</param>
        /// <param name="Name">資料名稱</param>
        /// <param name="Name">間隔時間</param>
        public static void Insert_Menu_Table(String Table, String[] Column, string Table_No, int Num, string Name, int Time)
        {
            string Statement = "INSERT INTO " + Table + "(";
            foreach (string s in Column)
                Statement += s + ",";
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += ") VALUES( ";
            Statement += "'" + Table_No + "',";
            Statement += "'" + Num + "',";
            Statement += "'" + Name + "',";
            Statement += "'" + Time + "',";
            Statement = Statement.Remove(Statement.Length - 1);
            Statement += ")";
            Connect.ExCmd(Statement);
        }

        /// <summary>
        /// 搜尋資料表中可用的空資料編號
        /// </summary>
        /// <param name="Table">資料表名稱</param>
        public static string Find_Null_Menu_Number(string Table)
        {
            bool ExitFlag = false;
            int iEmptyNo;
            string Re_iEmptyNo;
            DataTable dt = Connect.Search(Table);

            for (iEmptyNo = 1; iEmptyNo <= 9999; iEmptyNo++)
            {
                ExitFlag = false;

                foreach (DataRow r in dt.Rows)
                {
                    if (Convert.ToInt16(r["Table_No"].ToString()) == iEmptyNo)
                    {
                        ExitFlag = true;
                        break;
                    }
                }
                if (ExitFlag == false)
                {
                    break;
                }
            }

            Re_iEmptyNo = Add_Zero_To_Table_Number(iEmptyNo);

            return Re_iEmptyNo;
        }

        /// <summary>
        /// 搜尋資料表中可用的空資料編號
        /// </summary>
        /// <param name="Table">資料表名稱</param>
        public static int Find_Null_Menu_Int_Number(string Table)
        {
            bool ExitFlag = false;
            int iEmptyNo;
            DataTable dt = Connect.Search(Table);

            for (iEmptyNo = 1; iEmptyNo <= 9999; iEmptyNo++)
            {
                ExitFlag = false;
                
                foreach (DataRow r in dt.Rows)
                {
                    if (Convert.ToInt16(r["Table_No"].ToString()) == iEmptyNo)
                    {
                        ExitFlag = true;
                        break;
                    }
                }
                if (ExitFlag == false)
                {
                    break;
                }
            }

            return iEmptyNo;
        }

        /// <summary>
        /// 搜尋Menu資料表中，對應資料名稱的資料編號
        /// </summary>
        /// <param name="Table">資料表名稱</param>
        /// <param name="DataName">資料名稱</param>
        public static string Find_Menu_Table_No(String Table, String DataName)
        {
            int Table_No = 0;
            string Re_Table_No;
            DataTable dtTable;
            dtTable = Connect.Search(Table);

            foreach (DataRow dr in dtTable.Rows)
            {
                if (dr[0].ToString() == DataName)
                {
                    Table_No = Convert.ToInt32(dr[1]);
                    break;
                }
            }

            Re_Table_No = Add_Zero_To_Table_Number(Table_No);

            return Re_Table_No;
        }

        /// <summary>
        /// 搜尋Menu資料表中，對應資料名稱的資料編號
        /// </summary>
        /// <param name="Table">資料表名稱</param>
        /// <param name="DataName">資料名稱</param>
        public static string[] Find_Display_Menu_Table_No(String Table, String DataName)
        {
            string Re_Table_No;
            DataTable dtTable;
            dtTable = Connect.Search(Table);
            ListBox listbox1 = new ListBox();

            foreach (DataRow dr in dtTable.Rows)
            {
                if (dr[0].ToString() == DataName)
                {
                    Re_Table_No = Add_Zero_To_Table_Number(Convert.ToInt32(dr[1]));
                    listbox1.Items.Add(Re_Table_No);
                }
            }
            string[] S_Table_No = new string[listbox1.Items.Count];
            for (int i = 0; i < S_Table_No.Length; i++)
            {
                S_Table_No[i] = listbox1.Items[i].ToString();
            }

            return S_Table_No;
        }

        /// <summary>
        /// 搜尋Menu資料表中，對應資料名稱的資料編號
        /// </summary>
        /// <param name="Table">資料表名稱</param>
        /// <param name="DataName">資料名稱</param>
        public static int Find_Menu_Int_Table_No(String Table, String DataName)
        {
            int Table_No = 0;
            DataTable dtTable;
            dtTable = Connect.Search(Table);

            foreach (DataRow dr in dtTable.Rows)
            {
                if (dr[0].ToString() == DataName)
                {
                    Table_No = Convert.ToInt32(dr[1]);
                    break;
                }
            }

            return Table_No;
        }

        /// <summary>
        /// 將Menu資料表使用的資料編號補零
        /// </summary>
        /// <param name="Table_No">資料編號</param>
        public static string Add_Zero_To_Table_Number(int Table_No)
        {
            string Re_Table_No;

            if (Table_No < 10)
                Re_Table_No = "000" + Convert.ToString(Table_No);
            else if (Table_No < 100)
                Re_Table_No = "00" + Convert.ToString(Table_No);
            else if (Table_No < 1000)
                Re_Table_No = "0" + Convert.ToString(Table_No);
            else
                Re_Table_No = Convert.ToString(Table_No);

            return Re_Table_No;
        }

        /// <summary>
        /// 將Menu資料表使用的資料編號補零
        /// </summary>
        /// <param name="Table_No">資料編號</param>
        public static string Add_Zero_To_Table_Number(string Table_No)
        {
            string Re_Table_No;

            if (Convert.ToInt32(Table_No) < 10)
                Re_Table_No = "000" + Convert.ToString(Table_No);
            else if (Convert.ToInt32(Table_No) < 100)
                Re_Table_No = "00" + Convert.ToString(Table_No);
            else if (Convert.ToInt32(Table_No) < 1000)
                Re_Table_No = "0" + Convert.ToString(Table_No);
            else
                Re_Table_No = Convert.ToString(Table_No);

            return Re_Table_No;
        }

        /// <summary>
        /// 將Menu資料表使用的資料編號補零
        /// </summary>
        /// <param name="Table_No">資料編號</param>
        public static string[] Add_Zero_To_Table_Number(int[] Table_No)
        {
            string[] Re_Table_No = new string[Table_No.Length];

            for (int i = 0; i < Re_Table_No.Length; i++)
            {
                if (Table_No[i] < 10)
                    Re_Table_No[i] = "000" + Convert.ToString(Table_No[i]);
                else if (Table_No[i] < 100)
                    Re_Table_No[i] = "00" + Convert.ToString(Table_No[i]);
                else if (Table_No[i] < 1000)
                    Re_Table_No[i] = "0" + Convert.ToString(Table_No[i]);
                else
                    Re_Table_No[i] = Convert.ToString(Table_No[i]);
            }
            return Re_Table_No;
        }

      /*  public static Boolean Same_ListName(string Table, string ListName)
        {
            string[] Name = Connect.AddColumnData_To_String(Table, "Name");
            foreach (string s in Name)
            {
                if (s == ListName)
                {
                    if (Setting.En_Language)
                        MessageBox.Show("\"" + s + "\" exist, please use other name.");
                    else
                        MessageBox.Show("\"" + s + "\" 已存在，請使用其他名稱。");
                    return true;
                }
            }
            return false;
        } */

        public static string Find_Table_Quantity(String TableName, String DataName)
        {
            string Quantity_Item = "";
            DataTable dtTable;
            dtTable = Connect.Search(TableName);

            foreach (DataRow dr in dtTable.Rows)
            {
                if (dr[0].ToString() == DataName)
                {
                    Quantity_Item = dr[2].ToString();
                    break;
                }
            }
            return Quantity_Item;
        }

        public static string Find_Table_Interval_Time(String TableName, String DataName)
        {
            string Interval_Time = "";
            DataTable dtTable;
            dtTable = Connect.Search(TableName);

            foreach (DataRow dr in dtTable.Rows)
            {
                if (dr[0].ToString() == DataName)
                {
                    Interval_Time = dr[3].ToString();
                    break;
                }
            }
            return Interval_Time;
        }

      /*  public static Boolean Same_ListName(string Menu, string Name_Column, string ListName)
        {
            string[] Name = Connect.AddColumnData_To_String(Menu, Name_Column);
            foreach (string s in Name)
            {
                if (s == ListName)
                {
                    if (Setting.En_Language)
                        MessageBox.Show("\"" + s + "\" exist, please use other name.");
                    else
                        MessageBox.Show("\"" + s + "\" 已存在，請使用其他名稱。");
                    return true;
                }
            }
            return false;
        } */

        public static string Find_Table_Number(String TableName, String DataName)
        {
            int Table_No = 0;
            string Re_Table_No;
            DataTable dtTable;
            dtTable = Connect.Search(TableName);

            foreach (DataRow dr in dtTable.Rows)
            {
                if (dr[0].ToString() == DataName)
                {
                    Table_No = Convert.ToInt32(dr[1]);
                    break;
                }
            }
            Re_Table_No = Add_Zero_To_Table_Number(Table_No);

            return Re_Table_No;
        }

        /// <summary>
        /// 資料表查詢功能
        /// </summary>
        /// <param name="Table">資料表名稱</param>
        /// <returns></returns>
        public static DataRow Search_Row(String Table, String Column, String Data)
        {
            try
            {
                DataTable dt = new DataTable();
                ODA = new SqlDataAdapter("SELECT * FROM " + Table, Conn);
                ODA.Fill(dt);
                DataRow Data_Row = null;

                foreach(DataRow dr in dt.Rows)
                {
                    if (dr[Column].ToString() == Data)
                    {
                        Data_Row = dr;
                        break;
                    }
                }
                return Data_Row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 資料表查詢功能
        /// </summary>
        /// <param name="Table">資料表名稱</param>
        /// <returns></returns>
        public static DataRow Search_Row(String Table, String Column, int Data)
        {
            try
            {
                DataTable dt = new DataTable();
                ODA = new SqlDataAdapter("SELECT * FROM " + Table, Conn);
                ODA.Fill(dt);
                DataRow Data_Row = null;

                foreach (DataRow dr in dt.Rows)
                {
                    if (Convert.ToInt32(dr[Column]) == Data)
                    {
                        Data_Row = dr;
                        break;
                    }
                }
                return Data_Row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
