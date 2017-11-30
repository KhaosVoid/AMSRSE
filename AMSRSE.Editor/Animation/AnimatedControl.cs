using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AMSRSE.Editor.Animation
{
    public abstract class AnimatedControl : Control
    {
        #region Dependency Properties

        public static readonly DependencyProperty AnimationsProperty =
            DependencyProperty.Register("Animations", typeof(SequentialStoryboard), typeof(AnimatedControl));

        #endregion Dependency Properties

        #region Properties

        public SequentialStoryboard Animations
        {
            get { return (SequentialStoryboard)GetValue(AnimationsProperty); }
            set { SetValue(AnimationsProperty, value); }
        }

        #endregion Properties

        #region Ctor

        public AnimatedControl()
        {

        }

        #endregion Ctor
    }
}
