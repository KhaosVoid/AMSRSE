using AMSRSE.DataViewer.DataModels.Validation.Attributes;
using System;
using System.Collections.Generic;
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
            RegisterTracked("Int32Value", typeof(int), typeof(TestDataModel));

        public static readonly DependencyProperty UInt32ValueProperty =
            RegisterTracked("UInt32ValueProperty", typeof(uint), typeof(TestDataModel));

        public static readonly DependencyProperty FloatValueProperty =
            RegisterTracked("FloatValue", typeof(float), typeof(TestDataModel));

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

        public int Int32Value
        {
            get { return (int)GetValue(Int32ValueProperty); }
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
