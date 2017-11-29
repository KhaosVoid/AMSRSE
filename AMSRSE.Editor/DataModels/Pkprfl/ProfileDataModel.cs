using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMSRSE.BMSSV;
using System.Windows;
using AMSRSE.BMSSV.Chunks;
using AMSRSE.BMSSV.Enums;

namespace AMSRSE.Editor.DataModels.Pkprfl
{
    public class ProfileDataModel : DataModelBase
    {
        #region Enums

        public enum GameDifficulties : uint
        {
            Easy   = 0x00000000,
            Hard   = 0x01000000,
            Fusion = 0x02000000
        }

        #endregion Enums

        #region Dependency Properties

        public static readonly DependencyPropertyKey MaxEnergyPropertyKey =
            DependencyProperty.RegisterReadOnly("MaxEnergy", typeof(uint), typeof(ProfileDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty MaxEnergyProperty =
            MaxEnergyPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey CurrentEnergyPropertyKey =
            DependencyProperty.RegisterReadOnly("CurrentEnergy", typeof(uint), typeof(ProfileDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty CurrentEnergyProperty =
            CurrentEnergyPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey EnergyReserveTankUnlockedPropertyKey =
            DependencyProperty.RegisterReadOnly("EnergyReserveTankUnlocked", typeof(bool), typeof(ProfileDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty EnergyReserveTankUnlockedProperty =
            EnergyReserveTankUnlockedPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey IsEnergyReserveTankFullPropertyKey =
            DependencyProperty.RegisterReadOnly("IsEnergyReserveTankFull", typeof(bool), typeof(ProfileDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty IsEnergyReserveTankFullProperty =
            IsEnergyReserveTankFullPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey AeionEnergyReserveTankUnlockedPropertyKey =
            DependencyProperty.RegisterReadOnly("AeionEnergyReserveTankUnlocked", typeof(bool), typeof(ProfileDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty AeionEnergyReserveTankUnlockedProperty =
            AeionEnergyReserveTankUnlockedPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey IsAeionEnergyReserveTankFullPropertyKey =
            DependencyProperty.RegisterReadOnly("IsAeionEnergyReserveTankFull", typeof(bool), typeof(ProfileDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty IsAeionEnergyReserveTankFullProperty =
            IsAeionEnergyReserveTankFullPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey MissileReserveTankUnlockedPropertyKey =
            DependencyProperty.RegisterReadOnly("MissileReserveTankUnlocked", typeof(bool), typeof(ProfileDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty MissileReserveTankUnlockedProperty =
            MissileReserveTankUnlockedPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey IsMissileReserveTankFullPropertyKey =
            DependencyProperty.RegisterReadOnly("IsMissileReserveTankFull", typeof(bool), typeof(ProfileDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty IsMissileReserveTankFullProperty =
            IsMissileReserveTankFullPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey MetroidsKilledPropertyKey =
            DependencyProperty.RegisterReadOnly("MetroidsKilled", typeof(uint), typeof(ProfileDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty MetroidsKilledProperty =
            MetroidsKilledPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey GameDifficultyPropertyKey =
            DependencyProperty.RegisterReadOnly("GameDifficulty", typeof(GameDifficulties), typeof(ProfileDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty GameDifficultyProperty =
            GameDifficultyPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey SurfaceCollectedItemsCountPropertyKey =
            DependencyProperty.RegisterReadOnly("SurfaceCollectedItemsCount", typeof(uint), typeof(ProfileDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty SurfaceCollectedItemsCountProperty =
            SurfaceCollectedItemsCountPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey Area1CollectedItemsCountPropertyKey =
            DependencyProperty.RegisterReadOnly("Area1CollectedItemsCount", typeof(uint), typeof(ProfileDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Area1CollectedItemsCountProperty =
            Area1CollectedItemsCountPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey Area2CollectedItemsCountPropertyKey =
            DependencyProperty.RegisterReadOnly("Area2CollectedItemsCount", typeof(uint), typeof(ProfileDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Area2CollectedItemsCountProperty =
            Area2CollectedItemsCountPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey Area3CollectedItemsCountPropertyKey =
            DependencyProperty.RegisterReadOnly("Area3CollectedItemsCount", typeof(uint), typeof(ProfileDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Area3CollectedItemsCountProperty =
            Area3CollectedItemsCountPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey Area4CollectedItemsCountPropertyKey =
            DependencyProperty.RegisterReadOnly("Area4CollectedItemsCount", typeof(uint), typeof(ProfileDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Area4CollectedItemsCountProperty =
            Area4CollectedItemsCountPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey Area5CollectedItemsCountPropertyKey =
            DependencyProperty.RegisterReadOnly("Area5CollectedItemsCount", typeof(uint), typeof(ProfileDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Area5CollectedItemsCountProperty =
            Area5CollectedItemsCountPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey Area6CollectedItemsCountPropertyKey =
            DependencyProperty.RegisterReadOnly("Area6CollectedItemsCount", typeof(uint), typeof(ProfileDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Area6CollectedItemsCountProperty =
            Area6CollectedItemsCountPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey Area7CollectedItemsCountPropertyKey =
            DependencyProperty.RegisterReadOnly("Area7CollectedItemsCount", typeof(uint), typeof(ProfileDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Area7CollectedItemsCountProperty =
            Area7CollectedItemsCountPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey Area8CollectedItemsCountPropertyKey =
            DependencyProperty.RegisterReadOnly("Area8CollectedItemsCount", typeof(uint), typeof(ProfileDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Area8CollectedItemsCountProperty =
            Area8CollectedItemsCountPropertyKey.DependencyProperty;

        public static readonly DependencyPropertyKey MissionTimePropertyKey =
            DependencyProperty.RegisterReadOnly("MissionTime", typeof(TimeSpan), typeof(ProfileDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty MissionTimeProperty =
            MissionTimePropertyKey.DependencyProperty;

        #endregion Dependency Properties

        #region Properties

        public uint MaxEnergy
        {
            get { return (uint)GetValue(MaxEnergyProperty); }
            private set { SetValue(MaxEnergyPropertyKey, value); }
        }

        public uint CurrentEnergy
        {
            get { return (uint)GetValue(CurrentEnergyProperty); }
            private set { SetValue(CurrentEnergyPropertyKey, value); }
        }

        public bool EnergyReserveTankUnlocked
        {
            get { return (bool)GetValue(EnergyReserveTankUnlockedProperty); }
            private set { SetValue(EnergyReserveTankUnlockedPropertyKey, value); }
        }

        public bool IsEnergyReserveTankFull
        {
            get { return (bool)GetValue(IsEnergyReserveTankFullProperty); }
            private set { SetValue(IsEnergyReserveTankFullPropertyKey, value); }
        }

        public bool AeionEnergyReserveTankUnlocked
        {
            get { return (bool)GetValue(AeionEnergyReserveTankUnlockedProperty); }
            private set { SetValue(AeionEnergyReserveTankUnlockedPropertyKey, value); }
        }

        public bool IsAeionEnergyReserveTankFull
        {
            get { return (bool)GetValue(IsAeionEnergyReserveTankFullProperty); }
            private set { SetValue(IsAeionEnergyReserveTankFullPropertyKey, value); }
        }

        public bool MissileReserveTankUnlocked
        {
            get { return (bool)GetValue(MissileReserveTankUnlockedProperty); }
            private set { SetValue(MissileReserveTankUnlockedPropertyKey, value); }
        }

        public bool IsMissileReserveTankFull
        {
            get { return (bool)GetValue(IsMissileReserveTankFullProperty); }
            private set { SetValue(IsMissileReserveTankFullPropertyKey, value); }
        }

        public uint MetroidsKilled
        {
            get { return (uint)GetValue(MetroidsKilledProperty); }
            private set { SetValue(MetroidsKilledPropertyKey, value); }
        }

        public GameDifficulties GameDifficulty
        {
            get { return (GameDifficulties)GetValue(GameDifficultyProperty); }
            private set { SetValue(GameDifficultyPropertyKey, value); }
        }

        public uint SurfaceCollectedItemsCount
        {
            get { return (uint)GetValue(SurfaceCollectedItemsCountProperty); }
            private set { SetValue(SurfaceCollectedItemsCountPropertyKey, value); }
        }

        public uint Area1CollectedItemsCount
        {
            get { return (uint)GetValue(Area1CollectedItemsCountProperty); }
            private set { SetValue(Area1CollectedItemsCountPropertyKey, value); }
        }

        public uint Area2CollectedItemsCount
        {
            get { return (uint)GetValue(Area2CollectedItemsCountProperty); }
            private set { SetValue(Area2CollectedItemsCountPropertyKey, value); }
        }

        public uint Area3CollectedItemsCount
        {
            get { return (uint)GetValue(Area3CollectedItemsCountProperty); }
            private set { SetValue(Area3CollectedItemsCountPropertyKey, value); }
        }

        public uint Area4CollectedItemsCount
        {
            get { return (uint)GetValue(Area4CollectedItemsCountProperty); }
            private set { SetValue(Area4CollectedItemsCountPropertyKey, value); }
        }

        public uint Area5CollectedItemsCount
        {
            get { return (uint)GetValue(Area5CollectedItemsCountProperty); }
            private set { SetValue(Area5CollectedItemsCountPropertyKey, value); }
        }

        public uint Area6CollectedItemsCount
        {
            get { return (uint)GetValue(Area6CollectedItemsCountProperty); }
            private set { SetValue(Area6CollectedItemsCountPropertyKey, value); }
        }

        public uint Area7CollectedItemsCount
        {
            get { return (uint)GetValue(Area7CollectedItemsCountProperty); }
            private set { SetValue(Area7CollectedItemsCountPropertyKey, value); }
        }

        public uint Area8CollectedItemsCount
        {
            get { return (uint)GetValue(Area8CollectedItemsCountProperty); }
            private set { SetValue(Area8CollectedItemsCountPropertyKey, value); }
        }

        public TimeSpan MissionTime
        {
            get { return (TimeSpan)GetValue(MissionTimeProperty); }
            private set { SetValue(MissionTimePropertyKey, value); }
        }

        #endregion Properties

        #region Ctor

        public ProfileDataModel(BMSSVFile bmssvFile) : base(bmssvFile)
        {

        }

        #endregion Ctor

        #region Methods

        protected override void LoadData(BMSSVFile bmssvFile)
        {
            MaxEnergy = (uint)bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.MaxEnergy)?.Value;
            CurrentEnergy = (uint)bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.CurrentEnergy)?.Value;
            EnergyReserveTankUnlocked = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.EnergyReserveTankUnlocked)?.Value);
            IsEnergyReserveTankFull = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.IsEnergyReserveTankFull)?.Value);
            AeionEnergyReserveTankUnlocked = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.AeionEnergyReserveTankUnlocked)?.Value);
            IsAeionEnergyReserveTankFull = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.IsAeionEnergyReserveTankFull)?.Value);
            MissileReserveTankUnlocked = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.MissileReserveTankUnlocked)?.Value);
            IsMissileReserveTankFull = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.IsMissileReserveTankFull)?.Value);
            MetroidsKilled = (uint)bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.MetroidsKilled)?.Value;
            GameDifficulty = (GameDifficulties)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.GameDifficulty)?.Value;
            SurfaceCollectedItemsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.SurfaceCollectedItemsCount)?.Value;
            Area1CollectedItemsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area1CollectedItemsCount)?.Value;
            Area2CollectedItemsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area2CollectedItemsCount)?.Value;
            Area3CollectedItemsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area3CollectedItemsCount)?.Value;
            Area4CollectedItemsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area4CollectedItemsCount)?.Value;
            Area5CollectedItemsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area5CollectedItemsCount)?.Value;
            Area6CollectedItemsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area6CollectedItemsCount)?.Value;
            Area7CollectedItemsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area7CollectedItemsCount)?.Value;
            Area8CollectedItemsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area8CollectedItemsCount)?.Value;
            MissionTime = TimeSpan.FromSeconds((float)bmssvFile.GetChunk<Float32Chunk>(BlockIDs.MiscData, ChunkIDs.MissionTime)?.Value);
        }

        public override void CommitChanges(BMSSVFile bmssvFile)
        {
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.MaxEnergy).SetValue(MaxEnergy);
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.CurrentEnergy).SetValue(CurrentEnergy);
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.EnergyReserveTankUnlocked).SetValue(Convert.ToByte(EnergyReserveTankUnlocked));
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.IsEnergyReserveTankFull).SetValue(Convert.ToByte(IsEnergyReserveTankFull));
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.AeionEnergyReserveTankUnlocked).SetValue(Convert.ToByte(AeionEnergyReserveTankUnlocked));
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.IsAeionEnergyReserveTankFull).SetValue(Convert.ToByte(IsAeionEnergyReserveTankFull));
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.MissileReserveTankUnlocked).SetValue(Convert.ToByte(MissileReserveTankUnlocked));
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.IsMissileReserveTankFull).SetValue(Convert.ToByte(IsMissileReserveTankFull));
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.MetroidsKilled).SetValue(MetroidsKilled);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.GameDifficulty).SetValue((uint)GameDifficulty);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.SurfaceCollectedItemsCount).SetValue(SurfaceCollectedItemsCount);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area1CollectedItemsCount).SetValue(Area1CollectedItemsCount);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area2CollectedItemsCount).SetValue(Area2CollectedItemsCount);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area3CollectedItemsCount).SetValue(Area3CollectedItemsCount);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area4CollectedItemsCount).SetValue(Area4CollectedItemsCount);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area5CollectedItemsCount).SetValue(Area5CollectedItemsCount);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area6CollectedItemsCount).SetValue(Area6CollectedItemsCount);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area7CollectedItemsCount).SetValue(Area7CollectedItemsCount);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.MiscData, ChunkIDs.Area8CollectedItemsCount).SetValue(Area8CollectedItemsCount);
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.MiscData, ChunkIDs.MissionTime).SetValue((float)MissionTime.TotalSeconds);
        }

        #endregion Methods
    }
}
