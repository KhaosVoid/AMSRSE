using SaveDataReaderProto.BinaryMercurySteamSave.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDataReaderProto.BinaryMercurySteamSave.Chunks
{
    public class BlockIDChunk : Chunk<BlockIDs>
    {
        #region Ctor

        public BlockIDChunk(ChunkIDs chunkId, byte[] chunkDataBytes)
            : base(chunkId, DataTypes.BlockID, chunkDataBytes)
        {

        }

        #endregion Ctor

        #region Methods

        protected override void SetChunkData(byte[] chunkDataBytes)
        {
            this.ChunkData = chunkDataBytes;
            this.Value = (BlockIDs)BitConverter.ToUInt32(chunkDataBytes.Reverse().ToArray(), 0);
        }

        public override void SetValue(BlockIDs value)
        {
            
        }

        #endregion Methods
    }
}
