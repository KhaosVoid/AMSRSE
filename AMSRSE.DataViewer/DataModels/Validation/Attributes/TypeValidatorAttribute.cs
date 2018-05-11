using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSRSE.DataViewer.DataModels.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class TypeValidatorAttribute : ValidationAttribute
    {
        #region Validation Messages

        private const string VRESULT_INCORRECT_TYPE = "Value type mismatch. Expected: {0}";

        #endregion Validation Messages

        #region Properties

        public Type ValueType { get; set; }

        #endregion Properties

        #region Methods

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                if (value != null)
                    Convert.ChangeType(value, ValueType);
            }

            catch (Exception ex)
            {
                return new ValidationResult(
                    errorMessage: !string.IsNullOrWhiteSpace(ErrorMessage) ?
                        ErrorMessage :
                        string.Format(VRESULT_INCORRECT_TYPE, ValueType.Name));
            }

            return ValidationResult.Success;
        }

        #endregion Methods
    }
}
