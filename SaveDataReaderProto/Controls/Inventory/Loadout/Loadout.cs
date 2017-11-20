using SaveDataReaderProto.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace SaveDataReaderProto.Controls.Inventory.Loadout
{
    [TemplatePart(Name = PART_currentSuitImage, Type = typeof(Image))]
    public class Loadout : Control
    {
        #region Template Parts

        private const string PART_currentSuitImage = "PART_currentSuitImage";
        private Image _templatePart_currentSuitImage;

        #endregion Template Parts

        #region Dependency Properties

        public static readonly DependencyPropertyKey CurrentSuitImageSourcePropertyKey =
            DependencyProperty.RegisterReadOnly("CurrentSuitImageSource", typeof(ImageSource), typeof(Loadout), null);

        public static readonly DependencyProperty CurrentSuitImageSourceProperty =
            CurrentSuitImageSourcePropertyKey.DependencyProperty;

        #endregion Dependency Properties

        #region Properties

        public ImageSource CurrentSuitImageSource
        {
            get { return (ImageSource)GetValue(CurrentSuitImageSourceProperty); }
            private set { SetValue(CurrentSuitImageSourcePropertyKey, value); }
        }

        #endregion Properties

        #region Members

        private Storyboard _sbFadeOutSuitImage;
        private Storyboard _sbFadeInSuitImage;
        private DoubleAnimation _animFadeOutSuitImage;
        private DoubleAnimation _animFadeInSuitImage;

        #endregion Members

        #region Ctor

        public Loadout()
        {
            this.DataContextChanged += Loadout_DataContextChanged;
        }

        #endregion Ctor

        #region Methods

        public override void OnApplyTemplate()
        {
            _templatePart_currentSuitImage = this.GetTemplateChild(PART_currentSuitImage) as Image;

            CreateSuitAnimations();

            base.OnApplyTemplate();
        }

        private void Loadout_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                SetCurrentSuit();
                ((InventoryDataModel)this.DataContext).OnSuitChanged += Loadout_OnSuitChanged;
            }
        }

        private void CreateSuitAnimations()
        {
            _sbFadeOutSuitImage = new Storyboard();
            _sbFadeInSuitImage = new Storyboard();
            _animFadeOutSuitImage = new DoubleAnimation();
            _animFadeInSuitImage = new DoubleAnimation();

            _sbFadeOutSuitImage.RepeatBehavior = new RepeatBehavior(1);
            _sbFadeOutSuitImage.Completed += (sender, e) =>
            {
                SetCurrentSuit();
                _sbFadeInSuitImage.Begin();
            };

            _sbFadeInSuitImage.RepeatBehavior = new RepeatBehavior(1);

            Storyboard.SetTarget(_animFadeOutSuitImage, _templatePart_currentSuitImage);
            Storyboard.SetTargetProperty(_animFadeOutSuitImage, new PropertyPath(Image.OpacityProperty));
            _animFadeOutSuitImage.SpeedRatio = 4;
            _animFadeOutSuitImage.To = 0;
            _animFadeOutSuitImage.RepeatBehavior = new RepeatBehavior(1);

            Storyboard.SetTarget(_animFadeInSuitImage, _templatePart_currentSuitImage);
            Storyboard.SetTargetProperty(_animFadeInSuitImage, new PropertyPath(Image.OpacityProperty));
            _animFadeInSuitImage.SpeedRatio = 4;
            _animFadeInSuitImage.To = 1;
            _animFadeInSuitImage.RepeatBehavior = new RepeatBehavior(1);

            _sbFadeOutSuitImage.Children.Add(_animFadeOutSuitImage);
            _sbFadeInSuitImage.Children.Add(_animFadeInSuitImage);
        }

        private void Loadout_OnSuitChanged(bool hasVariaSuit, bool hasGravitySuit)
        {
            if (CurrentSuitImageSource == FindResource("Images.Upgrades.Suits.GravitySuit") as ImageSource && hasGravitySuit)
                return;

            _sbFadeOutSuitImage.Begin();
        }

        private void SetCurrentSuit()
        {
            ImageSource suitImageSource;

            if (!((InventoryDataModel)this.DataContext).HasVariaSuit && !((InventoryDataModel)this.DataContext).HasGravitySuit)
                suitImageSource = FindResource("Images.Upgrades.Suits.PowerSuit") as ImageSource;

            else if (((InventoryDataModel)this.DataContext).HasVariaSuit && !((InventoryDataModel)this.DataContext).HasGravitySuit)
                suitImageSource = FindResource("Images.Upgrades.Suits.VariaSuit") as ImageSource;

            else
                suitImageSource = FindResource("Images.Upgrades.Suits.GravitySuit") as ImageSource;

            CurrentSuitImageSource = suitImageSource;
        }

        #endregion Methods
    }
}
