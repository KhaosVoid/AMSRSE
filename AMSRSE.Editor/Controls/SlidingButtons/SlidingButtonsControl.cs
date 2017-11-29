using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AMSRSE.Editor.Controls.SlidingButtons
{
    public class SlidingButtonsControl : Control
    {
        #region Dependency Properties

        public static readonly DependencyProperty ChildrenProperty =
            DependencyProperty.Register("Children", typeof(SlideButtonCollection<SlideButton>), typeof(SlidingButtonsControl));

        #endregion Dependency Properties

        #region Properties

        public SlideButtonCollection<SlideButton> Children
        {
            get { return (SlideButtonCollection<SlideButton>)GetValue(ChildrenProperty); }
            set { SetValue(ChildrenProperty, value); }
        }

        #endregion Properties

        #region Ctor

        public SlidingButtonsControl()
        {
            Children = new SlideButtonCollection<SlideButton>();
        }

        #endregion Ctor
    }
}
