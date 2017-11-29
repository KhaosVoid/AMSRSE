using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMSRSE.BMSSV;
using System.Windows;
using AMSRSE.BMSSV.Chunks;
using AMSRSE.BMSSV.Enums;

namespace AMSRSE.Editor.DataModels.Common
{
    public class MiscDataDataModel : DataModelBase
    {
        #region Dependency Properties

        public static readonly DependencyProperty MissionTimeProperty =
            DependencyProperty.Register("MissionTime", typeof(TimeSpan), typeof(MiscDataDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty AmiiboFunctionalityUnlockedProperty =
            DependencyProperty.Register("AmiiboFunctionalityUnlocked", typeof(bool), typeof(MiscDataDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty EnergyReserveTankUnlockedProperty =
            DependencyProperty.Register("EnergyReserveTankUnlocked", typeof(bool), typeof(MiscDataDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty IsEnergyReserveTankFullProperty =
            DependencyProperty.Register("IsEnergyReserveTankFull", typeof(bool), typeof(MiscDataDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty AeionEnergyReserveTankUnlockedProperty =
            DependencyProperty.Register("AeionEnergyReserveTankUnlocked", typeof(bool), typeof(MiscDataDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty IsAeionEnergyReserveTankFullProperty =
            DependencyProperty.Register("IsAeionEnergyReserveTankFull", typeof(bool), typeof(MiscDataDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty MissileReserveTankUnlockedProperty =
            DependencyProperty.Register("MissileReserveTankUnlocked", typeof(bool), typeof(MiscDataDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty IsMissileReserveTankFullProperty =
            DependencyProperty.Register("IsMissileReserveTankFull", typeof(bool), typeof(MiscDataDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty SurfaceCollectedItemsCountProperty =
            DependencyProperty.Register("SurfaceCollectedItemsCount", typeof(uint), typeof(MiscDataDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Area1CollectedItemsCountProperty =
            DependencyProperty.Register("Area1CollectedItemsCount", typeof(uint), typeof(MiscDataDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Area2CollectedItemsCountProperty =
            DependencyProperty.Register("Area2CollectedItemsCount", typeof(uint), typeof(MiscDataDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Area3CollectedItemsCountProperty =
            DependencyProperty.Register("Area3CollectedItemsCount", typeof(uint), typeof(MiscDataDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Area4CollectedItemsCountProperty =
            DependencyProperty.Register("Area4CollectedItemsCount", typeof(uint), typeof(MiscDataDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Area5CollectedItemsCountProperty =
            DependencyProperty.Register("Area5CollectedItemsCount", typeof(uint), typeof(MiscDataDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Area6CollectedItemsCountProperty =
            DependencyProperty.Register("Area6CollectedItemsCount", typeof(uint), typeof(MiscDataDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Area7CollectedItemsCountProperty =
            DependencyProperty.Register("Area7CollectedItemsCount", typeof(uint), typeof(MiscDataDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Area8CollectedItemsCountProperty =
            DependencyProperty.Register("Area8CollectedItemsCount", typeof(uint), typeof(MiscDataDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty CurrentEventProperty =
            DependencyProperty.Register("CurrentEvent", typeof(string), typeof(MiscDataDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty CurrentEventLocationProperty =
            DependencyProperty.Register("CurrentEventLocation", typeof(string), typeof(MiscDataDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty MetroidsToKillInCurrentAreaProperty =
            DependencyProperty.Register("MetroidsTokillInCurrentArea", typeof(uint), typeof(MiscDataDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty SurfaceAlphaMetroidKilledProperty =
            DependencyProperty.Register("SurfaceAlphaMetroidKilled", typeof(bool), typeof(MiscDataDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Area1AlphaMetroid1KilledProperty =
            DependencyProperty.Register("Area1AlphaMetroid1Killed", typeof(bool), typeof(MiscDataDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Area1AlphaMetroid2KilledProperty =
            DependencyProperty.Register("Area1AlphaMetroid2Killed", typeof(bool), typeof(MiscDataDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Area1AlphaMetroid3KilledProperty =
            DependencyProperty.Register("Area1AlphaMetroid3Killed", typeof(bool), typeof(MiscDataDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Area1AlphaMetroid4KilledProperty =
            DependencyProperty.Register("Area1AlphaMetroid4Killed", typeof(bool), typeof(MiscDataDataModel), new PropertyMetadata(OnDataPropertyChanged));

        #endregion Dependency Properties

        #region Properties

        public TimeSpan MissionTime
        {
            get { return (TimeSpan)GetValue(MissionTimeProperty); }
            set { SetValue(MissionTimeProperty, value); }
        }

        public bool AmiiboFunctionalityUnlocked
        {
            get { return (bool)GetValue(AmiiboFunctionalityUnlockedProperty); }
            set { SetValue(AmiiboFunctionalityUnlockedProperty, value); }
        }

        public bool EnergyReserveTankUnlocked
        {
            get { return (bool)GetValue(EnergyReserveTankUnlockedProperty); }
            set { SetValue(EnergyReserveTankUnlockedProperty, value); }
        }

        public bool IsEnergyReserveTankFull
        {
            get { return (bool)GetValue(IsEnergyReserveTankFullProperty); }
            set { SetValue(IsEnergyReserveTankFullProperty, value); }
        }

        public bool AeionEnergyReserveTankUnlocked
        {
            get { return (bool)GetValue(AeionEnergyReserveTankUnlockedProperty); }
            set { SetValue(AeionEnergyReserveTankUnlockedProperty, value); }
        }

        public bool IsAeionEnergyReserveTankFull
        {
            get { return (bool)GetValue(IsAeionEnergyReserveTankFullProperty); }
            set { SetValue(IsAeionEnergyReserveTankFullProperty, value); }
        }

        public bool MissileReserveTankUnlocked
        {
            get { return (bool)GetValue(MissileReserveTankUnlockedProperty); }
            set { SetValue(MissileReserveTankUnlockedProperty, value); }
        }

        public bool IsMissileReserveTankFull
        {
            get { return (bool)GetValue(IsMissileReserveTankFullProperty); }
            set { SetValue(IsMissileReserveTankFullProperty, value); }
        }

        public uint SurfaceCollectedItemsCount
        {
            get { return (uint)GetValue(SurfaceCollectedItemsCountProperty); }
            set { SetValue(SurfaceCollectedItemsCountProperty, value); }
        }

        public uint Area1CollectedItemsCount
        {
            get { return (uint)GetValue(Area1CollectedItemsCountProperty); }
            set { SetValue(Area1CollectedItemsCountProperty, value); }
        }

        public uint Area2CollectedItemsCount
        {
            get { return (uint)GetValue(Area2CollectedItemsCountProperty); }
            set { SetValue(Area2CollectedItemsCountProperty, value); }
        }

        public uint Area3CollectedItemsCount
        {
            get { return (uint)GetValue(Area3CollectedItemsCountProperty); }
            set { SetValue(Area3CollectedItemsCountProperty, value); }
        }

        public uint Area4CollectedItemsCount
        {
            get { return (uint)GetValue(Area4CollectedItemsCountProperty); }
            set { SetValue(Area4CollectedItemsCountProperty, value); }
        }

        public uint Area5CollectedItemsCount
        {
            get { return (uint)GetValue(Area5CollectedItemsCountProperty); }
            set { SetValue(Area5CollectedItemsCountProperty, value); }
        }

        public uint Area6CollectedItemsCount
        {
            get { return (uint)GetValue(Area6CollectedItemsCountProperty); }
            set { SetValue(Area6CollectedItemsCountProperty, value); }
        }

        public uint Area7CollectedItemsCount
        {
            get { return (uint)GetValue(Area7CollectedItemsCountProperty); }
            set { SetValue(Area7CollectedItemsCountProperty, value); }
        }

        public uint Area8CollectedItemsCount
        {
            get { return (uint)GetValue(Area8CollectedItemsCountProperty); }
            set { SetValue(Area8CollectedItemsCountProperty, value); }
        }

        public string CurrentEvent
        {
            get { return (string)GetValue(CurrentEventProperty); }
            set { SetValue(CurrentEventProperty, value); }
        }

        public string CurrentEventLocation
        {
            get { return (string)GetValue(CurrentEventLocationProperty); }
            set { SetValue(CurrentEventLocationProperty, value); }
        }

        public uint MetroidsToKillInCurrentArea
        {
            get { return (uint)GetValue(MetroidsToKillInCurrentAreaProperty); }
            set { SetValue(MetroidsToKillInCurrentAreaProperty, value); }
        }

        public bool SurfaceAlphaMetroidKilled
        {
            get { return (bool)GetValue(SurfaceAlphaMetroidKilledProperty); }
            set { SetValue(SurfaceAlphaMetroidKilledProperty, value); }
        }

        public bool Area1AlphaMetroid1Killed
        {
            get { return (bool)GetValue(Area1AlphaMetroid1KilledProperty); }
            set { SetValue(Area1AlphaMetroid1KilledProperty, value); }
        }

        public bool Area1AlphaMetroid2Killed
        {
            get { return (bool)GetValue(Area1AlphaMetroid2KilledProperty); }
            set { SetValue(Area1AlphaMetroid2KilledProperty, value); }
        }

        public bool Area1AlphaMetroid3Killed
        {
            get { return (bool)GetValue(Area1AlphaMetroid3KilledProperty); }
            set { SetValue(Area1AlphaMetroid3KilledProperty, value); }
        }

        public bool Area1AlphaMetroid4Killed
        {
            get { return (bool)GetValue(Area1AlphaMetroid4KilledProperty); }
            set { SetValue(Area1AlphaMetroid4KilledProperty, value); }
        }

        #endregion Properties

        #region Ctor

        public MiscDataDataModel(BMSSVFile bmssvFile) : base(bmssvFile)
        {

        }

        #endregion Ctor

        #region Methods

        protected override void LoadData(BMSSVFile bmssvFile)
        {
            MissionTime = TimeSpan.FromSeconds((float)bmssvFile.GetChunk<Float32Chunk>(BlockIDs.MiscData, ChunkIDs.MissionTime)?.Value);
            AmiiboFunctionalityUnlocked = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.MiscData, ChunkIDs.AmiiboFunctionalityUnlocked)?.Value);
            EnergyReserveTankUnlocked = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.MiscData, ChunkIDs.EnergyReserveTankUnlocked)?.Value);
            IsEnergyReserveTankFull = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.MiscData, ChunkIDs.IsEnergyReserveTankFull)?.Value);
            AeionEnergyReserveTankUnlocked = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.MiscData, ChunkIDs.AeionEnergyReserveTankUnlocked)?.Value);
            IsAeionEnergyReserveTankFull = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.MiscData, ChunkIDs.IsAeionEnergyReserveTankFull)?.Value);
            MissileReserveTankUnlocked = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.MiscData, ChunkIDs.MissileReserveTankUnlocked)?.Value);
            IsMissileReserveTankFull = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.MiscData, ChunkIDs.IsMissileReserveTankFull)?.Value);
            SurfaceCollectedItemsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.SurfaceCollectedItemsCount)?.Value;
            Area1CollectedItemsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area1CollectedItemsCount)?.Value;
            Area2CollectedItemsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area2CollectedItemsCount)?.Value;
            Area3CollectedItemsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area3CollectedItemsCount)?.Value;
            Area4CollectedItemsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area4CollectedItemsCount)?.Value;
            Area5CollectedItemsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area5CollectedItemsCount)?.Value;
            Area6CollectedItemsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area6CollectedItemsCount)?.Value;
            Area7CollectedItemsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area7CollectedItemsCount)?.Value;
            Area8CollectedItemsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area8CollectedItemsCount)?.Value;
            CurrentEvent = Convert.ToString(bmssvFile.GetChunk<StringChunk>(BlockIDs.MiscData, ChunkIDs.CurrentEvent)?.Value);
            CurrentEventLocation = Convert.ToString(bmssvFile.GetChunk<StringChunk>(BlockIDs.MiscData, ChunkIDs.CurrentEventLocation)?.Value);
            MetroidsToKillInCurrentArea = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.MetroidsToKillInCurrentArea)?.Value;
            SurfaceAlphaMetroidKilled = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.MiscData, ChunkIDs.SurfaceAlphaMetroidKilled)?.Value);
            Area1AlphaMetroid1Killed = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.MiscData, ChunkIDs.Area1AlphaMetroid1Killed)?.Value);
            Area1AlphaMetroid2Killed = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.MiscData, ChunkIDs.Area1AlphaMetroid2Killed)?.Value);
            Area1AlphaMetroid3Killed = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.MiscData, ChunkIDs.Area1AlphaMetroid3Killed)?.Value);
            Area1AlphaMetroid4Killed = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.MiscData, ChunkIDs.Area1AlphaMetroid4Killed)?.Value);
        }

        public override void CommitChanges(BMSSVFile bmssvFile)
        {
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.MiscData, ChunkIDs.MissionTime).SetValue((float)MissionTime.TotalSeconds);
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.MiscData, ChunkIDs.AmiiboFunctionalityUnlocked).SetValue(Convert.ToByte(AmiiboFunctionalityUnlocked));
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.MiscData, ChunkIDs.EnergyReserveTankUnlocked).SetValue(Convert.ToByte(EnergyReserveTankUnlocked));
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.MiscData, ChunkIDs.IsEnergyReserveTankFull).SetValue(Convert.ToByte(IsEnergyReserveTankFull));
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.MiscData, ChunkIDs.AeionEnergyReserveTankUnlocked).SetValue(Convert.ToByte(AeionEnergyReserveTankUnlocked));
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.MiscData, ChunkIDs.IsAeionEnergyReserveTankFull).SetValue(Convert.ToByte(IsAeionEnergyReserveTankFull));
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.MiscData, ChunkIDs.MissileReserveTankUnlocked).SetValue(Convert.ToByte(MissileReserveTankUnlocked));
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.MiscData, ChunkIDs.IsMissileReserveTankFull).SetValue(Convert.ToByte(IsMissileReserveTankFull));
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.SurfaceCollectedItemsCount).SetValue(SurfaceCollectedItemsCount);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area1CollectedItemsCount).SetValue(Area1CollectedItemsCount);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area2CollectedItemsCount).SetValue(Area2CollectedItemsCount);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area3CollectedItemsCount).SetValue(Area3CollectedItemsCount);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area4CollectedItemsCount).SetValue(Area4CollectedItemsCount);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area5CollectedItemsCount).SetValue(Area5CollectedItemsCount);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area6CollectedItemsCount).SetValue(Area6CollectedItemsCount);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area7CollectedItemsCount).SetValue(Area7CollectedItemsCount);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area8CollectedItemsCount).SetValue(Area8CollectedItemsCount);
            bmssvFile.GetChunk<StringChunk>(BlockIDs.MiscData, ChunkIDs.CurrentEvent).SetValue(CurrentEvent);
            bmssvFile.GetChunk<StringChunk>(BlockIDs.MiscData, ChunkIDs.CurrentEventLocation).SetValue(CurrentEventLocation);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.MetroidsToKillInCurrentArea).SetValue(MetroidsToKillInCurrentArea);
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.MiscData, ChunkIDs.SurfaceAlphaMetroidKilled).SetValue(Convert.ToByte(SurfaceAlphaMetroidKilled));
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.MiscData, ChunkIDs.Area1AlphaMetroid1Killed).SetValue(Convert.ToByte(Area1AlphaMetroid1Killed));
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.MiscData, ChunkIDs.Area1AlphaMetroid2Killed).SetValue(Convert.ToByte(Area1AlphaMetroid2Killed));
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.MiscData, ChunkIDs.Area1AlphaMetroid3Killed).SetValue(Convert.ToByte(Area1AlphaMetroid3Killed));
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.MiscData, ChunkIDs.Area1AlphaMetroid4Killed).SetValue(Convert.ToByte(Area1AlphaMetroid4Killed));
        }

        #endregion Methods
    }
}
