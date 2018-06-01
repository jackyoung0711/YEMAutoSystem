using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace HuaidingSoft.DAL
{
    public class BaseTsourceDAL<T> where T : new()
    {
        //添加 获取addSql mysqlparameter[]
        public void GetAddTSourceSqlAndParameters(T t, int flag, out string strSql, out List<SqlParameter> listParas)
        {
            //flag==0表示自增 flag==1表示非自增
            listParas = new List<SqlParameter>();
            Type tSource = t.GetType(); //通过反射获取这个类的所有字段和数值
            StringBuilder sbSqlResult = new StringBuilder();
            StringBuilder sbSql = new StringBuilder();
            StringBuilder sbSql1 = new StringBuilder();
            PropertyInfo[] infos = tSource.GetProperties();
            sbSqlResult.Append("insert into " + tSource.Name + "(");
            for (int i = 0; i < infos.Length; i++)
            {
                listParas.Add(new SqlParameter("@" + infos[i].Name, infos[i].GetValue(t)));
                //infos[i].GetValue(
                if (flag == 0 && infos[i].Name == "Id") //自增不需要加第一个字段
                {
                    continue;
                }
                sbSql.Append(infos[i].Name + ",");
                sbSql1.Append("@" + infos[i].Name + ",");
            }
            sbSqlResult.Append(sbSql.Remove((sbSql.Length - 1), 1)); // + ")values(" + sbSql1.Remove((sbSql1.Length - 1), 1).ToString() + ")");
            sbSqlResult.Append(")values(");
            sbSqlResult.Append(sbSql1.Remove((sbSql1.Length - 1), 1) + ")");
            if (flag == 0)
            {
                listParas.RemoveAt(4);
            }
            strSql = sbSqlResult.ToString();
        }

        //批量添加
        public void GetBulkAddTSourceSqlAndParameters(List<T> list, int flag, out string sql, out List<SqlParameter> listParas)
        {
            listParas = new List<SqlParameter>();
            StringBuilder sbSqlResult = new StringBuilder();
            StringBuilder sbSql = new StringBuilder();
            T _t = new T();
            Type _tSource = _t.GetType();
            sbSqlResult.Append("insert into " + _tSource.Name + "(");
            PropertyInfo[] infos = _tSource.GetProperties();
            for (int i = 0; i < infos.Length; i++)
            {
                if (flag == 0 && i == 0) //自增不需要加第一个字段
                {
                    continue;
                }
                sbSql.Append(infos[i].Name + ",");
            }
            sbSqlResult.Append(sbSql.Remove((sbSql.Length - 1), 1));
            sbSqlResult.Append(")values");
            //拼接值
            StringBuilder sbSql1 = new StringBuilder();
            for (int m = 0; m < list.Count; m++)
            {
                T t = list[m];
                Type tSource = t.GetType(); //通过反射获取这个类的所有字段和数值
                PropertyInfo[] pInfos = tSource.GetProperties();
                sbSql1.Append("(");
                for (int j = 0; j < pInfos.Length; j++)
                {
                    if (flag == 0 && j == 0) //自增不需要加第一个字段
                    {
                        continue;
                    }
                    sbSql1.Append(this.GetString(pInfos[j], t));
                    sbSql1.Append(",");
                }
                sbSql1 = sbSql1.Remove((sbSql1.Length - 1), 1);
                sbSql1.Append("),");
            }
            sbSqlResult.Append(sbSql1.Remove((sbSql1.Length - 1), 1));
            sql = sbSqlResult.ToString();
        }

        //删除
        public void GetDeleteTsourceSqlAndParameters(string filedWhere, out string strSql)
        {
            StringBuilder sbStrSql = new StringBuilder();
            T t = new T();
            Type tSource = t.GetType();
            sbStrSql.Append("Delete from ");
            sbStrSql.Append(tSource.Name);
            if (!string.IsNullOrEmpty(filedWhere))
            {
                sbStrSql.Append(" where ");
                sbStrSql.Append(filedWhere);
            }
            strSql = sbStrSql.ToString();
        }

        //修改
        public void GetUpdateTSourceSqlAndParameters(T t, out string strSql, out List<SqlParameter> listParas)
        {
            StringBuilder sbSqlResult = new StringBuilder();
            listParas = new List<SqlParameter>();
            Type tSource = t.GetType(); //
            PropertyInfo[] infos = tSource.GetProperties();
            sbSqlResult.Append("update " + tSource.Name + " set ");

            for (int i = 1; i < infos.Length; i++)
            {
                sbSqlResult.Append(infos[i].Name); //+ "=?" + infos[i].Name + ","
                sbSqlResult.Append("=?");
                sbSqlResult.Append(infos[i].Name + ",");
                listParas.Add(new SqlParameter("?" + infos[i].Name, infos[i].GetValue(t)));
            }
            sbSqlResult = sbSqlResult.Remove((sbSqlResult.Length - 1), 1);
            sbSqlResult.Append(" where ");
            sbSqlResult.Append(infos[0].Name);
            sbSqlResult.Append("=?");
            sbSqlResult.Append(infos[0].Name);
            listParas.Add(new SqlParameter("?" + infos[0].Name, infos[0].GetValue(t)));
            strSql = sbSqlResult.ToString();
        }

        //修改2
        public void GetUpdateTSourceSqlAndParameters(string setFiled, out string strSql, out List<SqlParameter> listParas)
        {
            listParas = new List<SqlParameter>();
            T t = new T();
            Type tSource = t.GetType();
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("update ");
            sbSql.Append(tSource.Name);
            sbSql.Append(" set ");
            sbSql.Append(setFiled);
            strSql = sbSql.ToString();
        }

        ////判断类型
        private string GetString(PropertyInfo info, object obj)
        {
            string result = "";
            string typeName = info.PropertyType.Name;
            switch (typeName)
            {
                case "Int32":
                    result = info.GetValue(obj).ToString();
                    break;

                case "String":
                    result = "\'" + info.GetValue(obj) + "\'";
                    break;

                case "Int64":
                    result = info.GetValue(obj).ToString();
                    break;
                    //case "Boolean": para.Value = Convert.ToBoolean(info.GetValue(obj)); break;
            }
            return result;
        }
    }
}