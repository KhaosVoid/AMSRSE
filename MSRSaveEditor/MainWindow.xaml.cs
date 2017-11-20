using SaveDataReaderProto.BinaryMercurySteamSave;
using SaveDataReaderProto.BinaryMercurySteamSave.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MSRSaveEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //BMSSVFile.Open(@"H:\Games\3DS\ROMS\3DS\Metroid Samus Returns\Saves\Metroid Samus Returns (original)\profile0\common.bmssv");
            //var bmssv = BMSSVFile.Open(@"C:\Users\ztommey\Downloads\common.bmssv");
            //bmssv.SetChunkValue<float>(BlockIDs.Inventory, ChunkIDs.MaxEnergy, 5000);
            //bmssv.SetChunkValue<float>(BlockIDs.Inventory, ChunkIDs.MaxMissiles, 5000);
            //bmssv.Save(@"C:\Users\ztommey\Downloads\common2.bmssv");
        }
    }
}
