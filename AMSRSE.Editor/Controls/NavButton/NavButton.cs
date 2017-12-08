using AMSRSE.Editor.Views.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSRSE.Editor.Controls.NavButton
{
    public class NavButton : SpriteButton.SpriteButton
    {
        #region Ctor

        public NavButton()
        {

        }

        #endregion Ctor

        #region Methods

        protected override void OnClicked()
        {
            //if (DynamicViewHost.GetNavigateTo(this) is DynamicViewBase dv &&
            //    DynamicViewHost.GetNavigationDirection(this) is DynamicViewHost.NavigationDirections nd)
            //    dv.SetAsCurrentView(nd);
        }

        #endregion Methods
    }
}
