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

        private SequentialStoryboard _expandProfile0;
        private StoryboardSequence _expandProfile0_HideProfiles1_2;
        private StoryboardSequence _expandProfile0_ExpandProfile0;

        private SequentialStoryboard _retractProfile0;
        private StoryboardSequence _retractProfile0_RestoreProfiles;
        private StoryboardSequence _retractProfile0_ShowProfiles1_2;

        private SequentialStoryboard _expandProfile1;
        private StoryboardSequence _expandProfile1_HideProfiles0_2;
        private StoryboardSequence _expandProfile1_ExpandProfile1;

        private SequentialStoryboard _retractProfile1;
        private StoryboardSequence _retractProfile1_RestoreProfiles;
        private StoryboardSequence _retractProfile1_ShowProfiles0_2;

        private SequentialStoryboard _expandProfile2;
        private StoryboardSequence _expandProfile2_HideProfiles0_1;
        private StoryboardSequence _expandProfile2_ExpandProfile2;

        private SequentialStoryboard _retractProfile2;
        private StoryboardSequence _retractProfile2_RestoreProfiles;
        private StoryboardSequence _retractProfile2_ShowProfiles0_1;

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

                //_profile0RetractProfileStoryboard.Begin();
            });

            _closeProfile1Command = new DelegateCommand((o) =>
            {
                _templatePart_ProfileItem1.FadeOutActions();
                _templatePart_ProfileItem1.IsSelected = false;

                _templatePart_ProfileItem0.Visibility = Visibility.Visible;
                _templatePart_ProfileItem2.Visibility = Visibility.Visible;

                //_profile1RetractProfileStoryboard.Begin();
            });

            _closeProfile2Command = new DelegateCommand((o) =>
            {
                _templatePart_ProfileItem2.FadeOutActions();
                _templatePart_ProfileItem2.IsSelected = false;

                _templatePart_ProfileItem0.Visibility = Visibility.Visible;
                _templatePart_ProfileItem1.Visibility = Visibility.Visible;

                //_profile2RetractProfileStoryboard.Begin();
            });
        }

        #endregion Ctor

        #region Methods

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                _templatePart_ProfileItem0 = this.GetTemplateChild(PART_ProfileItem0) as ProfileItem;
                _templatePart_ProfileItem1 = this.GetTemplateChild(PART_ProfileItem1) as ProfileItem;
                _templatePart_ProfileItem2 = this.GetTemplateChild(PART_ProfileItem2) as ProfileItem;

                CreateProfileAnimations();

                _templatePart_ProfileItem0.OnSelected += _templatePart_ProfileItem0_OnSelected;
                _templatePart_ProfileItem1.OnSelected += _templatePart_ProfileItem1_OnSelected;
                _templatePart_ProfileItem2.OnSelected += _templatePart_ProfileItem2_OnSelected;

                _templatePart_ProfileItem0.OnProfileActionsFadedOut += _templatePart_ProfileItem0_OnProfileActionsFadedOut;
                _templatePart_ProfileItem1.OnProfileActionsFadedOut += _templatePart_ProfileItem1_OnProfileActionsFadedOut;
                _templatePart_ProfileItem2.OnProfileActionsFadedOut += _templatePart_ProfileItem2_OnProfileActionsFadedOut;

                _templatePart_ProfileItem0.CloseProfileCommand = _closeProfile0Command;
                _templatePart_ProfileItem1.CloseProfileCommand = _closeProfile1Command;
                _templatePart_ProfileItem2.CloseProfileCommand = _closeProfile2Command;
            }
        }

        private void CreateProfileAnimations()
        {
            #region Base Storyboard & Animations

            Storyboard _storyboard = new Storyboard() { SpeedRatio = 4 };

            ThicknessAnimation anim_ProfileSwipeLeft = this.Style.Resources["ANIM_ProfileSwipeLeft"] as ThicknessAnimation;
            DoubleAnimation anim_ProfileFadeOut = this.Style.Resources["ANIM_ProfileFadeOut"] as DoubleAnimation;
            ThicknessAnimation anim_ProfileSwipeRight = this.Style.Resources["ANIM_ProfileSwipeRight"] as ThicknessAnimation;
            DoubleAnimation anim_ProfileFadeIn = this.Style.Resources["ANIM_ProfileFadeIn"] as DoubleAnimation;
            DoubleAnimation anim_ProfileExpand = this.Style.Resources["ANIM_ProfileExpand"] as DoubleAnimation;
            DoubleAnimation anim_ProfileCollapse = this.Style.Resources["ANIM_ProfileCollapse"] as DoubleAnimation;
            DoubleAnimation anim_ProfileRestore = this.Style.Resources["ANIM_ProfileRestore"] as DoubleAnimation;

            #endregion Base Storyboard & Animations

            #region Assign Sequential Storyboards

            _expandProfile0 = Animations["ExpandProfile0"] as SequentialStoryboard;
            _expandProfile0_HideProfiles1_2 = _expandProfile0["HideProfiles1-2"] as StoryboardSequence;
            _expandProfile0_ExpandProfile0 = _expandProfile0["ExpandProfile0"] as StoryboardSequence;

            _retractProfile0 = Animations["RetractProfile0"] as SequentialStoryboard;
            _retractProfile0_RestoreProfiles = _retractProfile0["RestoreProfiles"] as StoryboardSequence;
            _retractProfile0_ShowProfiles1_2 = _retractProfile0["ShowProfiles1-2"] as StoryboardSequence;

            _expandProfile1 = Animations["ExpandProfile1"] as SequentialStoryboard;
            _expandProfile1_HideProfiles0_2 = _expandProfile1["HideProfiles0-2"] as StoryboardSequence;
            _expandProfile1_ExpandProfile1 = _expandProfile1["ExpandProfile1"] as StoryboardSequence;

            _retractProfile1 = Animations["RetractProfile1"] as SequentialStoryboard;
            _retractProfile1_RestoreProfiles = _retractProfile1["RestoreProfiles"] as StoryboardSequence;
            _retractProfile1_ShowProfiles0_2 = _retractProfile1["ShowProfiles0-2"] as StoryboardSequence;

            _expandProfile2 = Animations["ExpandProfile2"] as SequentialStoryboard;
            _expandProfile2_HideProfiles0_1 = _expandProfile2["HideProfiles0-1"] as StoryboardSequence;
            _expandProfile2_ExpandProfile2 = _expandProfile2["ExpandProfile2"] as StoryboardSequence;

            _retractProfile2 = Animations["RetractProfile2"] as SequentialStoryboard;
            _retractProfile2_RestoreProfiles = _retractProfile2["RestoreProfiles"] as StoryboardSequence;
            _retractProfile2_ShowProfiles0_1 = _retractProfile2["ShowProfiles0-1"] as StoryboardSequence;

            #endregion Assign Sequential Storyboards

            #region Add Animations for Profile 0

            _expandProfile0.Completed += _expandProfile0_Completed;

            _expandProfile0_HideProfiles1_2.Storyboard = _storyboard.Clone();
            _expandProfile0_HideProfiles1_2.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileSwipeLeft, _templatePart_ProfileItem1));
            _expandProfile0_HideProfiles1_2.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileFadeOut, _templatePart_ProfileItem1));
            _expandProfile0_HideProfiles1_2.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileSwipeLeft, _templatePart_ProfileItem2));
            _expandProfile0_HideProfiles1_2.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileFadeOut, _templatePart_ProfileItem2));

            _expandProfile0_ExpandProfile0.Storyboard = _storyboard.Clone();
            _expandProfile0_ExpandProfile0.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileExpand, _templatePart_ProfileItem0));
            _expandProfile0_ExpandProfile0.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileCollapse, _templatePart_ProfileItem1));
            _expandProfile0_ExpandProfile0.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileCollapse, _templatePart_ProfileItem2));

            _retractProfile0_RestoreProfiles.Storyboard = _storyboard.Clone();
            _retractProfile0_RestoreProfiles.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileRestore, _templatePart_ProfileItem0));
            _retractProfile0_RestoreProfiles.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileRestore, _templatePart_ProfileItem1));
            _retractProfile0_RestoreProfiles.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileRestore, _templatePart_ProfileItem2));

            _retractProfile0_ShowProfiles1_2.Storyboard = _storyboard.Clone();
            _retractProfile0_ShowProfiles1_2.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileSwipeRight, _templatePart_ProfileItem1));
            _retractProfile0_ShowProfiles1_2.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileFadeIn, _templatePart_ProfileItem1));
            _retractProfile0_ShowProfiles1_2.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileSwipeRight, _templatePart_ProfileItem2));
            _retractProfile0_ShowProfiles1_2.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileFadeIn, _templatePart_ProfileItem2));

            #endregion Add Animations for Profile 0

            #region Add Animations for Profile 1

            _expandProfile1.Completed += _expandProfile1_Completed;

            _expandProfile1_HideProfiles0_2.Storyboard = _storyboard.Clone();
            _expandProfile1_HideProfiles0_2.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileSwipeLeft, _templatePart_ProfileItem0));
            _expandProfile1_HideProfiles0_2.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileFadeOut, _templatePart_ProfileItem0));
            _expandProfile1_HideProfiles0_2.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileSwipeLeft, _templatePart_ProfileItem2));
            _expandProfile1_HideProfiles0_2.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileFadeOut, _templatePart_ProfileItem2));

            _expandProfile1_ExpandProfile1.Storyboard = _storyboard.Clone();
            _expandProfile1_ExpandProfile1.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileCollapse, _templatePart_ProfileItem0));
            _expandProfile1_ExpandProfile1.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileExpand, _templatePart_ProfileItem1));
            _expandProfile1_ExpandProfile1.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileCollapse, _templatePart_ProfileItem2));

            _retractProfile1_RestoreProfiles.Storyboard = _storyboard.Clone();
            _retractProfile1_RestoreProfiles.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileRestore, _templatePart_ProfileItem0));
            _retractProfile1_RestoreProfiles.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileRestore, _templatePart_ProfileItem1));
            _retractProfile1_RestoreProfiles.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileRestore, _templatePart_ProfileItem2));

            _retractProfile1_ShowProfiles0_2.Storyboard = _storyboard.Clone();
            _retractProfile1_ShowProfiles0_2.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileSwipeRight, _templatePart_ProfileItem0));
            _retractProfile1_ShowProfiles0_2.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileFadeIn, _templatePart_ProfileItem0));
            _retractProfile1_ShowProfiles0_2.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileSwipeRight, _templatePart_ProfileItem2));
            _retractProfile1_ShowProfiles0_2.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileFadeIn, _templatePart_ProfileItem2));

            #endregion Add Animations for Profile 1

            #region Add Animations for Profile 2

            _expandProfile2.Completed += _expandProfile2_Completed;

            _expandProfile2_HideProfiles0_1.Storyboard = _storyboard.Clone();
            _expandProfile2_HideProfiles0_1.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileSwipeLeft, _templatePart_ProfileItem0));
            _expandProfile2_HideProfiles0_1.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileFadeOut, _templatePart_ProfileItem0));
            _expandProfile2_HideProfiles0_1.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileSwipeLeft, _templatePart_ProfileItem1));
            _expandProfile2_HideProfiles0_1.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileFadeOut, _templatePart_ProfileItem1));

            _expandProfile2_ExpandProfile2.Storyboard = _storyboard.Clone();
            _expandProfile2_ExpandProfile2.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileCollapse, _templatePart_ProfileItem0));
            _expandProfile2_ExpandProfile2.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileCollapse, _templatePart_ProfileItem1));
            _expandProfile2_ExpandProfile2.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileExpand, _templatePart_ProfileItem2));

            _retractProfile2_RestoreProfiles.Storyboard = _storyboard.Clone();
            _retractProfile2_RestoreProfiles.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileRestore, _templatePart_ProfileItem0));
            _retractProfile2_RestoreProfiles.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileRestore, _templatePart_ProfileItem1));
            _retractProfile2_RestoreProfiles.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileRestore, _templatePart_ProfileItem2));

            _retractProfile2_ShowProfiles0_1.Storyboard = _storyboard.Clone();
            _retractProfile2_ShowProfiles0_1.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileSwipeRight, _templatePart_ProfileItem0));
            _retractProfile2_ShowProfiles0_1.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileFadeIn, _templatePart_ProfileItem0));
            _retractProfile2_ShowProfiles0_1.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileSwipeRight, _templatePart_ProfileItem1));
            _retractProfile2_ShowProfiles0_1.Storyboard.Children.Add(CloneAnimationForTarget(anim_ProfileFadeIn, _templatePart_ProfileItem1));

            #endregion Add Animations for Profile 2
        }

        private AnimationTimeline CloneAnimationForTarget(AnimationTimeline animation, DependencyObject target)
        {
            AnimationTimeline anim = animation.Clone();
            Storyboard.SetTarget(anim, target);

            return anim;
        }

        private void _expandProfile0_Completed(SequentialStoryboardItem ssbi)
        {
            _templatePart_ProfileItem0.FadeInActions();
        }

        private void _expandProfile1_Completed(SequentialStoryboardItem ssbi)
        {
            _templatePart_ProfileItem1.FadeInActions();
        }

        private void _expandProfile2_Completed(SequentialStoryboardItem ssbi)
        {
            _templatePart_ProfileItem2.FadeInActions();
        }

        private void _templatePart_ProfileItem0_OnSelected()
        {
            _expandProfile0.Start();
        }

        private void _templatePart_ProfileItem1_OnSelected()
        {
            _expandProfile1.Start();
        }

        private void _templatePart_ProfileItem2_OnSelected()
        {
            _expandProfile2.Start();
        }

        private void _templatePart_ProfileItem0_OnProfileActionsFadedOut()
        {
            _retractProfile0.Start();
        }

        private void _templatePart_ProfileItem1_OnProfileActionsFadedOut()
        {
            _retractProfile1.Start();
        }

        private void _templatePart_ProfileItem2_OnProfileActionsFadedOut()
        {
            _retractProfile2.Start();
        }

        #endregion Methods
    }
}
