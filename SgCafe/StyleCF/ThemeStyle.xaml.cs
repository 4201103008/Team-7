using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace StyleCF
{
    public partial class ThemeStyle : ResourceDictionary
    {
        public ThemeStyle()
        {
            InitializeComponent();
        }

        private void WindowRoot_Loaded(object sender, RoutedEventArgs e)
        {
            var _wind = (Window)((FrameworkElement)sender).TemplatedParent;
            // Update constraints.
            if (_wind.ResizeMode == ResizeMode.CanResize)
            {
                // Attach resizer
                WindowsResizer wr = new WindowsResizer(_wind);
                wr.addResizerRight((Rectangle)_wind.Template.FindName("rightSizeGrip", _wind));
                wr.addResizerLeft((Rectangle)_wind.Template.FindName("leftSizeGrip", _wind));
                wr.addResizerUp((Rectangle)_wind.Template.FindName("topSizeGrip", _wind));
                wr.addResizerDown((Rectangle)_wind.Template.FindName("bottomSizeGrip", _wind));
                wr.addResizerLeftUp((Rectangle)_wind.Template.FindName("topLeftSizeGrip", _wind));
                wr.addResizerRightUp((Rectangle)_wind.Template.FindName("topRightSizeGrip", _wind));
                wr.addResizerLeftDown((Rectangle)_wind.Template.FindName("bottomLeftSizeGrip", _wind));
                wr.addResizerRightDown((Rectangle)_wind.Template.FindName("bottomRightSizeGrip", _wind));
            }
        }

        private void GW_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var _wind = (Window)((FrameworkElement)sender).TemplatedParent;
            if (e.ClickCount == 2)
                bt_MaxState_Click(sender, e);
            else
            {
                if (_wind.WindowState == WindowState.Maximized)
                {
                    Size maxSize = new Size(_wind.ActualWidth, _wind.ActualHeight);
                    Size resSize = _wind.RestoreBounds.Size;

                    double curX = e.GetPosition(_wind).X;
                    double curY = e.GetPosition(_wind).Y;

                    double newX = curX / maxSize.Width * resSize.Width;
                    double newY = curY;

                    _wind.WindowState = WindowState.Normal;

                    _wind.Left = curX - newX;
                    _wind.Top = curY - newY;
                }
                _wind.DragMove();
            }
        }

        private void bt_Minimized_Click(object sender, RoutedEventArgs e)
        {
            var _wind = (Window)((FrameworkElement)sender).TemplatedParent;
            _wind.WindowState = WindowState.Minimized;
        }

        private void bt_MaxState_Click(object sender, RoutedEventArgs e)
        {
            var _wind = (Window)((FrameworkElement)sender).TemplatedParent;
            if (_wind.WindowState == WindowState.Maximized)
                _wind.WindowState = WindowState.Normal;
            else
                _wind.WindowState = WindowState.Maximized;
        }

        private void bt_Close_Click(object sender, RoutedEventArgs e)
        {
            var _wind = (Window)((FrameworkElement)sender).TemplatedParent;
            _wind.Close();
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var _wind = (Window)((FrameworkElement)sender).TemplatedParent;
            _wind.DragMove();
            if (_wind.WindowState == WindowState.Maximized)
                _wind.WindowState = WindowState.Normal;
        }
    }
}