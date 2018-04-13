using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AMSRSE.DataViewer.DataModels
{
    public class FileModel : DependencyObject
    {
        #region Dependency Properties

        public static readonly DependencyProperty BlocksProperty =
            DependencyProperty.Register("Blocks", typeof(IList), typeof(FileModel));

        #endregion Dependency Properties

        #region Properties

        public IList Blocks
        {
            get { return (IList)GetValue(BlocksProperty); }
            set { SetValue(BlocksProperty, value); }
        }

        #endregion Properties

        #region Ctor

        static FileModel()
        {
            BlocksProperty.OverrideMetadata(typeof(FileModel), new PropertyMetadata(new ObservableCollection<BlockModel>()));
        }

        public FileModel()
        {

        }

        #endregion Ctor
    }
}
