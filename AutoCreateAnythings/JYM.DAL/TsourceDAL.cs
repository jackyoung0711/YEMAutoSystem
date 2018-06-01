using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using MigrationData.DAL;

namespace HuaidingSoft.DAL
{
    public class TsourceDal<T> where T : new()
    {
        private readonly BaseTsourceDAL<T> bDal = new BaseTsourceDAL<T>();

        //批量添加
        public int AddBulkTSources(List<T> list, int flag)
        {
            List<SqlParameter> listParas;
            string strSql;
            this.bDal.GetBulkAddTSourceSqlAndParameters(list, flag, out strSql, out listParas);
            return SqlHelper.ExecuteNoneQuery(strSql, listParas.ToArray());
        }

        //添加
        public int AddTSource(T t, int flag)
        {
            //flag==0表示自增 flag==1表示非自增
            List<SqlParameter> listParas;
            string strSql;
            this.bDal.GetAddTSourceSqlAndParameters(t, flag, out strSql, out listParas);
            return SqlHelper.ExecuteNoneQuery(strSql, listParas.ToArray());
        }

        //删除
        public int DeleteTSource(string filedWhere)
        {
            string sql;
            this.bDal.GetDeleteTsourceSqlAndParameters(filedWhere, out sql);
            return SqlHelper.ExecuteNoneQuery(sql);
        }

        //获取某个类的所有的数据且按照什么排序
        public DataTable GetAllTSources(List<string> filedoutPut = null, string filedWhere = null, string filedOrder = null, string order = null, string limit = null)
        {
            T t = new T();
            Type tSource = t.GetType();
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("select ");
            if (filedoutPut != null)
            {
                if (filedoutPut.Count > 0)
                {
                    sbSql.Append(filedoutPut[0]);
                    for (int i = 1; i < filedoutPut.Count; i++)
                    {
                        sbSql.Append(",");
                        sbSql.Append(filedoutPut[i]);
                    }
                }
            }
            else
            {
                sbSql.Append("* ");
            }
            sbSql.Append(" from ");
            sbSql.Append(tSource.Name);
            if (!string.IsNullOrEmpty(filedWhere))
            {
                sbSql.Append(" where ");
                //sbSql.Append("");
                sbSql.Append(filedWhere);
            }
            if (!string.IsNullOrEmpty(filedOrder))
            {
                sbSql.Append(" order by ");
                sbSql.Append(filedOrder);
                sbSql.Append(" ");
                sbSql.Append(!string.IsNullOrEmpty(order) ? order : "DESC");
            }
            //限制数量
            if (!string.IsNullOrEmpty(limit))
            {
                sbSql.Append(" limit ");
                sbSql.Append(limit);
            }
            return SqlHelper.ExecuteDataTable(sbSql.ToString());
        }

        /// <summary>
        ///     查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable GetAllTSourcesByPage(string sql)
        {
            return SqlHelper.Query(sql, null, false);
        }

        //取出最大的id
        public int GetMaxTSourceid(string filedId, string filedWhere = null)
        {
            T t = new T();
            Type tSource = t.GetType();
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("select Max(");
            sbSql.Append(filedId);
            sbSql.Append(") from " + tSource.Name);
            if (!string.IsNullOrEmpty(filedWhere))
            {
                sbSql.Append(" where ");
                sbSql.Append(filedWhere);
            }
            object obj = SqlHelper.ExecuteScalar(sbSql.ToString());
            bool c = Equals(obj, null);
            bool d = Equals(obj, DBNull.Value);
            if (Equals(obj, null))
            {
                return -1;
            }
            if (Equals(obj, DBNull.Value))
            {
                return 0;
            }
            return Convert.ToInt32(obj);
        }

        ////判断类型
        public SqlParameter GetMysqlparameter(PropertyInfo info, object obj)
        {
            SqlParameter para = new SqlParameter();
            para.ParameterName = info.Name;
            string typeName = info.PropertyType.Name;
            switch (typeName)
            {
                case "Int32":
                    para.Value = Convert.ToInt32(info.GetValue(obj));
                    break;

                case "String":
                    para.Value = info.GetValue(obj).ToString();
                    break;

                case "Boolean":
                    para.Value = Convert.ToBoolean(info.GetValue(obj));
                    break;
            }
            return para;
        }

        //根据某些条件查询数据的数量
        public int GetNumsBySettings(string filedWhere = null)
        {
            T t = new T();
            Type tSource = t.GetType();
            StringBuilder sbSql = new StringBuilder();
            new List<SqlParameter>();
            sbSql.Append("select count(*) ");
            sbSql.Append("from ");
            sbSql.Append(tSource.Name);
            if (!string.IsNullOrEmpty(filedWhere))
            {
                sbSql.Append(" where ");
                //sbSql.Append("");
                sbSql.Append(filedWhere);
            }
            return Convert.ToInt32(SqlHelper.ExecuteScalar(sbSql.ToString()));
        }

        //修改
        public int UpdateTSource(T t)
        {
            List<SqlParameter> listParas;
            string strSql;
            this.bDal.GetUpdateTSourceSqlAndParameters(t, out strSql, out listParas);
            return SqlHelper.ExecuteNoneQuery(strSql);
        }

        //修改2
        public int UpdateTSource(string setFiled)
        {
            string strSql;
            List<SqlParameter> listParas;
            this.bDal.GetUpdateTSourceSqlAndParameters(setFiled, out strSql, out listParas);
            return SqlHelper.ExecuteNoneQuery(strSql);
        }
    }
}