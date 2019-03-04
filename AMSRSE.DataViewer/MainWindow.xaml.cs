using System.Collections.ObjectModel;
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

        public MainWindow()
        {
            InitializeComponent();

            DataModels.TestDataModel testModel = Magatama.Core.DataModels.EditableModel.Initialize(
                new DataModels.TestDataModel()
                {
                    FirstName = "Test",
                    LastName = "Employee",
                    Info = "Parent Data Model",
                    TestList = new ObservableCollection<string>()
                    {
                        "Item1",
                        "Item2",
                        "Item3"
                    },
                    TestList2 = new string[3]
                    {
                        "Item1",
                        "Item2",
                        "Item3"
                    },
                    TestList3 = new ObservableCollection<DataModels.TestDataModel>()
                    {
                        new DataModels.TestDataModel()
                        {
                            FirstName = "Test",
                            LastName = "Employee",
                            Info = "Child Data Model 1",
                            TestList = new ObservableCollection<string>()
                            {
                                "String Item 1",
                                "String Item 2",
                                "String Item 3"
                            },
                            TestList2 = new string[3]
                            {
                                "String 1",
                                "String 2",
                                "String 3"
                            }
                        }
                    }
                });

            TestString = "Hello World";

            TestArray = new byte[8];

            TestArray[0] = 0xFF;
        }
    }
}
