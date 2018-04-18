using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AMSRSE.DataViewer.DataModels
{
    public class TestDataModel : EditableModel
    {
        #region Dependency Properties

        public static readonly DependencyProperty FirstNameProperty =
            RegisterTracked("FirstName", typeof(string), typeof(TestDataModel));

        public static readonly DependencyProperty LastNameProperty =
            RegisterTracked("LastName", typeof(string), typeof(TestDataModel));

        public static readonly DependencyProperty InfoProperty =
            RegisterTracked("Info", typeof(string), typeof(TestDataModel), new PropertyMetadata("Hello World", OnInfoPropertyChangedCallback));

        #endregion Dependency Properties

        #region Properties

        public string FirstName
        {
            get { return (string)GetValue(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }

        public string LastName
        {
            get { return (string)GetValue(LastNameProperty); }
            set { SetValue(LastNameProperty, value); }
        }

        public string Info
        {
            get { return (string)GetValue(InfoProperty); }
            set { SetValue(InfoProperty, value); }
        }

        #endregion Properties

        #region Ctor

        public TestDataModel()
        {

        }

        #endregion Ctor

        #region Dependency Property Callbacks

        private static void OnInfoPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var test = d as TestDataModel;
            var test2 = test.HasChanges;
        }

        #endregion Dependency Property Callbacks
    }
}
