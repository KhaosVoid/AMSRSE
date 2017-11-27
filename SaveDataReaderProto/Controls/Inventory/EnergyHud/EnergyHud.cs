using SaveDataReaderProto.DataModels.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SaveDataReaderProto.Controls.Inventory.EnergyHud
{
    public class EnergyHud : Control
    {
        #region Dependency Properties
        
        public static readonly DependencyProperty MaxEnergyProperty =
            InventoryDataModel.MaxEnergyProperty.AddOwner(typeof(EnergyHud), new PropertyMetadata(OnMaxEnergyPropertyChanged));

        public static readonly DependencyProperty CurrentEnergyProperty =
            InventoryDataModel.CurrentEnergyProperty.AddOwner(typeof(EnergyHud), new PropertyMetadata(OnCurrentEnergyPropertyChanged));

        public static readonly DependencyPropertyKey CurrentTankEnergyPropertyKey =
            DependencyProperty.RegisterReadOnly("CurrentTankEnergy", typeof(short), typeof(EnergyHud), null);

        public static readonly DependencyProperty CurrentTankEnergyProperty =
            CurrentTankEnergyPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey MaxEnergyTanksPropertyKey =
            DependencyProperty.RegisterReadOnly("MaxEnergyTanks", typeof(short), typeof(EnergyHud), new PropertyMetadata(OnMaxEnergyTanksPropertyChanged));

        public static readonly DependencyProperty MaxEnergyTanksProperty =
            MaxEnergyTanksPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey CurrentEnergyTanksPropertyKey =
            DependencyProperty.RegisterReadOnly("CurrentEnergyTanks", typeof(short), typeof(EnergyHud), new PropertyMetadata(OnCurrentEnergyTanksPropertyChanged));

        public static readonly DependencyProperty CurrentEnergyTanksProperty =
            CurrentEnergyTanksPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey EnergyTanksPropertyKey =
            DependencyProperty.RegisterReadOnly("EnergyTanks", typeof(ReadOnlyObservableCollection<EnergyTank>), typeof(EnergyHud), null);

        public static readonly DependencyProperty EnergyTanksProperty =
            EnergyTanksPropertyKey.DependencyProperty;

        #endregion Dependency Properties

        #region Properties

        public uint MaxEnergy
        {
            get { return (uint)GetValue(MaxEnergyProperty); }
            set { SetValue(MaxEnergyProperty, value); }
        }

        public uint CurrentEnergy
        {
            get { return (uint)GetValue(CurrentEnergyProperty); }
            set { SetValue(CurrentEnergyProperty, value); }
        }

        public short CurrentTankEnergy
        {
            get { return (short)GetValue(CurrentTankEnergyProperty); }
            private set { SetValue(CurrentTankEnergyPropertyKey, value); }
        }

        public short MaxEnergyTanks
        {
            get { return (short)GetValue(MaxEnergyTanksProperty); }
            private set { SetValue(MaxEnergyTanksPropertyKey, value); }
        }

        public short CurrentEnergyTanks
        {
            get { return (short)GetValue(CurrentEnergyTanksProperty); }
            private set { SetValue(CurrentEnergyTanksPropertyKey, value); }
        }

        public ReadOnlyObservableCollection<EnergyTank> EnergyTanks
        {
            get { return (ReadOnlyObservableCollection<EnergyTank>)GetValue(EnergyTanksProperty); }
            private set { SetValue(EnergyTanksPropertyKey, value); }
        }

        #endregion Properties

        #region Members

        private ObservableCollection<EnergyTank> _energyTanks;

        #endregion Members

        #region Ctor

        public EnergyHud()
        {
            _energyTanks = new ObservableCollection<EnergyTank>();
            EnergyTanks = new ReadOnlyObservableCollection<EnergyTank>(_energyTanks);
        }

        #endregion Ctor

        #region Dependency Property Callbacks

        private static void OnMaxEnergyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is EnergyHud eHud)
            {
                if (eHud.MaxEnergy > 1099)
                    eHud.MaxEnergyTanks = 10;

                else
                    eHud.MaxEnergyTanks = (short)Math.Abs(eHud.MaxEnergy / 100);
            }
        }

        private static void OnCurrentEnergyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is EnergyHud eHud)
            {
                if (eHud.CurrentEnergy > 1099)
                    eHud.CurrentEnergyTanks = 10;

                else
                    eHud.CurrentEnergyTanks = (short)Math.Abs(eHud.CurrentEnergy / 100);

                eHud.CurrentTankEnergy = (short)(eHud.CurrentEnergy - (Math.Abs(eHud.CurrentEnergy / 100) * 100));
            }
        }

        private static void OnMaxEnergyTanksPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is EnergyHud eHud && (short)e.OldValue != (short)e.NewValue)
            {
                bool tanksAdded = (short)e.OldValue < (short)e.NewValue;

                for (int i = eHud._energyTanks.Count; tanksAdded ? i < (short)e.NewValue : i > (short)e.NewValue; i = tanksAdded ? ++i : --i)
                {
                    if (tanksAdded)
                        eHud._energyTanks.Add(new EnergyTank());

                    else
                        eHud._energyTanks.RemoveAt(i - 1);
                }
            }
        }

        private static void OnCurrentEnergyTanksPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is EnergyHud eHud && (short)e.OldValue != (short)e.NewValue)
            {
                for (int i = 0; i < eHud._energyTanks.Count; i++)
                {
                    eHud._energyTanks[i].HasEnergy =
                        i < (short)e.NewValue ? true : false;
                }
            }
        }

        #endregion Dependency Property Callbacks
    }
}
