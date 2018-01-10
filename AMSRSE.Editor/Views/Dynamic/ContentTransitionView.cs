using AMSRSE.Editor.Controls.SpriteButton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AMSRSE.Editor.Views.Dynamic
{
    public class ContentTransitionView : DynamicViewBase
    {
        #region Enums

        public enum Transitions
        {
            FadeIn,
            FadeOut,
            SwipeFadeInLeft,
            SwipeFadeOutLeft,
            SwipeFadeInRight,
            SwipeFadeOutRight
        }

        #endregion Enums

        #region Dependency Properties

        public static readonly DependencyProperty TransitionProperty =
            DependencyProperty.RegisterAttached("Transition", typeof(Transitions), typeof(ContentTransitionView));

        #endregion Dependency Properties

        #region Ctor

        public ContentTransitionView()
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
