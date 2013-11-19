using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace timeToShutdown
{
    /// <summary>
    /// Clock.xaml 的交互逻辑
    /// </summary>
    public partial class Clock : Window
    {
        int hour, minute, second;
        double Hangle, Mangle, Sangle,centerX,centerY;
        Canvas canvas = new Canvas();
        DispatcherTimer timer = new DispatcherTimer();
        Path sp = new Path();
        Path mp = new Path();
        Path hp = new Path();
        Ellipse e;
        Ellipse clockDial;
        //TextBlock h = new TextBlock();
        //TextBlock m = new TextBlock();
        //TextBlock s = new TextBlock();
        //Line ls = new Line();

        public Clock()
        {
            InitializeComponent();

            this.windows.SizeToContent = System.Windows.SizeToContent.WidthAndHeight;
            this.windows.ResizeMode = System.Windows.ResizeMode.NoResize;
            this.windows.WindowStyle = System.Windows.WindowStyle.None;
            this.windows.AllowsTransparency = true;
            this.windows.Background = new SolidColorBrush(Color.FromArgb(00, 00, 00, 00)); ;
            this.windows.Height = 240;
            this.windows.Width = 240;

            hour = DateTime.Now.Hour % 12;
            minute = DateTime.Now.Minute;
            second = DateTime.Now.Second;

            canvas.Width = windows.Width;
            canvas.Height = windows.Width -20;

            canvas.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            canvas.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            //canvas.Background = new SolidColorBrush(Color.FromRgb(255,255,0));//显示canvas

            grid.Children.Add(canvas);

            Sangle = second * 6 - 90;
            Mangle = minute * 6 - 90;
            Hangle = (hour * 30) - 90 + (minute * 0.5);

            //RotateTransform rt = new RotateTransform();

            centerY = canvas.Height/2;
            centerX = canvas.Width/2;

            //h.Text = "  *-------->";
            //h.Width = 120;
            //h.Height = 12;
            //h.SetValue(Canvas.LeftProperty, canvas.Width/2);
            //h.SetValue(Canvas.TopProperty, canvas.Height/2 -10);
            //rt = new RotateTransform(Hangle, xRotate, yRotate);
            //h.RenderTransform = rt;
            //canvas.Children.Add(h);

            //m.Text = "  *----------->";
            //m.Width = h.Width;
            //m.Height = h.Height;
            //m.SetValue(Canvas.LeftProperty, centerX);
            //m.SetValue(Canvas.TopProperty, canvas.Height / 2 -10);
            //rt = new RotateTransform(Mangle, xRotate, yRotate);
            //m.RenderTransform = rt;
            //canvas.Children.Add(m);

            //s.Text = "--*---------------->";
            //s.Width = h.Width;
            //s.Height = h.Height;
            //s.SetValue(Canvas.LeftProperty, centerX);
            //s.SetValue(Canvas.TopProperty, canvas.Height / 2 -10);
            //rt = new RotateTransform(Sangle, xRotate, yRotate);
            //s.RenderTransform = rt;
            //canvas.Children.Add(s);

            //ls.Stroke = new SolidColorBrush(Colors.Black);
            ////ls.SetValue(Canvas.LeftProperty, centerX);
            ////ls.SetValue(Canvas.TopProperty, canvas.Height / 2 -10);
            //ls.X1 = 150;
            //ls.Y1 = 130;
            //ls.X2 = 220;
            //ls.Y2 = 130;
            //ls.RenderTransform = new RotateTransform(Sangle,150,130);
            //canvas.Children.Add(ls);

            //指针
            //Point ori = new Point(centerX, centerY);
            Point ori = new Point(centerX,centerY);

            Point spt = new Point(centerX + 90, centerY);
            timeLine(sp, ori, spt);
            sp.RenderTransform = new RotateTransform(Sangle, centerX, centerY);

            Point mpt = new Point(centerX + 65, centerY);
            timeLine(mp, ori, mpt);
            mp.RenderTransform = new RotateTransform(Mangle, centerX, centerY);

            Point hpt = new Point(centerX + 35, centerY);
            timeLine(hp, ori, hpt);
            hp.RenderTransform = new RotateTransform(Hangle, centerX, centerY);
            //指针结束

            e = new Ellipse(); //中心原点
            e.Width = 6;
            e.Height = 6;
            e.SetValue(Canvas.LeftProperty, centerX - e.Width/2);
            e.SetValue(Canvas.TopProperty, canvas.Height / 2 - e.Height/2);
            e.Fill = new SolidColorBrush(Colors.Black);
            grid.Children.Add(e);

            clockDial = new Ellipse(); //表盘
            clockDial.Width = 220;
            clockDial.Height = 220;
            clockDial.SetValue(Canvas.LeftProperty, centerX - clockDial.Width/2);
            clockDial.SetValue(Canvas.TopProperty, centerY - clockDial.Height/2);

            RadialGradientBrush rg = new RadialGradientBrush();
            rg.GradientOrigin = new Point(0.5, 0.5);
            rg.GradientStops.Add(new GradientStop(Color.FromRgb(122, 122, 122), 0.9));
            rg.GradientStops.Add(new GradientStop(Colors.Black, 0.92));
            rg.GradientStops.Add(new GradientStop(Color.FromRgb(200,200,200), 0.95));
            rg.GradientStops.Add(new GradientStop(Colors.Black, 0.98));
            rg.GradientStops.Add(new GradientStop(Color.FromRgb(99, 99, 99), 1));
            clockDial.Stroke = rg;
            clockDial.StrokeThickness = 6;
            clockDial.Fill = new SolidColorBrush(Color.FromArgb(08, 00, 00, 00));
            
            clockDial.MouseLeftButtonDown += new MouseButtonEventHandler(mouseLeftDownClockDiag);
            grid.MouseEnter += new MouseEventHandler(mouseMoveClockDiag);
            clockDial.MouseEnter += new MouseEventHandler(mouseMoveClockDiag);
            grid.MouseLeave += new MouseEventHandler((object sender, MouseEventArgs ee) => { canvas.Children.Clear(); referchCanvas(); });
            grid.Children.Add(clockDial);
            //表盘结束

            timer.Interval = new TimeSpan(10000000);
            timer.Tick += new EventHandler(timer_Tick);
            timer.IsEnabled = true;
            timer.Start();
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            //TextBlock timers = new TextBlock();
            //timers.Text = "    " + Hangle.ToString() + " " + Mangle.ToString() + " " + Sangle.ToString();
            //canvas.Children.Add(timers);

            this.canvas.Children.Clear();
            //this.canvas.Children.Remove(timers);

            hour = DateTime.Now.Hour % 12;
            minute = DateTime.Now.Minute;
            second = DateTime.Now.Second;

            Sangle = second * 6 - 90;
            Mangle = minute * 6 - 90;
            Hangle = (hour * 30) - 90 + (minute * 0.5);

            //h.RenderTransform = new RotateTransform(Hangle, xRotate, yRotate);
            //s.RenderTransform = new RotateTransform(Sangle, xRotate, yRotate);
            //m.RenderTransform = new RotateTransform(Mangle, xRotate, yRotate);

            //ls.RenderTransform = new RotateTransform(Sangle,150, 130);

            //canvas.Children.Add(h);
            //canvas.Children.Add(m);
            //canvas.Children.Add(s);
            //canvas.Children.Add(ls);

            sp.RenderTransform = new RotateTransform(Sangle, centerX, centerY);
            mp.RenderTransform = new RotateTransform(Mangle, centerX, centerY);
            hp.RenderTransform = new RotateTransform(Hangle, centerX, centerY);

            referchCanvas();
        }

        private void referchCanvas()
        {
            canvas.Children.Add(sp);
            canvas.Children.Add(mp);
            canvas.Children.Add(hp);;
        }

        private void timeLine(Path ph, Point pt1, Point pt2) //绘制线段
        {
            ph.Stroke = new SolidColorBrush(Colors.Black);
            ph.StrokeThickness = 2;

            StreamGeometry sg = new StreamGeometry();
            sg.FillRule = FillRule.EvenOdd;

            using (StreamGeometryContext sgt = sg.Open())
            {
                //List<Point> lp = new List<Point>();
               //lp.Add(new Point(pt2.X - 5, pt2.Y + 4));
                //lp.Add(new Point(pt2.X - 5, pt2.Y - 4));
                //lp.Add(pt2);

                sgt.BeginFigure(pt1,false,false);
                sgt.LineTo(pt2,true,false);

                sgt.BeginFigure(pt2, true, false);
                sgt.LineTo(new Point(pt2.X - 5, pt2.Y + 4),true,false);

                sgt.BeginFigure(pt2, true, false);
                sgt.LineTo(new Point(pt2.X - 5, pt2.Y - 4), true, false);

                //sgt.PolyLineTo(lp, true, true);
                //sgt.LineTo(new Point(pt2.X - 5, pt2.Y + 4), true, false);
                //sgt.LineTo(pt2, true, false);
                //sgt.LineTo(new Point(pt2.X - 5, pt2.Y - 4), true, false);
            }
            sg.Freeze();
            ph.Data = sg;
            canvas.Children.Add(ph);
        }

        private void mouseLeftDownClockDiag(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void mouseMoveClockDiag(object sender, MouseEventArgs e)
        {
            Grid g = new Grid();
            g.Width = 16;
            g.Height = 16;
            LinearGradientBrush lgb = new LinearGradientBrush();
            lgb.StartPoint = new Point(0, 1);
            lgb.EndPoint = new Point(0, 0);
            lgb.GradientStops.Add(new GradientStop(Colors.Red,0));
            lgb.GradientStops.Add(new GradientStop(Color.FromRgb(220,220,220), 1));
            g.Background = lgb;
            g.SetValue(Canvas.LeftProperty, canvas.Width - 30);

            Path p = new Path();
            p.Stroke = new SolidColorBrush(Colors.White);
            p.StrokeThickness = 2;
            StreamGeometry s = new StreamGeometry();
            using (StreamGeometryContext sgc = s.Open())
            {
                sgc.BeginFigure(new Point(2, 2), false, false);
                sgc.LineTo(new Point(12, 12), true, false);

                sgc.BeginFigure(new Point(12, 2), false, false);
                sgc.LineTo(new Point(2, 12), true, false);
            }
            s.Freeze();
            p.Data = s;
            
            g.Children.Add(p);
            g.MouseLeftButtonDown += new MouseButtonEventHandler((object senders, MouseButtonEventArgs ee) => { this.Close(); });
            canvas.Children.Add(g);
        }

    }
}
