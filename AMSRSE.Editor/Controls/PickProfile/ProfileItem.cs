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
    public class ProfileItem : Control
    {
        #region Dependency Properties

        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(ProfileItem), new PropertyMetadata(OnIsSelectedPropertyChanged));

        #endregion Dependency Properties

        #region Properties

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
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
            if (d is ProfileItem pi)
                pi.OnSelected?.Invoke();
        }

        #endregion Dependency Property Callbacks

        #region Methods

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            if (!IsSelected)
                IsSelected = true;
        }

        #endregion Methods
    }
}
