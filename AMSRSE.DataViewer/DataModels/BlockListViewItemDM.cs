using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AMSRSE.DataViewer.DataModels
{
    public class BlockListViewItemDM : DependencyObject
    {
        #region Enums

        public enum ChangeTypes
        {
            None, Added, Removed
        }

        #endregion Enums

        #region Dependency Properties

        public static readonly DependencyProperty ChunkCountProperty =
            DependencyProperty.Register("ChunkCount", typeof(int), typeof(BlockListViewItemDM));

        public static readonly DependencyProperty BlockNameProperty =
            DependencyProperty.Register("BlockName", typeof(string), typeof(BlockListViewItemDM));

        public static readonly DependencyProperty BlockIdProperty =
            DependencyProperty.Register("BlockId", typeof(uint), typeof(BlockListViewItemDM));

        public static readonly DependencyProperty ChangeTypeProperty =
            DependencyProperty.Register("ChangeType", typeof(ChangeTypes), typeof(BlockListViewItemDM));

        #endregion Dependency Properties

        #region Properties

        public int ChunkCount
        {
            get { return (int)GetValue(ChunkCountProperty); }
            set { SetValue(ChunkCountProperty, value); }
        }

        public string BlockName
        {
            get { return (string)GetValue(BlockNameProperty); }
            set { SetValue(BlockNameProperty, value); }
        }

        public uint BlockId
        {
            get { return (uint)GetValue(BlockIdProperty); }
            set { SetValue(BlockIdProperty, value); }
        }

        public ChangeTypes ChangeType
        {
            get { return (ChangeTypes)GetValue(ChangeTypeProperty); }
            set { SetValue(ChangeTypeProperty, value); }
        }

        #endregion Properties

        #region Ctor

        public BlockListViewItemDM()
        {

        }

        #endregion Ctor
    }
}
