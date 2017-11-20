using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveDataReaderProto.BinaryMercurySteamSave.Enums;

namespace SaveDataReaderProto.BinaryMercurySteamSave.Chunks
{
    public abstract class Chunk<T> : IChunk
    {
        #region Properties

        public uint ChunkBinarySize => CalculateChunkSize();

        public ChunkIDs ChunkID { get; protected set; }

        public DataTypes DataType { get; protected set; }

        protected byte[] ChunkData { get; set; }

        public T Value { get; protected set; }

        #endregion Properties

        #region Ctor

        protected Chunk(ChunkIDs chunkId, DataTypes dataType, byte[] chunkDataBytes)
        {
            ChunkID = chunkId;
            DataType = dataType;

            if (chunkDataBytes != null)
                SetChunkData(chunkDataBytes);
        }

        protected Chunk(ChunkIDs chunkId, DataTypes dataType, T chunkValue)
        {
            ChunkID = chunkId;
            DataType = dataType;

            if (chunkValue != null)
                SetValue(chunkValue);
        }

        #endregion Ctor

        #region Methods

        protected virtual uint CalculateChunkSize()
        {
            ushort chunkIdLength = 0x04;
            ushort chunkDataTypeLength = 0x01;
            uint chunkDataLength = (uint)ChunkData.Length;
            
            return (uint)(chunkIdLength + chunkDataTypeLength + chunkDataLength);
        }

        public virtual byte[] GetBytes()
        {
            byte[] chunkBytes = new byte[0x04 + 0x01 + ChunkData.Length];
            byte[] chunkIdBytes = BitConverter.GetBytes((uint)ChunkID).Reverse().ToArray();
            byte[] chunkDataTypeBytes = new byte[] { (byte)DataType };

            Array.Copy(chunkIdBytes, 0, chunkBytes, 0, 4);
            Array.Copy(chunkDataTypeBytes, 0, chunkBytes, 4, 1);
            Array.Copy(ChunkData, 0, chunkBytes, 5, ChunkData.Length);

            return chunkBytes;
        }

        protected abstract void SetChunkData(byte[] chunkDataBytes);
        public abstract void SetValue(T value);

        #endregion Methods
    }
}
