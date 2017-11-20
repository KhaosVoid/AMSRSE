using SaveDataReaderProto.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace SaveDataReaderProto.Controls.Inventory.AeionHud
{
    [TemplatePart(Name = PART_AEMax, Type = typeof(Border))]
    [TemplatePart(Name = PART_AECurrent, Type = typeof(Rectangle))]
    public class AeionHud : Control
    {
        #region Template Parts

        private const string PART_AEMax = "PART_AEMax";
        private Border _templatePart_AEMax;

        private const string PART_AECurrent = "PART_AECurrent";
        private Rectangle _templatePart_AECurrent;

        #endregion Template Parts

        #region Dependency Properties

        public static readonly DependencyProperty MaxAeionEnergyProperty =
            InventoryDataModel.MaxAeionEnergyProperty.AddOwner(typeof(AeionHud), new PropertyMetadata(OnMaxAeionEnergyPropertyChanged));

        public static readonly DependencyProperty CurrentAeionEnergyProperty =
            InventoryDataModel.CurrentAeionEnergyProperty.AddOwner(typeof(AeionHud), new PropertyMetadata(OnCurrentAeionEnergyPropertyChanged));

        #endregion Dependency Properties

        #region Properties

        public uint MaxAeionEnergy
        {
            get { return (uint)GetValue(MaxAeionEnergyProperty); }
            set { SetValue(MaxAeionEnergyProperty, value); }
        }

        public uint CurrentAeionEnergy
        {
            get { return (uint)GetValue(CurrentAeionEnergyProperty); }
            set { SetValue(CurrentAeionEnergyProperty, value); }
        }

        #endregion Properties

        #region Ctor

        public AeionHud()
        {
            this.Loaded += AeionHud_Loaded;
        }

        #endregion Ctor

        #region Dependency Property Callbacks

        private static void OnMaxAeionEnergyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is AeionHud aHud && aHud.IsLoaded)
                aHud.CalculateAeionEnergy();
        }

        private static void OnCurrentAeionEnergyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is AeionHud aHud && aHud.IsLoaded)
                aHud.CalculateAeionEnergy();
        }

        #endregion Dependency Property Callbacks

        #region Methods

        public override void OnApplyTemplate()
        {
            _templatePart_AEMax = this.GetTemplateChild(PART_AEMax) as Border;
            _templatePart_AECurrent = this.GetTemplateChild(PART_AECurrent) as Rectangle;

            base.OnApplyTemplate();
        }

        private void AeionHud_Loaded(object sender, RoutedEventArgs e)
        {
            CalculateAeionEnergy();
        }

        private void CalculateAeionEnergy()
        {
            _templatePart_AEMax.HorizontalAlignment = MaxAeionEnergy >= 2200 ?
                HorizontalAlignment.Stretch :
                HorizontalAlignment.Left;

            double aeWidth = MaxAeionEnergy >= 2200 ?
                this.ActualWidth :
                ((double)MaxAeionEnergy / 2200d) * this.ActualWidth;

            double clippedCurrentAE = CurrentAeionEnergy > 2200 ? 2200 : CurrentAeionEnergy;
            double clippedMaxAE = MaxAeionEnergy > 2200 ? 2200 : MaxAeionEnergy;

            _templatePart_AEMax.Width = aeWidth;

            _templatePart_AECurrent.HorizontalAlignment = CurrentAeionEnergy >= MaxAeionEnergy ?
                HorizontalAlignment.Stretch :
                HorizontalAlignment.Left;

            _templatePart_AECurrent.Width = CurrentAeionEnergy >= MaxAeionEnergy ?
                aeWidth :
                (clippedCurrentAE / clippedMaxAE) * aeWidth;
        }

        #endregion Methods
    }
}
