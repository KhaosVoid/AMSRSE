using AMSRSE.BMSSV;
using AMSRSE.InfoXml;
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
    public class FileModel : EditableModel
    {
        #region Dependency Properties

        public static readonly DependencyProperty FilePathProperty =
            RegisterTracked("FilePath", typeof(string), typeof(FileModel));

        public static readonly DependencyProperty BlocksProperty =
            RegisterTracked("Blocks", typeof(IList), typeof(FileModel), new PropertyMetadata(BlocksPropertyChangedCallback));

        #endregion Dependency Properties

        #region Properties

        public string FilePath
        {
            get { return (string)GetValue(FilePathProperty); }
            set { SetValue(FilePathProperty, value); }
        }

        public IList Blocks
        {
            get { return (IList)GetValue(BlocksProperty); }
            set { SetValue(BlocksProperty, value); }
        }

        #endregion Properties

        #region Ctor

        public FileModel()
        {
            Blocks = new ObservableCollection<BlockModel>();

            if (!DesignerProperties.GetIsInDesignMode(this))
                ((ObservableCollection<BlockModel>)Blocks).CollectionChanged += Blocks_CollectionChanged;
        }

        public FileModel(BMSSVFile bmssv)
        {
            IngestBMSSVFile(bmssv);
        }

        #endregion Ctor

        #region Dependency Property Callbacks

        private static void BlocksPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FileModel fileModel &&
                !DesignerProperties.GetIsInDesignMode(fileModel))
            {
                var blocks = fileModel.Blocks as ObservableCollection<BlockModel>;
                blocks.CollectionChanged -= fileModel.Blocks_CollectionChanged;
                blocks.CollectionChanged += fileModel.Blocks_CollectionChanged;
            }
        }

        #endregion Dependency Property Callbacks

        #region Methods

        private void IngestBMSSVFile(BMSSVFile bmssv)
        {
            var blocks = new ObservableCollection<BlockModel>();
            BMSSVInfo bmssvInfo = BMSSVInfo.Load("bmssv-info.xml");

            for (int b = 0; b < bmssv.Blocks.Count; b++)
            {
                uint blockId = (uint)bmssv.Blocks[b].BlockID;
                string blockName = bmssvInfo.GetName("BlockNames", blockId);

                if (blockName == null)
                {
                    blockName = "Unknown";
                    bmssvInfo.AddName("BlockNames", blockId, blockName);
                }

                var chunks = new ObservableCollection<ChunkModel>();

                for (int c = 0; c < bmssv.Blocks[b].Chunks.Count; c++)
                {
                    if (bmssv.Blocks[b].Chunks[c].DataType == BMSSV.Enums.DataTypes.BlockID)
                        continue;

                    ChunkModel chunkModel = new ChunkModel();
                    chunkModel.ChunkId = (uint)bmssv.Blocks[b].Chunks[c].ChunkID;

                    string chunkName = bmssvInfo.GetName("ChunkNames", chunkModel.ChunkId);

                    if (chunkName == null)
                    {
                        chunkName = "Unknown";
                        bmssvInfo.AddName("ChunkNames", chunkModel.ChunkId, chunkName);
                    }

                    chunkModel.ChunkName = chunkName;
                    BMSSV.Chunks.IChunk chunk = bmssv.Blocks[b].Chunks[c];

                    switch (bmssv.Blocks[b].Chunks[c].DataType)
                    {
                        case BMSSV.Enums.DataTypes.Float32:
                            chunkModel.DataType = ChunkModel.DataTypes.Float32;
                            chunkModel.Value = ((BMSSV.Chunks.Float32Chunk)chunk).Value;
                            break;

                        case BMSSV.Enums.DataTypes.String:
                            chunkModel.DataType = ChunkModel.DataTypes.String;
                            chunkModel.Value = ((BMSSV.Chunks.StringChunk)chunk).Value;
                            break;

                        case BMSSV.Enums.DataTypes.UInt32:
                            chunkModel.DataType = ChunkModel.DataTypes.UInt32;
                            chunkModel.Value = ((BMSSV.Chunks.UInt32Chunk)chunk).Value;
                            break;

                        case BMSSV.Enums.DataTypes.UInt8:
                            chunkModel.DataType = ChunkModel.DataTypes.UInt8;
                            chunkModel.Value = ((BMSSV.Chunks.UInt8Chunk)chunk).Value;
                            break;

                        case BMSSV.Enums.DataTypes.UInt8Array:
                            chunkModel.DataType = ChunkModel.DataTypes.UInt8Array;
                            chunkModel.Value = ((BMSSV.Chunks.UInt8ArrayChunk)chunk).Value;
                            break;
                    }

                    chunks.Add(chunkModel);
                }

                BlockModel blockModel = new BlockModel(chunks)
                {
                    BlockId = blockId,
                    BlockName = blockName
                };

                blocks.Add(blockModel);
            }

            Blocks = blocks;
            FilePath = bmssv.FilePath;
            ((ObservableCollection<BlockModel>)Blocks).CollectionChanged += Blocks_CollectionChanged;

            for (int b = 0; b < Blocks.Count; b++)
                ((ObservableCollection<BlockModel>)Blocks)[b].ModelPropertyChanged += BlockModel_PropertyChanged;
        }

        private void Blocks_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var blocks = Blocks as ObservableCollection<BlockModel>;
            var originalBlocks = _originalPropertyValues[BlocksProperty] as ObservableCollection<BlockModel>;

            if (e.Action == NotifyCollectionChangedAction.Add ||
                e.Action == NotifyCollectionChangedAction.Replace)
            {
                for (int i = 0; i < e.NewItems.Count; i++)
                {
                    ((BlockModel)e.NewItems[i]).ModelPropertyChanged -= BlockModel_PropertyChanged;
                    ((BlockModel)e.NewItems[i]).ModelPropertyChanged += BlockModel_PropertyChanged;
                }
            }

            if (e.Action == NotifyCollectionChangedAction.Remove ||
                e.Action == NotifyCollectionChangedAction.Replace ||
                e.Action == NotifyCollectionChangedAction.Reset)
            {
                for (int i = 0; i < e.OldItems.Count; i++)
                    ((BlockModel)e.OldItems[i]).ModelPropertyChanged -= BlockModel_PropertyChanged;
            }

            if (blocks.Count != originalBlocks.Count ||
                blocks.Where(b => b.HasChanges).Count() > 0)
                HasChanges = true;
        }

        private void BlockModel_PropertyChanged(DependencyProperty p, object newValue)
        {
            HasChanges = true;
        }

        protected override void OnRevertChanges()
        {
            ((ObservableCollection<BlockModel>)Blocks).CollectionChanged += Blocks_CollectionChanged;
        }

        #endregion Methods
    }
}
