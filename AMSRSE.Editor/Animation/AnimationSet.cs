using AMSRSE.Editor.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace AMSRSE.Editor.Animation
{
    public class AnimationSet : XamlSafeObservableCollection<SequentialStoryboard>
    {
        #region Ctor

        public AnimationSet()
        {

        }

        #endregion Ctor
    }
}
