using AMSRSE.DataViewer.DataModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AMSRSE.DataViewer.Controls
{
    public class BlockListView : ControlBase
    {
        #region Dependency Properties

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(IList), typeof(BlockListView));

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(BlockModel), typeof(BlockListView));

        public static readonly DependencyProperty CanEditProperty =
            DependencyProperty.Register("CanEdit", typeof(bool), typeof(BlockListView));

        #endregion Dependency Properties

        #region Properties

        public IList Items
        {
            get { return (IList)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public BlockModel SelectedItem
        {
            get { return (BlockModel)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public bool CanEdit
        {
            get { return (bool)GetValue(CanEditProperty); }
            set { SetValue(CanEditProperty, value); }
        }

        #endregion Properties

        #region Ctor

        public BlockListView()
        {
            Items = new ObservableCollection<BlockModel>();

            InitializeComponent(
                xamlPath: new Uri("/AMSRSE.DataViewer;component/Controls/BlockListView.xaml", UriKind.Relative));
        }

        #endregion Ctor
    }
}
