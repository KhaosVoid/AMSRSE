using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AMSRSE.InfoXml
{
    public class BMSSVInfo
    {
        #region Dependency Properties

        public static readonly DependencyProperty BlockNamesProperty =
            DependencyProperty.Register("BlockNames", typeof(IList<Name>), typeof(BMSSVInfo));

        #endregion Dependency Properties

        #region Ctor

        public BMSSVInfo()
        {

        }

        #endregion Ctor

        #region Methods

        public static BMSSVInfo Load(string path)
        {
            return null;
        }

        #endregion Methods
    }
}
