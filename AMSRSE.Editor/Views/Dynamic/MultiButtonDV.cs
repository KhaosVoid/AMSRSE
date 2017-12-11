using AMSRSE.Editor.Animation;
using AMSRSE.Editor.Controls.SpriteButton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AMSRSE.Editor.Views.Dynamic
{
    public class MultiButtonDV : DynamicViewBase
    {
        #region Dependency Properties

        public static readonly DependencyProperty ButtonsProperty =
            DependencyProperty.Register("Buttons", typeof(SpriteButtonCollection<SpriteButton>), typeof(MultiButtonDV), new PropertyMetadata(OnButtonsPropertyChanged));

        #endregion Dependency Properties

        #region Properties

        public SpriteButtonCollection<SpriteButton> Buttons
        {
            get { return (SpriteButtonCollection<SpriteButton>)GetValue(ButtonsProperty); }
            set { SetValue(ButtonsProperty, value); }
        }

        #endregion Properties

        #region Ctor

        public MultiButtonDV()
        {
            Buttons = new SpriteButtonCollection<SpriteButton>();
            this.Loaded += (sender, e) => { FadeIn(); };
        }

        #endregion Ctor

        #region Dependency Property Callbacks

        private static void OnButtonsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MultiButtonDV mdv)
            {
                if (e.OldValue is SpriteButtonCollection<SpriteButton> osbc)
                    osbc.CollectionChanged -= mdv.Buttons_CollectionChanged;

                if (e.NewValue is SpriteButtonCollection<SpriteButton> nsbc)
                {
                    nsbc.CollectionChanged -= mdv.Buttons_CollectionChanged;
                    nsbc.CollectionChanged += mdv.Buttons_CollectionChanged;
                }

                mdv.SubscribeButtonsNavigation();
            }
        }

        #endregion Dependency Property Callbacks

        #region Methods

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            SubscribeButtonsNavigation();
        }

        private void Buttons_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            for (int i = 0; i < e.OldItems?.Count; i++)
                ((SpriteButton)e.OldItems[i]).Clicked -= MultiButtonDV_Clicked;

            for (int i = 0; i < e.NewItems?.Count; i++)
            {
                if (DynamicViewHost.GetNavigateTo((SpriteButton)e.NewItems[i]) is string ntstr &&
                    DynamicViewHost.GetNavigationDirection((SpriteButton)e.NewItems[i]) is DynamicViewHost.NavigationDirections nd)
                    ((SpriteButton)e.NewItems[i]).Clicked += MultiButtonDV_Clicked;
            }

            SubscribeButtonsNavigation();
        }

        private void SubscribeButtonsNavigation()
        {
            for (int i = 0; i < Buttons?.Count; i++)
            {
                if (DynamicViewHost.GetNavigateTo(Buttons[i]) is string ntstr &&
                    DynamicViewHost.GetNavigationDirection(Buttons[i]) is DynamicViewHost.NavigationDirections nd)
                {
                    Buttons[i].Clicked -= MultiButtonDV_Clicked;
                    Buttons[i].Clicked += MultiButtonDV_Clicked;
                }
            }
        }

        private void MultiButtonDV_Clicked(SpriteButton sender)
        {
            var navigateTo = DynamicViewHost.GetNavigateTo(sender);
            var navigationDirection = DynamicViewHost.GetNavigationDirection(sender);

            GetView(navigateTo).SetAsCurrentView(navigationDirection);
        }

        #endregion Methods
    }
}
