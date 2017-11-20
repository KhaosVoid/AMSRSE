using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SaveDataReaderProto.Controls.Inventory.Equipment
{
    public class EquipmentContainer : Control
    {
        #region Dependency Properties

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(EquipmentCollection<EquipmentItem>), typeof(EquipmentContainer));

        #endregion Dependency Properties

        #region Properties

        public EquipmentCollection<EquipmentItem> Items
        {
            get { return (EquipmentCollection<EquipmentItem>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        #endregion Properties

        #region Ctor

        public EquipmentContainer()
        {
            Items = new EquipmentCollection<EquipmentItem>();
        }

        #endregion Ctor
    }
}
