using AMSRSE.Editor.Animation;
using AMSRSE.Editor.Controls.NavButton;
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
    public class YesNoDV : DynamicViewBase
    {
        #region Dependency Properties

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(YesNoDV));

        public static readonly DependencyProperty YesButtonProperty =
            DependencyProperty.Register("YesButton", typeof(SpriteButton), typeof(YesNoDV), new PropertyMetadata(OnYesButtonPropertyChanged));

        public static readonly DependencyProperty NoButtonProperty =
            DependencyProperty.Register("NoButton", typeof(SpriteButton), typeof(YesNoDV), new PropertyMetadata(OnNoButtonPropertyChanged));

        #endregion Dependency Properties

        #region Properties

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public SpriteButton YesButton
        {
            get { return (SpriteButton)GetValue(YesButtonProperty); }
            set { SetValue(YesButtonProperty, value); }
        }

        public SpriteButton NoButton
        {
            get { return (SpriteButton)GetValue(NoButtonProperty); }
            set { SetValue(NoButtonProperty, value); }
        }

        #endregion Properties

        #region Ctor

        public YesNoDV()
        {
            this.Loaded += (sender, e) => { FadeIn(); };
        }

        #endregion Ctor

        #region Dependency Property Callbacks

        private static void OnYesButtonPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is YesNoDV yndv)
            {
                if (e.OldValue is NavButton oyb)
                    oyb.Clicked -= yndv.NavButton_Clicked;

                if (e.NewValue is NavButton nyb &&
                    DynamicViewHost.GetNavigateTo(nyb) is string)
                    nyb.Clicked += yndv.NavButton_Clicked;
            }
        }

        private static void OnNoButtonPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is YesNoDV yndv)
            {
                if (e.OldValue is NavButton onb)
                    onb.Clicked -= yndv.NavButton_Clicked;

                if (e.NewValue is NavButton nnb &&
                    DynamicViewHost.GetNavigateTo(nnb) is string)
                    nnb.Clicked += yndv.NavButton_Clicked;
            }
        }

        #endregion Dependency Property Callbacks

        #region Methods

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            SubscribeButtonsNavigation();
        }

        private void SubscribeButtonsNavigation()
        {
            if (YesButton is NavButton)
            {
                YesButton.Clicked -= NavButton_Clicked;
                YesButton.Clicked += NavButton_Clicked;
            }

            if (NoButton is NavButton)
            {
                NoButton.Clicked -= NavButton_Clicked;
                NoButton.Clicked += NavButton_Clicked;
            }
        }

        private void NavButton_Clicked(SpriteButton sender)
        {
            var navigateTo = DynamicViewHost.GetNavigateTo(sender);
            var navigationDirection = DynamicViewHost.GetNavigationDirection(sender);

            GetView(navigateTo).SetAsCurrentView(navigationDirection);
        }

        #endregion Methods
    }
}
