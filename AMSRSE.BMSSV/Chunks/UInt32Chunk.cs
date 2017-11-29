using AMSRSE.BMSSV.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSRSE.BMSSV.Chunks
{
    public class UInt32Chunk : Chunk<uint>
    {
        #region Ctor

        public UInt32Chunk(ChunkIDs chunkId, byte[] chunkDataBytes)
            : base(chunkId, DataTypes.UInt32, chunkDataBytes)
        {

        }

        #endregion Ctor

        #region Methods

        protected override void SetChunkData(byte[] chunkDataBytes)
        {
            this.ChunkData = chunkDataBytes;
            this.Value = BitConverter.ToUInt32(chunkDataBytes, 0);
        }

        public override void SetValue(uint value)
        {
            this.Value = value;
            this.ChunkData = BitConverter.GetBytes(value);
        }

        #endregion Methods
    }
}
