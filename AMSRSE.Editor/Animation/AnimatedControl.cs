using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

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

        #region Members

        private static AnimatedControl testAnim;

        #endregion Members

        #region Methods

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (Animations?.Children.Count > 0)
                SetTargetsForAnimations(Animations);
        }

        private void SetTargetsForAnimations(SequentialStoryboard sequentialStoryboard)
        {
            for (int s = 0; s < sequentialStoryboard.Children.Count; s++)
            {
                if (sequentialStoryboard.Children[s] is SequentialStoryboard ssb)
                {
                    SetTargetsForAnimations(ssb);
                }

                else if (sequentialStoryboard.Children[s] is StoryboardSequence sbs)
                {
                    for (int a = 0; a < sbs.Storyboard?.Children.Count; a++)
                    {
                        string targetName = StoryboardSequence.GetAnimationTargetName(sbs.Storyboard.Children[a]);
                        var target = targetName.ToLower() == "self" ?
                            this : this.Template.FindName(targetName, this) as DependencyObject;

                        if (target is null)
                            throw new Exception("Could not find animation target!");

                        Storyboard.SetTarget(
                            element: sbs.Storyboard.Children[a],
                            value: target);
                    }
                }
            }
        }

        #endregion Methods
    }
}
