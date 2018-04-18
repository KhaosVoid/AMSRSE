using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AMSRSE.DataViewer.Controls
{
    public class ChunkListViewItem : ControlBase
    {
        #region Dependency Properties

        public static readonly DependencyProperty CanEditProperty =
            DependencyProperty.Register("CanEdit", typeof(bool), typeof(ChunkListViewItem));

        #endregion Dependency Properties

        #region Properties

        public bool CanEdit
        {
            get { return (bool)GetValue(CanEditProperty); }
            set { SetValue(CanEditProperty, value); }
        }

        #endregion Properties

        #region Ctor

        public ChunkListViewItem()
        {
            InitializeComponent(
                xamlPath: new Uri("/AMSRSE.DataViewer;component/Controls/ChunkListViewItem.xaml", UriKind.Relative));
        }

        #endregion Ctor
    }
}
