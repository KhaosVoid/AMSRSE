using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AMSRSE.DataViewer.DataModels
{
    public class ChunkModel : DependencyObject
    {
        #region Enums

        public enum DataTypes
        {
            Float32, 
            String,
            UInt32,
            UInt8Array,
            UInt8
        }

        #endregion Enums

        #region Dependency Properties

        public static readonly DependencyProperty ChunkIdProperty =
            DependencyProperty.Register("ChunkId", typeof(uint), typeof(ChunkModel));

        public static readonly DependencyProperty ChunkNameProperty =
            DependencyProperty.Register("ChunkName", typeof(string), typeof(ChunkModel));

        public static readonly DependencyProperty DataTypeProperty =
            DependencyProperty.Register("DataType", typeof(DataTypes), typeof(ChunkModel));

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(object), typeof(ChunkModel));

        #endregion Dependency Properties

        #region Properties

        public uint ChunkId
        {
            get { return (uint)GetValue(ChunkIdProperty); }
            set { SetValue(ChunkIdProperty, value); }
        }

        public string ChunkName
        {
            get { return (string)GetValue(ChunkNameProperty); }
            set { SetValue(ChunkNameProperty, value); }
        }

        public DataTypes DataType
        {
            get { return (DataTypes)GetValue(DataTypeProperty); }
            set { SetValue(DataTypeProperty, value); }
        }

        public object Value
        {
            get { return GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        #endregion Properties

        #region Ctor

        public ChunkModel()
        {

        }

        #endregion Ctor
    }
}
