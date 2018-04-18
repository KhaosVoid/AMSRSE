using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AMSRSE.DataViewer.DataModels
{
    public abstract class EditableModel : DependencyObject
    {
        #region Dependency Properties

        public static readonly DependencyPropertyKey HasChangesPropertyKey =
            DependencyProperty.RegisterReadOnly("HasChanges", typeof(bool), typeof(EditableModel), null);

        public static readonly DependencyProperty HasChangesProperty =
            HasChangesPropertyKey.DependencyProperty;

        #endregion Dependency Properties

        #region Properties

        public bool HasChanges
        {
            get { return (bool)GetValue(HasChangesProperty); }
            private set { SetValue(HasChangesPropertyKey, value); }
        }

        #endregion Properties

        #region Members

        private Dictionary<string, object> _originalPropertyValues;

        #endregion Members

        #region Ctor

        public EditableModel()
        {
            _originalPropertyValues = new Dictionary<string, object>();
        }

        #endregion Ctor

        #region Methods

        protected static DependencyProperty RegisterTracked(string name, Type propertyType, Type ownerType)
        {
            return RegisterTracked(name, propertyType, ownerType, null, null);
        }

        protected static DependencyProperty RegisterTracked(string name, Type propertyType, Type ownerType, PropertyMetadata typeMetadata)
        {
            return RegisterTracked(name, propertyType, ownerType, typeMetadata, null);
        }

        protected static DependencyProperty RegisterTracked(string name, Type propertyType, Type ownerType, PropertyMetadata typeMetadata, ValidateValueCallback validateValueCallback)
        {
            PropertyMetadata metadata = new PropertyMetadata(
                defaultValue: typeMetadata?.DefaultValue,
                propertyChangedCallback: (d, e) =>
                {
                    CheckDependencyPropertyChanges(d, e);
                    typeMetadata?.PropertyChangedCallback?.Invoke(d, e);
                },
                coerceValueCallback: typeMetadata?.CoerceValueCallback);

            return DependencyProperty.Register(name, propertyType, ownerType, metadata, validateValueCallback);
        }

        //TODO: Try to find a way to call this for dependency properties that have a default value.
        //      Currently, the default value does not get added to the original values dictionary
        //      because the property changed callback never gets fired.
        private static void CheckDependencyPropertyChanges(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is EditableModel editableModel)
            {
                if (editableModel._originalPropertyValues.ContainsKey(e.Property.Name))
                {
                    if (!editableModel.HasChanges && editableModel._originalPropertyValues[e.Property.Name] != e.NewValue)
                        editableModel.HasChanges = true;
                }

                else
                    editableModel._originalPropertyValues.Add(e.Property.Name, e.NewValue);
            }
        }

        #endregion Methods
    }
}
