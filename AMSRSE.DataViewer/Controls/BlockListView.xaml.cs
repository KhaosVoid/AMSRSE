using AMSRSE.DataViewer.DataModels;
using Magatama.Core.Controls;
using Magatama.Core.DataModels;
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
        #region Enums

        public enum BlockChangeVisibilityTypes
        {
            Remove,
            Add
        }

        #endregion Enums

        #region Dependency Properties

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ObservableCollection<BlockModel>), typeof(BlockListView), new PropertyMetadata(defaultValue: new ObservableCollection<BlockModel>()));

        public static readonly DependencyProperty SelectedBlockProperty =
            DependencyProperty.Register("SelectedBlock", typeof(BlockModel), typeof(BlockListView));

        public static readonly DependencyProperty CanEditProperty =
            DependencyProperty.Register("CanEdit", typeof(bool), typeof(BlockListView));

        #endregion Dependency Properties

        #region Properties

        public IList Items
        {
            get { return (IList)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public BlockModel SelectedBlock
        {
            get { return (BlockModel)GetValue(SelectedBlockProperty); }
            set { SetValue(SelectedBlockProperty, value); }
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
            InitializeComponent(
                xamlPath: new Uri("/AMSRSE.DataViewer;component/Controls/BlockListView.xaml", UriKind.Relative));
        }

        #endregion Ctor
    }
}
