using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using JYM.Model;
using JYM.Service;
using MigrationData.DAL;

namespace JYM.AutoSystem
{
    internal static class Program
    {
        /// <summary>
        ///     应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //2.将回调的开户数据更新到数据库中
            Task.Run(() =>
            {
                JymService jymService = new JymService();
                while (true)
                {
                    try
                    {
                        DataTable dt = SqlHelper.Query("select Id,UserIdentifier from accountUsers where IsActivity=0 order by Id desc", null, false);
                        if (dt.Rows.Count == 0)
                        {
                            Thread.Sleep(100);
                            continue;
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow dr = dt.Rows[i];
                            string userIdentifier = dr["UserIdentifier"].ToString();
                            UserInfo userInfo = jymService.GetUserInfoAsync(userIdentifier).Result;
                            if (userInfo != null)
                            {
                                if (userInfo.IsActivation)
                                {
                                    //更新
                                    SqlHelper.ExecuteNoneQuery($"update accountUsers set IsActivity=1,IsVerifed=1 where Id={dr["Id"]}");
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Thread.Sleep(100);
                    }
                }
            });
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AutoSystemForm());
        }
    }
}