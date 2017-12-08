using AMSRSE.Editor.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AMSRSE.Editor.Controls.SpriteButton
{
    public class SpriteButton : Control
    {
        #region Dependency Properties

        public static readonly DependencyProperty IsToggleButtonProperty =
            DependencyProperty.Register("IsToggleButton", typeof(bool), typeof(SpriteButton));

        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(SpriteButton));

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(DelegateCommand), typeof(SpriteButton));

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(SpriteButton));

        public static readonly DependencyProperty UnselectedSpriteProperty =
            DependencyProperty.Register("UnselectedSprite", typeof(ImageSource), typeof(SpriteButton));

        public static readonly DependencyProperty SelectedSpriteProperty =
            DependencyProperty.Register("SelectedSprite", typeof(ImageSource), typeof(SpriteButton));

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(SpriteButton));

        #endregion Dependency Properties

        #region Properties

        public bool IsToggleButton
        {
            get { return (bool)GetValue(IsToggleButtonProperty); }
            set { SetValue(IsToggleButtonProperty, value); }
        }

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public DelegateCommand Command
        {
            get { return (DelegateCommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public ImageSource UnselectedSprite
        {
            get { return (ImageSource)GetValue(UnselectedSpriteProperty); }
            set { SetValue(UnselectedSpriteProperty, value); }
        }

        public ImageSource SelectedSprite
        {
            get { return (ImageSource)GetValue(SelectedSpriteProperty); }
            set { SetValue(SelectedSpriteProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        #endregion Properties

        #region Events

        public delegate void ToggledHandler(bool isSelected);
        public event ToggledHandler Toggled;

        public delegate void ClickedHandler(SpriteButton sender);
        public event ClickedHandler Clicked;

        #endregion Events

        #region Ctor

        public SpriteButton()
        {
            
        }

        #endregion Ctor

        #region Methods

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            if (IsToggleButton)
            {
                IsSelected = !IsSelected;
                Toggled?.Invoke(IsSelected);
            }

            OnClicked();
            Clicked?.Invoke(this);
            Command?.Execute(CommandParameter);
        }

        protected virtual void OnClicked()
        {

        }

        #endregion Methods
    }
}
