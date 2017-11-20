using SaveDataReaderProto.BinaryMercurySteamSave.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDataReaderProto.BinaryMercurySteamSave.Chunks
{
    public class UInt8Chunk : Chunk<byte>
    {
        #region Ctor

        public UInt8Chunk(ChunkIDs chunkId, byte[] chunkDataBytes)
            : base(chunkId, DataTypes.UInt8, chunkDataBytes)
        {

        }

        #endregion Ctor

        #region Methods

        protected override void SetChunkData(byte[] chunkDataBytes)
        {
            this.ChunkData = chunkDataBytes;
            this.Value = chunkDataBytes[0];
        }

        public override void SetValue(byte value)
        {
            this.Value = value;
            this.ChunkData = new byte[1] { value };
        }

        #endregion Methods
    }
}
