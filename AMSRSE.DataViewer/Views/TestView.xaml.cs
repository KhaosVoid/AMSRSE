using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AMSRSE.DataViewer.Views
{
    public class TestView : ViewBase
    {
        #region Dependency Properties

        public static readonly DependencyProperty TestStringProperty =
            DependencyProperty.Register("TestString", typeof(string), typeof(TestView));

        #endregion Dependency Properties

        #region Properties

        public string TestString
        {
            get { return (string)GetValue(TestStringProperty); }
            set { SetValue(TestStringProperty, value); }
        }

        #endregion Properties

        #region Ctor

        static TestView()
        {
            TestStringProperty.OverrideMetadata(typeof(TestView), new PropertyMetadata("Hello World"));
        }

        public TestView()
        {
            InitializeComponent(
                xamlPath: new Uri("/AMSRSE.DataViewer;component/Views/TestView.xaml", UriKind.Relative));
        }

        #endregion Ctor

        #region Methods



        #endregion Methods
    }
}
