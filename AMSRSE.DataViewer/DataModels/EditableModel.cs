using AMSRSE.DataViewer.DataModels.Validation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AMSRSE.DataViewer.DataModels
{
    public abstract class EditableModel : DependencyObject, IDataErrorInfo, ISupportInitialize
    {
        #region Dependency Properties

        public static readonly DependencyPropertyKey HasChangesPropertyKey =
            DependencyProperty.RegisterReadOnly("HasChanges", typeof(bool), typeof(EditableModel), null);

        public static readonly DependencyProperty HasChangesProperty =
            HasChangesPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey IsValidPropertyKey =
            DependencyProperty.RegisterReadOnly("IsValid", typeof(bool), typeof(EditableModel), null);

        public static readonly DependencyProperty IsValidProperty =
            IsValidPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey ValidationErrorsPropertyKey =
            DependencyProperty.RegisterReadOnly("ValidationErrors", typeof(IDictionary), typeof(EditableModel), null);

        public static readonly DependencyProperty ValidationErrorsProperty =
            ValidationErrorsPropertyKey.DependencyProperty;

        #endregion Dependency Properties

        #region Properties

        public bool HasChanges
        {
            get { return (bool)GetValue(HasChangesProperty); }
            protected set { SetValue(HasChangesPropertyKey, value); }
        }

        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            private set { SetValue(IsValidPropertyKey, value); }
        }

        public IDictionary ValidationErrors
        {
            get { return (IDictionary)GetValue(ValidationErrorsProperty); }
            private set { SetValue(ValidationErrorsPropertyKey, value); }
        }

        #endregion Properties

        #region Members

        private static List<DependencyProperty> _trackedProperties;
        protected Dictionary<DependencyProperty, object> _originalPropertyValues;
        private bool _canTrack;

        #endregion Members

        #region Events

        public delegate void ModelPropertyChangedHandler(DependencyProperty p, object newValue);
        public event ModelPropertyChangedHandler ModelPropertyChanged;

        #endregion Events

        #region Ctor

        static EditableModel()
        {
            _trackedProperties = new List<DependencyProperty>();
        }

        public EditableModel()
        {
            ValidationErrors = new Dictionary<string, string>();
            _originalPropertyValues = new Dictionary<DependencyProperty, object>();
        }

        #endregion Ctor

        #region IDataErrorInfo

        string IDataErrorInfo.Error
        {
            get { return null; }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {

                string error = string.Empty;
                var dpDescriptor = DependencyPropertyDescriptor.FromName(propertyName, this.GetType(), this.GetType());

                if (dpDescriptor != null)
                {
                    var results = new List<ValidationResult>(1);

                    var result = Validator.TryValidateProperty(
                        value: this.GetValue(dpDescriptor.DependencyProperty),
                        validationContext: new ValidationContext(this)
                        {
                            MemberName = propertyName
                        },
                        validationResults: results);

                    if (!result)
                    {
                        var validationResult = results.First();
                        error = validationResult.ErrorMessage;

                        if (ValidationErrors.Contains(propertyName))
                            ValidationErrors[propertyName] = error;

                        else
                            ValidationErrors.Add(propertyName, error);
                    }

                    else
                    {
                        if (ValidationErrors.Contains(propertyName))
                            ValidationErrors.Remove(propertyName);
                    }
                }

                IsValid = ValidationErrors.Count > 0 ? false : true;
                return error;
            }
        }

        #endregion IDataErrorInfo

        #region ISupportInitialize

        public void BeginInit()
        {
            _originalPropertyValues = new Dictionary<DependencyProperty, object>();
            _canTrack = false;
        }

        public void EndInit()
        {
            for (int p = 0; p < _trackedProperties.Count; p++)
            {
                var value = GetValue(_trackedProperties[p]);

                if (value is INotifyCollectionChanged observableCollection)
                {
                    observableCollection.CollectionChanged -= Collection_CollectionChanged;
                    observableCollection.CollectionChanged += Collection_CollectionChanged;

                    if (value is IEnumerable<EditableModel> collection)
                    {
                        for (int m = 0; m < collection.Count(); m++)
                        {
                            collection.ElementAt(m).ModelPropertyChanged -= EditableModel_ModelPropertyChanged;
                            collection.ElementAt(m).ModelPropertyChanged += EditableModel_ModelPropertyChanged;
                        }
                    }
                }

                _originalPropertyValues.Add(_trackedProperties[p], DeepCopyPropertyValue(value));
            }

            _canTrack = true;
        }

        private void EditableModel_ModelPropertyChanged(DependencyProperty property, object newValue)
        {
            CheckChanges();
        }

        private void Collection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            CheckChanges();
        }

        #endregion ISupportInitialize

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

            DependencyProperty dp = DependencyProperty.Register(name, propertyType, ownerType, metadata, validateValueCallback);
            _trackedProperties.Add(dp);

            return dp;
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

            DependencyPropertyKey dpk = DependencyProperty.RegisterReadOnly(name, propertyType, ownerType, metadata, validateValueCallback);
            _trackedProperties.Add(dpk.DependencyProperty);

            return dpk;
        }

        private static void CheckDependencyPropertyChanges(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is EditableModel editableModel &&
                !DesignerProperties.GetIsInDesignMode(editableModel) &&
                editableModel._canTrack)
            {
                editableModel.CheckChanges();

                //if (editableModel._originalPropertyValues.Where(i => i.Value != editableModel.GetValue(i.Key)).Count() > 0)
                //    editableModel.HasChanges = true;

                //else
                //    editableModel.HasChanges = false;

                editableModel.RaiseModelPropertyChanged(e.Property, e.NewValue);
            }
        }

        protected void RaiseModelPropertyChanged(DependencyProperty p, object newValue)
        {
            ModelPropertyChanged?.Invoke(p, newValue);
        }

        private void CheckChanges()
        {
            if (_canTrack)
            {
                bool hasChanges = false;

                if (_originalPropertyValues.Where(i => i.Value != GetValue(i.Key)).Count() > 0)
                    hasChanges = true;

                else
                {
                    var observableCollections = _originalPropertyValues.Where(i => i.Value is INotifyCollectionChanged).ToDictionary(k => k.Key, v => v.Value);

                    for (int c = 0; c < observableCollections.Count(); c++)
                    {
                        var originalCollection = (IList)observableCollections.ElementAt(c).Value;
                        var collection = (IList)GetValue(observableCollections.ElementAt(c).Key);

                        if (originalCollection.Count != collection.Count)
                        {
                            hasChanges = true;
                            break;
                        }

                        for (int i = 0; i < collection.Count; i++)
                        {
                            if (collection[i] is EditableModel editableModel && editableModel.HasChanges)
                            {
                                hasChanges = true;
                                break;
                            }

                            if (collection[i] != originalCollection[i])
                            {
                                hasChanges = true;
                                break;
                            }
                        }
                    }
                }

                HasChanges = hasChanges;
            }
        }

        public void RevertChanges()
        {
            _canTrack = false;

            for (int p = 0; p < _originalPropertyValues.Count; p++)
            {
                var value = DeepCopyPropertyValue(_originalPropertyValues.ElementAt(p).Value);

                if (value is INotifyCollectionChanged observableCollection)
                {
                    observableCollection.CollectionChanged -= Collection_CollectionChanged;
                    observableCollection.CollectionChanged += Collection_CollectionChanged;

                    if (value is IEnumerable<EditableModel> collection)
                    {
                        for (int m = 0; m < collection.Count(); m++)
                        {
                            collection.ElementAt(m).ModelPropertyChanged -= EditableModel_ModelPropertyChanged;
                            collection.ElementAt(m).ModelPropertyChanged += EditableModel_ModelPropertyChanged;
                        }
                    }
                }

                SetValue(_originalPropertyValues.ElementAt(p).Key, value);
            }

            OnRevertChanges();

            HasChanges = false;

            _canTrack = true;
        }

        protected virtual void OnRevertChanges()
        {

        }

        private EditableModel DeepCopy()
        {
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Position = 0;

                return formatter.Deserialize(stream) as EditableModel;
            }
        }

        private object DeepCopyPropertyValue(object objSource)
        {
            if (objSource == null)
                return null;

            Type typeSource = objSource.GetType();

            if (typeSource.IsValueType ||
                typeSource.IsEnum ||
                typeSource.Equals(typeof(String)))
            {
                return objSource;
            }

            //if (objSource is EditableModel editableModel)
            //    return editableModel.DeepCopy();

            object objTarget = Activator.CreateInstance(typeSource);

            PropertyInfo[] propertyInfo = typeSource.GetProperties(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (PropertyInfo property in propertyInfo)
            {
                if(property.CanWrite)
                {
                    if (property.PropertyType.IsValueType ||
                        property.PropertyType.IsEnum ||
                        property.PropertyType.Equals(typeof(String)))
                    {
                        property.SetValue(objTarget, property.GetValue(objSource, null), null);
                    }

                    else
                    {
                        if (objSource is IList objSourceList)
                        {
                            for (int i = 0; i < objSourceList.Count; i++)
                                ((IList)objTarget).Add(DeepCopyPropertyValue(objSourceList[i]));
                        }

                        else
                        {
                            object objPropertyValue = property.GetValue(objSource);

                            if (objPropertyValue == null)
                                property.SetValue(objTarget, null, null);

                            else
                                property.SetValue(objTarget, DeepCopyPropertyValue(objPropertyValue), null);
                        }
                    }
                }
            }

            if (objTarget is EditableModel editableModel)
            {
                editableModel._canTrack = true;
                editableModel.EndInit();
            }

            return objTarget;
        }

        #endregion Methods
    }
}
