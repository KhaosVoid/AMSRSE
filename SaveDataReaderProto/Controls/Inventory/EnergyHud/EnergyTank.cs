using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SaveDataReaderProto.Controls.Inventory.EnergyHud
{
    public class EnergyTank : Control
    {
        #region Dependency Properties

        public static readonly DependencyProperty HasEnergyProperty =
            DependencyProperty.Register("HasEnergy", typeof(bool), typeof(EnergyTank));

        #endregion Dependency Properties

        #region Properties

        public bool HasEnergy
        {
            get { return (bool)GetValue(HasEnergyProperty); }
            set { SetValue(HasEnergyProperty, value); }
        }

        #endregion Properties

        #region Ctor

        public EnergyTank()
        {
            
        }

        #endregion Ctor
    }
}
