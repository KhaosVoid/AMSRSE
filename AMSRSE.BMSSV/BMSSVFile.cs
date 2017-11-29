using AMSRSE.BMSSV.Chunks;
using AMSRSE.BMSSV.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSRSE.BMSSV
{
    public class BMSSVFile
    {
        #region Properties

        public string FilePath { get; internal set; }
        public IReadOnlyList<Block> Blocks { get; private set; }

        #endregion Properties

        #region Members

        private List<Block> _blocks = new List<Block>();

        #endregion Members

        #region Ctor

        private BMSSVFile()
        {
            Blocks = _blocks;
        }

        #endregion Ctor

        #region Indexer

        public IChunk this[BlockIDs blockId, ChunkIDs chunkId]
        {
            get => GetChunk<IChunk>(blockId, chunkId);
        }

        #endregion Indexer

        #region Methods

        public static BMSSVFile Open(string path)
        {
            BMSSVFile bmssvFile;

            if (!File.Exists(path))
                throw new Exception("Could not find BMSSV.");

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                bmssvFile = new BMSSVFile()
                {
                    FilePath = path
                };

                byte[] numberOfBlocksBytes = new byte[4];
                uint numberOfBlocks;

                fs.Read(numberOfBlocksBytes, 0, 4);
                numberOfBlocks = BitConverter.ToUInt32(numberOfBlocksBytes/*.Reverse().ToArray()*/, 0);

                for (int b = 0; b < numberOfBlocks; b++)
                    bmssvFile._blocks.Add(ReadBlock(fs));
            }

            return bmssvFile;
        }

        public void Save(string path = null)
        {
            if (path == null)
                path = FilePath;

            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                byte[] numberOfBlocksBytes = BitConverter.GetBytes((uint)Blocks.Count);

                fs.Write(numberOfBlocksBytes, 0, 4);

                for (int b = 0; b < Blocks.Count; b++)
                    WriteBlock(Blocks[b], fs);
            }
        }

        #region Read Methods

        private static Block ReadBlock(FileStream fileStream)
        {
            byte[] numberOfChunksBytes = new byte[4];
            uint numberOfChunks;
            Block block = new Block();
            List<IChunk> chunks = new List<IChunk>();

            fileStream.Read(numberOfChunksBytes, 0, 4);
            numberOfChunks = BitConverter.ToUInt32(numberOfChunksBytes/*.Reverse().ToArray()*/, 0);

            for (int c = 0; c < numberOfChunks; c++)
                block.AddChunk(ReadChunk(fileStream));

            block.BlockID = ((BlockIDChunk)block.Chunks.First(c => c.ChunkID == ChunkIDs.BlockID)).Value;
            block.Name = BMSSVNameTable.BlockNames[block.BlockID];

            return block;
        }

        private static IChunk ReadChunk(FileStream fileStream)
        {
            byte[] chunkIdBytes = new byte[4];
            byte[] chunkDataTypeBytes = new byte[1];

            ChunkIDs chunkId;
            DataTypes chunkDataType;

            fileStream.Read(chunkIdBytes, 0, 4);
            fileStream.Read(chunkDataTypeBytes, 0, 1);

            chunkId = (ChunkIDs)BitConverter.ToUInt32(chunkIdBytes.Reverse().ToArray(), 0);
            chunkDataType = (DataTypes)chunkDataTypeBytes[0];

            switch (chunkDataType)
            {
                case DataTypes.BlockID:
                    return ReadBlockIDChunk(fileStream, chunkId);

                case DataTypes.UInt8:
                    return ReadUInt8Chunk(fileStream, chunkId);

                case DataTypes.UInt8Array:
                    return ReadUInt8ArrayChunk(fileStream, chunkId);

                case DataTypes.UInt32:
                    return ReadUInt32Chunk(fileStream, chunkId);

                case DataTypes.Float32:
                    return ReadFloat32Chunk(fileStream, chunkId);

                case DataTypes.String:
                    return ReadStringChunk(fileStream, chunkId);

                default:
                    throw new Exception("Unknown chunk type!");
            }
        }

        private static BlockIDChunk ReadBlockIDChunk(FileStream fileStream, ChunkIDs chunkId)
        {
            byte[] chunkDataBytes = new byte[4];
            fileStream.Read(chunkDataBytes, 0, 4);

            return new BlockIDChunk(
                chunkId: chunkId,
                chunkDataBytes: chunkDataBytes);
        }

        private static UInt8Chunk ReadUInt8Chunk(FileStream fileStream, ChunkIDs chunkId)
        {
            byte[] chunkDataBytes = new byte[1];
            fileStream.Read(chunkDataBytes, 0, 1);

            return new UInt8Chunk(
                chunkId: chunkId,
                chunkDataBytes: chunkDataBytes);
        }

        private static UInt8ArrayChunk ReadUInt8ArrayChunk(FileStream fileStream, ChunkIDs chunkId)
        {
            byte[] uint8ArrayChunkLengthBytes = new byte[4];
            uint uint8ArrayChunkLength;

            fileStream.Read(uint8ArrayChunkLengthBytes, 0, 4);
            uint8ArrayChunkLength = BitConverter.ToUInt32(uint8ArrayChunkLengthBytes, 0);

            byte[] chunkDataBytes = new byte[uint8ArrayChunkLength];
            fileStream.Read(chunkDataBytes, 0, (int)uint8ArrayChunkLength);

            return new UInt8ArrayChunk(
                    chunkId: chunkId,
                    chunkDataBytes: chunkDataBytes);
        }

        private static UInt32Chunk ReadUInt32Chunk(FileStream fileStream, ChunkIDs chunkId)
        {
            byte[] chunkDataBytes = new byte[4];
            fileStream.Read(chunkDataBytes, 0, 4);

            return new UInt32Chunk(
                    chunkId: chunkId,
                    chunkDataBytes: chunkDataBytes);
        }

        private static Float32Chunk ReadFloat32Chunk(FileStream fileStream, ChunkIDs chunkId)
        {
            byte[] chunkDataBytes = new byte[4];
            fileStream.Read(chunkDataBytes, 0, 4);

            return new Float32Chunk(
                    chunkId: chunkId,
                    chunkDataBytes: chunkDataBytes);
        }

        private static StringChunk ReadStringChunk(FileStream fileStream, ChunkIDs chunkId)
        {
            long lastPosition = fileStream.Position;
            int chunkStringNullPosition;
            byte[] chunkBuffer = new byte[1024];

            fileStream.Read(chunkBuffer, 0, 1024);
            chunkStringNullPosition = Array.IndexOf(chunkBuffer, (byte)0x00);

            if (chunkStringNullPosition < 0)
            {
                fileStream.Position = lastPosition;
                return new StringChunk(
                        chunkId: chunkId,
                        chunkDataBytes: null);
            }

            byte[] chunkDataBytes = new byte[chunkStringNullPosition + 1];
            fileStream.Position = lastPosition;
            fileStream.Read(chunkDataBytes, 0, chunkDataBytes.Length);

            return new StringChunk(
                    chunkId: chunkId,
                    chunkDataBytes: chunkDataBytes);
        }

        #endregion Read Methods

        #region Write Methods

        private void WriteBlock(Block block, FileStream fileStream)
        {
            byte[] numberOfChunksBytes = BitConverter.GetBytes((uint)block.Chunks.Count);

            fileStream.Write(numberOfChunksBytes, 0, 4);

            for (int c = 0; c < block.Chunks.Count; c++)
                WriteChunk(block.Chunks[c], fileStream);
        }

        private void WriteChunk(IChunk chunk, FileStream fileStream)
        {
            byte[] chunkBytes = chunk.GetBytes();
            fileStream.Write(chunkBytes, 0, chunkBytes.Length);
        }

        #endregion Write Methods

        #region Get/Set Methods

        public Block GetBlock(BlockIDs blockId)
        {
            return Blocks.FirstOrDefault(b => b.BlockID == blockId);
        }

        public T GetChunk<T>(BlockIDs blockId, ChunkIDs chunkId) where T : IChunk
        {
            Block block = GetBlock(blockId);
            IChunk chunk = block?.Chunks.FirstOrDefault(c => c.ChunkID == chunkId);

            if (block == null)
            {
                block = new Block() { BlockID = blockId };
                _blocks.Add(block);
            }

            if (chunk == null)
            {
                chunk = (IChunk)Activator.CreateInstance(typeof(T), chunkId);
                block.AddChunk(chunk);
            }

            return (T)chunk;
        }

        //public void SetChunkValue<T>(BlockIDs blockId, ChunkIDs chunkId, T value)
        //{
        //    Block block = GetBlock(blockId);

        //    if (block == null)
        //    {
        //        block = new Block() { BlockID = blockId };
        //        _blocks.Add(block);
        //    }

        //    Chunk<T> chunk = GetChunk<IChunk>(blockId, chunkId) as Chunk<T>;

        //    if (chunk == null)
        //    {
        //        chunk.SetValue(value);
        //    }

        //    else
        //        throw new Exception("Could not set chunk value.");
        //}

        #endregion Get/Set Methods

        #endregion Methods
    }
}
