using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media.Animation;

namespace AMSRSE.Editor.Animation
{
    public class TemplatedAnimation : DependencyObject
    {
        #region Dependency Properties

        public static readonly DependencyProperty AnimationProperty =
            DependencyProperty.Register("Animation", typeof(Timeline), typeof(TemplatedAnimation));

        public static readonly DependencyProperty AnimationTargetNameProperty =
            DependencyProperty.Register("AnimationTargetName", typeof(string), typeof(TemplatedAnimation));

        #endregion Dependency Properties

        #region Properties

        public Timeline Animation
        {
            get { return (Timeline)GetValue(AnimationProperty); }
            set { SetValue(AnimationProperty, value); }
        }

        public string AnimationTargetName
        {
            get { return (string)GetValue(AnimationTargetNameProperty); }
            set { SetValue(AnimationTargetNameProperty, value); }
        }

        #endregion Properties

        #region Ctor

        public TemplatedAnimation()
        {
            
        }

        #endregion Ctor
    }
}
