using System;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace StyleCF.Control
{
    class FontList : ObservableCollection<string>
    {
        public FontList()
        {
            foreach (FontFamily f in Fonts.SystemFontFamilies)
            {
                this.Add(f.ToString());
            }
        }
    }
}
