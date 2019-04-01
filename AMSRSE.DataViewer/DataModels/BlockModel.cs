using Magatama.Core.DataModels;
using Magatama.Core.DataModels.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AMSRSE.DataViewer.DataModels
{
    [IdProperty("BlockId")]
    public class BlockModel : EditableModel
    {
        #region Dependency Properties

        public static readonly DependencyProperty BlockIdProperty =
            RegisterTracked("BlockId", typeof(uint), typeof(BlockModel));

        public static readonly DependencyProperty BlockNameProperty =
            RegisterTracked("BlockName", typeof(string), typeof(BlockModel));

        public static readonly DependencyProperty ChunksProperty =
            RegisterTracked("Chunks", typeof(IList), typeof(BlockModel));

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

        public IList Chunks
        {
            get { return (IList)GetValue(ChunksProperty); }
            set { SetValue(ChunksProperty, value); }
        }

        #endregion Properties

        #region Ctor

        public BlockModel()
        {
            Chunks = new ObservableCollection<ChunkModel>();
        }

        public BlockModel(ObservableCollection<ChunkModel> chunks)
        {
            Chunks = chunks;
        }

        #endregion Ctor
    }
}
