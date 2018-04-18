using AMSRSE.BMSSV;
using AMSRSE.InfoXml;
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

        public static readonly DependencyProperty FilePathProperty =
            DependencyProperty.Register("FilePath", typeof(string), typeof(FileModel));

        public static readonly DependencyProperty BlocksProperty =
            DependencyProperty.Register("Blocks", typeof(IList), typeof(FileModel));

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
        }

        public FileModel(BMSSVFile bmssv)
        {
            IngestBMSSVFile(bmssv);
        }

        #endregion Ctor

        #region Methods

        private void IngestBMSSVFile(BMSSVFile bmssv)
        {
            Blocks = new ObservableCollection<BlockModel>();
            BMSSVInfo bmssvInfo = BMSSVInfo.Load("bmssv-info.xml");

            for (int b = 0; b < bmssv.Blocks.Count; b++)
            {
                BlockModel blockModel = new BlockModel();
                blockModel.BlockId = (uint)bmssv.Blocks[b].BlockID;

                string blockName = bmssvInfo.GetName("BlockNames", blockModel.BlockId);

                if (blockName == null)
                {
                    blockName = "Unknown";
                    bmssvInfo.AddName("BlockNames", blockModel.BlockId, blockName);
                }

                blockModel.BlockName = blockName;

                blockModel.Chunks = new ObservableCollection<ChunkModel>();

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

                    blockModel.Chunks.Add(chunkModel);
                }

                Blocks.Add(blockModel);
            }

            FilePath = bmssv.FilePath;
        }

        #endregion Methods
    }
}
