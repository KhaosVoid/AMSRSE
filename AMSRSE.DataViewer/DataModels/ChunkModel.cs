﻿using Magatama.Core.DataModels;
using Magatama.Core.DataModels.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AMSRSE.DataViewer.DataModels
{
    [IdProperty("ChunkId")]
    public class ChunkModel : EditableModel
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
            RegisterTracked("ChunkId", typeof(uint), typeof(ChunkModel));

        public static readonly DependencyProperty ChunkNameProperty =
            RegisterTracked("ChunkName", typeof(string), typeof(ChunkModel));

        public static readonly DependencyProperty DataTypeProperty =
            RegisterTracked("DataType", typeof(DataTypes), typeof(ChunkModel));

        public static readonly DependencyProperty ValueProperty =
            RegisterTracked("Value", typeof(object), typeof(ChunkModel));

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
