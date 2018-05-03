using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AMSRSE.DataViewer.DataModels.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class PhoneNumberValidatorAttribute : ValidationAttribute
    {
        #region Validation Messages

        private const string VRESULT_INCORRECT_PHONE_NUMBER =
            "Please enter a correct phone number.";

        #endregion Validation Messages

        #region Methods

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && value is string pnValue)
            {
                if (!Regex.IsMatch(pnValue, "^\\d{10}$"))
                    return new ValidationResult(VRESULT_INCORRECT_PHONE_NUMBER);
            }

            return ValidationResult.Success;
        }

        #endregion Methods
    }
}
