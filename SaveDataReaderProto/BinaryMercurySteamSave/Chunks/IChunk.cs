using SaveDataReaderProto.BinaryMercurySteamSave.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDataReaderProto.BinaryMercurySteamSave.Chunks
{
    public interface IChunk
    {
        #region Properties

        uint ChunkBinarySize { get; }
        ChunkIDs ChunkID { get; }
        DataTypes DataType { get; }
        byte[] GetBytes();

        #endregion Properties
    }
}
