using AMSRSE.DataViewer.Commands;
using AMSRSE.DataViewer.DataModels;
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

        public static readonly DependencyPropertyKey RevertChangesCommandPropertyKey =
            DependencyProperty.RegisterReadOnly("RevertChangesCommand", typeof(DelegateCommand), typeof(TestView), null);

        public static readonly DependencyProperty RevertChangesCommandProperty =
            RevertChangesCommandPropertyKey.DependencyProperty;

        #endregion Dependency Properties

        #region Properties

        public string TestString
        {
            get { return (string)GetValue(TestStringProperty); }
            set { SetValue(TestStringProperty, value); }
        }

        public DelegateCommand RevertChangesCommand
        {
            get { return (DelegateCommand)GetValue(RevertChangesCommandProperty); }
            private set { SetValue(RevertChangesCommandPropertyKey, value); }
        }

        #endregion Properties

        #region Ctor

        static TestView()
        {
            TestStringProperty.OverrideMetadata(typeof(TestView), new PropertyMetadata("Hello World"));
        }

        public TestView()
        {
            RevertChangesCommand = new DelegateCommand((o) => { RevertChanges(); });

            InitializeComponent(
                xamlPath: new Uri("/AMSRSE.DataViewer;component/Views/TestView.xaml", UriKind.Relative));
        }

        #endregion Ctor

        #region Methods

        private void RevertChanges()
        {
            if (DataContext is EditableModel editableModel)
                editableModel.RevertChanges();
        }

        #endregion Methods
    }
}
