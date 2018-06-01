using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MigrationData.DAL
{
    public static class SqlHelper
    {
        private static readonly string constring = ConfigurationManager.AppSettings["autoSystemConnectionstr"];

        /// <summary>
        ///     返回datatable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pms"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] pms)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(constring);
            connection.Open();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connection))
            {
                if (pms != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                adapter.Fill(dt);
            }
            return dt;
        }

        /// <summary>
        ///     执行增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pms"></param>
        /// <returns></returns>
        public static int ExecuteNoneQuery(string sql, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        ///     返回单个值
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pms"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static DataTable Query(string sql, SqlParameter[] plist, bool proc)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    SqlCommand cmd = new SqlCommand(sql, con) { CommandTimeout = 50000000 };
                    if (plist != null)
                    {
                        cmd.Parameters.AddRange(plist);
                    }
                    if (proc)
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                return dt;
            }
            return dt;
        }

        public static bool SqlBulkCopyByDatatable(string dtName, DataTable dt, out string message)
        {
            bool result = false;
            message = string.Empty;
            try
            {
                using (SqlConnection conn = new SqlConnection(constring))
                {
                    conn.Open();
                    using (SqlBulkCopy sqlbulkcopy =
                        new SqlBulkCopy(constring, SqlBulkCopyOptions.UseInternalTransaction))
                    {
                        sqlbulkcopy.BulkCopyTimeout = 3600;
                        sqlbulkcopy.DestinationTableName = dtName;
                        sqlbulkcopy.BatchSize = 1000;
                        sqlbulkcopy.NotifyAfter = 1;
                        //sqlbulkcopy.SqlRowsCopied += Sqlbulkcopy_SqlRowsCopied;
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            sqlbulkcopy.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);
                        }
                        sqlbulkcopy.WriteToServer(dt);
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return result;
        }
    }
}