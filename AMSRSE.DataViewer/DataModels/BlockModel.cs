using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AMSRSE.DataViewer.DataModels
{
    public class BlockModel : EditableModel
    {
        #region Enums

        public enum ChangeTypes
        {
            None, Added, Removed
        }

        #endregion Enums

        #region Dependency Properties

        public static readonly DependencyProperty BlockIdProperty =
            RegisterTracked("BlockId", typeof(uint), typeof(BlockModel));

        public static readonly DependencyProperty BlockNameProperty =
            RegisterTracked("BlockName", typeof(string), typeof(BlockModel));

        public static readonly DependencyProperty ChunksProperty =
            RegisterTracked("Chunks", typeof(IList), typeof(BlockModel), new PropertyMetadata(ChunksPropertyChangedCallback));

        public static readonly DependencyProperty ChangeTypeProperty =
            DependencyProperty.Register("ChangeType", typeof(ChangeTypes), typeof(BlockModel));

        public static readonly DependencyProperty ChunksChangedProperty =
            DependencyProperty.Register("ChunksChanged", typeof(bool), typeof(BlockModel));

        #endregion Dependency Properties

        #region Properties

        public uint BlockId
        {
            get { return (uint)GetValue(BlockIdProperty); }
            set { SetValue(BlockIdProperty, value); }
        }

        public string BlockName
        {
            get { return (string)GetValue(BlockNameProperty); }
            set { SetValue(BlockNameProperty, value); }
        }

        public IList Chunks
        {
            get { return (IList)GetValue(ChunksProperty); }
            set { SetValue(ChunksProperty, value); }
        }

        public ChangeTypes ChangeType
        {
            get { return (ChangeTypes)GetValue(ChangeTypeProperty); }
            set { SetValue(ChangeTypeProperty, value); }
        }

        public bool ChunksChanged
        {
            get { return (bool)GetValue(ChunksChangedProperty); }
            set { SetValue(ChunksChangedProperty, value); }
        }

        #endregion Properties

        #region Ctor

        public BlockModel()
        {
            Chunks = new ObservableCollection<ChunkModel>();

            if (!DesignerProperties.GetIsInDesignMode(this))
                ((ObservableCollection<ChunkModel>)Chunks).CollectionChanged += Chunks_CollectionChanged;
        }

        public BlockModel(ObservableCollection<ChunkModel> chunks)
        {
            Chunks = chunks;

            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                ((ObservableCollection<ChunkModel>)Chunks).CollectionChanged += Chunks_CollectionChanged;

                for (int c = 0; c < Chunks.Count; c++)
                    ((ObservableCollection<ChunkModel>)Chunks)[c].ModelPropertyChanged += ChunkModel_PropertyChanged;
            }
        }

        private void Chunks_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var chunks = Chunks as ObservableCollection<ChunkModel>;
            var originalChunks = _originalPropertyValues[ChunksProperty] as ObservableCollection<ChunkModel>;

            if (e.Action == NotifyCollectionChangedAction.Add ||
                e.Action == NotifyCollectionChangedAction.Replace)
            {
                for (int i = 0; i < e.NewItems.Count; i++)
                {
                    ((ChunkModel)e.NewItems[i]).ModelPropertyChanged -= ChunkModel_PropertyChanged;
                    ((ChunkModel)e.NewItems[i]).ModelPropertyChanged += ChunkModel_PropertyChanged;
                }
            }

            if (e.Action == NotifyCollectionChangedAction.Remove ||
                e.Action == NotifyCollectionChangedAction.Replace ||
                e.Action == NotifyCollectionChangedAction.Reset)
            {
                for (int i = 0; i < e.OldItems.Count; i++)
                    ((ChunkModel)e.OldItems[i]).ModelPropertyChanged -= ChunkModel_PropertyChanged;
            }

            if (chunks.Count != originalChunks.Count ||
                chunks.Where(c => c.HasChanges).Count() > 0)
                HasChanges = true;
        }

        private void ChunkModel_PropertyChanged(DependencyProperty p, object newValue)
        {
            HasChanges = true;
            RaiseModelPropertyChanged(p, newValue);
        }

        protected override void OnRevertChanges()
        {
            ((ObservableCollection<ChunkModel>)Chunks).CollectionChanged += Chunks_CollectionChanged;
        }

        #endregion Ctor

        #region Dependency Property Callbacks

        private static void ChunksPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is BlockModel blockModel &&
                !DesignerProperties.GetIsInDesignMode(blockModel))
            {
                var chunks = blockModel.Chunks as ObservableCollection<ChunkModel>;
                chunks.CollectionChanged -= blockModel.Chunks_CollectionChanged;
                chunks.CollectionChanged += blockModel.Chunks_CollectionChanged;
            }
        }

        #endregion Dependency Property Callbacks
    }
}
