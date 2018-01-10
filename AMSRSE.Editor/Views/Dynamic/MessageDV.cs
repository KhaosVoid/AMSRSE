using AMSRSE.Editor.Controls.SpriteButton;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AMSRSE.Editor.Views.Dynamic
{
    public class MessageDV : DynamicViewBase
    {
        #region Dependency Properties

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(MessageDV));

        public static readonly DependencyProperty OKButtonProperty =
            DependencyProperty.Register("OKButton", typeof(SpriteButton), typeof(MessageDV), new PropertyMetadata(OnOKButtonPropertyChanged));

        #endregion Dependency Properties

        #region Properties

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public SpriteButton OKButton
        {
            get { return (SpriteButton)GetValue(OKButtonProperty); }
            set { SetValue(OKButtonProperty, value); }
        }

        #endregion Properties

        #region Ctor

        public MessageDV()
        {
            this.Loaded += (sender, e) => { FadeIn(); };
        }

        #endregion Ctor

        #region Dependency Property Callbacks

        private static void OnOKButtonPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MessageDV mdv)
            {
                if (e.OldValue is SpriteButton oob)
                    oob.Clicked -= mdv.SpriteButton_Clicked;

                if (e.NewValue is SpriteButton nob &&
                    DynamicViewHost.GetNavigateTo(nob) is string)
                    nob.Clicked += mdv.SpriteButton_Clicked;
            }
        }

        #endregion Dependency Property Callbacks

        #region Methods

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            SubscribeButtonNavigation();
        }

        private void SubscribeButtonNavigation()
        {
            if (OKButton is SpriteButton)
            {
                OKButton.Clicked -= SpriteButton_Clicked;
                OKButton.Clicked += SpriteButton_Clicked;
            }
        }

        private void SpriteButton_Clicked(SpriteButton sender)
        {
            var navigateTo = DynamicViewHost.GetNavigateTo(sender);
            var navigationDirection = DynamicViewHost.GetNavigationDirection(sender);

            GetView(navigateTo).SetAsCurrentView(navigationDirection);
        }

        #endregion Methods
    }
}
