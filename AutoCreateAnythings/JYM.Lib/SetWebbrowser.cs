using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Security.AccessControl;
using Microsoft.Win32;

namespace JYM.Lib
{
    /// <summary>
    ///     设置
    /// </summary>
    public static class SetWebbrowser
    {
        public static uint GeoEmulationModee(int browserVersion)
        {
            uint mode = 11000; // Internet Explorer 11. Webpages containing standards-based !DOCTYPE directives are displayed in IE11 Standards mode.
            switch (browserVersion)
            {
                case 7:
                    mode = 7000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE7 Standards mode.
                    break;

                case 8:
                    mode = 8000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE8 mode.
                    break;

                case 9:
                    mode = 9000; // Internet Explorer 9. Webpages containing standards-based !DOCTYPE directives are displayed in IE9 mode.
                    break;

                case 10:
                    mode = 10000; // Internet Explorer 10.
                    break;

                case 11:
                    mode = 11000; // Internet Explorer 11
                    break;
            }
            return mode;
        }

        public static int GetBrowserVersion()
        {
            int browserVersion = 0;
            using (RegistryKey ieKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer",
                RegistryKeyPermissionCheck.ReadSubTree,
                RegistryRights.QueryValues))
            {
                if (ieKey != null)
                {
                    object version = ieKey.GetValue("svcVersion");
                    if (null == version)
                    {
                        version = ieKey.GetValue("Version");
                        if (null == version)
                            throw new ApplicationException("Microsoft Internet Explorer is required!");
                    }
                    int.TryParse(version.ToString().Split('.')[0], out browserVersion);
                }
            }
            //如果小于7
            if (browserVersion < 7)
            {
                throw new ApplicationException("不支持的浏览器版本!");
            }
            return browserVersion;
        }

        public static void SumitForm(int ieVersion)
        {
            // don't change the registry if running in-proc inside Visual Studio
            if (LicenseManager.UsageMode != LicenseUsageMode.Runtime)
                return;
            //获取程序及名称
            string appName = Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);
            //得到浏览器的模式的值
            uint ieMode = GeoEmulationModee(ieVersion);

            string featureControlRegKey = @"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\";
            //设置浏览器对应用程序（appName）以什么模式（ieMode）运行
            Registry.SetValue(featureControlRegKey + "FEATURE_BROWSER_EMULATION",
                appName, ieMode, RegistryValueKind.DWord);
            // enable the features which are "On" for the full Internet Explorer browser
            //不晓得设置有什么用
            Registry.SetValue(featureControlRegKey + "FEATURE_ENABLE_CLIPCHILDREN_OPTIMIZATION",
                appName, 1, RegistryValueKind.DWord);
        }
    }
}