using AMSRSE.DataViewer.DataModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AMSRSE.DataViewer.Controls
{
    public class BlockListView : ControlBase
    {
        #region Dependency Properties

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(IList), typeof(BlockListView));

        #endregion Dependency Properties

        #region Properties

        public IList Items
        {
            get { return (IList)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        #endregion Properties

        #region Ctor

        static BlockListView()
        {
            ItemsProperty.OverrideMetadata(typeof(BlockListView), new PropertyMetadata(new ObservableCollection<BlockModel>()));
        }

        public BlockListView()
        {
            InitializeComponent(
                xamlPath: new Uri("/AMSRSE.DataViewer;component/Controls/BlockListView.xaml", UriKind.Relative));
        }

        #endregion Ctor
    }
}
