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
    public class ProfileItem : Control
    {
        #region Template Parts

        private const string PART_SelectedProfileActionsDV = "PART_SelectedProfileActionsDV";
        private SelectedProfileActionsDV _templatePart_SelectedProfileActionsDN;

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
            _templatePart_SelectedProfileActionsDN = this.GetTemplateChild(PART_SelectedProfileActionsDV) as SelectedProfileActionsDV;

            base.OnApplyTemplate();
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            if (!IsSelected)
                IsSelected = true;
        }

        public void FadeInActions()
        {
            _templatePart_SelectedProfileActionsDN.FadeIn();
        }

        public void FadeOutActions()
        {
            _templatePart_SelectedProfileActionsDN.FadeOut();
        }

        #endregion Methods
    }
}
