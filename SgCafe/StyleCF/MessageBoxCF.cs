using System.Windows;

namespace StyleCF
{
    public class MessageBoxCF
    {
        public static MessageBoxResult Show(string caption)
        {
            return MSGB.ShowCore(caption);
        }
        public static MessageBoxResult Show(string caption, string messageBoxText)
        {
            return MSGB.ShowCore(caption, messageBoxText);
        }
        public static MessageBoxResult Show(string caption, string messageBoxText, MessageBoxImage icon)
        {
            return MSGB.ShowCore(caption, messageBoxText, icon);
        }
        public static MessageBoxResult Show(string caption, string messageBoxText, MessageBoxImage icon, MessageBoxButton button)
        {
            return MSGB.ShowCore(caption, messageBoxText, icon, button);
        }
    }
}
