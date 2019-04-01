using AMSRSE.DataViewer.DataModels;
using AMSRSE.DataViewer.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSRSE.DataViewer.Designer.Mocks.Views
{
    public class BMSSVComparisonViewMock : BMSSVComparisonView
    {
        #region Ctor

        public BMSSVComparisonViewMock()
        {
            FileA = GenerateFileA();
            FileB = GenerateFileB();
        }

        #endregion Ctor

        #region Methods

        private FileModel GenerateFileA()
        {
            return new FileModel()
            {
                FilePath = "C:\\fakepath_A\\common.bmssv",
                Blocks = new ObservableCollection<BlockModel>()
                {
                    new BlockModel()
                    {
                        BlockId = 0x3814CFC7, BlockName = "Metroids Killed (By Type)",
                        Chunks = new ObservableCollection<ChunkModel>()
                        {
                            new ChunkModel() { ChunkId = 0x91E9DEEE, ChunkName = "Alpha Metroids Killed",  DataType = ChunkModel.DataTypes.UInt32, Value = 8 },
                            new ChunkModel() { ChunkId = 0x8A007DFA, ChunkName = "Gamma Metroids Killed",  DataType = ChunkModel.DataTypes.UInt32, Value = 1 }
                        }
                    },
                    new BlockModel()
                    {
                        BlockId = 0xD97207D2, BlockName = "Items Collected (By Area)",
                        Chunks = new ObservableCollection<ChunkModel>()
                        {
                            new ChunkModel() { ChunkId = 0x1F6E32DA, ChunkName = "Surface",  DataType = ChunkModel.DataTypes.UInt32, Value = 4 },
                            new ChunkModel() { ChunkId = 0x1DD4CC59, ChunkName = "Area 1",   DataType = ChunkModel.DataTypes.UInt32, Value = 8 },
                            new ChunkModel() { ChunkId = 0x9A3461E1, ChunkName = "Area 2",   DataType = ChunkModel.DataTypes.UInt32, Value = 3 }
                        }
                    },
                    new BlockModel()
                    {
                        BlockId = 0xC1BED709, BlockName = "Unknown"
                    },
                    new BlockModel()
                    {
                        BlockId = 0xFEBC51D5, BlockName = "Inventory",
                        Chunks = new ObservableCollection<ChunkModel>()
                        {
                            new ChunkModel() { ChunkId = 0x09E50EEE, ChunkName = "Total Metroids",         DataType = ChunkModel.DataTypes.Float32, Value = 40   },
                            new ChunkModel() { ChunkId = 0x55F1D6B6, ChunkName = "Max Missiles",           DataType = ChunkModel.DataTypes.Float32, Value = 264  },
                            new ChunkModel() { ChunkId = 0xFE981519, ChunkName = "Metroids Killed",        DataType = ChunkModel.DataTypes.Float32, Value = 9    },
                            new ChunkModel() { ChunkId = 0x70833890, ChunkName = "Max Energy",             DataType = ChunkModel.DataTypes.Float32, Value = 399  },
                            new ChunkModel() { ChunkId = 0xE9877735, ChunkName = "Max Power Bombs",        DataType = ChunkModel.DataTypes.Float32, Value = 0    },
                            new ChunkModel() { ChunkId = 0xCBA0FFDF, ChunkName = "Max Super Missiles",     DataType = ChunkModel.DataTypes.Float32, Value = 0    },
                            new ChunkModel() { ChunkId = 0x77561E39, ChunkName = "Ice Beam",               DataType = ChunkModel.DataTypes.Float32, Value = 1    },
                            new ChunkModel() { ChunkId = 0x9BD12C5A, ChunkName = "Max Aeion Energy",       DataType = ChunkModel.DataTypes.Float32, Value = 1200 },
                            new ChunkModel() { ChunkId = 0x733C15CE, ChunkName = "Current Energy",         DataType = ChunkModel.DataTypes.Float32, Value = 399  },
                            new ChunkModel() { ChunkId = 0x42CED42A, ChunkName = "Current Missiles",       DataType = ChunkModel.DataTypes.Float32, Value = 64   },
                            new ChunkModel() { ChunkId = 0x455A1D6A, ChunkName = "Current Super Missiles", DataType = ChunkModel.DataTypes.Float32, Value = 0    },
                            new ChunkModel() { ChunkId = 0xB074A1EE, ChunkName = "Current Power Bombs",    DataType = ChunkModel.DataTypes.Float32, Value = 0    },
                            new ChunkModel() { ChunkId = 0x634DC541, ChunkName = "High Jump Boots",        DataType = ChunkModel.DataTypes.Float32, Value = 0    },
                            new ChunkModel() { ChunkId = 0x20046296, ChunkName = "Screw Attack",           DataType = ChunkModel.DataTypes.Float32, Value = 0    },
                            new ChunkModel() { ChunkId = 0x194F3BAA, ChunkName = "Space Jump",             DataType = ChunkModel.DataTypes.Float32, Value = 0    },
                            new ChunkModel() { ChunkId = 0xEA9E382B, ChunkName = "Morph Ball",             DataType = ChunkModel.DataTypes.Float32, Value = 1    },
                            new ChunkModel() { ChunkId = 0x576E4803, ChunkName = "Scan Pulse",             DataType = ChunkModel.DataTypes.Float32, Value = 1    },
                            new ChunkModel() { ChunkId = 0xB9805F37, ChunkName = "Current Aeion Energy",   DataType = ChunkModel.DataTypes.Float32, Value = 1200 },
                            new ChunkModel() { ChunkId = 0xA9FB0778, ChunkName = "Spring Ball",            DataType = ChunkModel.DataTypes.Float32, Value = 0    },
                            new ChunkModel() { ChunkId = 0x462D2463, ChunkName = "Current Metroid DNA",    DataType = ChunkModel.DataTypes.Float32, Value = 2    },
                            new ChunkModel() { ChunkId = 0xA34423D9, ChunkName = "Charge Beam",            DataType = ChunkModel.DataTypes.Float32, Value = 1    },
                            new ChunkModel() { ChunkId = 0x03FDA58A, ChunkName = "Morph Ball Bomb",        DataType = ChunkModel.DataTypes.Float32, Value = 1    },
                            new ChunkModel() { ChunkId = 0x06F58B9C, ChunkName = "Spider Ball",            DataType = ChunkModel.DataTypes.Float32, Value = 0    },
                            new ChunkModel() { ChunkId = 0x7D145810, ChunkName = "Lightning Armor",        DataType = ChunkModel.DataTypes.Float32, Value = 0    },
                            new ChunkModel() { ChunkId = 0xF7E06C74, ChunkName = "Varia Suit",             DataType = ChunkModel.DataTypes.Float32, Value = 0    },
                        }
                    }
                }
            };
        }

        private FileModel GenerateFileB()
        {
            return new FileModel()
            {
                FilePath = "C:\\fakepath_B\\common.bmssv",
                Blocks = new ObservableCollection<BlockModel>()
                {
                    new BlockModel()
                    {
                        BlockId = 0x3814CFC7, BlockName = "Metroids Killed (By Type)",
                        Chunks = new ObservableCollection<ChunkModel>()
                        {
                            new ChunkModel() { ChunkId = 0x91E9DEEE, ChunkName = "Alpha Metroids Killed",  DataType = ChunkModel.DataTypes.UInt32, Value = 17 },
                            new ChunkModel() { ChunkId = 0x8A007DFA, ChunkName = "Gamma Metroids Killed",  DataType = ChunkModel.DataTypes.UInt32, Value = 14 },
                            new ChunkModel() { ChunkId = 0xD22BF145, ChunkName = "Zeta Metroids Killed",   DataType = ChunkModel.DataTypes.UInt32, Value = 4  },
                            new ChunkModel() { ChunkId = 0xC14D2774, ChunkName = "Omega Metroids Killed",  DataType = ChunkModel.DataTypes.UInt32, Value = 4  },
                            new ChunkModel() { ChunkId = 0x7B7D796F, ChunkName = "Normal Metroids Killed", DataType = ChunkModel.DataTypes.UInt32, Value = 10 },
                            new ChunkModel() { ChunkId = 0x4164D39C, ChunkName = "Metroid Queen Killed",   DataType = ChunkModel.DataTypes.UInt32, Value = 1  }
                        }
                    },
                    new BlockModel()
                    {
                        BlockId = 0xD97207D2, BlockName = "Items Collected (By Area)",
                        Chunks = new ObservableCollection<ChunkModel>()
                        {
                            new ChunkModel() { ChunkId = 0x1F6E32DA, ChunkName = "Surface",  DataType = ChunkModel.DataTypes.UInt32, Value = 14 },
                            new ChunkModel() { ChunkId = 0x1DD4CC59, ChunkName = "Area 1",   DataType = ChunkModel.DataTypes.UInt32, Value = 14 },
                            new ChunkModel() { ChunkId = 0x9A3461E1, ChunkName = "Area 2",   DataType = ChunkModel.DataTypes.UInt32, Value = 18 },
                            new ChunkModel() { ChunkId = 0xE7940589, ChunkName = "Area 3",   DataType = ChunkModel.DataTypes.UInt32, Value = 21 },
                            new ChunkModel() { ChunkId = 0xD5F34B4B, ChunkName = "Area 4",   DataType = ChunkModel.DataTypes.UInt32, Value = 21 },
                            new ChunkModel() { ChunkId = 0x2FB3829B, ChunkName = "Area 5",   DataType = ChunkModel.DataTypes.UInt32, Value = 23 },
                            new ChunkModel() { ChunkId = 0x5213E6F3, ChunkName = "Area 6",   DataType = ChunkModel.DataTypes.UInt32, Value = 12 },
                            new ChunkModel() { ChunkId = 0x77DB0BAC, ChunkName = "Area 7",   DataType = ChunkModel.DataTypes.UInt32, Value = 13 },
                            new ChunkModel() { ChunkId = 0xDED6C283, ChunkName = "Area 8",   DataType = ChunkModel.DataTypes.UInt32, Value = 14 }
                        }
                    },
                    new BlockModel()
                    {
                        BlockId = 0xC1BED709, BlockName = "Unknown"
                    },
                    new BlockModel()
                    {
                        BlockId = 0xBDBE58A1, BlockName = "Unknown"
                    },
                    new BlockModel()
                    {
                        BlockId = 0xFEBC51D5, BlockName = "Inventory",
                        Chunks = new ObservableCollection<ChunkModel>()
                        {
                            new ChunkModel() { ChunkId = 0x09E50EEE, ChunkName = "Total Metroids",         DataType = ChunkModel.DataTypes.Float32, Value = 50   },
                            new ChunkModel() { ChunkId = 0x55F1D6B6, ChunkName = "Max Missiles",           DataType = ChunkModel.DataTypes.Float32, Value = 264  },
                            new ChunkModel() { ChunkId = 0xFE981519, ChunkName = "Metroids Killed",        DataType = ChunkModel.DataTypes.Float32, Value = 50   },
                            new ChunkModel() { ChunkId = 0x70833890, ChunkName = "Max Energy",             DataType = ChunkModel.DataTypes.Float32, Value = 1099 },
                            new ChunkModel() { ChunkId = 0xE9877735, ChunkName = "Max Power Bombs",        DataType = ChunkModel.DataTypes.Float32, Value = 20   },
                            new ChunkModel() { ChunkId = 0xCBA0FFDF, ChunkName = "Max Super Missiles",     DataType = ChunkModel.DataTypes.Float32, Value = 35   },
                            new ChunkModel() { ChunkId = 0x77561E39, ChunkName = "Ice Beam",               DataType = ChunkModel.DataTypes.Float32, Value = 1    },
                            new ChunkModel() { ChunkId = 0x9BD12C5A, ChunkName = "Max Aeion Energy",       DataType = ChunkModel.DataTypes.Float32, Value = 2200 },
                            new ChunkModel() { ChunkId = 0x733C15CE, ChunkName = "Current Energy",         DataType = ChunkModel.DataTypes.Float32, Value = 1099 },
                            new ChunkModel() { ChunkId = 0x42CED42A, ChunkName = "Current Missiles",       DataType = ChunkModel.DataTypes.Float32, Value = 264  },
                            new ChunkModel() { ChunkId = 0x455A1D6A, ChunkName = "Current Super Missiles", DataType = ChunkModel.DataTypes.Float32, Value = 35   },
                            new ChunkModel() { ChunkId = 0xB074A1EE, ChunkName = "Current Power Bombs",    DataType = ChunkModel.DataTypes.Float32, Value = 20   },
                            new ChunkModel() { ChunkId = 0x634DC541, ChunkName = "High Jump Boots",        DataType = ChunkModel.DataTypes.Float32, Value = 1    },
                            new ChunkModel() { ChunkId = 0x20046296, ChunkName = "Screw Attack",           DataType = ChunkModel.DataTypes.Float32, Value = 1    },
                            new ChunkModel() { ChunkId = 0x194F3BAA, ChunkName = "Space Jump",             DataType = ChunkModel.DataTypes.Float32, Value = 1    },
                            new ChunkModel() { ChunkId = 0xEA9E382B, ChunkName = "Morph Ball",             DataType = ChunkModel.DataTypes.Float32, Value = 1    },
                            new ChunkModel() { ChunkId = 0x576E4803, ChunkName = "Scan Pulse",             DataType = ChunkModel.DataTypes.Float32, Value = 1    },
                            new ChunkModel() { ChunkId = 0xB9805F37, ChunkName = "Current Aeion Energy",   DataType = ChunkModel.DataTypes.Float32, Value = 2200 },
                            new ChunkModel() { ChunkId = 0xA9FB0778, ChunkName = "Spring Ball",            DataType = ChunkModel.DataTypes.Float32, Value = 1    },
                            new ChunkModel() { ChunkId = 0x462D2463, ChunkName = "Current Metroid DNA",    DataType = ChunkModel.DataTypes.Float32, Value = 0    },
                            new ChunkModel() { ChunkId = 0xA34423D9, ChunkName = "Charge Beam",            DataType = ChunkModel.DataTypes.Float32, Value = 1    },
                            new ChunkModel() { ChunkId = 0x03FDA58A, ChunkName = "Morph Ball Bomb",        DataType = ChunkModel.DataTypes.Float32, Value = 1    },
                            new ChunkModel() { ChunkId = 0x06F58B9C, ChunkName = "Spider Ball",            DataType = ChunkModel.DataTypes.Float32, Value = 1    },
                            new ChunkModel() { ChunkId = 0x7D145810, ChunkName = "Lightning Armor",        DataType = ChunkModel.DataTypes.Float32, Value = 1    },
                            new ChunkModel() { ChunkId = 0xF7E06C74, ChunkName = "Varia Suit",             DataType = ChunkModel.DataTypes.Float32, Value = 1    },
                            new ChunkModel() { ChunkId = 0x8E7272BA, ChunkName = "Wave Beam",              DataType = ChunkModel.DataTypes.Float32, Value = 1    },
                            new ChunkModel() { ChunkId = 0x5CBD3A2B, ChunkName = "Beam Burst",             DataType = ChunkModel.DataTypes.Float32, Value = 1    },
                            new ChunkModel() { ChunkId = 0xCBB372C9, ChunkName = "Grapple Beam",           DataType = ChunkModel.DataTypes.Float32, Value = 1    },
                            new ChunkModel() { ChunkId = 0xCB790519, ChunkName = "Spazer Beam",            DataType = ChunkModel.DataTypes.Float32, Value = 1    },
                            new ChunkModel() { ChunkId = 0x4871DBB7, ChunkName = "Phase Drift",            DataType = ChunkModel.DataTypes.Float32, Value = 1    },
                            new ChunkModel() { ChunkId = 0xD55B9714, ChunkName = "Plasma Beam",            DataType = ChunkModel.DataTypes.Float32, Value = 1    },
                            new ChunkModel() { ChunkId = 0x999DACAD, ChunkName = "Gravity Suit",           DataType = ChunkModel.DataTypes.Float32, Value = 1    },
                            new ChunkModel() { ChunkId = 0xE6E8ECB4, ChunkName = "Baby Metroid",           DataType = ChunkModel.DataTypes.Float32, Value = 1    }
                        }
                    },
                    new BlockModel()
                    {
                        BlockId = 0x63580F44, BlockName = "Unknown"
                    }
                }
            };
        }

        public override void OnApplyTemplate()
        {
            CompareFilesCommand.Execute();

            base.OnApplyTemplate();
        }

        #endregion Methods
    }
}
