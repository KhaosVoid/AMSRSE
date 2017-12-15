using AMSRSE.Editor.Animation;
using AMSRSE.Editor.Commands;
using AMSRSE.Editor.Views.Dynamic.PickProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AMSRSE.Editor.Controls.PickProfile
{
    [TemplatePart(Name = PART_SelectedProfileActionsDV, Type = typeof(SelectedProfileActionsDV))]
    public class ProfileItem : AnimatedControl
    {
        #region Template Parts

        private const string PART_SelectedProfileActionsDV = "PART_SelectedProfileActionsDV";
        private SelectedProfileActionsDV _templatePart_SelectedProfileActionsDV;

        #endregion Template Parts

        #region Dependency Properties

        public static readonly DependencyProperty FileNameProperty =
            DependencyProperty.Register("FileName", typeof(string), typeof(ProfileItem));

        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(ProfileItem), new PropertyMetadata(OnIsSelectedPropertyChanged));

        public static readonly DependencyProperty CloseProfileCommandProperty =
            DependencyProperty.Register("CloseProfileCommand", typeof(DelegateCommand), typeof(ProfileItem));

        #endregion Dependency Properties

        #region Properties

        public string FileName
        {
            get { return (string)GetValue(FileNameProperty); }
            set { SetValue(FileNameProperty, value); }
        }

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public DelegateCommand CloseProfileCommand
        {
            get { return (DelegateCommand)GetValue(CloseProfileCommandProperty); }
            set { SetValue(CloseProfileCommandProperty, value); }
        }

        #endregion Properties

        #region Events

        public delegate void SelectedHandler();
        public event SelectedHandler OnSelected;

        public delegate void ProfileActionsFadedOutHandler();
        public event ProfileActionsFadedOutHandler OnProfileActionsFadedOut;

        #endregion Events

        #region Ctor

        public ProfileItem()
        {
            
        }

        #endregion Ctor

        #region Dependency Property Callbacks

        private static void OnIsSelectedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ProfileItem pi && pi.IsSelected)
                pi.OnSelected?.Invoke();
        }

        #endregion Dependency Property Callbacks

        #region Methods

        public override void OnApplyTemplate()
        {
            //_templatePart_SelectedProfileActionsDV = this.GetTemplateChild(PART_SelectedProfileActionsDV) as SelectedProfileActionsDV;

            
            //_templatePart_SelectedProfileActionsDV.Animations["FadeOut"].Completed -= ProfileItem_ProfileActionsFadeOutAnimationCompleted;
            //_templatePart_SelectedProfileActionsDV.Animations["FadeOut"].Completed += ProfileItem_ProfileActionsFadeOutAnimationCompleted;

            //_templatePart_SelectedProfileActionsDV.OnFadeOutComplete += () =>
            //{
            //    OnProfileActionsFadedOut?.Invoke();
            //};

            base.OnApplyTemplate();
        }

        private void ProfileItem_ProfileActionsFadeOutAnimationCompleted(SequentialStoryboardItem ssbi)
        {
            OnProfileActionsFadedOut?.Invoke();
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            if (!IsSelected)
                IsSelected = true;
        }

        public void FadeInActions()
        {
            //_templatePart_SelectedProfileActionsDN.FadeIn();

            //_templatePart_SelectedProfileActionsDV.Animations["FadeIn"].Start();
        }

        public void FadeOutActions()
        {
            //_templatePart_SelectedProfileActionsDN.FadeOut();

            //_templatePart_SelectedProfileActionsDV.Animations["FadeOut"].Start();
        }

        #endregion Methods
    }
}
