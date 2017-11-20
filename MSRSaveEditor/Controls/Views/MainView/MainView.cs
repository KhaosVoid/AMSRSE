using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MSRSaveEditor.Controls.Views.MainView
{
    public class MainView : Control
    {
        #region Dependency Properties

        public static readonly DependencyProperty ViewProperty =
            DependencyProperty.Register("View", typeof(ViewBase), typeof(MainView));

        #endregion Dependency Properties

        #region Properties

        public ViewBase View
        {
            get { return (ViewBase)GetValue(ViewProperty); }
            set { SetValue(ViewProperty, value); }
        }

        #endregion Properties

        #region Ctor

        public MainView()
        {

        }

        #endregion Ctor
    }
}
