using AMSRSE.DataViewer.Commands;
using AMSRSE.DataViewer.DataModels;
using Magatama.Core.DataModels;
using Magatama.Core.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AMSRSE.DataViewer.Views
{
    public class TestView : ViewBase
    {
        #region Dependency Properties

        public static readonly DependencyProperty TestStringProperty =
            DependencyProperty.Register("TestString", typeof(string), typeof(TestView));

        public static readonly DependencyPropertyKey AddItemCommandPropertyKey =
            DependencyProperty.RegisterReadOnly("AddItemCommand", typeof(DelegateCommand), typeof(TestView), null);

        public static readonly DependencyProperty AddItemCommandProperty =
            AddItemCommandPropertyKey.DependencyProperty;

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

        public DelegateCommand AddItemCommand
        {
            get { return (DelegateCommand)GetValue(AddItemCommandProperty); }
            private set { SetValue(AddItemCommandPropertyKey, value); }
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
            AddItemCommand = new DelegateCommand((o) => { AddItem(); });
            RevertChangesCommand = new DelegateCommand((o) => { RevertChanges(); });

            InitializeComponent(
                xamlPath: new Uri("/AMSRSE.DataViewer;component/Views/TestView.xaml", UriKind.Relative));
        }

        #endregion Ctor

        #region Methods

        private void AddItem()
        {
            if (DataContext is TestDataModel tdm)
            {
                //tdm.TestList.Add(new TestDataModel()
                //{
                //    Info = "!!Hello World!!"
                //});
            }
        }

        private void RevertChanges()
        {
            if (DataContext is EditableModel editableModel)
                editableModel.RevertChanges();
        }

        #endregion Methods
    }
}
