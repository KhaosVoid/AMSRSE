using AMSRSE.Editor.Animation;
using AMSRSE.Editor.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace AMSRSE.Editor.Views.Dynamic.PickProfile
{
    public class SelectedProfileActionsDV : DynamicViewBase
    {
        #region Dependency Properties

        public static readonly DependencyProperty CloseProfileCommandProperty =
            DependencyProperty.Register("CloseProfileCommand", typeof(DelegateCommand), typeof(SelectedProfileActionsDV));

        #endregion Dependency Properties

        #region Properties

        public DelegateCommand CloseProfileCommand
        {
            get { return (DelegateCommand)GetValue(CloseProfileCommandProperty); }
            set { SetValue(CloseProfileCommandProperty, value); }
        }

        #endregion Properties

        #region Members

        private Storyboard _fadeInStoryboard;
        private Storyboard _fadeOutStoryboard;

        private DoubleAnimation _fadeOutAnimation;
        private DoubleAnimation _fadeInAnimation;

        private double _animationSpeed = 4;

        #endregion Members

        #region Ctor

        public SelectedProfileActionsDV()
        {

        }

        #endregion Ctor

        #region Methods

        public override void OnApplyTemplate()
        {
            //CreateAnimations();

            base.OnApplyTemplate();
        }

        private void CreateAnimations()
        {
            _fadeInStoryboard = new Storyboard();
            _fadeOutStoryboard = new Storyboard();

            _fadeInAnimation = new DoubleAnimation();
            _fadeOutAnimation = new DoubleAnimation();

            Storyboard.SetTarget(_fadeInAnimation, this);
            Storyboard.SetTargetProperty(_fadeInAnimation, new PropertyPath(OpacityProperty));
            _fadeInAnimation.SpeedRatio = _animationSpeed;
            _fadeInAnimation.To = 1;

            Storyboard.SetTarget(_fadeOutAnimation, this);
            Storyboard.SetTargetProperty(_fadeOutAnimation, new PropertyPath(OpacityProperty));
            _fadeOutAnimation.SpeedRatio = _animationSpeed;
            _fadeOutAnimation.To = 0;

            _fadeInStoryboard.Children.Add(_fadeInAnimation);

            _fadeOutStoryboard.Children.Add(_fadeOutAnimation);
            _fadeOutStoryboard.Completed += (sender, e) => this.RaiseOnFadeOutComplete();
        }

        public override void FadeIn()
        {
            if (this.IsLoaded)
                this.Animations["FadeIn"].Start();

            else
                this.Opacity = 1;
            //_fadeInStoryboard.Begin();
        }

        public override void FadeOut()
        {
            this.Animations["FadeOut"].Start();
            //_fadeOutStoryboard.Begin();
        }

        #endregion Methods
    }
}
