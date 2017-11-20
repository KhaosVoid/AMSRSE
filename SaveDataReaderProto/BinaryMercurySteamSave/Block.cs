using SaveDataReaderProto.BinaryMercurySteamSave.Chunks;
using SaveDataReaderProto.BinaryMercurySteamSave.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDataReaderProto.BinaryMercurySteamSave
{
    public class Block
    {
        #region Properties

        public BlockIDs BlockID { get; internal set; }
        public string Name { get; internal set; }
        public IReadOnlyList<IChunk> Chunks { get; internal set; }

        #endregion Properties

        #region Members

        private List<IChunk> _chunks = new List<IChunk>();

        #endregion Members

        #region Ctor

        internal Block()
        {
            Chunks = _chunks;
        }

        #endregion Ctor

        #region Methods

        internal void AddChunk(IChunk chunk)
        {
            _chunks.Add(chunk);
        }

        internal void RemoveChunk(ChunkIDs chunkId)
        {
            _chunks.Remove(_chunks.First(c => c.ChunkID == chunkId));
        }

        #endregion Methods
    }
}
