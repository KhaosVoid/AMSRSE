using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AMSRSE.DataViewer.DataModels
{
    public class BlockModel : DependencyObject
    {
        #region Enums

        public enum ChangeTypes
        {
            None, Added, Removed
        }

        #endregion Enums

        #region Dependency Properties

        public static readonly DependencyProperty BlockIdProperty =
            DependencyProperty.Register("BlockId", typeof(uint), typeof(BlockModel));

        public static readonly DependencyProperty BlockNameProperty =
            DependencyProperty.Register("BlockName", typeof(string), typeof(BlockModel));

        //TODO: Create ChunksModel
        public static readonly DependencyProperty ChunksProperty =
            DependencyProperty.Register("Chunks", typeof(int), typeof(BlockModel));

        public static readonly DependencyProperty ChangeTypeProperty =
            DependencyProperty.Register("ChangeType", typeof(ChangeTypes), typeof(BlockModel));

        #endregion Dependency Properties

        #region Properties

        public uint BlockId
        {
            get { return (uint)GetValue(BlockIdProperty); }
            set { SetValue(BlockIdProperty, value); }
        }

        public string BlockName
        {
            get { return (string)GetValue(BlockNameProperty); }
            set { SetValue(BlockNameProperty, value); }
        }

        public int Chunks
        {
            get { return (int)GetValue(ChunksProperty); }
            set { SetValue(ChunksProperty, value); }
        }

        public ChangeTypes ChangeType
        {
            get { return (ChangeTypes)GetValue(ChangeTypeProperty); }
            set { SetValue(ChangeTypeProperty, value); }
        }

        #endregion Properties

        #region Ctor

        public BlockModel()
        {

        }

        #endregion Ctor
    }
}
