using SaveDataReaderProto.BinaryMercurySteamSave.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDataReaderProto.BinaryMercurySteamSave
{
    public static class BMSSV
    {
        #region Properties

        public static IReadOnlyDictionary<BlockIDs, string> BlockNames => _blockNames;
        public static IReadOnlyDictionary<ChunkIDs, string> ChunkNames => _chunkNames;

        #endregion Properties

        #region Members

        private static IReadOnlyDictionary<BlockIDs, string> _blockNames = new Dictionary<BlockIDs, string>()
        {
            #region Globally Used

            { BlockIDs.Unknown,                 "Unknown"                              },

            #endregion Globally Used

            #region Common

            { BlockIDs.ItemsCollectedByArea,    "Items Collected (By Area)"            },
            { BlockIDs.Unknown_CB17C79F,        "Unknown (CB17C79F)"                   },
            { BlockIDs.MiscData,                "Misc Data"                            },
            { BlockIDs.Unknown_68E39AC0,        "Unknown (68E39AC0)"                   },
            { BlockIDs.SaveSpawnLocation,       "Save / Spawn Location"                },
            { BlockIDs.CutscenesTutorialMsgs,   "Cutscense / Tutorial Messages"        },
            { BlockIDs.Unknown_C1BED709,        "Unknown (C1BED709)"                   },
            { BlockIDs.Unknown_BDBE58A1,        "Unknown (BDBE58A1)"                   },
            { BlockIDs.MetroidsKilledByType,    "Metroids Killed (By Type)"            },
            { BlockIDs.TeleportStationsVisited, "Teleport Stations Visited / Unlocked" },
            { BlockIDs.Unknown_63580F44,        "Unknown (63580F44)"                   },
            { BlockIDs.Inventory,               "Inventory"                            }

            #endregion Common
        };

        private static IReadOnlyDictionary<ChunkIDs, string> _chunkNames = new Dictionary<ChunkIDs, string>()
        {
            #region Globally Used

            { ChunkIDs.Unknown,                 "Unknown"                              },
            { ChunkIDs.BlockID,                 "Block ID"                             },

            #endregion Globally Used

            #region Common

            #region Items Collected (By Area)

            { ChunkIDs.Surface,                 "Surface"                              },
            { ChunkIDs.Area1,                   "Area 1"                               },
            { ChunkIDs.Area2,                   "Area 2"                               },
            { ChunkIDs.Area3,                   "Area 3"                               },
            { ChunkIDs.Area4,                   "Area 4"                               },
            { ChunkIDs.Area5,                   "Area 5"                               },
            { ChunkIDs.Area6,                   "Area 6"                               },
            { ChunkIDs.Area7,                   "Area 7"                               },
            { ChunkIDs.Area8,                   "Area 8"                               },

            #endregion Items Collected (By Area)

            #region Metroids Killed (By Type)

            { ChunkIDs.AlphaMetroids,           "Alpha Metroids"                       },
            { ChunkIDs.GammaMetroids,           "Gamma Metroids"                       },
            { ChunkIDs.ZetaMetroids,            "Zeta Metroids"                        },
            { ChunkIDs.OmegaMetroids,           "Omega Metroids"                       },
            { ChunkIDs.NormalMetroids,          "Normal Metroids"                      },
            { ChunkIDs.MetroidQueen,            "Metroid Queen"                        },

            #endregion Metroids Killed (By Type)

            #region Inventory

            { ChunkIDs.TotalMetroids,           "Total Metroids"                       },
            { ChunkIDs.MaxMissiles,             "Max Missiles"                         },
            { ChunkIDs.MetroidsKilled,          "Metroids Killed"                      },
            { ChunkIDs.MaxEnergy,               "Max Energy"                           },
            { ChunkIDs.MaxPowerBombs,           "Max Power Bombs"                      },
            { ChunkIDs.MaxSuperMissiles,        "Max Super Missiles"                   },
            { ChunkIDs.IceBeam,                 "Ice Beam"                             },
            { ChunkIDs.MaxAeionEnergy,          "Max Aeion Energy"                     },
            { ChunkIDs.CurrentEnergy,           "Current Energy"                       },
            { ChunkIDs.CurrentMissiles,         "Current Missiles"                     },
            { ChunkIDs.CurrentSuperMissiles,    "Current Super Missiles"               },
            { ChunkIDs.CurrentPowerBombs,       "Current Power Bombs"                  },
            { ChunkIDs.HighJumpBoots,           "High Jump Boots"                      },
            { ChunkIDs.ScrewAttack,             "Screw Attack"                         },
            { ChunkIDs.SpaceJump,               "Space Jump"                           },
            { ChunkIDs.MorphBall,               "Morph Ball"                           },
            { ChunkIDs.ScanPulse,               "Scan Pulse"                           },
            { ChunkIDs.CurrentAeionEnergy,      "Current Aeion Energy"                 },
            { ChunkIDs.SpringBall,              "Spring Ball"                          },
            { ChunkIDs.CurrentMetroidDNA,       "Current Metroid DNA"                  },
            { ChunkIDs.ChargeBeam,              "Charge Beam"                          },
            { ChunkIDs.MorphBallBomb,           "Morph Ball Bomb"                      },
            { ChunkIDs.SpiderBall,              "Spider Ball"                          },
            { ChunkIDs.LightningArmor,          "Lightning Armor"                      },
            { ChunkIDs.VariaSuit,               "Varia Suit"                           },
            { ChunkIDs.WaveBeam,                "Wave Beam"                            },
            { ChunkIDs.BeamBurst,               "Beam Burst"                           },
            { ChunkIDs.GrappleBeam,             "Grapple Beam"                         },
            { ChunkIDs.SpazerBeam,              "Spazer Beam"                          },
            { ChunkIDs.PhaseDrift,              "Phase Drift"                          },
            { ChunkIDs.PlasmaBeam,              "Plasma Beam"                          },
            { ChunkIDs.GravitySuit,             "Gravity Suit"                         },
            { ChunkIDs.BabyMetroid,             "Baby Metroid"                         },

            #endregion Inventory

            #endregion Common
        };

        #endregion Members
    }
}
