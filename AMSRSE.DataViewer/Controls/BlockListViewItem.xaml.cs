using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AMSRSE.DataViewer.Controls
{
    public class BlockListViewItem : ControlBase
    {
        #region Dependency Properties

        public static readonly DependencyProperty AddedColorProperty =
            DependencyProperty.Register("AddedColor", typeof(SolidColorBrush), typeof(BlockListViewItem));

        public static readonly DependencyProperty RemovedColorProperty =
            DependencyProperty.Register("RemovedColor", typeof(SolidColorBrush), typeof(BlockListViewItem));

        #endregion Dependency Properties

        #region Properties

        public SolidColorBrush AddedColor
        {
            get { return (SolidColorBrush)GetValue(AddedColorProperty); }
            set { SetValue(AddedColorProperty, value); }
        }

        public SolidColorBrush RemovedColor
        {
            get { return (SolidColorBrush)GetValue(RemovedColorProperty); }
            set { SetValue(RemovedColorProperty, value); }
        }

        #endregion Properties

        #region Ctor

        public BlockListViewItem()
        {
            InitializeComponent(
                xamlPath: new Uri("/AMSRSE.DataViewer;component/Controls/BlockListViewItem.xaml", UriKind.Relative));
        }

        #endregion Ctor
    }
}
