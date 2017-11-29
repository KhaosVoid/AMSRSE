using AMSRSE.BMSSV.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSRSE.BMSSV.Chunks
{
    public class StringChunk : Chunk<string>
    {
        #region Ctor

        public StringChunk(ChunkIDs chunkId, byte[] chunkDataBytes)
            : base(chunkId, DataTypes.String, chunkDataBytes)
        {

        }

        #endregion Ctor

        #region Methods

        protected override void SetChunkData(byte[] chunkDataBytes)
        {
            this.ChunkData = chunkDataBytes;
            this.Value = Encoding.UTF8.GetString(chunkDataBytes).Trim(new char[] { (char)0x00 });
        }

        public override void SetValue(string value)
        {
            this.Value = value;
            this.ChunkData = Encoding.UTF8.GetBytes(value + (char)0x00);
        }

        #endregion Methods
    }
}
