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

                this.Animations["RetractProfile0"].Start();
            });

            _closeProfile1Command = new DelegateCommand((o) =>
            {
                _templatePart_ProfileItem1.FadeOutActions();
                _templatePart_ProfileItem1.IsSelected = false;

                _templatePart_ProfileItem0.Visibility = Visibility.Visible;
                _templatePart_ProfileItem2.Visibility = Visibility.Visible;

                this.Animations["RetractProfile1"].Start();
            });

            _closeProfile2Command = new DelegateCommand((o) =>
            {
                _templatePart_ProfileItem2.FadeOutActions();
                _templatePart_ProfileItem2.IsSelected = false;

                _templatePart_ProfileItem0.Visibility = Visibility.Visible;
                _templatePart_ProfileItem1.Visibility = Visibility.Visible;

                this.Animations["RetractProfile2"].Start();
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

                _templatePart_ProfileItem0.OnSelected += _templatePart_ProfileItem0_OnSelected;
                _templatePart_ProfileItem1.OnSelected += _templatePart_ProfileItem1_OnSelected;
                _templatePart_ProfileItem2.OnSelected += _templatePart_ProfileItem2_OnSelected;

                _templatePart_ProfileItem0.OnProfileActionsFadedOut += _templatePart_ProfileItem0_OnProfileActionsFadedOut;
                _templatePart_ProfileItem1.OnProfileActionsFadedOut += _templatePart_ProfileItem1_OnProfileActionsFadedOut;
                _templatePart_ProfileItem2.OnProfileActionsFadedOut += _templatePart_ProfileItem2_OnProfileActionsFadedOut;

                _templatePart_ProfileItem0.CloseProfileCommand = _closeProfile0Command;
                _templatePart_ProfileItem1.CloseProfileCommand = _closeProfile1Command;
                _templatePart_ProfileItem2.CloseProfileCommand = _closeProfile2Command;

                this.Animations["ExpandProfile0"].Completed += ExpandProfile0_Completed;
                this.Animations["ExpandProfile1"].Completed += ExpandProfile1_Completed;
                this.Animations["ExpandProfile2"].Completed += ExpandProfile2_Completed;
            }
        }

        private void ExpandProfile0_Completed(SequentialStoryboardItem ssbi)
        {
            _templatePart_ProfileItem0.FadeInActions();
        }

        private void ExpandProfile1_Completed(SequentialStoryboardItem ssbi)
        {
            _templatePart_ProfileItem1.FadeInActions();
        }

        private void ExpandProfile2_Completed(SequentialStoryboardItem ssbi)
        {
            _templatePart_ProfileItem2.FadeInActions();
        }

        private void _templatePart_ProfileItem0_OnSelected()
        {
            this.Animations["ExpandProfile0"].Start();
        }

        private void _templatePart_ProfileItem1_OnSelected()
        {
            this.Animations["ExpandProfile1"].Start();
        }

        private void _templatePart_ProfileItem2_OnSelected()
        {
            this.Animations["ExpandProfile2"].Start();
        }

        private void _templatePart_ProfileItem0_OnProfileActionsFadedOut()
        {
            this.Animations["RetractProfile0"].Start();
        }

        private void _templatePart_ProfileItem1_OnProfileActionsFadedOut()
        {
            this.Animations["RetractProfile1"].Start();
        }

        private void _templatePart_ProfileItem2_OnProfileActionsFadedOut()
        {
            this.Animations["RetractProfile2"].Start();
        }

        #endregion Methods
    }
}
