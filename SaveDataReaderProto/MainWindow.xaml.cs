using Microsoft.Win32;
using SaveDataReaderProto.BinaryMercurySteamSave;
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

namespace SaveDataReaderProto
{
    public partial class MainWindow : Window
    {
        #region Members

        BMSSVFile bmssvFile;

        #endregion Members

        #region Ctor

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion Ctor

        #region Methods

        private void btnLoadFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Load MSR Profile Data (Binary Mercury Steam Save)";
            ofd.FileName = "common.bmssv";
            ofd.Filter = "Binary Mercury Steam Save|common.bmssv";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == true)
            {
                bmssvFile = BMSSVFile.Open(ofd.FileName);
                inventory.LoadData(bmssvFile);

                if (inventory.Visibility != Visibility.Visible)
                    inventory.Visibility = Visibility.Visible;

                if (btnSaveFileAs.Visibility != Visibility.Visible)
                    btnSaveFileAs.Visibility = Visibility.Visible;
            }
        }

        private void btnSaveFileAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save MSR Profile Data (Binary Mercury Steam Save)";
            sfd.FileName = "common.bmssv";
            sfd.Filter = "Binary Mercury Steam Save|common.bmssv";
            sfd.CreatePrompt = true;
            sfd.OverwritePrompt = true;

            if (sfd.ShowDialog() == true)
            {
                inventory.CommitChanges(bmssvFile);
                bmssvFile.Save(sfd.FileName);
            }
        }

        #endregion Methods
    }
}
