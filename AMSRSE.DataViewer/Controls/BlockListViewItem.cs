using AMSRSE.BMSSV.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AMSRSE.DataViewer.Controls
{
    public class BlockListViewItem : Control
    {
        #region Enums

        public enum ChangeTypes
        {
            None, Added, Removed
        }

        #endregion Enums

        #region Dependency Properties

        public static readonly DependencyProperty ChunkCountProperty =
            DependencyProperty.Register("ChunkCount", typeof(int), typeof(BlockListViewItem));

        public static readonly DependencyProperty BlockNameProperty =
            DependencyProperty.Register("BlockName", typeof(string), typeof(BlockListViewItem));

        public static readonly DependencyProperty BlockIdProperty =
            DependencyProperty.Register("BlockId", typeof(uint), typeof(BlockListViewItem));

        public static readonly DependencyProperty ChangeTypeProperty =
            DependencyProperty.Register("ChangeType", typeof(ChangeTypes), typeof(BlockListViewItem));

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

        #region Events

        public delegate void ItemSelectedHandler();
        public event ItemSelectedHandler ItemSelected;

        #endregion Events

        #region Ctor

        public BlockListViewItem()
        {

        }

        #endregion Ctor
    }
}
