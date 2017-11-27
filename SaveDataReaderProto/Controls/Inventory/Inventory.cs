using SaveDataReaderProto.BinaryMercurySteamSave;
using SaveDataReaderProto.DataModels.Common;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SaveDataReaderProto.Controls.Inventory
{
    public class Inventory : Control
    {
        #region Ctor

        public Inventory()
        {

        }

        #endregion Ctor

        #region Methods

        public void LoadData(BMSSVFile bmssvFile)
        {
            this.DataContext = new InventoryDataModel(bmssvFile);
        }

        public void CommitChanges(BMSSVFile bmssvFile)
        {
            ((InventoryDataModel)this.DataContext).CommitChanges(bmssvFile);
        }

        #endregion Methods
    }
}
