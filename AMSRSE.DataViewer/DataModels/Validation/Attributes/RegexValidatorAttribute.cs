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
    public class RegexValidatorAttribute : ValidationAttribute
    {
        #region Validation Messages

        private const string VRESULT_INCORRECT_VALUE =
            "Value is incorrect.";

        #endregion Validation Messages

        #region Properties

        public string RegexPattern { get; set; }

        #endregion Properties

        #region Methods

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && value is string rValue)
            {
                if (!Regex.IsMatch(rValue, RegexPattern))
                    return new ValidationResult(
                        errorMessage: !string.IsNullOrWhiteSpace(ErrorMessage) ?
                            ErrorMessage : VRESULT_INCORRECT_VALUE);
            }

            return ValidationResult.Success;
        }

        #endregion Methods
    }
}
