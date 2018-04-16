using AMSRSE.DataViewer.Controls;
using AMSRSE.DataViewer.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AMSRSE.DataViewer.Views
{
    public class BMSSVExplorerView : ViewBase
    {
        #region Dependency Properties

        public static readonly DependencyProperty LoadedFileProperty =
            DependencyProperty.Register("LoadedFile", typeof(FileModel), typeof(BMSSVExplorerView));

        public static readonly DependencyProperty SelectedBlockProperty =
            DependencyProperty.Register("SelectedBlock", typeof(BlockModel), typeof(BMSSVExplorerView));

        #endregion Dependency Properties

        #region Properties

        public FileModel LoadedFile
        {
            get { return (FileModel)GetValue(LoadedFileProperty); }
            set { SetValue(LoadedFileProperty, value); }
        }

        public BlockModel SelectedBlock
        {
            get { return (BlockModel)GetValue(SelectedBlockProperty); }
            set { SetValue(SelectedBlockProperty, value); }
        }

        #endregion Properties

        #region Ctor

        public BMSSVExplorerView()
        {
            InitializeComponent(
                xamlPath: new Uri("/AMSRSE.DataViewer;component/Views/BMSSVExplorerView.xaml", UriKind.Relative));
        }

        #endregion Ctor
    }
}
