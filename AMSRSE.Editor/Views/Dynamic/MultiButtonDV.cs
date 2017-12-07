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
            DependencyProperty.Register("Buttons", typeof(SpriteButtonCollection<SpriteButton>), typeof(MultiButtonDV));

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
        }

        #endregion Ctor

        #region Methods

        public override void FadeIn()
        {
            this.Opacity = 1;
            //throw new NotImplementedException();
        }

        public override void FadeOut()
        {
            //throw new NotImplementedException();
        }

        #endregion Methods
    }
}
