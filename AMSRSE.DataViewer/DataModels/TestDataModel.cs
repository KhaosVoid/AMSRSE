using Magatama.Core.DataModels;
using Magatama.Core.DataModels.Validation.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public static readonly DependencyProperty PhoneNumberProperty =
            RegisterTracked("PhoneNumber", typeof(string), typeof(TestDataModel), new PropertyMetadata(""));

        public static readonly DependencyProperty Int32ValueProperty =
            RegisterTracked("Int32Value", typeof(string), typeof(TestDataModel));

        public static readonly DependencyProperty UInt32ValueProperty =
            RegisterTracked("UInt32ValueProperty", typeof(uint), typeof(TestDataModel));

        public static readonly DependencyProperty FloatValueProperty =
            RegisterTracked("FloatValue", typeof(float), typeof(TestDataModel));

        public static readonly DependencyProperty TestListProperty =
            RegisterTracked("TestList", typeof(ObservableCollection<string>), typeof(TestDataModel), null);

        public static readonly DependencyProperty TestList2Property =
            RegisterTracked("TestList2", typeof(string[]), typeof(TestDataModel));

        public static readonly DependencyProperty TestList3Property =
            RegisterTracked("TestList3", typeof(ObservableCollection<TestDataModel>), typeof(TestDataModel));

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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone number is required.")]
        [PhoneNumberValidator]
        public string PhoneNumber
        {
            get { return (string)GetValue(PhoneNumberProperty); }
            set { SetValue(PhoneNumberProperty, value); }
        }

        [Required(ErrorMessage = "Value is required.")]
        [NumberValidator(NumberType = NumberValidatorAttribute.NumberTypes.Int, NumberStyle = System.Globalization.NumberStyles.Any)]
        public string Int32Value
        {
            get { return (string)GetValue(Int32ValueProperty); }
            set { SetValue(Int32ValueProperty, value); }
        }

        public uint UInt32Value
        {
            get { return (uint)GetValue(UInt32ValueProperty); }
            set { SetValue(UInt32ValueProperty, value); }
        }

        public float FloatValue
        {
            get { return (float)GetValue(FloatValueProperty); }
            set { SetValue(FloatValueProperty, value); }
        }

        public IList TestList
        {
            get { return (IList)GetValue(TestListProperty); }
            set { SetValue(TestListProperty, value); }
        }

        public string[] TestList2
        {
            get { return (string[])GetValue(TestList2Property); }
            set { SetValue(TestList2Property, value); }
        }

        public IList TestList3
        {
            get { return (IList)GetValue(TestList3Property); }
            set { SetValue(TestList3Property, value); }
        }

        #endregion Properties

        #region Ctor

        public TestDataModel()
        {
            TestList = new ObservableCollection<string>();
            TestList3 = new ObservableCollection<TestDataModel>();
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
