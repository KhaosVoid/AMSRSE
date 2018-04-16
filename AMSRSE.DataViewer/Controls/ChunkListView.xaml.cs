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
    public class ChunkListView : ControlBase
    {
        #region Dependency Properties

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(IList), typeof(ChunkListView));

        #endregion Dependency Properties

        #region Properties

        public IList Items
        {
            get { return (IList)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        #endregion Properties

        #region Ctor

        static ChunkListView()
        {
            ItemsProperty.OverrideMetadata(typeof(ChunkListView), new PropertyMetadata(new ObservableCollection<ChunkModel>()));
        }

        public ChunkListView()
        {
            InitializeComponent(
                xamlPath: new Uri("/AMSRSE.DataViewer;component/Controls/ChunkListView.xaml", UriKind.Relative));
        }

        #endregion Ctor
    }
}
