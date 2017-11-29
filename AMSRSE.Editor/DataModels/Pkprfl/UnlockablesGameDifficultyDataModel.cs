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
    public class UnlockablesGameDifficultyDataModel : DataModelBase
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

        public static readonly DependencyProperty GameDifficultyProperty =
            DependencyProperty.Register("GameDifficulty", typeof(GameDifficulties), typeof(UnlockablesGameDifficultyDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty EnergyReserveTankUnlockedProperty =
            DependencyProperty.Register("EnergyReserveTankUnlocked", typeof(bool), typeof(UnlockablesGameDifficultyDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty IsEnergyReserveTankFullProperty =
            DependencyProperty.Register("IsEnergyReserveTankFull", typeof(bool), typeof(UnlockablesGameDifficultyDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty AeionEnergyReserveTankUnlockedProperty =
            DependencyProperty.Register("AeionEnergyReserveTankUnlocked", typeof(bool), typeof(UnlockablesGameDifficultyDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty IsAeionEnergyReserveTankFullProperty =
            DependencyProperty.Register("IsAeionEnergyReserveTankFull", typeof(bool), typeof(UnlockablesGameDifficultyDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty MissileReserveTankUnlockedProperty =
            DependencyProperty.Register("MissileReserveTankUnlocked", typeof(bool), typeof(UnlockablesGameDifficultyDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty IsMissileReserveTankFullProperty =
            DependencyProperty.Register("IsMissileReserveTankFull", typeof(bool), typeof(UnlockablesGameDifficultyDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty AmiiboFunctionalityUnlockedProperty =
            DependencyProperty.Register("AmiiboFunctionalityUnlocked", typeof(bool), typeof(UnlockablesGameDifficultyDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty HasAmiiboOptionUnlockedMsgDisplayedProperty =
            DependencyProperty.Register("HasAmiiboOptionUnlockedMsgDisplayed", typeof(bool), typeof(UnlockablesGameDifficultyDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty HasGameBeenCompletedProperty =
            DependencyProperty.Register("HasGameBeenCompleted", typeof(bool), typeof(UnlockablesGameDifficultyDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty Metroid2GalleryUnlockedProperty =
            DependencyProperty.Register("Metroid2GalleryUnlocked", typeof(bool), typeof(UnlockablesGameDifficultyDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty ConceptArtGalleryUnlockedProperty =
            DependencyProperty.Register("ConceptArtGalleryUnlocked", typeof(bool), typeof(UnlockablesGameDifficultyDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty SoundTestUnlockedProperty =
            DependencyProperty.Register("SoundTestUnlocked", typeof(bool), typeof(UnlockablesGameDifficultyDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty FusionModeUnlockedProperty =
            DependencyProperty.Register("FusionModeUnlocked", typeof(bool), typeof(UnlockablesGameDifficultyDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty ChozoMemoriesPage1PartsCountProperty =
            DependencyProperty.Register("ChozoMemoriesPage1PartsCount", typeof(uint), typeof(UnlockablesGameDifficultyDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty ChozoMemoriesPage2PartsCountProperty =
            DependencyProperty.Register("ChozoMemoriesPage2PartsCount", typeof(uint), typeof(UnlockablesGameDifficultyDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty ChozoMemoriesPage3PartsCountProperty =
            DependencyProperty.Register("ChozoMemoriesPage3PartsCount", typeof(uint), typeof(UnlockablesGameDifficultyDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty ChozoMemoriesPage4PartsCountProperty =
            DependencyProperty.Register("ChozoMemoriesPage4PartsCount", typeof(uint), typeof(UnlockablesGameDifficultyDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty ChozoMemoriesPage5PartsCountProperty =
            DependencyProperty.Register("ChozoMemoriesPage5PartsCount", typeof(uint), typeof(UnlockablesGameDifficultyDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty ChozoMemoriesPage6PartsCountProperty =
            DependencyProperty.Register("ChozoMemoriesPage6PartsCount", typeof(uint), typeof(UnlockablesGameDifficultyDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty ChozoMemoriesPage7PartsCountProperty =
            DependencyProperty.Register("ChozoMemoriesPage7PartsCount", typeof(uint), typeof(UnlockablesGameDifficultyDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty ChozoMemoriesPage8PartsCountProperty =
            DependencyProperty.Register("ChozoMemoriesPage8PartsCount", typeof(uint), typeof(UnlockablesGameDifficultyDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty ChozoMemoriesPage9PartsCountProperty =
            DependencyProperty.Register("ChozoMemoriesPage9PartsCount", typeof(uint), typeof(UnlockablesGameDifficultyDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty ChozoMemoriesPage10PartsCountProperty =
            DependencyProperty.Register("ChozoMemoriesPage10PartsCount", typeof(uint), typeof(UnlockablesGameDifficultyDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty ChozoMemoriesPage11PartsCountProperty =
            DependencyProperty.Register("ChozoMemoriesPage11PartsCount", typeof(uint), typeof(UnlockablesGameDifficultyDataModel), new PropertyMetadata(OnDataPropertyChanged));

        #endregion Dependency Properties

        #region Properties

        public GameDifficulties GameDifficulty
        {
            get { return (GameDifficulties)GetValue(GameDifficultyProperty); }
            set { SetValue(GameDifficultyProperty, value); }
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

        public bool AmiiboFunctionalityUnlocked
        {
            get { return (bool)GetValue(AmiiboFunctionalityUnlockedProperty); }
            set { SetValue(AmiiboFunctionalityUnlockedProperty, value); }
        }

        public bool HasAmiiboOptionUnlockedMsgDisplayed
        {
            get { return (bool)GetValue(HasAmiiboOptionUnlockedMsgDisplayedProperty); }
            set { SetValue(HasAmiiboOptionUnlockedMsgDisplayedProperty, value); }
        }

        public bool HasGameBeenCompleted
        {
            get { return (bool)GetValue(HasGameBeenCompletedProperty); }
            set { SetValue(HasGameBeenCompletedProperty, value); }
        }

        public bool Metroid2GalleryUnlocked
        {
            get { return (bool)GetValue(Metroid2GalleryUnlockedProperty); }
            set { SetValue(Metroid2GalleryUnlockedProperty, value); }
        }

        public bool ConceptArtGalleryUnlocked
        {
            get { return (bool)GetValue(ConceptArtGalleryUnlockedProperty); }
            set { SetValue(ConceptArtGalleryUnlockedProperty, value); }
        }

        public bool SoundTestUnlocked
        {
            get { return (bool)GetValue(SoundTestUnlockedProperty); }
            set { SetValue(SoundTestUnlockedProperty, value); }
        }

        public bool FusionModeUnlocked
        {
            get { return (bool)GetValue(FusionModeUnlockedProperty); }
            set { SetValue(FusionModeUnlockedProperty, value); }
        }

        public uint ChozoMemoriesPage1PartsCount
        {
            get { return (uint)GetValue(ChozoMemoriesPage1PartsCountProperty); }
            set { SetValue(ChozoMemoriesPage1PartsCountProperty, value); }
        }

        public uint ChozoMemoriesPage2PartsCount
        {
            get { return (uint)GetValue(ChozoMemoriesPage2PartsCountProperty); }
            set { SetValue(ChozoMemoriesPage2PartsCountProperty, value); }
        }

        public uint ChozoMemoriesPage3PartsCount
        {
            get { return (uint)GetValue(ChozoMemoriesPage3PartsCountProperty); }
            set { SetValue(ChozoMemoriesPage3PartsCountProperty, value); }
        }

        public uint ChozoMemoriesPage4PartsCount
        {
            get { return (uint)GetValue(ChozoMemoriesPage4PartsCountProperty); }
            set { SetValue(ChozoMemoriesPage4PartsCountProperty, value); }
        }

        public uint ChozoMemoriesPage5PartsCount
        {
            get { return (uint)GetValue(ChozoMemoriesPage5PartsCountProperty); }
            set { SetValue(ChozoMemoriesPage5PartsCountProperty, value); }
        }

        public uint ChozoMemoriesPage6PartsCount
        {
            get { return (uint)GetValue(ChozoMemoriesPage6PartsCountProperty); }
            set { SetValue(ChozoMemoriesPage6PartsCountProperty, value); }
        }

        public uint ChozoMemoriesPage7PartsCount
        {
            get { return (uint)GetValue(ChozoMemoriesPage7PartsCountProperty); }
            set { SetValue(ChozoMemoriesPage7PartsCountProperty, value); }
        }

        public uint ChozoMemoriesPage8PartsCount
        {
            get { return (uint)GetValue(ChozoMemoriesPage8PartsCountProperty); }
            set { SetValue(ChozoMemoriesPage8PartsCountProperty, value); }
        }

        public uint ChozoMemoriesPage9PartsCount
        {
            get { return (uint)GetValue(ChozoMemoriesPage9PartsCountProperty); }
            set { SetValue(ChozoMemoriesPage9PartsCountProperty, value); }
        }

        public uint ChozoMemoriesPage10PartsCount
        {
            get { return (uint)GetValue(ChozoMemoriesPage10PartsCountProperty); }
            set { SetValue(ChozoMemoriesPage10PartsCountProperty, value); }
        }

        public uint ChozoMemoriesPage11PartsCount
        {
            get { return (uint)GetValue(ChozoMemoriesPage11PartsCountProperty); }
            set { SetValue(ChozoMemoriesPage11PartsCountProperty, value); }
        }

        #endregion Properties

        #region Ctor

        public UnlockablesGameDifficultyDataModel(BMSSVFile bmssvFile) : base(bmssvFile)
        {

        }

        #endregion Ctor

        #region Methods

        protected override void LoadData(BMSSVFile bmssvFile)
        {
            GameDifficulty = (GameDifficulties)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.GameDifficulty)?.Value;
            EnergyReserveTankUnlocked = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.EnergyReserveTankUnlocked)?.Value);
            IsEnergyReserveTankFull = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.IsEnergyReserveTankFull)?.Value);
            AeionEnergyReserveTankUnlocked = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.AeionEnergyReserveTankUnlocked)?.Value);
            IsAeionEnergyReserveTankFull = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.IsAeionEnergyReserveTankFull)?.Value);
            MissileReserveTankUnlocked = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.MissileReserveTankUnlocked)?.Value);
            IsMissileReserveTankFull = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.IsMissileReserveTankFull)?.Value);
            AmiiboFunctionalityUnlocked = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.AmiiboFunctionalityUnlocked)?.Value);
            HasAmiiboOptionUnlockedMsgDisplayed = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.HasAmiiboOptionUnlockedMsgDisplayed)?.Value);
            HasGameBeenCompleted = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.HasGameBeenCompleted)?.Value);
            Metroid2GalleryUnlocked = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.Metroid2GalleryUnlocked)?.Value);
            ConceptArtGalleryUnlocked = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.ConceptArtGalleryUnlocked)?.Value);
            SoundTestUnlocked = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.SoundTestUnlocked)?.Value);
            FusionModeUnlocked = Convert.ToBoolean(bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.FusionModeUnlocked)?.Value);
            ChozoMemoriesPage1PartsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.ChozoMemoriesPage1PartsCount)?.Value;
            ChozoMemoriesPage2PartsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.ChozoMemoriesPage2PartsCount)?.Value;
            ChozoMemoriesPage3PartsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.ChozoMemoriesPage3PartsCount)?.Value;
            ChozoMemoriesPage4PartsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.ChozoMemoriesPage4PartsCount)?.Value;
            ChozoMemoriesPage5PartsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.ChozoMemoriesPage5PartsCount)?.Value;
            ChozoMemoriesPage6PartsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.ChozoMemoriesPage6PartsCount)?.Value;
            ChozoMemoriesPage7PartsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.ChozoMemoriesPage7PartsCount)?.Value;
            ChozoMemoriesPage8PartsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.ChozoMemoriesPage8PartsCount)?.Value;
            ChozoMemoriesPage9PartsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.ChozoMemoriesPage9PartsCount)?.Value;
            ChozoMemoriesPage10PartsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.ChozoMemoriesPage10PartsCount)?.Value;
            ChozoMemoriesPage11PartsCount = (uint)bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.ChozoMemoriesPage11PartsCount)?.Value;
        }

        public override void CommitChanges(BMSSVFile bmssvFile)
        {
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.GameDifficulty).SetValue((uint)GameDifficulty);
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.EnergyReserveTankUnlocked).SetValue(Convert.ToByte(EnergyReserveTankUnlocked));
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.IsEnergyReserveTankFull).SetValue(Convert.ToByte(IsEnergyReserveTankFull));
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.AeionEnergyReserveTankUnlocked).SetValue(Convert.ToByte(AeionEnergyReserveTankUnlocked));
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.IsAeionEnergyReserveTankFull).SetValue(Convert.ToByte(IsAeionEnergyReserveTankFull));
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.MissileReserveTankUnlocked).SetValue(Convert.ToByte(MissileReserveTankUnlocked));
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.IsMissileReserveTankFull).SetValue(Convert.ToByte(IsMissileReserveTankFull));
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.AmiiboFunctionalityUnlocked).SetValue(Convert.ToByte(AmiiboFunctionalityUnlocked));
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.HasAmiiboOptionUnlockedMsgDisplayed).SetValue(Convert.ToByte(HasAmiiboOptionUnlockedMsgDisplayed));
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.HasGameBeenCompleted).SetValue(Convert.ToByte(HasGameBeenCompleted));
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.Metroid2GalleryUnlocked).SetValue(Convert.ToByte(Metroid2GalleryUnlocked));
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.ConceptArtGalleryUnlocked).SetValue(Convert.ToByte(ConceptArtGalleryUnlocked));
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.SoundTestUnlocked).SetValue(Convert.ToByte(SoundTestUnlocked));
            bmssvFile.GetChunk<UInt8Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.FusionModeUnlocked).SetValue(Convert.ToByte(FusionModeUnlocked));
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.ChozoMemoriesPage1PartsCount).SetValue(ChozoMemoriesPage1PartsCount);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.ChozoMemoriesPage2PartsCount).SetValue(ChozoMemoriesPage2PartsCount);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.ChozoMemoriesPage3PartsCount).SetValue(ChozoMemoriesPage3PartsCount);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.ChozoMemoriesPage4PartsCount).SetValue(ChozoMemoriesPage4PartsCount);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.ChozoMemoriesPage5PartsCount).SetValue(ChozoMemoriesPage5PartsCount);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.ChozoMemoriesPage6PartsCount).SetValue(ChozoMemoriesPage6PartsCount);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.ChozoMemoriesPage7PartsCount).SetValue(ChozoMemoriesPage7PartsCount);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.ChozoMemoriesPage8PartsCount).SetValue(ChozoMemoriesPage8PartsCount);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.ChozoMemoriesPage9PartsCount).SetValue(ChozoMemoriesPage9PartsCount);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.ChozoMemoriesPage10PartsCount).SetValue(ChozoMemoriesPage10PartsCount);
            bmssvFile.GetChunk<UInt32Chunk>(BlockIDs.UnlockablesGameDifficulty, ChunkIDs.ChozoMemoriesPage11PartsCount).SetValue(ChozoMemoriesPage11PartsCount);

        }

        #endregion Methods
    }
}
