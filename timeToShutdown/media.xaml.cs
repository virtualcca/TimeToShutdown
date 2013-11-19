using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace timeToShutdown
{
    /// <summary>
    /// media.xaml 的交互逻辑
    /// </summary>
    public partial class media : Window
    {
        bool play = false;

        public media()
        {
            InitializeComponent();
            MessageBox.Show("以下程序Bug好多 不弄了 特么的!");
            mediaElement1.LoadedBehavior = MediaState.Manual;
            mediaElement1.UnloadedBehavior = MediaState.Stop;

            makeStartButton();

        }

        private void makeEllipseButton()
        {
            Ellipse e = new Ellipse();
            e.Width = 34;
            e.Height = 34;
            e.Stroke = new SolidColorBrush(Colors.Black);
            e.StrokeThickness = 1;
            //e.MouseEnter += new MouseEventHandler((object sender, MouseEventArgs ee) => { Cursor = new System.Windows.Input.Cursor(@"C:\Windows\Cursors\aero_link_l.cur"); });
            e.MouseLeftButtonDown += new MouseButtonEventHandler(playEllipseMouseLeftButtonDown);
            RadialGradientBrush btnL = new RadialGradientBrush();
            btnL.RadiusX = 0.5;
            btnL.RadiusY = 0.5;
            btnL.Center = new Point(0.5, 0.5);
            btnL.GradientStops.Add(new GradientStop(Color.FromRgb(255,255,255), 0));
            btnL.GradientStops.Add(new GradientStop(Color.FromRgb(122, 122, 122), 0.8));
            btnL.GradientStops.Add(new GradientStop(Color.FromRgb(255, 255, 255), 1));
            e.Fill = btnL;
            playGrid.Children.Add(e);
        }

        private void makeStartButton()
        {
            makeEllipseButton();

            Polygon pg = new Polygon();
            pg.Stroke = new SolidColorBrush(Colors.Black);
            pg.StrokeThickness = 1;
            pg.Points.Add(new Point(23, 17));
            pg.Points.Add(new Point(11, 24));
            pg.Points.Add(new Point(11, 10));
            pg.Fill = new SolidColorBrush(Colors.Blue);
            pg.MouseLeftButtonDown += new MouseButtonEventHandler(playEllipseMouseLeftButtonDown);
            playGrid.Children.Add(pg);

            //Path ph = new Path();
            //ph.Stroke = new SolidColorBrush(Colors.Black);
            //ph.StrokeThickness = 1;
            //StreamGeometry sg = new StreamGeometry();
            //using (StreamGeometryContext sgc = sg.Open())
            //{
            //    sgc.BeginFigure(new Point(25, 17), false,true);
            //    sgc.LineTo(new Point(7,25),true,false);
            //    sgc.LineTo(new Point(7, 9), true, false);
            //}
            //sg.Freeze();
            //ph.Data = sg;
            //ph.Fill = new SolidColorBrush(Colors.Blue);
            //ph.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            //playGrid.Children.Add(ph);

        }

        private void makePauseButton()
        {
            makeEllipseButton();

            //Path ph = new Path();
            //ph.Stroke = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            //ph.StrokeThickness = 3;
            //StreamGeometry sg = new StreamGeometry();
            //using (StreamGeometryContext sgc = sg.Open())
            //{
            //    sgc.BeginFigure(new Point(12, 4), false, false);
            //    sgc.LineTo(new Point(12, 30), true, false);

            //    sgc.BeginFigure(new Point(120, 4), false, false);
            //    sgc.LineTo(new Point(20, 30), true, false);
            //}
            //sg.Freeze();
            //ph.Data = sg;
            //playGrid.Children.Add(ph);

            Rectangle r1 = new Rectangle();
            r1.Fill = new SolidColorBrush(Colors.Blue);
            r1.Width = 4;
            r1.Height = 15;
            r1.Margin = new Thickness(-10, 2,0,0);
            playGrid.Children.Add(r1);

            Rectangle r2 = new Rectangle();
            r2.Fill = new SolidColorBrush(Colors.Blue);
            r2.Width = 4;
            r2.Height = 15;
            r2.Margin = new Thickness(10, 2, 0, 0);
            playGrid.Children.Add(r2);
        }

        private void Open_Click(object sender,RoutedEventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.CheckPathExists = true;
            od.CheckPathExists = true;
            od.DefaultExt = "avi视频文件|*avi||mp4视频文件|*.mp4";
            od.Title = "Open The Video";

            if (od.ShowDialog().Value)
            {
                mediaElement1.Source = new System.Uri(od.FileName);
                
                play = true;

                //MediaTimeline mtl = new MediaTimeline();
                //mtl.Source = new System.Uri(od.FileName);
                //mediaElement1.BeginAnimation(MediaElement.SourceProperty, mtl);
                //time = mtl.Duration;
                //mediaElement1_MediaOpened_1(this, e);
            }

        }

        private void playEllipseMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            if (play == false)
            {
                playGrid.Children.Clear();
                makeStartButton();
                mediaElement1.Play();
                play = true;
            }
            else
            {
                playGrid.Children.Clear();
                makePauseButton();
                mediaElement1.Pause();
                play = false;
            }
            text.Text = mediaElement1.Position.ToString();
        }

        private void mediaElement1_MediaOpened_1(object sender, RoutedEventArgs e)
        {
            //mediaElement1.Play();
            Slider1.Maximum = mediaElement1.NaturalDuration.TimeSpan.TotalMilliseconds;
            text.Text = mediaElement1.NaturalDuration.TimeSpan.TotalMilliseconds.ToString();
        }

        private void mediatimeline_CurrentTimeInvalidated_1(object sender, EventArgs e)
        {
            Slider1.Value = mediaElement1.Position.TotalMilliseconds;
        }

    }
}
