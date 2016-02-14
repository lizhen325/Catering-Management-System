using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Configuration;
using System.Data;

namespace ItcastCater.DAL
{
    public class SqliteHelper
    {
        private static readonly string str = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

        /// <summary>
        /// 增删改 都可以
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="ps">sql语句中的参数</param>
        /// <returns>返回受影响的行数</returns>
        public static int ExecuteNonQuery(string sql, params SQLiteParameter[] ps)
        {
            using(SQLiteConnection con = new SQLiteConnection(str))
            {
                using(SQLiteCommand cmd = new SQLiteCommand(sql,con))
                {
                    if(ps!=null)
                    {
                        cmd.Parameters.AddRange(ps);

                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 查询首行首列
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="ps">sql语句中的参数</param>
        /// <returns>首行首列，object</returns>
        public static object ExecuteSclar(string sql, params SQLiteParameter[] ps)
        {
            using(SQLiteConnection con = new SQLiteConnection(str))
            {
                using(SQLiteCommand cmd = new SQLiteCommand(sql,con))
                {
                    con.Open();
                    if(ps!=null)
                    {
                        cmd.Parameters.AddRange(ps);
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 多行多列
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="ps">sql语句参数</param>
        /// <returns>多行多列</returns>
        public static SQLiteDataReader ExecuteReader(string sql, params SQLiteParameter[] ps)
        {
            SQLiteConnection con = new SQLiteConnection(str);
            using(SQLiteCommand cmd = new SQLiteCommand(sql,con))
            {
                if(ps!=null)
                {
                    cmd.Parameters.AddRange(ps);
                }
                try
                {
                    con.Open();
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch (Exception e)
                {
                    con.Close();
                    con.Dispose();
                    throw e;
                }
            }
        }

        /// <summary>
        /// 查询的是一个表
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="ps">sql语句参数</param>
        /// <returns>一个表</returns>
        public static DataTable ExecuteTable(string sql, params SQLiteParameter[] ps)
        {
            DataTable dt = new DataTable();
            using(SQLiteDataAdapter sda = new SQLiteDataAdapter(sql,str))
            {
                if(ps!=null)
                {
                    sda.SelectCommand.Parameters.AddRange(ps);
                }
                sda.Fill(dt);
                return dt;
            }
        }
    }
}
