using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shapes;

namespace AMSRSE.Editor.Controls.NineGrid
{
    [TemplatePart(Name = PART_TopLeftRect, Type = typeof(Rectangle))]
    [TemplatePart(Name = PART_TopMiddleRect, Type = typeof(Rectangle))]
    [TemplatePart(Name = PART_TopRightRect, Type = typeof(Rectangle))]
    [TemplatePart(Name = PART_MiddleLeftRect, Type = typeof(Rectangle))]
    [TemplatePart(Name = PART_CenterRect, Type = typeof(Rectangle))]
    [TemplatePart(Name = PART_MiddleRightRect, Type = typeof(Rectangle))]
    [TemplatePart(Name = PART_BottomLeftRect, Type = typeof(Rectangle))]
    [TemplatePart(Name = PART_BottomMiddleRect, Type = typeof(Rectangle))]
    [TemplatePart(Name = PART_BottomRightRect, Type = typeof(Rectangle))]
    public class NineGrid : ContentControl
    {
        #region Template Parts

        private const string PART_TopLeftRect = "PART_TopLeftRect";
        private Rectangle _templatePart_TopLeftRect;

        private const string PART_TopMiddleRect = "PART_TopMiddleRect";
        private Rectangle _templatePart_TopMiddleRect;

        private const string PART_TopRightRect = "PART_TopRightRect";
        private Rectangle _templatePart_TopRightRect;

        private const string PART_MiddleLeftRect = "PART_MiddleLeftRect";
        private Rectangle _templatePart_MiddleLeftRect;

        private const string PART_CenterRect = "PART_CenterRect";
        private Rectangle _templatePart_CenterRect;

        private const string PART_MiddleRightRect = "PART_MiddleRightRect";
        private Rectangle _templatePart_MiddleRightRect;

        private const string PART_BottomLeftRect = "PART_BottomLeftRect";
        private Rectangle _templatePart_BottomLeftRect;

        private const string PART_BottomMiddleRect = "PART_BottomMiddleRect";
        private Rectangle _templatePart_BottomMiddleRect;

        private const string PART_BottomRightRect = "PART_BottomRightRect";
        private Rectangle _templatePart_BottomRightRect;

        #endregion Template Parts

        #region Dependency Properties

        public static readonly DependencyProperty ImageBorderProperty =
            DependencyProperty.Register("ImageBorder", typeof(Thickness), typeof(NineGrid), new PropertyMetadata(OnImageBorderPropertyChanged));

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(NineGrid));

        public static readonly DependencyProperty ImageEffectProperty =
            DependencyProperty.Register("ImageEffect", typeof(Effect), typeof(NineGrid));

        #endregion Dependency Properties

        #region Properties

        public Thickness ImageBorder
        {
            get { return (Thickness)GetValue(ImageBorderProperty); }
            set { SetValue(ImageBorderProperty, value); }
        }

        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public Effect ImageEffect
        {
            get { return (Effect)GetValue(ImageEffectProperty); }
            set { SetValue(ImageEffectProperty, value); }
        }

        #endregion Properties

        #region Ctor

        public NineGrid()
        {
            this.Loaded += NineGrid_Loaded;
        }

        #endregion Ctor

        #region Dependency Property Callbacks

        private static void OnImageBorderPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is NineGrid ng && ng.IsLoaded && !DesignerProperties.GetIsInDesignMode(ng))
                ng.UpdateBorder();
        }

        #endregion Dependency Property Callbacks

        #region Methods

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _templatePart_TopLeftRect = this.GetTemplateChild(PART_TopLeftRect) as Rectangle;
            _templatePart_TopMiddleRect = this.GetTemplateChild(PART_TopMiddleRect) as Rectangle;
            _templatePart_TopRightRect = this.GetTemplateChild(PART_TopRightRect) as Rectangle;
            _templatePart_MiddleLeftRect = this.GetTemplateChild(PART_MiddleLeftRect) as Rectangle;
            _templatePart_CenterRect = this.GetTemplateChild(PART_CenterRect) as Rectangle;
            _templatePart_MiddleRightRect = this.GetTemplateChild(PART_MiddleRightRect) as Rectangle;
            _templatePart_BottomLeftRect = this.GetTemplateChild(PART_BottomLeftRect) as Rectangle;
            _templatePart_BottomMiddleRect = this.GetTemplateChild(PART_BottomMiddleRect) as Rectangle;
            _templatePart_BottomRightRect = this.GetTemplateChild(PART_BottomRightRect) as Rectangle;
        }

        private void NineGrid_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateBorder();
        }

        private void UpdateBorder()
        {
            NGSize ngSize = new NGSize(
                left: ImageBorder.Left / ImageSource.Width,
                top: ImageBorder.Top / ImageSource.Height,
                right: ImageBorder.Right / ImageSource.Width,
                bottom: ImageBorder.Bottom / ImageSource.Height);

            ((ImageBrush)_templatePart_TopLeftRect.Fill).Viewbox = new Rect(0, 0, ngSize.Left, ngSize.Top);
            ((ImageBrush)_templatePart_TopMiddleRect.Fill).Viewbox = new Rect(ngSize.Left, 0, ngSize.MidWidth, ngSize.Top);
            ((ImageBrush)_templatePart_TopRightRect.Fill).Viewbox = new Rect(1 - ngSize.Right, 0, ngSize.Right, ngSize.Top);
            ((ImageBrush)_templatePart_MiddleLeftRect.Fill).Viewbox = new Rect(0, ngSize.Top, ngSize.Left, ngSize.MidHeight);
            ((ImageBrush)_templatePart_CenterRect.Fill).Viewbox = new Rect(ngSize.Left, ngSize.Top, ngSize.MidWidth, ngSize.MidHeight);
            ((ImageBrush)_templatePart_MiddleRightRect.Fill).Viewbox = new Rect(1 - ngSize.Right, ngSize.Top, ngSize.Right, ngSize.MidHeight);
            ((ImageBrush)_templatePart_BottomLeftRect.Fill).Viewbox = new Rect(0, 1 - ngSize.Bottom, ngSize.Left, ngSize.Bottom);
            ((ImageBrush)_templatePart_BottomMiddleRect.Fill).Viewbox = new Rect(ngSize.Left, 1 - ngSize.Bottom, ngSize.MidWidth, ngSize.Bottom);
            ((ImageBrush)_templatePart_BottomRightRect.Fill).Viewbox = new Rect(1 - ngSize.Right, 1 - ngSize.Bottom, ngSize.Right, ngSize.Bottom);

            _templatePart_TopLeftRect.Width = ImageBorder.Left;
            _templatePart_TopLeftRect.Height = ImageBorder.Top;

            _templatePart_TopMiddleRect.Width = double.NaN;
            _templatePart_TopMiddleRect.Height = ImageBorder.Top;

            _templatePart_TopRightRect.Width = ImageBorder.Right;
            _templatePart_TopRightRect.Height = ImageBorder.Top;

            _templatePart_MiddleLeftRect.Width = ImageBorder.Left;
            _templatePart_MiddleLeftRect.Height = double.NaN;

            _templatePart_CenterRect.Width = double.NaN;
            _templatePart_CenterRect.Height = double.NaN;

            _templatePart_MiddleRightRect.Width = ImageBorder.Right;
            _templatePart_MiddleRightRect.Height = double.NaN;

            _templatePart_BottomLeftRect.Width = ImageBorder.Left;
            _templatePart_BottomLeftRect.Height = ImageBorder.Bottom;

            _templatePart_BottomMiddleRect.Width = double.NaN;
            _templatePart_BottomMiddleRect.Height = ImageBorder.Bottom;

            _templatePart_BottomRightRect.Width = ImageBorder.Right;
            _templatePart_BottomRightRect.Height = ImageBorder.Bottom;
        }

        #endregion Methods
    }
}
