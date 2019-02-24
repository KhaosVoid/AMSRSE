using Magatama.Core.DataModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace AMSRSE.DataViewer.DataModels.Validation
{
    [ContentProperty("Validators")]
    public class ModelValidation : DependencyObject
    {
        #region Dependency Properties

        public static readonly DependencyProperty ModelValidationProperty =
            DependencyProperty.RegisterAttached("ModelValidation", typeof(ModelValidation), typeof(ModelValidation));

        public static readonly DependencyPropertyKey ValidatorsPropertyKey =
            DependencyProperty.RegisterReadOnly("Validators", typeof(IList), typeof(ModelValidation), null);

        public static readonly DependencyProperty ValidatorsProperty =
            ValidatorsPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey IsValidPropertyKey =
            DependencyProperty.RegisterReadOnly("IsValid", typeof(bool), typeof(ModelValidation), null);

        public static readonly DependencyProperty IsValidProperty =
            IsValidPropertyKey.DependencyProperty;

        #endregion Dependency Properties

        #region Properties

        public IList Validators
        {
            get { return (IList)GetValue(ValidatorsProperty); }
            private set { SetValue(ValidatorsPropertyKey, value); }
        }

        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            private set { SetValue(IsValidPropertyKey, value); }
        }

        #endregion Properties

        #region Ctor

        public ModelValidation()
        {
            Validators = new ObservableCollection<PropertyValidator>();
        }

        #endregion Ctor

        #region Attached Property Methods

        public static ModelValidation GetModelValidation(EditableModel obj)
        {
            return (ModelValidation)obj.GetValue(ModelValidationProperty);
        }

        public static void SetModelValidation(EditableModel obj, ModelValidation value)
        {
            obj.SetValue(ModelValidationProperty, value);
        }

        #endregion Attached Property Methods

        #region Methods

        public void Validate(DependencyObject d)
        {
            bool isValid = true;
            for (int i = 0; i < Validators.Count; i++)
            {
                var validator = ((ObservableCollection<PropertyValidator>)Validators)[i];

                validator.Validate(d);

                if (validator.Errors.Count > 0)
                    isValid = false;
            }

            IsValid = isValid;
        }

        public string ValidateProperty(DependencyObject d, string propertyName)
        {
            var propertyValidator =
                ((ObservableCollection<PropertyValidator>)Validators).FirstOrDefault(
                    pv => pv.Property.Name == propertyName);

            return propertyValidator?.ValidateOnce(d);
        }

        #endregion Methods
    }
}
