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
using System.Globalization;

namespace StyleCF.Control
{
    public class NotBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool) value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("IsNullConverter");
        }
    }
    
    //public class selectTimeH : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        return ((TimeSpan)value).Hours;
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        return new TimeSpan((int)value,)
    //    }
    //}

    public partial class TimeCf : UserControl
    {
        private static readonly TimeSpan MinValidTime = new TimeSpan(0, 0, 0);
        private static readonly TimeSpan MaxValidTime = new TimeSpan(23, 59, 59);
        private TextBox selectedTextBox;
        
        public TimeCf()
        {
            InitializeComponent();

            SelectedTime = new TimeSpan(0, 0, 0);
        }

        public TimeSpan SelectedTime
        {
            get { return (TimeSpan)GetValue(SelectedTimeProperty); }
            set { SetValue(SelectedTimeProperty, value); }
        }

        public static readonly DependencyProperty SelectedTimeProperty =
            DependencyProperty.Register(
            "SelectedTime",
            typeof(TimeSpan),
            typeof(TimeCf),
            new FrameworkPropertyMetadata(TimeCf.MinValidTime, new PropertyChangedCallback(TimeCf.OnSelectedTimeChanged), new CoerceValueCallback(TimeCf.CoerceSelectedTime)));

        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }

        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register(
            "IsReadOnly",
            typeof(bool),
            typeof(TimeCf),
            new PropertyMetadata(false));

        public TimeSpan MinTime
        {
            get { return (TimeSpan)GetValue(MinTimeProperty); }
            set { SetValue(MinTimeProperty, value); }
        }

        public static readonly DependencyProperty MinTimeProperty =
            DependencyProperty.Register(
            "MinTime",
            typeof(TimeSpan),
            typeof(TimeCf),
            new FrameworkPropertyMetadata(TimeCf.MinValidTime, new PropertyChangedCallback(TimeCf.OnMinTimeChanged)),
            new ValidateValueCallback(TimeCf.IsValidTime));

        public TimeSpan MaxTime
        {
            get { return (TimeSpan)GetValue(MaxTimeProperty); }
            set { SetValue(MaxTimeProperty, value); }
        }

        public static readonly DependencyProperty MaxTimeProperty =
            DependencyProperty.Register(
            "MaxTime",
            typeof(TimeSpan),
            typeof(TimeCf),
            new FrameworkPropertyMetadata(TimeCf.MaxValidTime, new PropertyChangedCallback(TimeCf.OnMaxTimeChanged), new CoerceValueCallback(TimeCf.CoerceMaxTime)),
            new ValidateValueCallback(TimeCf.IsValidTime));

        public event RoutedPropertyChangedEventHandler<TimeSpan> SelectedTimeChanged
        {
            add { base.AddHandler(SelectedTimeChangedEvent, value); }
            remove { base.RemoveHandler(SelectedTimeChangedEvent, value); }
        }

        public static readonly RoutedEvent SelectedTimeChangedEvent =
            EventManager.RegisterRoutedEvent(
            "SelectedTimeChanged",
            RoutingStrategy.Bubble,
            typeof(RoutedPropertyChangedEventHandler<TimeSpan>),
            typeof(TimeCf));

        private static object CoerceSelectedTime(DependencyObject d, object value)
        {
            TimeCf timePicker = (TimeCf)d;
            TimeSpan minimum = timePicker.MinTime;
            if ((TimeSpan)value < minimum)
            {
                return minimum;
            }
            TimeSpan maximum = timePicker.MaxTime;
            if ((TimeSpan)value > maximum)
            {
                return maximum;
            }
            return value;
        }

        private static object CoerceMaxTime(DependencyObject d, object value)
        {
            TimeCf timePicker = (TimeCf)d;
            TimeSpan minimum = timePicker.MinTime;
            if ((TimeSpan)value < minimum)
            {
                return minimum;
            }
            return value;
        }

        private static bool IsValidTime(object value)
        {
            TimeSpan time = (TimeSpan)value;
            return MinValidTime <= time && time <= MaxValidTime;
        }

        protected virtual void OnSelectedTimeChanged(TimeSpan oldSelectedTime, TimeSpan newSelectedTime)
        {
            RoutedPropertyChangedEventArgs<TimeSpan> e = new RoutedPropertyChangedEventArgs<TimeSpan>(oldSelectedTime, newSelectedTime);
            e.RoutedEvent = SelectedTimeChangedEvent;
            base.RaiseEvent(e);
        }

        private static void OnSelectedTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TimeCf element = (TimeCf)d;
            element.OnSelectedTimeChanged((TimeSpan)e.OldValue, (TimeSpan)e.NewValue);
        }

        protected virtual void OnMinTimeChanged(TimeSpan oldMinTime, TimeSpan newMinTime)
        {
        }

        private static void OnMinTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TimeCf element = (TimeCf)d;
            element.CoerceValue(MaxTimeProperty);
            element.CoerceValue(SelectedTimeProperty);
            element.OnMinTimeChanged((TimeSpan)e.OldValue, (TimeSpan)e.NewValue);
        }

        protected virtual void OnMaxTimeChanged(TimeSpan oldMaxTime, TimeSpan newMaxTime)
        {
        }

        private static void OnMaxTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TimeCf element = (TimeCf)d;
            element.CoerceValue(SelectedTimeProperty);
            element.OnMaxTimeChanged((TimeSpan)e.OldValue, (TimeSpan)e.NewValue);
        }

        //private void editht(int s)
        //{
        //    if (s < 0 || s > 23)
        //        s = 0;
        //    s = s - SelectedTime.Hours;
        //    SelectedTime.Add(new TimeSpan(s, 0, 0));
        //}

        //private void editmt(int s)
        //{
        //    if (s < 0 || s > 59)
        //        s = 0;
        //    s = s - SelectedTime.Minutes;
        //    SelectedTime.Add(new TimeSpan(0, s, 0));
        //}

        //private void editst(int s)
        //{
        //    if (s < 0 || s > 59)
        //        s = 0;
        //    s = s - SelectedTime.Seconds;
        //    SelectedTime.Add(new TimeSpan(0, 0, s));
        //}

        private void IncrementDecrementTime(int step)
        {
            if (selectedTextBox == null)
            {
                selectedTextBox = PART_HourTextBox;
            }

            TimeSpan time;

            if (selectedTextBox == PART_HourTextBox)
            {
                time = SelectedTime.Add(new TimeSpan(step, 0, 0));
            }
            else if (selectedTextBox == PART_MinuteTextBox)
            {
                time = SelectedTime.Add(new TimeSpan(0, step, 0));
            }
            else
            {
                time = SelectedTime.Add(new TimeSpan(0, 0, step));
            }

            SelectedTime = time;
        }

        private void PART_IncrementButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsReadOnly)
                IncrementDecrementTime(1);
        }

        private void PART_DecrementButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsReadOnly)
                IncrementDecrementTime(-1);
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            selectedTextBox = sender as TextBox;
        }

        //private void TimePreviewTextInput(object sender, TextCompositionEventArgs e)
        //{
        //    if (!char.IsDigit(e.Text, e.Text.Length - 1))
        //        e.Handled = true;
        //}

        //private void TimeMouseLeave(object sender, MouseEventArgs e)
        //{
        //    int so;
        //    TextBox c = (TextBox)sender;
        //    if (c.Text.Length == 0)
        //        so = 0;
        //    else
        //        so = int.Parse(c.Text);
        //    if (c == PART_HourTextBox)
        //        so %= 24;
        //    else
        //        so %= 60;
        //    try
        //    {
        //        if (c == PART_HourTextBox)
        //        {
        //            so -= SelectedTime.Hours;
        //            SelectedTime = SelectedTime.Add(new TimeSpan(so, 0, 0));
        //        }
        //        else if (c == PART_MinuteTextBox)
        //        {
        //            so -= SelectedTime.Minutes;
        //            SelectedTime = SelectedTime.Add(new TimeSpan(0, so, 0));
        //        }
        //        else if (c == PART_SecondTextBox)
        //        {
        //            so -= SelectedTime.Seconds;
        //            SelectedTime = SelectedTime.Add(new TimeSpan(0, 0, so));
        //        }
        //    }
        //    catch { }
        //}
    }
}