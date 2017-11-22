using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveDataReaderProto.BinaryMercurySteamSave;
using System.Windows;
using SaveDataReaderProto.BinaryMercurySteamSave.Chunks;
using SaveDataReaderProto.BinaryMercurySteamSave.Enums;

namespace SaveDataReaderProto.DataModels
{
    public class ItemsCollectedByAreaDataModel : DataModelBase
    {
        #region Dependency Properties

        public static readonly DependencyProperty SurfaceItemsProperty =
            DependencyProperty.Register("SurfaceItems", typeof(uint), typeof(ItemsCollectedByAreaDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Area1ItemsProperty =
            DependencyProperty.Register("Area1Items", typeof(uint), typeof(ItemsCollectedByAreaDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Area2ItemsProperty =
            DependencyProperty.Register("Area2Items", typeof(uint), typeof(ItemsCollectedByAreaDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Area3ItemsProperty =
            DependencyProperty.Register("Area3Items", typeof(uint), typeof(ItemsCollectedByAreaDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Area4ItemsProperty =
            DependencyProperty.Register("Area4Items", typeof(uint), typeof(ItemsCollectedByAreaDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Area5ItemsProperty =
            DependencyProperty.Register("Area5Items", typeof(uint), typeof(ItemsCollectedByAreaDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Area6ItemsProperty =
            DependencyProperty.Register("Area6Items", typeof(uint), typeof(ItemsCollectedByAreaDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Area7ItemsProperty =
            DependencyProperty.Register("Area7Items", typeof(uint), typeof(ItemsCollectedByAreaDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Area8ItemsProperty =
            DependencyProperty.Register("Area8Items", typeof(uint), typeof(ItemsCollectedByAreaDataModel), new PropertyMetadata(OnDataPropertyChanged));

        #endregion Dependency Properties

        #region Properties

        public uint SurfaceItems
        {
            get { return (uint)GetValue(SurfaceItemsProperty); }
            set { SetValue(SurfaceItemsProperty, value); }
        }

        public uint Area1Items
        {
            get { return (uint)GetValue(Area1ItemsProperty); }
            set { SetValue(Area1ItemsProperty, value); }
        }

        public uint Area2Items
        {
            get { return (uint)GetValue(Area2ItemsProperty); }
            set { SetValue(Area2ItemsProperty, value); }
        }

        public uint Area3Items
        {
            get { return (uint)GetValue(Area3ItemsProperty); }
            set { SetValue(Area3ItemsProperty, value); }
        }

        public uint Area4Items
        {
            get { return (uint)GetValue(Area4ItemsProperty); }
            set { SetValue(Area4ItemsProperty, value); }
        }

        public uint Area5Items
        {
            get { return (uint)GetValue(Area5ItemsProperty); }
            set { SetValue(Area5ItemsProperty, value); }
        }

        public uint Area6Items
        {
            get { return (uint)GetValue(Area6ItemsProperty); }
            set { SetValue(Area6ItemsProperty, value); }
        }

        public uint Area7Items
        {
            get { return (uint)GetValue(Area7ItemsProperty); }
            set { SetValue(Area7ItemsProperty, value); }
        }

        public uint Area8Items
        {
            get { return (uint)GetValue(Area8ItemsProperty); }
            set { SetValue(Area8ItemsProperty, value); }
        }

        #endregion Properties

        #region Ctor

        public ItemsCollectedByAreaDataModel(BMSSVFile bmssvFile) : base(bmssvFile)
        {

        }

        #endregion Ctor

        #region Methods

        protected override void LoadData(BMSSVFile bmssvFile)
        {
            SurfaceItems = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.ItemsCollectedByArea, ChunkIDs.Surface)?.Value;
            Area1Items = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.ItemsCollectedByArea, ChunkIDs.Area1)?.Value;
            Area2Items = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.ItemsCollectedByArea, ChunkIDs.Area2)?.Value;
            Area3Items = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.ItemsCollectedByArea, ChunkIDs.Area3)?.Value;
            Area4Items = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.ItemsCollectedByArea, ChunkIDs.Area4)?.Value;
            Area5Items = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.ItemsCollectedByArea, ChunkIDs.Area5)?.Value;
            Area6Items = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.ItemsCollectedByArea, ChunkIDs.Area6)?.Value;
            Area7Items = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.ItemsCollectedByArea, ChunkIDs.Area7)?.Value;
            Area8Items = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.ItemsCollectedByArea, ChunkIDs.Area8)?.Value;
        }

        public override void CommitChanges(BMSSVFile bmssvFile)
        {
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.ItemsCollectedByArea, ChunkIDs.Surface).SetValue(SurfaceItems);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.ItemsCollectedByArea, ChunkIDs.Area1).SetValue(Area1Items);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.ItemsCollectedByArea, ChunkIDs.Area2).SetValue(Area2Items);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.ItemsCollectedByArea, ChunkIDs.Area3).SetValue(Area3Items);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.ItemsCollectedByArea, ChunkIDs.Area4).SetValue(Area4Items);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.ItemsCollectedByArea, ChunkIDs.Area5).SetValue(Area5Items);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.ItemsCollectedByArea, ChunkIDs.Area6).SetValue(Area6Items);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.ItemsCollectedByArea, ChunkIDs.Area7).SetValue(Area7Items);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.ItemsCollectedByArea, ChunkIDs.Area8).SetValue(Area8Items);
        }

        #endregion Methods
    }
}
