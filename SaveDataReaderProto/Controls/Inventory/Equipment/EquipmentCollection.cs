using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDataReaderProto.Controls.Inventory.Equipment
{
    public class EquipmentCollection<E> : ObservableCollection<E> where E : EquipmentItem
    {

    }
}
