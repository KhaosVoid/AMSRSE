using Magatama.Core.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace AMSRSE.DataViewer.Controls
{
    public class ChunkListViewItem : ControlBase
    {
        #region Dependency Properties

        public static readonly DependencyProperty AddedColorProperty =
            DependencyProperty.Register("AddedColor", typeof(SolidColorBrush), typeof(ChunkListViewItem));

        public static readonly DependencyProperty ModifiedColorProperty =
            DependencyProperty.Register("ModifiedColor", typeof(SolidColorBrush), typeof(ChunkListViewItem));

        public static readonly DependencyProperty RemovedColorProperty =
            DependencyProperty.Register("RemovedColor", typeof(SolidColorBrush), typeof(ChunkListViewItem));

        public static readonly DependencyProperty CanEditProperty =
            DependencyProperty.Register("CanEdit", typeof(bool), typeof(ChunkListViewItem));

        #endregion Dependency Properties

        #region Properties

        public SolidColorBrush AddedColor
        {
            get { return (SolidColorBrush)GetValue(AddedColorProperty); }
            set { SetValue(AddedColorProperty, value); }
        }

        public SolidColorBrush ModifiedColor
        {
            get { return (SolidColorBrush)GetValue(ModifiedColorProperty); }
            set { SetValue(ModifiedColorProperty, value); }
        }

        public SolidColorBrush RemovedColor
        {
            get { return (SolidColorBrush)GetValue(RemovedColorProperty); }
            set { SetValue(RemovedColorProperty, value); }
        }

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
