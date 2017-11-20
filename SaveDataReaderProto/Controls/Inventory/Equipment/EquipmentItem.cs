using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SaveDataReaderProto.Controls.Inventory.Equipment
{
    public class EquipmentItem : Control
    {
        #region Dependency Properties

        public static readonly DependencyProperty UnselectedIconProperty =
            DependencyProperty.Register("UnselectedIcon", typeof(ImageSource), typeof(EquipmentItem));

        public static readonly DependencyProperty SelectedIconProperty =
            DependencyProperty.Register("SelectedIcon", typeof(ImageSource), typeof(EquipmentItem));

        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(EquipmentItem));

        #endregion Dependency Properties

        #region Properties

        public ImageSource UnselectedIcon
        {
            get { return (ImageSource)GetValue(UnselectedIconProperty); }
            set { SetValue(UnselectedIconProperty, value); }
        }

        public ImageSource SelectedIcon
        {
            get { return (ImageSource)GetValue(SelectedIconProperty); }
            set { SetValue(SelectedIconProperty, value); }
        }

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        #endregion Properties

        #region Events

        public delegate void EquipmentItemToggleHandler(bool isSelected);
        public event EquipmentItemToggleHandler OnEquipmentItemToggled;

        #endregion Events

        #region Ctor

        public EquipmentItem()
        {
            
        }

        #endregion Ctor

        #region Methods

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            IsSelected = !IsSelected;

            OnEquipmentItemToggled?.Invoke(IsSelected);
        }

        #endregion Methods
    }
}
