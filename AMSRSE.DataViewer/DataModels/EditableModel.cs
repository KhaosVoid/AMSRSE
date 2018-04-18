using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            protected set { SetValue(HasChangesPropertyKey, value); }
        }

        #endregion Properties

        #region Members

        protected Dictionary<DependencyProperty, object> _originalPropertyValues;

        #endregion Members

        #region Events

        public delegate void ModelPropertyChangedHandler(DependencyProperty p, object newValue);
        public event ModelPropertyChangedHandler ModelPropertyChanged;

        #endregion Events

        #region Ctor

        public EditableModel()
        {
            _originalPropertyValues = new Dictionary<DependencyProperty, object>();
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
            object defaultValue;

            if (typeMetadata != null)
                defaultValue = typeMetadata.DefaultValue;

            else
                defaultValue = propertyType.IsValueType ?
                    Activator.CreateInstance(propertyType) :
                    null;

            PropertyMetadata metadata = new PropertyMetadata(
                defaultValue: defaultValue,
                propertyChangedCallback: (d, e) =>
                {
                    CheckDependencyPropertyChanges(d, e);
                    typeMetadata?.PropertyChangedCallback?.Invoke(d, e);
                },
                coerceValueCallback: typeMetadata?.CoerceValueCallback);

            return DependencyProperty.Register(name, propertyType, ownerType, metadata, validateValueCallback);
        }

        protected static DependencyPropertyKey RegisterReadOnlyTracked(string name, Type propertyType, Type ownerType, PropertyMetadata typeMetadata)
        {
            return RegisterReadOnlyTracked(name, propertyType, ownerType, typeMetadata, null);
        }

        protected static DependencyPropertyKey RegisterReadOnlyTracked(string name, Type propertyType, Type ownerType, PropertyMetadata typeMetadata, ValidateValueCallback validateValueCallback)
        {
            object defaultValue;

            if (typeMetadata != null)
                defaultValue = typeMetadata.DefaultValue;

            else
                defaultValue = propertyType.IsValueType ?
                    Activator.CreateInstance(propertyType) :
                    null;

            PropertyMetadata metadata = new PropertyMetadata(
                defaultValue: defaultValue,
                propertyChangedCallback: (d, e) =>
                {
                    CheckDependencyPropertyChanges(d, e);
                    typeMetadata?.PropertyChangedCallback?.Invoke(d, e);
                },
                coerceValueCallback: typeMetadata?.CoerceValueCallback);

            return DependencyProperty.RegisterReadOnly(name, propertyType, ownerType, metadata, validateValueCallback);
        }

        //TODO: Try to find a way to call this for dependency properties that have a default value.
        //      Currently, the default value does not get added to the original values dictionary
        //      because the property changed callback never gets fired.
        private static void CheckDependencyPropertyChanges(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is EditableModel editableModel &&
                !DesignerProperties.GetIsInDesignMode(editableModel))
            {
                if (editableModel._originalPropertyValues.ContainsKey(e.Property))
                {
                    if (!editableModel.HasChanges && editableModel._originalPropertyValues[e.Property] != e.NewValue)
                        editableModel.HasChanges = true;
                }

                else
                    editableModel._originalPropertyValues.Add(e.Property, e.NewValue);

                editableModel.RaiseModelPropertyChanged(e.Property, e.NewValue);
            }
        }

        protected void RaiseModelPropertyChanged(DependencyProperty p, object newValue)
        {
            ModelPropertyChanged?.Invoke(p, newValue);
        }

        public void RevertChanges()
        {
            for (int p = 0; p < _originalPropertyValues.Count; p++)
                SetValue(_originalPropertyValues.ElementAt(p).Key, _originalPropertyValues.ElementAt(p).Value);

            OnRevertChanges();

            HasChanges = false;
        }

        protected virtual void OnRevertChanges()
        {

        }

        #endregion Methods
    }
}
