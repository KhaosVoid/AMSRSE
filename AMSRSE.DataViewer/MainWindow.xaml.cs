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

            TestString = "Hello World";

            TestArray = new byte[8];

            TestArray[0] = 0xFF;
        }
    }
}
