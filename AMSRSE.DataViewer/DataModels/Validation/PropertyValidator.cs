using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AMSRSE.DataViewer.DataModels.Validation
{
    public class PropertyValidator : IValidator
    {
        #region Properties

        public DependencyProperty Property { get; set; }
        public string ErrorText { get; private set; }
        public IList Validators { get; set; }
        public bool IsRequired { get; set; }
        public IList Errors { get; private set; }

        #endregion Properties

        #region Ctor

        public PropertyValidator()
        {
            Validators = new ObservableCollection<IValidator>();
        }

        #endregion Ctor

        #region Methods

        public string Validate(DependencyObject d)
        {
            return Validate(d, Property, false);
        }

        public string ValidateOnce(DependencyObject d)
        {
            return Validate(d, Property, true);
        }

        public string Validate(DependencyObject d, DependencyProperty p)
        {
            return Validate(d, p, false);
        }
        
        public string ValidateOnce(DependencyObject d, DependencyProperty p)
        {
            return Validate(d, p, true);
        }

        private string Validate(DependencyObject d, DependencyProperty p, bool validateOnce)
        {
            var errors = new List<string>();
            string errorText = null;

            if (IsRequired && d.GetValue(p) == null)
            {
                errorText = $"{p.Name} is required";
                errors.Add(errorText);
            }

            else
            {
                for (int i = 0; i < Validators.Count; i++)
                {
                    var validationErrorText = ((IValidator)Validators[i]).Validate(d, p);

                    if (validationErrorText != null)
                        errors.Add(validationErrorText);
                }

                if (errors.Count > 0)
                    errorText = $"One or more errors occurred for the property '{p.Name}'";
            }

            if (!validateOnce)
            {
                Errors = errors;
                ErrorText = errorText;
            }

            return errorText;
        }

        #endregion Methods
    }
}
