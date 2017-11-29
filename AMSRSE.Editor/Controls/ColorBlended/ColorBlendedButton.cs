using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MSRSaveEditor.Controls.ColorBlended
{
    public class ColorBlendedButton : ColorBlendedBase
    {
        #region Dependency Properties

        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(ColorBlendedButton));

        #endregion Dependency Properties

        #region Properties

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        #endregion Properties

        #region Ctor

        public ColorBlendedButton()
        {

        }

        #endregion Ctor
    }
}
