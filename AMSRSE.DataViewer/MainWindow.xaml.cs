using Magatama.Core.DataModels.Extensions;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace AMSRSE.DataViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty TestStringProperty =
            DependencyProperty.Register("TestString", typeof(string), typeof(MainWindow), new PropertyMetadata(TestStringPropertyChanged));

        public static readonly DependencyProperty TestArrayProperty =
            DependencyProperty.Register("TestArray", typeof(byte[]), typeof(MainWindow), new PropertyMetadata(TestArrayPropertyChanged));

        public string TestString
        {
            get { return (string)GetValue(TestStringProperty); }
            set { SetValue(TestStringProperty, value); }
        }

        public byte[] TestArray
        {
            get { return (byte[])GetValue(TestArrayProperty); }
            set { SetValue(TestArrayProperty, value); }
        }

        private static void TestStringPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MainWindow)
            {

            }
        }

        private static void TestArrayPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MainWindow)
            {

            }
        }

        public class TestDataModel2 : DataModels.TestDataModel
        {
            public static readonly DependencyProperty TestStringProperty =
                RegisterTracked("TestString", typeof(string), typeof(TestDataModel2));

            public string TestString
            {
                get { return (string)GetValue(TestStringProperty); }
                set { SetValue(TestStringProperty, value); }
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            DataModels.TestDataModel tdm = new DataModels.TestDataModel()
            {
                FirstName = "Test1",
                Info = "Original"
            };
            tdm.Initialize();

            var test1 = tdm.GetOriginal();

            TestDataModel2 tdm2_1 = new TestDataModel2()
            {
                TestString = "Hello World!!!",
                FirstName = "Test1",
                Info = "Original"
            };
            tdm2_1.Initialize();

            var test2 = tdm2_1.GetOriginal();

            TestDataModel2 tdm2_2 = tdm2_1.Clone();


            //DataModels.TestDataModel testModel = Magatama.Core.DataModels.EditableModel.Initialize(
            //    new DataModels.TestDataModel()
            //    {
            //        FirstName = "Test",
            //        LastName = "Employee",
            //        Info = "Parent Data Model",
            //        TestList = new ObservableCollection<string>()
            //        {
            //            "Item1",
            //            "Item2",
            //            "Item3"
            //        },
            //        TestList2 = new string[3]
            //        {
            //            "Item1",
            //            "Item2",
            //            "Item3"
            //        },
            //        TestList3 = new ObservableCollection<DataModels.TestDataModel>()
            //        {
            //            new DataModels.TestDataModel()
            //            {
            //                FirstName = "Test",
            //                LastName = "Employee",
            //                Info = "Child Data Model 1",
            //                TestList = new ObservableCollection<string>()
            //                {
            //                    "String Item 1",
            //                    "String Item 2",
            //                    "String Item 3"
            //                },
            //                TestList2 = new string[3]
            //                {
            //                    "String 1",
            //                    "String 2",
            //                    "String 3"
            //                }
            //            }
            //        }
            //    });

            //Magatama.Core.DataModels.EditableModelChangeHistoryEntry test = Magatama.Core.DataModels.EditableModelChangeHistoryEntry.CompareOriginal(testModel);

            //testModel.FirstName = null;
            //testModel.PhoneNumber = "1234567890";
            //testModel.Int32Value = "42";

            //testModel.TestList.Add("Item4");
            //testModel.TestList2 = new string[3]
            //{
            //    "Item1",
            //    "Item2",
            //    "Item3"
            //};

            //((DataModels.TestDataModel)testModel.TestList3[0]).Info = "Hello World!!!!!!!!";

            //testModel.RevertChanges();

            //TestString = "Hello World";

            //TestArray = new byte[8];

            //TestArray[0] = 0xFF;
        }

        private void btnCompare_Click(object sender, RoutedEventArgs e)
        {
            //SetChangeHistory();
        }

        //private void SetChangeHistory()
        //{
        //    Magatama.Core.DataModels.EditableModelChangeHistoryEntry compareResults = Magatama.Core.DataModels.EditableModelChangeHistoryEntry.CompareEditableModel(
        //        em1: bmssvExplorerView.LoadedFile,
        //        em2: bmssvExplorerView2.LoadedFile);

        //    Magatama.Core.DataModels.EditableModelChangeHistoryEntry blockResults = compareResults.ChangedItems.FirstOrDefault(r => r.Property == "Blocks");

        //    if (blockResults != null)
        //    {
        //        for (int b = 0; b < blockResults.ChangedItems.Count; b++)
        //        {
        //            var blockResult = blockResults.ChangedItems[b];

        //            Magatama.Core.DataModels.EditableModel.SetChangeHistory(
        //                (DataModels.BlockModel)blockResult.Value, blockResult);

        //            Magatama.Core.DataModels.EditableModelChangeHistoryEntry chunkResults =
        //                blockResult.ChangedItems.FirstOrDefault(r => r.Property == "Chunks");

        //            if (chunkResults != null)
        //            {
        //                for (int c = 0; c < chunkResults.ChangedItems.Count; c++)
        //                {
        //                    var chunkResult = chunkResults.ChangedItems[c];

        //                    Magatama.Core.DataModels.EditableModel.SetChangeHistory(
        //                        (DataModels.ChunkModel)chunkResult.Value, chunkResult);
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
