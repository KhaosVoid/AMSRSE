using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSRSE.DataViewer.Controls
{
    public class ChunkListViewItem : ControlBase
    {
        #region Ctor

        public ChunkListViewItem()
        {
            InitializeComponent(
                xamlPath: new Uri("/AMSRSE.DataViewer;component/Controls/ChunkListViewItem.xaml", UriKind.Relative));
        }

        #endregion Ctor
    }
}
