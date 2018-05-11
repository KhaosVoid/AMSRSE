using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSRSE.DataViewer.DataModels.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class NumberValidatorAttribute : ValidationAttribute
    {
        #region Enums

        public enum NumberTypes
        {
            Byte,
            UShort,
            UInt,
            ULong,
            SByte,
            Short,
            Int,
            Long,
            Single,
            Double,
            Float
        }

        #endregion Enums

        #region Properties

        public NumberTypes NumberType { get; set; }
        public NumberStyles NumberStyle { get; set; }

        #endregion Properties

        #region Validation Messages

        private const string VRESULT_INCORRECT_VALUE = "The value is not a valid number.";

        #endregion Validation Messages

        #region Methods

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && value is string nValue)
            {
                try
                {
                    if (NumberStyle.HasFlag(NumberStyles.AllowHexSpecifier))
                        nValue = nValue.ToLower().Replace("0x", "").Replace("&h", "");


                    switch (NumberType)
                    {
                        case NumberTypes.Byte:
                            byte.Parse(nValue, NumberStyle);
                            break;

                        case NumberTypes.UShort:
                            ushort.Parse(nValue, NumberStyle);
                            break;

                        case NumberTypes.UInt:
                            uint.Parse(nValue, NumberStyle);
                            break;

                        case NumberTypes.ULong:
                            ulong.Parse(nValue, NumberStyle);
                            break;

                        case NumberTypes.SByte:
                            sbyte.Parse(nValue, NumberStyle);
                            break;

                        case NumberTypes.Short:
                            short.Parse(nValue, NumberStyle);
                            break;

                        case NumberTypes.Int:
                            int.Parse(nValue, NumberStyle);
                            break;

                        case NumberTypes.Long:
                            long.Parse(nValue, NumberStyle);
                            break;

                        case NumberTypes.Single:
                            Single.Parse(nValue, NumberStyle);
                            break;

                        case NumberTypes.Float:
                            float.Parse(nValue, NumberStyle);
                            break;

                        case NumberTypes.Double:
                            double.Parse(nValue, NumberStyle);
                            break;
                    }
                }

                catch (Exception ex)
                {
                    return new ValidationResult(
                        errorMessage: !string.IsNullOrWhiteSpace(ErrorMessage) ?
                            ErrorMessage : VRESULT_INCORRECT_VALUE);
                }
            }

            return ValidationResult.Success;
        }

        #endregion Methods
    }
}
