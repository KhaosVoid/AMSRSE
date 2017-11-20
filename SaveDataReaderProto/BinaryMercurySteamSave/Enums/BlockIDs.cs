using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDataReaderProto.BinaryMercurySteamSave.Enums
{
    public enum BlockIDs : uint
    {
        Unknown                 = 0xFFFFFFFF,
        ItemsCollectedByArea    = 0xD97207D2,
        Unknown_CB17C79F        = 0xCB17C79F,
        MiscData                = 0xC72341EA,
        Unknown_68E39AC0        = 0x68E39AC0,
        SaveSpawnLocation       = 0x1C421E97,
        CutscenesTutorialMsgs   = 0x6F49393E,
        Unknown_C1BED709        = 0xC1BED709,
        Unknown_BDBE58A1        = 0xBDBE58A1,
        MetroidsKilledByType    = 0x3814CFC7,
        TeleportStationsVisited = 0xBC6C23CE,
        Unknown_63580F44        = 0x63580F44,
        Inventory               = 0xFEBC51D5
    }
}
