using AMSRSE.Editor.Animation;
using AMSRSE.Editor.Commands;
using AMSRSE.Editor.Views.Dynamic;
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
    [TemplatePart(Name = PART_ProfileMetadata, Type = typeof(Grid))]
    [TemplatePart(Name = PART_PkprflDecisionView, Type = typeof(DynamicViewHost))]
    public class ProfileItem : AnimatedControl
    {
        #region Template Parts

        private const string PART_ProfileMetadata = "PART_ProfileMetadata";
        private Grid _templatePart_ProfileMetadata;

        private const string PART_PkprflDecisionView = "PART_PkprflDecisionView";
        private DynamicViewHost _templatePart_PkprflDecisionView;

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
            _templatePart_ProfileMetadata = this.GetTemplateChild(PART_ProfileMetadata) as Grid;
            _templatePart_PkprflDecisionView = this.GetTemplateChild(PART_PkprflDecisionView) as DynamicViewHost;

            _templatePart_ProfileMetadata.MouseDown += _templatePart_ProfileMetadata_MouseDown;
            _templatePart_PkprflDecisionView.Opacity = 0;

            base.OnApplyTemplate();
        }

        private void _templatePart_ProfileMetadata_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsSelected)
                IsSelected = true;
        }

        private void ProfileItem_ProfileActionsFadeOutAnimationCompleted(SequentialStoryboardItem ssbi)
        {
            OnProfileActionsFadedOut?.Invoke();
        }

        public void FadeInActions()
        {
            _templatePart_PkprflDecisionView.Animations["FadeIn"].Completed += (ssbi) =>
            {
                var test1 = this;
                var test2 = _templatePart_PkprflDecisionView;
                var test3 = System.Windows.Media.Animation.Storyboard.GetTarget(((StoryboardSequence)ssbi).Storyboard.Children[0]);
            };

            _templatePart_PkprflDecisionView.Animations["FadeIn"].Start();
            //_templatePart_SelectedProfileActionsDN.FadeIn();
            //_templatePart_SelectedProfileActionsDV.Animations["FadeIn"].Start();
        }

        public void FadeOutActions()
        {
            _templatePart_PkprflDecisionView.Animations["FadeOut"].Start();
            //_templatePart_SelectedProfileActionsDN.FadeOut();

            //_templatePart_SelectedProfileActionsDV.Animations["FadeOut"].Start();
        }

        #endregion Methods
    }
}
