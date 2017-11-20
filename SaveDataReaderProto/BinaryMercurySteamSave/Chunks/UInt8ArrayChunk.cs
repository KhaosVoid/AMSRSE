using SaveDataReaderProto.BinaryMercurySteamSave.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDataReaderProto.BinaryMercurySteamSave.Chunks
{
    public class UInt8ArrayChunk : Chunk<byte[]>
    {
        #region Ctor

        public UInt8ArrayChunk(ChunkIDs chunkId, byte[] chunkDataBytes)
            : base(chunkId, DataTypes.UInt8Array, chunkDataBytes)
        {

        }

        #endregion Ctor

        #region Methods

        protected override uint CalculateChunkSize()
        {
            return base.CalculateChunkSize() + 0x04;
        }

        public override byte[] GetBytes()
        {
            byte[] chunkBytes = new byte[0x04 + 0x01 + 0x04 + ChunkData.Length];
            byte[] chunkIdBytes = BitConverter.GetBytes((uint)ChunkID).Reverse().ToArray();
            byte[] chunkDataTypeBytes = new byte[] { (byte)DataType };
            byte[] chunkArrayLengthBytes = BitConverter.GetBytes((uint)ChunkData.Length);

            Array.Copy(chunkIdBytes, 0, chunkBytes, 0, 4);
            Array.Copy(chunkDataTypeBytes, 0, chunkBytes, 4, 1);
            Array.Copy(chunkArrayLengthBytes, 0, chunkBytes, 5, 4);
            Array.Copy(ChunkData, 0, chunkBytes, 9, ChunkData.Length);

            return chunkBytes;
        }

        protected override void SetChunkData(byte[] chunkDataBytes)
        {
            this.ChunkData = chunkDataBytes;
            this.Value = chunkDataBytes;
        }

        public override void SetValue(byte[] value)
        {
            this.Value = value;
            this.ChunkData = value;
        }

        #endregion Methods
    }
}
