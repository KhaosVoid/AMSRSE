using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSRSE.BMSSV.Enums
{
    public enum DataTypes : byte
    {
        Unknown    = 0xFF,
        BlockID    = 0x75,
        UInt8      = 0x62,
        UInt8Array = 0x63,
        UInt32     = 0x69,
        Float32    = 0x66,
        String     = 0x73
    }
}
