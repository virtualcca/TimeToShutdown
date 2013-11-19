using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Globalization;

namespace timeToShutdown
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup_1(object sender, StartupEventArgs e)
        {
            //base.OnStartup(e);
            LoadLanguage();
        }

        private void LoadLanguage() //载入语言配置
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            ResourceDictionary langRd = null;
            try
            {
                langRd = System.Windows.Application.LoadComponent(new Uri(@"Lang\" + currentCulture.Name + ".xaml", UriKind.Relative)) as ResourceDictionary;
            }
            catch
            { }
            if (langRd != null)
            {
                if (this.Resources.MergedDictionaries.Count > 0)
                {
                    this.Resources.MergedDictionaries.Clear();
                }
                this.Resources.MergedDictionaries.Add(langRd);
            }

        }
    }
}
