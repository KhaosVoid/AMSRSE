using SaveDataReaderProto.BinaryMercurySteamSave.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDataReaderProto.BinaryMercurySteamSave.Chunks
{
    public class Float32Chunk : Chunk<float>
    {
        #region Ctor

        public Float32Chunk(ChunkIDs chunkId, byte[] chunkDataBytes)
            : base(chunkId, DataTypes.Float32, chunkDataBytes)
        {

        }

        public Float32Chunk(ChunkIDs chunkId, float chunkValue)
            : base(chunkId, DataTypes.Float32, chunkValue)
        {

        }

        public Float32Chunk(ChunkIDs chunkId)
            : base(chunkId, DataTypes.Float32, (float)default)
        {

        }

        #endregion Ctor

        #region Methods

        protected override void SetChunkData(byte[] chunkDataBytes)
        {
            this.ChunkData = chunkDataBytes;
            this.Value = BitConverter.ToSingle(chunkDataBytes, 0);
        }

        public override void SetValue(float value)
        {
            this.Value = value;
            this.ChunkData = BitConverter.GetBytes(value);
        }

        #endregion Methods
    }
}
