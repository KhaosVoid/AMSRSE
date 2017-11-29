using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AMSRSE.Editor.Controls.SlidingButtons
{
    public class SlideButton : Control
    {
        #region Dependency Properties

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(RoutedCommand), typeof(SlideButton));

        #endregion Dependency Properties

        #region Properties

        public RoutedCommand Command
        {
            get { return (RoutedCommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        #endregion Properties

        #region Commands

        public static readonly RoutedCommand CommandButtonAction =
            new RoutedCommand("CommandButtonAction", typeof(SlideButton));

        #endregion Commands

        #region Ctor

        public SlideButton()
        {

        }

        #endregion Ctor

        #region Methods

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            Command?.Execute(null, this);

            base.OnMouseDown(e);
        }

        #endregion Methods
    }
}
