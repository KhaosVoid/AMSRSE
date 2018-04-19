using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace AMSRSE.DataViewer.DataModels.Validation
{
    public class RegexValidator : IValidator
    {
        #region Properties

        public string ErrorText { get; set; }
        public string RegexPattern { get; set; }

        #endregion Properties

        #region Ctor

        public RegexValidator()
        {

        }

        #endregion Ctor

        #region Methods

        public string Validate(DependencyObject d, DependencyProperty p)
        {
            var value = d.GetValue(p);

            if (value == null ||
                Regex.IsMatch(value.ToString(), RegexPattern))
                return null;

            return string.IsNullOrWhiteSpace(ErrorText) ?
                $"{p.Name} is invalid" :
                ErrorText;
        }

        #endregion Methods
    }
}
