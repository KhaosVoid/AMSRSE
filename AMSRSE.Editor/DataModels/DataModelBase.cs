using AMSRSE.BMSSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AMSRSE.Editor.DataModels
{
    public abstract class DataModelBase : DependencyObject
    {
        #region Dependency Properties

        public static readonly DependencyPropertyKey HasChangesPropertyKey =
            DependencyProperty.RegisterReadOnly("HasChanges", typeof(bool), typeof(DataModelBase), null);

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

        private bool _dataLoaded;

        #endregion Members

        #region Ctor

        public DataModelBase(BMSSVFile bmssvFile)
        {
            LoadData(bmssvFile);
        }

        #endregion Ctor

        #region Methods

        protected abstract void LoadData(BMSSVFile bmssvFile);

        public void SaveChanges(BMSSVFile bmssvFile)
        {
            if (HasChanges)
            {
                CommitChanges(bmssvFile);
                //bmssvFile.Save();
            }
        }

        public abstract void CommitChanges(BMSSVFile bmssvFile);

        protected static void OnDataPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DataModelBase dmb &&
                dmb._dataLoaded &&
                e.NewValue != e.OldValue &&
                !dmb.HasChanges)
                dmb.HasChanges = true;
        }

        #endregion Methods
    }
}
