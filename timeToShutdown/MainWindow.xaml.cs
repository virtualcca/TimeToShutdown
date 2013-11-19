using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Globalization;

namespace timeToShutdown
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private delegate void timeToCommand(int cmd);
        public static MainWindow MW = null;
        timeToCommand TCD;
        DispatcherTimer timer = new DispatcherTimer();
        private NotifyIcon notifyIcon = null;
        private Boolean boolShutdown = false;
        int Time,cmd;

        //引用DLL关机API
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct TokPriv1Luid
        {
            public int Count;
            public long Luid;
            public int Attr;
        }  

        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GetCurrentProcess();

        [DllImport("advapi32.dll", ExactSpelling =
        true, SetLastError = true)]
        internal static extern bool OpenProcessToken(
        IntPtr h, int acc, ref IntPtr phtok);

        [DllImport("advapi32.dll", SetLastError = true)]
        internal static extern bool LookupPrivilegeValue
        (string host, string name, ref long pluid);

        [DllImport("advapi32.dll", ExactSpelling =
        true, SetLastError = true)]
        internal static extern bool
        AdjustTokenPrivileges(IntPtr htok, bool disall,
        ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool ExitWindowsEx(int flg, int rea);  
        //引用结束

        //关机代码
        internal const int SE_PRIVILEGE_ENABLED = 0x00000002;
        internal const int TOKEN_QUERY = 0x00000008;
        internal const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
        internal const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";
        internal const int EWX_LOGOFF = 0x00000000;
        internal const int EWX_SHUTDOWN = 0x00000001;
        internal const int EWX_REBOOT = 0x00000002;
        internal const int EWX_FORCE = 0x00000004;
        internal const int EWX_POWEROFF = 0x00000008;
        internal const int EWX_FORCEIFHUNG = 0x00000010;

        private static void DoExitWin(int flg)
        {
            bool ok;
            TokPriv1Luid tp;
            IntPtr hproc = GetCurrentProcess();
            IntPtr htok = IntPtr.Zero;
            ok = OpenProcessToken(hproc,
            TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, ref htok);
            tp.Count = 1;
            tp.Luid = 0;
            tp.Attr = SE_PRIVILEGE_ENABLED;
            ok = LookupPrivilegeValue(
            null, SE_SHUTDOWN_NAME, ref tp.Luid);
            ok = AdjustTokenPrivileges(
            htok, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero);
            ok = ExitWindowsEx(flg, 0);
        }//关机代码结束


        public MainWindow()
        {
            InitializeComponent();
            MW = this;
            //LoadLanguage();

            this.Top = SystemParameters.PrimaryScreenHeight * 0.25;
            this.Left = SystemParameters.PrimaryScreenWidth * 0.3;

            System.Windows.Controls.TextBlock tliyan = new System.Windows.Controls.TextBlock();
            tliyan.Text = "Tina ";
            tliyan.FontFamily = new System.Windows.Media.FontFamily("微软雅黑");
            tliyan.FontSize = 16;
            tliyan.Margin = new System.Windows.Thickness(10, 0, 0, 2);
            tliyan.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
            tliyan.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            main.Children.Add(tliyan);


            timer.IsEnabled = true;
            timer.Interval = new TimeSpan(10000000);
            timer.Tick += new EventHandler(timer_Tick);
        }
        
        private void timer_Tick(object sender, EventArgs e) //时钟TICK
        {
            timeNow.Content = string.Concat("", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
        }

        private void close_Click(object sender, RoutedEventArgs e)//关闭
        {
            if (boolShutdown == true)
            {
                this.Hide();
                initialTray();
                notifyIcon.Visible = true;
            }
            else
            {
                notifyIcon = null;
                this.Close();
            }
        }

        private void min_Click(object sender, RoutedEventArgs e) //最小化
        {
            this.WindowState = WindowState.Minimized;
            initialTray();
            notifyIcon.Visible = true;
            this.Hide();
        }

        private void initialTray() //初始化托盘
        {

            notifyIcon = new NotifyIcon();
            notifyIcon.BalloonTipText = " ..程序运行中啦..";
            notifyIcon.ShowBalloonTip(1500);
            if (boolShutdown == true)
            {
                notifyIcon.Text = "距离倒计时还剩" + Time + "秒";
            }
            else
                notifyIcon.Text = "点此打开程序";
            notifyIcon.Icon = new System.Drawing.Icon(@"NotifyIcon.ico");
            notifyIcon.Visible = true;
            notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(NotifyIcon_MouseClick);
            //notifyIcon.ContextMenu

            System.Windows.Forms.MenuItem Exit = new System.Windows.Forms.MenuItem("退出");
            Exit.Click += new EventHandler(Exit_Click);

            System.Windows.Forms.MenuItem[] child = new System.Windows.Forms.MenuItem[] {Exit };

            notifyIcon.ContextMenu = new System.Windows.Forms.ContextMenu(child);
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            notifyIcon = null;
            this.Close();
        }


        private void NotifyIcon_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e) //托盘左键
        {
            if (e.Button == MouseButtons.Left)
            {
                    this.Visibility = Visibility.Visible;
                    this.WindowState = WindowState.Normal;
                    this.Activate();
                /*
                if (this.Visibility == Visibility.Visible)
                {
                    this.Visibility = Visibility.Hidden;
                }
                else
                {
                    this.Visibility = Visibility.Visible;
                    this.WindowState = WindowState.Normal;
                    this.Activate();
                }*/
            }
        }

        private void Window_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void RunButton_Click(object sender, RoutedEventArgs e) //Run按钮
        {
            try
            {
                Time = int.Parse(timeTextBoxSecond.Text);
                Time += (int.Parse(timeTextBoxMinutes.Text) * 60);
                Time += (int.Parse(timeTextBoxHour.Text) * 3600);
            }
            catch(FormatException)
            {
                System.Windows.MessageBox.Show("请输入正确的时间", "时间输入错误");
            }

            if (Time < 10)
            {
                System.Windows.MessageBox.Show("输入的时间不能小于10s，请重新输入");
            }
            else
            {
                boolShutdown = true;

                if (PowerOff.IsChecked == true)
                    cmd = EWX_POWEROFF;
                else if (RestStart.IsChecked == true)
                    cmd = EWX_REBOOT;
                else if (LoginOff.IsChecked == true)
                    cmd = EWX_LOGOFF;
                else
                    cmd = EWX_FORCE;

                TCD = new timeToCommand(DoExitWin);

                timeTextBoxHour.IsReadOnly = true;
                timeTextBoxMinutes.IsReadOnly = true;
                timeTextBoxSecond.IsReadOnly = true;

                timer.Tick += new EventHandler(timeout_Tick);//添加倒计时到Tick
            }
        }

        private void timeout_Tick(object sender, EventArgs e)//倒计时
        {
            int hour, min, sec,temp;
            hour = Time / 3600;
            temp = Time % 3600;
            min = temp / 60;
            sec = temp % 60;

            timeTextBoxHour.Text = hour.ToString();
            timeTextBoxMinutes.Text = min.ToString();
            timeTextBoxSecond.Text = sec.ToString();

            if (Time == 0)
            {
                TCD(cmd);
                timer.Tick -= new EventHandler(timeout_Tick);//倒计时完成后取消Tick时事件
            }

            Time--;
        }

        private void timeTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)//验证输入
        {
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || e.Key.ToString() == "Tab")
                e.Handled = false;
            else if ((e.Key >= Key.D0 && e.Key <= Key.D9) && e.KeyboardDevice.Modifiers != ModifierKeys.Shift)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void timeTextBoxHour_LostFocus(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.TextBox txt = sender as System.Windows.Controls.TextBox;
            if (txt.Text == "" || txt.Text == "  " || txt.Text == " ")
            {
                System.Windows.MessageBox.Show("请输入有效数值");
                txt.Focus();
                txt.Text = "0";
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)//Cancel按钮
        {
            timer.Tick -= new EventHandler(timeout_Tick);

            timeTextBoxHour.IsReadOnly = false;
            timeTextBoxMinutes.IsReadOnly = false;
            timeTextBoxSecond.IsReadOnly = false;

            boolShutdown = false;
        }

        private void Set_Click(object sender, RoutedEventArgs e)//设置菜单
        {
            Set s = new Set();
            s.ShowDialog();
        }

        private void Clock_Click(object sender, RoutedEventArgs e)//Clock菜单
        {
            Clock c = new Clock();
            c.Show();
        }

        public void setBackGroup(string s)//设置背景(Public)
        {
            try
            {
                main.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(s));
            }
            catch
            {
                main.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f9f9f9"));
            }
        }

        private void Player_Click(object sender, RoutedEventArgs e)//播放器
        {
            media m = new media();
            m.Show();
        }

    }

    public class DataValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int? time = value as int?;
            if (time != null)
            {
                if (time <= 60)
                {
                    return new ValidationResult(true, null);
                }
            }
            return new ValidationResult(false, "Data Error");

        }
    }

}
