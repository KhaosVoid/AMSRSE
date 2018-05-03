using AMSRSE.DataViewer.DataModels.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AMSRSE.DataViewer.DataModels
{
    public class TestData2Model : DependencyObject, IDataErrorInfo
    {
        #region Dependency Properties

        public static readonly DependencyPropertyKey IsValidPropertyKey =
            DependencyProperty.RegisterReadOnly("IsValid", typeof(bool), typeof(TestData2Model), null);

        public static readonly DependencyProperty IsValidProperty =
            IsValidPropertyKey.DependencyProperty;

        public static readonly DependencyProperty PhoneNumberProperty =
            DependencyProperty.Register("PhoneNumber", typeof(string), typeof(TestData2Model));

        #endregion Dependency Properties

        #region Properties

        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            private set { SetValue(IsValidPropertyKey, value); }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Value is required.")]
        [PhoneNumberValidator]
        public string PhoneNumber
        {
            get { return (string)GetValue(PhoneNumberProperty); }
            set { SetValue(PhoneNumberProperty, value); }
        }

        #endregion Properties

        #region Members

        private Dictionary<string, string> _validationErrors = new Dictionary<string, string>();

        #endregion Members

        #region Ctor

        public TestData2Model()
        {

        }

        #endregion Ctor

        #region IDataErrorInfo

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;

                if (columnName == "PhoneNumber")
                {
                    var results = new List<ValidationResult>(1);

                    var result = Validator.TryValidateProperty(
                        PhoneNumber,
                        new ValidationContext(this)
                        {
                            MemberName = columnName
                        },
                        results);

                    if (!result)
                    {
                        var validationResult = results.First();
                        error = validationResult.ErrorMessage;

                        if (_validationErrors.ContainsKey(columnName))
                            _validationErrors[columnName] = error;

                        else
                            _validationErrors.Add(columnName, error);
                    }

                    else
                    {
                        if (_validationErrors.ContainsKey(columnName))
                            _validationErrors.Remove(columnName);
                    }

                    IsValid = _validationErrors.Count > 0 ? false : true;

                    return error;
                }

                throw new ArgumentException("Invalid property name", columnName);
            }
        }

        #endregion IDataErrorInfo
    }
}
