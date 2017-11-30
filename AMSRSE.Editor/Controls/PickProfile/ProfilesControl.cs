using AMSRSE.Editor.Animation;
using AMSRSE.Editor.Commands;
using AMSRSE.Editor.DataModels.Pkprfl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace AMSRSE.Editor.Controls.PickProfile
{
    [TemplatePart(Name = PART_ProfileItem0, Type = typeof(ProfileItem))]
    [TemplatePart(Name = PART_ProfileItem1, Type = typeof(ProfileItem))]
    [TemplatePart(Name = PART_ProfileItem2, Type = typeof(ProfileItem))]
    public class ProfilesControl : AnimatedControl
    {
        #region Template Parts

        private const string PART_ProfileItem0 = "PART_ProfileItem0";
        private ProfileItem _templatePart_ProfileItem0;

        private const string PART_ProfileItem1 = "PART_ProfileItem1";
        private ProfileItem _templatePart_ProfileItem1;

        private const string PART_ProfileItem2 = "PART_ProfileItem2";
        private ProfileItem _templatePart_ProfileItem2;

        #endregion Template Parts

        #region Dependency Properties

        public static readonly DependencyPropertyKey Profile0DataPropertyKey =
            DependencyProperty.RegisterReadOnly("Profile0Data", typeof(ProfileDataModel), typeof(ProfilesControl), null);

        public static readonly DependencyProperty Profile0DataProperty =
            Profile0DataPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey Profile1DataPropertyKey =
            DependencyProperty.RegisterReadOnly("Profile1Data", typeof(ProfileDataModel), typeof(ProfilesControl), null);

        public static readonly DependencyProperty Profile1DataProperty =
            Profile1DataPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey Profile2DataPropertyKey =
            DependencyProperty.RegisterReadOnly("Profile2Data", typeof(ProfileDataModel), typeof(ProfilesControl), null);

        public static readonly DependencyProperty Profile2DataProperty =
            Profile2DataPropertyKey.DependencyProperty;

        #endregion Dependency Properties

        #region Properties

        public ProfileDataModel Profile0Data
        {
            get { return (ProfileDataModel)GetValue(Profile0DataProperty); }
            private set { SetValue(Profile0DataPropertyKey, value); }
        }

        public ProfileDataModel Profile1Data
        {
            get { return (ProfileDataModel)GetValue(Profile1DataProperty); }
            private set { SetValue(Profile1DataPropertyKey, value); }
        }

        public ProfileDataModel Profile2Data
        {
            get { return (ProfileDataModel)GetValue(Profile2DataProperty); }
            private set { SetValue(Profile2DataPropertyKey, value); }
        }

        #endregion Properties

        #region Members

        private Storyboard _profile0FadeOutOtherProfilesStoryboard;
        private Storyboard _profile0ExpandProfileStoryboard;
        private Storyboard _profile0FadeInOtherProfilesStoryboard;
        private Storyboard _profile0RetractProfileStoryboard;

        private Storyboard _profile1FadeOutOtherProfilesStoryboard;
        private Storyboard _profile1ExpandProfileStoryboard;
        private Storyboard _profile1FadeInOtherProfilesStoryboard;
        private Storyboard _profile1RetractProfileStoryboard;

        private Storyboard _profile2FadeOutOtherProfilesStoryboard;
        private Storyboard _profile2ExpandProfileStoryboard;
        private Storyboard _profile2FadeInOtherProfilesStoryboard;
        private Storyboard _profile2RetractProfileStoryboard;

        private ThicknessAnimation _profile0SwipeLeftAnimation;
        private DoubleAnimation _profile0FadeOutAnimation;
        private ThicknessAnimation _profile0SwipeRightAnimation;
        private DoubleAnimation _profile0FadeInAnimation;
        private DoubleAnimation _profile0ExpandAnimation;
        private DoubleAnimation _profile0CollapseAnimation;
        private DoubleAnimation _profile0RestoreSizeAnimation;

        private ThicknessAnimation _profile1SwipeLeftAnimation;
        private DoubleAnimation _profile1FadeOutAnimation;
        private ThicknessAnimation _profile1SwipeRightAnimation;
        private DoubleAnimation _profile1FadeInAnimation;
        private DoubleAnimation _profile1ExpandAnimation;
        private DoubleAnimation _profile1CollapseAnimation;
        private DoubleAnimation _profile1RestoreSizeAnimation;

        private ThicknessAnimation _profile2SwipeLeftAnimation;
        private DoubleAnimation _profile2FadeOutAnimation;
        private ThicknessAnimation _profile2SwipeRightAnimation;
        private DoubleAnimation _profile2FadeInAnimation;
        private DoubleAnimation _profile2ExpandAnimation;
        private DoubleAnimation _profile2CollapseAnimation;
        private DoubleAnimation _profile2RestoreSizeAnimation;

        private double _animationSpeed = 4;

        #endregion Members

        #region Commands

        private DelegateCommand _closeProfile0Command;
        private DelegateCommand _closeProfile1Command;
        private DelegateCommand _closeProfile2Command;

        #endregion Commands

        #region Ctor

        public ProfilesControl()
        {
            _closeProfile0Command = new DelegateCommand((o) =>
            {
                _templatePart_ProfileItem0.FadeOutActions();
                _templatePart_ProfileItem0.IsSelected = false;

                _templatePart_ProfileItem1.Visibility = Visibility.Visible;
                _templatePart_ProfileItem2.Visibility = Visibility.Visible;

                _profile0RetractProfileStoryboard.Begin();
            });

            _closeProfile1Command = new DelegateCommand((o) =>
            {
                _templatePart_ProfileItem1.FadeOutActions();
                _templatePart_ProfileItem1.IsSelected = false;

                _templatePart_ProfileItem0.Visibility = Visibility.Visible;
                _templatePart_ProfileItem2.Visibility = Visibility.Visible;

                _profile1RetractProfileStoryboard.Begin();
            });

            _closeProfile2Command = new DelegateCommand((o) =>
            {
                _templatePart_ProfileItem2.FadeOutActions();
                _templatePart_ProfileItem2.IsSelected = false;

                _templatePart_ProfileItem0.Visibility = Visibility.Visible;
                _templatePart_ProfileItem1.Visibility = Visibility.Visible;

                _profile2RetractProfileStoryboard.Begin();
            });
        }

        #endregion Ctor

        #region Methods

        public override void OnApplyTemplate()
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                _templatePart_ProfileItem0 = this.GetTemplateChild(PART_ProfileItem0) as ProfileItem;
                _templatePart_ProfileItem1 = this.GetTemplateChild(PART_ProfileItem1) as ProfileItem;
                _templatePart_ProfileItem2 = this.GetTemplateChild(PART_ProfileItem2) as ProfileItem;

                CreateProfileAnimations();

                _templatePart_ProfileItem0.OnSelected += _templatePart_ProfileItem0_OnSelected;
                _templatePart_ProfileItem1.OnSelected += _templatePart_ProfileItem1_OnSelected;
                _templatePart_ProfileItem2.OnSelected += _templatePart_ProfileItem2_OnSelected;

                _templatePart_ProfileItem0.CloseProfileCommand = _closeProfile0Command;
                _templatePart_ProfileItem1.CloseProfileCommand = _closeProfile1Command;
                _templatePart_ProfileItem2.CloseProfileCommand = _closeProfile2Command;
            }

            base.OnApplyTemplate();
        }

        private void CreateProfileAnimations()
        {
            #region Create Base Animations

            ThicknessAnimation profileSwipeLeftAnimation = new ThicknessAnimation();
            DoubleAnimation profileFadeOutAnimation = new DoubleAnimation();
            ThicknessAnimation profileSwipeRightAnimation = new ThicknessAnimation();
            DoubleAnimation profileFadeInAnimation = new DoubleAnimation();
            DoubleAnimation profileExpandAnimation = new DoubleAnimation();
            DoubleAnimation profileCollapseAnimation = new DoubleAnimation();
            DoubleAnimation profileRestoreSizeAnimation = new DoubleAnimation();

            profileSwipeLeftAnimation.SpeedRatio = _animationSpeed;
            //profileSwipeLeftAnimation.From = new Thickness(0, 0, 0, 0);
            profileSwipeLeftAnimation.To = new Thickness(-64, 0, 0, 0);

            profileFadeOutAnimation.SpeedRatio = _animationSpeed;
            profileFadeOutAnimation.To = 0;

            profileSwipeRightAnimation.SpeedRatio = _animationSpeed;
            //profileSwipeRightAnimation.From = new Thickness(-64, 0, 0, 0);
            profileSwipeRightAnimation.To = new Thickness(0, 0, 0, 0);

            profileFadeInAnimation.SpeedRatio = _animationSpeed;
            profileFadeInAnimation.To = 1;

            profileExpandAnimation.SpeedRatio = _animationSpeed;
            //profileExpandAnimation.From = 140;
            profileExpandAnimation.To = 420;

            profileCollapseAnimation.SpeedRatio = _animationSpeed;
            //profileCollapseAnimation.From = 140;
            profileCollapseAnimation.To = 0;

            profileRestoreSizeAnimation.SpeedRatio = _animationSpeed;
            //profileRestoreSizeAnimation.From = 0;
            profileRestoreSizeAnimation.To = 140;

            #endregion Create Base Animations

            #region Create Animations for Profiles

            #region Clone Animations for Profile 0

            _profile0SwipeLeftAnimation = profileSwipeLeftAnimation.Clone();
            Storyboard.SetTarget(_profile0SwipeLeftAnimation, _templatePart_ProfileItem0);
            Storyboard.SetTargetProperty(_profile0SwipeLeftAnimation, new PropertyPath(MarginProperty));

            _profile0FadeOutAnimation = profileFadeOutAnimation.Clone();
            Storyboard.SetTarget(_profile0FadeOutAnimation, _templatePart_ProfileItem0);
            Storyboard.SetTargetProperty(_profile0FadeOutAnimation, new PropertyPath(OpacityProperty));

            _profile0SwipeRightAnimation = profileSwipeRightAnimation.Clone();
            Storyboard.SetTarget(_profile0SwipeRightAnimation, _templatePart_ProfileItem0);
            Storyboard.SetTargetProperty(_profile0SwipeRightAnimation, new PropertyPath(MarginProperty));

            _profile0FadeInAnimation = profileFadeInAnimation.Clone();
            Storyboard.SetTarget(_profile0FadeInAnimation, _templatePart_ProfileItem0);
            Storyboard.SetTargetProperty(_profile0FadeInAnimation, new PropertyPath(OpacityProperty));

            _profile0ExpandAnimation = profileExpandAnimation.Clone();
            Storyboard.SetTarget(_profile0ExpandAnimation, _templatePart_ProfileItem0);
            Storyboard.SetTargetProperty(_profile0ExpandAnimation, new PropertyPath(HeightProperty));

            _profile0CollapseAnimation = profileCollapseAnimation.Clone();
            Storyboard.SetTarget(_profile0CollapseAnimation, _templatePart_ProfileItem0);
            Storyboard.SetTargetProperty(_profile0CollapseAnimation, new PropertyPath(HeightProperty));

            _profile0RestoreSizeAnimation = profileRestoreSizeAnimation.Clone();
            Storyboard.SetTarget(_profile0RestoreSizeAnimation, _templatePart_ProfileItem0);
            Storyboard.SetTargetProperty(_profile0RestoreSizeAnimation, new PropertyPath(HeightProperty));

            #endregion Clone Animations for Profile 0

            #region Clone Animations for Profile 1

            _profile1SwipeLeftAnimation = profileSwipeLeftAnimation.Clone();
            Storyboard.SetTarget(_profile1SwipeLeftAnimation, _templatePart_ProfileItem1);
            Storyboard.SetTargetProperty(_profile1SwipeLeftAnimation, new PropertyPath(MarginProperty));

            _profile1FadeOutAnimation = profileFadeOutAnimation.Clone();
            Storyboard.SetTarget(_profile1FadeOutAnimation, _templatePart_ProfileItem1);
            Storyboard.SetTargetProperty(_profile1FadeOutAnimation, new PropertyPath(OpacityProperty));

            _profile1SwipeRightAnimation = profileSwipeRightAnimation.Clone();
            Storyboard.SetTarget(_profile1SwipeRightAnimation, _templatePart_ProfileItem1);
            Storyboard.SetTargetProperty(_profile1SwipeRightAnimation, new PropertyPath(MarginProperty));

            _profile1FadeInAnimation = profileFadeInAnimation.Clone();
            Storyboard.SetTarget(_profile1FadeInAnimation, _templatePart_ProfileItem1);
            Storyboard.SetTargetProperty(_profile1FadeInAnimation, new PropertyPath(OpacityProperty));

            _profile1ExpandAnimation = profileExpandAnimation.Clone();
            Storyboard.SetTarget(_profile1ExpandAnimation, _templatePart_ProfileItem1);
            Storyboard.SetTargetProperty(_profile1ExpandAnimation, new PropertyPath(HeightProperty));

            _profile1CollapseAnimation = profileCollapseAnimation.Clone();
            Storyboard.SetTarget(_profile1CollapseAnimation, _templatePart_ProfileItem1);
            Storyboard.SetTargetProperty(_profile1CollapseAnimation, new PropertyPath(HeightProperty));

            _profile1RestoreSizeAnimation = profileRestoreSizeAnimation.Clone();
            Storyboard.SetTarget(_profile1RestoreSizeAnimation, _templatePart_ProfileItem1);
            Storyboard.SetTargetProperty(_profile1RestoreSizeAnimation, new PropertyPath(HeightProperty));

            #endregion Clone Animations for Profile 1

            #region Clone Animations for Profile 2

            _profile2SwipeLeftAnimation = profileSwipeLeftAnimation.Clone();
            Storyboard.SetTarget(_profile2SwipeLeftAnimation, _templatePart_ProfileItem2);
            Storyboard.SetTargetProperty(_profile2SwipeLeftAnimation, new PropertyPath(MarginProperty));

            _profile2FadeOutAnimation = profileFadeOutAnimation.Clone();
            Storyboard.SetTarget(_profile2FadeOutAnimation, _templatePart_ProfileItem2);
            Storyboard.SetTargetProperty(_profile2FadeOutAnimation, new PropertyPath(OpacityProperty));

            _profile2SwipeRightAnimation = profileSwipeRightAnimation.Clone();
            Storyboard.SetTarget(_profile2SwipeRightAnimation, _templatePart_ProfileItem2);
            Storyboard.SetTargetProperty(_profile2SwipeRightAnimation, new PropertyPath(MarginProperty));

            _profile2FadeInAnimation = profileFadeInAnimation.Clone();
            Storyboard.SetTarget(_profile2FadeInAnimation, _templatePart_ProfileItem2);
            Storyboard.SetTargetProperty(_profile2FadeInAnimation, new PropertyPath(OpacityProperty));

            _profile2ExpandAnimation = profileExpandAnimation.Clone();
            Storyboard.SetTarget(_profile2ExpandAnimation, _templatePart_ProfileItem2);
            Storyboard.SetTargetProperty(_profile2ExpandAnimation, new PropertyPath(HeightProperty));

            _profile2CollapseAnimation = profileCollapseAnimation.Clone();
            Storyboard.SetTarget(_profile2CollapseAnimation, _templatePart_ProfileItem2);
            Storyboard.SetTargetProperty(_profile2CollapseAnimation, new PropertyPath(HeightProperty));

            _profile2RestoreSizeAnimation = profileRestoreSizeAnimation.Clone();
            Storyboard.SetTarget(_profile2RestoreSizeAnimation, _templatePart_ProfileItem2);
            Storyboard.SetTargetProperty(_profile2RestoreSizeAnimation, new PropertyPath(HeightProperty));

            #endregion Clone Animations for Profile 2

            #endregion Create Animations for Profiles

            #region Create Storyboards

            #region Create Storyboards for Profile 0

            _profile0FadeOutOtherProfilesStoryboard = new Storyboard();
            _profile0ExpandProfileStoryboard = new Storyboard();
            _profile0FadeInOtherProfilesStoryboard = new Storyboard();
            _profile0RetractProfileStoryboard = new Storyboard();

            _profile0FadeOutOtherProfilesStoryboard.Children.Add(_profile1FadeOutAnimation);
            _profile0FadeOutOtherProfilesStoryboard.Children.Add(_profile1SwipeLeftAnimation);
            _profile0FadeOutOtherProfilesStoryboard.Children.Add(_profile2FadeOutAnimation);
            _profile0FadeOutOtherProfilesStoryboard.Children.Add(_profile2SwipeLeftAnimation);
            _profile0FadeOutOtherProfilesStoryboard.Completed += (sender, e) =>
            {
                _profile0ExpandProfileStoryboard.Begin();
            };

            _profile0ExpandProfileStoryboard.Children.Add(_profile0ExpandAnimation);
            _profile0ExpandProfileStoryboard.Children.Add(_profile1CollapseAnimation);
            _profile0ExpandProfileStoryboard.Children.Add(_profile2CollapseAnimation);
            _profile0ExpandProfileStoryboard.Completed += (sender, e) =>
            {
                _templatePart_ProfileItem1.Visibility = Visibility.Collapsed;
                _templatePart_ProfileItem2.Visibility = Visibility.Collapsed;

                _templatePart_ProfileItem0.FadeInActions();
            };

            _profile0RetractProfileStoryboard.Children.Add(_profile0RestoreSizeAnimation);
            _profile0RetractProfileStoryboard.Children.Add(_profile1RestoreSizeAnimation);
            _profile0RetractProfileStoryboard.Children.Add(_profile2RestoreSizeAnimation);
            _profile0RetractProfileStoryboard.Completed += (sender, e) =>
            {
                _profile0FadeInOtherProfilesStoryboard.Begin();
            };

            _profile0FadeInOtherProfilesStoryboard.Children.Add(_profile1FadeInAnimation);
            _profile0FadeInOtherProfilesStoryboard.Children.Add(_profile1SwipeRightAnimation);
            _profile0FadeInOtherProfilesStoryboard.Children.Add(_profile2FadeInAnimation);
            _profile0FadeInOtherProfilesStoryboard.Children.Add(_profile2SwipeRightAnimation);

            #endregion Create Storyboards for Profile 0

            #region Create Storyboards for Profile 1

            _profile1FadeOutOtherProfilesStoryboard = new Storyboard();
            _profile1ExpandProfileStoryboard = new Storyboard();
            _profile1FadeInOtherProfilesStoryboard = new Storyboard();
            _profile1RetractProfileStoryboard = new Storyboard();

            _profile1FadeOutOtherProfilesStoryboard.Children.Add(_profile0FadeOutAnimation);
            _profile1FadeOutOtherProfilesStoryboard.Children.Add(_profile0SwipeLeftAnimation);
            _profile1FadeOutOtherProfilesStoryboard.Children.Add(_profile2FadeOutAnimation);
            _profile1FadeOutOtherProfilesStoryboard.Children.Add(_profile2SwipeLeftAnimation);
            _profile1FadeOutOtherProfilesStoryboard.Completed += (sender, e) =>
            {
                _profile1ExpandProfileStoryboard.Begin();
            };

            _profile1ExpandProfileStoryboard.Children.Add(_profile0CollapseAnimation);
            _profile1ExpandProfileStoryboard.Children.Add(_profile1ExpandAnimation);
            _profile1ExpandProfileStoryboard.Children.Add(_profile2CollapseAnimation);
            _profile1ExpandProfileStoryboard.Completed += (sender, e) =>
            {
                _templatePart_ProfileItem0.Visibility = Visibility.Collapsed;
                _templatePart_ProfileItem2.Visibility = Visibility.Collapsed;

                _templatePart_ProfileItem1.FadeInActions();
            };

            _profile1RetractProfileStoryboard.Children.Add(_profile0RestoreSizeAnimation);
            _profile1RetractProfileStoryboard.Children.Add(_profile1RestoreSizeAnimation);
            _profile1RetractProfileStoryboard.Children.Add(_profile2RestoreSizeAnimation);
            _profile1RetractProfileStoryboard.Completed += (sender, e) =>
            {
                _profile1FadeInOtherProfilesStoryboard.Begin();
            };

            _profile1FadeInOtherProfilesStoryboard.Children.Add(_profile0FadeInAnimation);
            _profile1FadeInOtherProfilesStoryboard.Children.Add(_profile0SwipeRightAnimation);
            _profile1FadeInOtherProfilesStoryboard.Children.Add(_profile2FadeInAnimation);
            _profile1FadeInOtherProfilesStoryboard.Children.Add(_profile2SwipeRightAnimation);

            #endregion Create Storyboards for Profile 1

            #region Create Storyboards for Profile 2

            _profile2FadeOutOtherProfilesStoryboard = new Storyboard();
            _profile2ExpandProfileStoryboard = new Storyboard();
            _profile2FadeInOtherProfilesStoryboard = new Storyboard();
            _profile2RetractProfileStoryboard = new Storyboard();

            _profile2FadeOutOtherProfilesStoryboard.Children.Add(_profile0FadeOutAnimation);
            _profile2FadeOutOtherProfilesStoryboard.Children.Add(_profile0SwipeLeftAnimation);
            _profile2FadeOutOtherProfilesStoryboard.Children.Add(_profile1FadeOutAnimation);
            _profile2FadeOutOtherProfilesStoryboard.Children.Add(_profile1SwipeLeftAnimation);
            _profile2FadeOutOtherProfilesStoryboard.Completed += (sender, e) =>
            {
                _profile2ExpandProfileStoryboard.Begin();
            };

            _profile2ExpandProfileStoryboard.Children.Add(_profile0CollapseAnimation);
            _profile2ExpandProfileStoryboard.Children.Add(_profile1CollapseAnimation);
            _profile2ExpandProfileStoryboard.Children.Add(_profile2ExpandAnimation);
            _profile2ExpandProfileStoryboard.Completed += (sender, e) =>
            {
                _templatePart_ProfileItem0.Visibility = Visibility.Collapsed;
                _templatePart_ProfileItem1.Visibility = Visibility.Collapsed;

                _templatePart_ProfileItem2.FadeInActions();
            };

            _profile2RetractProfileStoryboard.Children.Add(_profile0RestoreSizeAnimation);
            _profile2RetractProfileStoryboard.Children.Add(_profile1RestoreSizeAnimation);
            _profile2RetractProfileStoryboard.Children.Add(_profile2RestoreSizeAnimation);
            _profile2RetractProfileStoryboard.Completed += (sender, e) =>
            {
                _profile2FadeInOtherProfilesStoryboard.Begin();
            };

            _profile2FadeInOtherProfilesStoryboard.Children.Add(_profile0FadeInAnimation);
            _profile2FadeInOtherProfilesStoryboard.Children.Add(_profile0SwipeRightAnimation);
            _profile2FadeInOtherProfilesStoryboard.Children.Add(_profile1FadeInAnimation);
            _profile2FadeInOtherProfilesStoryboard.Children.Add(_profile1SwipeRightAnimation);

            #endregion Create Storyboards for Profile 2

            #endregion Create Storyboards
        }

        private void _templatePart_ProfileItem0_OnSelected()
        {
            _profile0FadeOutOtherProfilesStoryboard.Begin();
        }

        private void _templatePart_ProfileItem1_OnSelected()
        {
            _profile1FadeOutOtherProfilesStoryboard.Begin();
        }

        private void _templatePart_ProfileItem2_OnSelected()
        {
            _profile2FadeOutOtherProfilesStoryboard.Begin();
        }

        #endregion Methods
    }
}
