using AMSRSE.BMSSV;
using AMSRSE.InfoXml;
using Magatama.Core.DataModels;
using Magatama.Core.DataModels.Extensions;
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
            RegisterTracked("Blocks", typeof(IList), typeof(FileModel));

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

        #endregion Ctor

        #region Methods

        public static FileModel FromBMSSV(BMSSVFile bmssv)
        {
            FileModel fileModel = new FileModel();
            BMSSVInfo bmssvInfo = BMSSVInfo.Load("bmssv-info.xml");
            var blocks = new ObservableCollection<BlockModel>();

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

            fileModel.Blocks = blocks;
            fileModel.FilePath = bmssv.FilePath;

            fileModel.Initialize();

            return fileModel;
        }

        #endregion Methods
    }
}
