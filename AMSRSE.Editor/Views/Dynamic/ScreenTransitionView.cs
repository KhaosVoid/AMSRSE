using AMSRSE.Editor.Controls.SpriteButton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AMSRSE.Editor.Views.Dynamic
{
    public class ScreenTransitionView : DynamicViewBase
    {
        #region Enums

        public enum Transitions
        {
            SlideFadeIn,
            SlideFadeOut
        }

        #endregion Enums

        #region Dependency Properties

        public static readonly DependencyProperty TransitionProperty =
            DependencyProperty.RegisterAttached("Transition", typeof(Transitions), typeof(ScreenTransitionView));

        #endregion Dependency Properties

        #region Ctor

        public ScreenTransitionView()
        {

        }

        #endregion Ctor

        #region Attached Property Methods

        public static Transitions GetTransition(SpriteButton sb)
        {
            return (Transitions)sb.GetValue(TransitionProperty);
        }

        public static void SetTransition(SpriteButton sb, Transitions value)
        {
            sb.SetValue(TransitionProperty, value);
        }

        #endregion Attached Property Methods
    }
}
