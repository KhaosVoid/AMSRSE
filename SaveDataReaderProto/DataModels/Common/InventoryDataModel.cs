using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveDataReaderProto.BinaryMercurySteamSave;
using System.Windows;
using SaveDataReaderProto.BinaryMercurySteamSave.Chunks;
using SaveDataReaderProto.BinaryMercurySteamSave.Enums;

namespace SaveDataReaderProto.DataModels.Common
{
    public class InventoryDataModel : DataModelBase
    {
        #region Dependency Properties

        public static readonly DependencyProperty MaxEnergyProperty =
            DependencyProperty.Register("MaxEnergy", typeof(uint), typeof(InventoryDataModel), new PropertyMetadata(OnMaxEnergyPropertyChanged));

        public static readonly DependencyProperty CurrentEnergyProperty =
            DependencyProperty.Register("CurrentEnergy", typeof(uint), typeof(InventoryDataModel), new PropertyMetadata(OnCurrentEnergyPropertyChanged));

        public static readonly DependencyProperty MaxAeionEnergyProperty =
            DependencyProperty.Register("MaxAeionEnergy", typeof(uint), typeof(InventoryDataModel), new PropertyMetadata(OnMaxAeionEnergyPropertyChanged));

        public static readonly DependencyProperty CurrentAeionEnergyProperty =
            DependencyProperty.Register("CurrentAeionEnergy", typeof(uint), typeof(InventoryDataModel), new PropertyMetadata(OnCurrentAeionEnergyPropertyChanged));

        public static readonly DependencyProperty MaxMissilesProperty =
            DependencyProperty.Register("MaxMissles", typeof(uint), typeof(InventoryDataModel), new PropertyMetadata(OnMaxMissilesPropertyChanged));

        public static readonly DependencyProperty CurrentMissilesProperty =
            DependencyProperty.Register("CurrentMissiles", typeof(uint), typeof(InventoryDataModel), new PropertyMetadata(OnCurrentMissilesPropertyChanged));

        public static readonly DependencyPropertyKey HasMissilesPropertyKey =
            DependencyProperty.RegisterReadOnly("HasMissiles", typeof(bool), typeof(InventoryDataModel), null);

        public static readonly DependencyProperty HasMissilesProperty =
            HasMissilesPropertyKey.DependencyProperty;

        public static readonly DependencyProperty MaxSuperMissilesProperty =
            DependencyProperty.Register("MaxSuperMissiles", typeof(uint), typeof(InventoryDataModel), new PropertyMetadata(OnMaxSuperMissilesPropertyChanged));

        public static readonly DependencyProperty CurrentSuperMissilesProperty =
            DependencyProperty.Register("CurrentSuperMissiles", typeof(uint), typeof(InventoryDataModel), new PropertyMetadata(OnCurrentSuperMissilesPropertyChanged));

        public static readonly DependencyPropertyKey HasSuperMissilesPropertyKey =
            DependencyProperty.RegisterReadOnly("HasSuperMissiles", typeof(bool), typeof(InventoryDataModel), null);

        public static readonly DependencyProperty HasSuperMissilesProperty =
            HasSuperMissilesPropertyKey.DependencyProperty;

        public static readonly DependencyProperty MaxPowerBombsProperty =
            DependencyProperty.Register("MaxPowerBombs", typeof(uint), typeof(InventoryDataModel), new PropertyMetadata(OnMaxPowerBombsPropertyChanged));

        public static readonly DependencyProperty CurrentPowerBombsProperty =
            DependencyProperty.Register("CurrentPowerBombs", typeof(uint), typeof(InventoryDataModel), new PropertyMetadata(OnCurrentPowerBombsPropertyChanged));

        public static readonly DependencyPropertyKey HasPowerBombsPropertyKey =
            DependencyProperty.RegisterReadOnly("HasPowerBombs", typeof(bool), typeof(InventoryDataModel), null);

        public static readonly DependencyProperty HasPowerBombsProperty =
            HasPowerBombsPropertyKey.DependencyProperty;

        public static readonly DependencyProperty HasScanPulseProperty =
            DependencyProperty.Register("HasScanPulse", typeof(bool), typeof(InventoryDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty HasLightningArmorProperty =
            DependencyProperty.Register("HasLightningArmor", typeof(bool), typeof(InventoryDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty HasBeamBurstProperty =
            DependencyProperty.Register("HasBeamBurst", typeof(bool), typeof(InventoryDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty HasPhaseDriftProperty =
            DependencyProperty.Register("HasPhaseDrift", typeof(bool), typeof(InventoryDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty HasChargeBeamProperty =
            DependencyProperty.Register("HasChargeBeam", typeof(bool), typeof(InventoryDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty HasWaveBeamProperty =
            DependencyProperty.Register("HasWaveBeam", typeof(bool), typeof(InventoryDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty HasSpazerBeamProperty =
            DependencyProperty.Register("HasSpazerBeam", typeof(bool), typeof(InventoryDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty HasPlasmaBeamProperty =
            DependencyProperty.Register("HasPlasmaBeam", typeof(bool), typeof(InventoryDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty HasIceBeamProperty =
            DependencyProperty.Register("HasIceBeam", typeof(bool), typeof(InventoryDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty HasGrappleBeamProperty =
            DependencyProperty.Register("HasGrappleBeam", typeof(bool), typeof(InventoryDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty HasMorphBallProperty =
            DependencyProperty.Register("HasMorphBall", typeof(bool), typeof(InventoryDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty HasMorphBallBombProperty =
            DependencyProperty.Register("HasMorphBallBomb", typeof(bool), typeof(InventoryDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty HasSpringBallProperty =
            DependencyProperty.Register("HasSpringBall", typeof(bool), typeof(InventoryDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty HasSpiderBallProperty =
            DependencyProperty.Register("HasSpiderBall", typeof(bool), typeof(InventoryDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty HasHighJumpBootsProperty =
            DependencyProperty.Register("HasHighJumpBoots", typeof(bool), typeof(InventoryDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty HasSpaceJumpProperty =
            DependencyProperty.Register("HasSpaceJump", typeof(bool), typeof(InventoryDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty HasScrewAttackProperty =
            DependencyProperty.Register("HasScrewAttack", typeof(bool), typeof(InventoryDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty HasVariaSuitProperty =
            DependencyProperty.Register("HasVariaSuit", typeof(bool), typeof(InventoryDataModel), new PropertyMetadata(OnSuitPropertyChanged));

        public static readonly DependencyProperty HasGravitySuitProperty =
            DependencyProperty.Register("HasGravitySuit", typeof(bool), typeof(InventoryDataModel), new PropertyMetadata(OnSuitPropertyChanged));

        public static readonly DependencyProperty TotalMetroidsProperty =
            DependencyProperty.Register("TotalMetroids", typeof(uint), typeof(InventoryDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty MetroidsKilledProperty =
            DependencyProperty.Register("MetroidsKilled", typeof(uint), typeof(InventoryDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty CurrentMetroidDNAProperty =
            DependencyProperty.Register("CurrentMetroidDNA", typeof(uint), typeof(InventoryDataModel), new PropertyMetadata(OnDataPropertyChanged));

        public static readonly DependencyProperty HasBabyMetroidProperty =
            DependencyProperty.Register("HasBabyMetroid", typeof(bool), typeof(InventoryDataModel), new PropertyMetadata(OnDataPropertyChanged));

        #endregion Dependency Properties

        #region Properties

        public uint MaxEnergy
        {
            get { return (uint)GetValue(MaxEnergyProperty); }
            set { SetValue(MaxEnergyProperty, value); }
        }

        public uint CurrentEnergy
        {
            get { return (uint)GetValue(CurrentEnergyProperty); }
            set { SetValue(CurrentEnergyProperty, value); }
        }

        public uint MaxAeionEnergy
        {
            get { return (uint)GetValue(MaxAeionEnergyProperty); }
            set { SetValue(MaxAeionEnergyProperty, value); }
        }

        public uint CurrentAeionEnergy
        {
            get { return (uint)GetValue(CurrentAeionEnergyProperty); }
            set { SetValue(CurrentAeionEnergyProperty, value); }
        }

        public uint MaxMissiles
        {
            get { return (uint)GetValue(MaxMissilesProperty); }
            set { SetValue(MaxMissilesProperty, value); }
        }

        public uint CurrentMissiles
        {
            get { return (uint)GetValue(CurrentMissilesProperty); }
            set { SetValue(CurrentMissilesProperty, value); }
        }

        public bool HasMissiles
        {
            get { return (bool)GetValue(HasMissilesProperty); }
            private set { SetValue(HasMissilesPropertyKey, value); }
        }

        public uint MaxSuperMissiles
        {
            get { return (uint)GetValue(MaxSuperMissilesProperty); }
            set { SetValue(MaxSuperMissilesProperty, value); }
        }

        public uint CurrentSuperMissiles
        {
            get { return (uint)GetValue(CurrentSuperMissilesProperty); }
            set { SetValue(CurrentSuperMissilesProperty, value); }
        }

        public bool HasSuperMissiles
        {
            get { return (bool)GetValue(HasSuperMissilesProperty); }
            private set { SetValue(HasSuperMissilesPropertyKey, value); }
        }

        public uint MaxPowerBombs
        {
            get { return (uint)GetValue(MaxPowerBombsProperty); }
            set { SetValue(MaxPowerBombsProperty, value); }
        }

        public uint CurrentPowerBombs
        {
            get { return (uint)GetValue(CurrentPowerBombsProperty); }
            set { SetValue(CurrentPowerBombsProperty, value); }
        }

        public bool HasPowerBombs
        {
            get { return (bool)GetValue(HasPowerBombsProperty); }
            private set { SetValue(HasPowerBombsPropertyKey, value); }
        }

        public bool HasScanPulse
        {
            get { return (bool)GetValue(HasScanPulseProperty); }
            set { SetValue(HasScanPulseProperty, value); }
        }

        public bool HasLightningArmor
        {
            get { return (bool)GetValue(HasLightningArmorProperty); }
            set { SetValue(HasLightningArmorProperty, value); }
        }

        public bool HasBeamBurst
        {
            get { return (bool)GetValue(HasBeamBurstProperty); }
            set { SetValue(HasBeamBurstProperty, value); }
        }

        public bool HasPhaseDrift
        {
            get { return (bool)GetValue(HasPhaseDriftProperty); }
            set { SetValue(HasPhaseDriftProperty, value); }
        }

        public bool HasChargeBeam
        {
            get { return (bool)GetValue(HasChargeBeamProperty); }
            set { SetValue(HasChargeBeamProperty, value); }
        }

        public bool HasWaveBeam
        {
            get { return (bool)GetValue(HasWaveBeamProperty); }
            set { SetValue(HasWaveBeamProperty, value); }
        }

        public bool HasSpazerBeam
        {
            get { return (bool)GetValue(HasSpazerBeamProperty); }
            set { SetValue(HasSpazerBeamProperty, value); }
        }

        public bool HasPlasmaBeam
        {
            get { return (bool)GetValue(HasPlasmaBeamProperty); }
            set { SetValue(HasPlasmaBeamProperty, value); }
        }

        public bool HasIceBeam
        {
            get { return (bool)GetValue(HasIceBeamProperty); }
            set { SetValue(HasIceBeamProperty, value); }
        }

        public bool HasGrappleBeam
        {
            get { return (bool)GetValue(HasGrappleBeamProperty); }
            set { SetValue(HasGrappleBeamProperty, value); }
        }

        public bool HasMorphBall
        {
            get { return (bool)GetValue(HasMorphBallProperty); }
            set { SetValue(HasMorphBallProperty, value); }
        }

        public bool HasMorphBallBomb
        {
            get { return (bool)GetValue(HasMorphBallBombProperty); }
            set { SetValue(HasMorphBallBombProperty, value); }
        }

        public bool HasSpringBall
        {
            get { return (bool)GetValue(HasSpringBallProperty); }
            set { SetValue(HasSpringBallProperty, value); }
        }

        public bool HasSpiderBall
        {
            get { return (bool)GetValue(HasSpiderBallProperty); }
            set { SetValue(HasSpiderBallProperty, value); }
        }

        public bool HasHighJumpBoots
        {
            get { return (bool)GetValue(HasHighJumpBootsProperty); }
            set { SetValue(HasHighJumpBootsProperty, value); }
        }

        public bool HasSpaceJump
        {
            get { return (bool)GetValue(HasSpaceJumpProperty); }
            set { SetValue(HasSpaceJumpProperty, value); }
        }

        public bool HasScrewAttack
        {
            get { return (bool)GetValue(HasScrewAttackProperty); }
            set { SetValue(HasScrewAttackProperty, value); }
        }

        public bool HasVariaSuit
        {
            get { return (bool)GetValue(HasVariaSuitProperty); }
            set { SetValue(HasVariaSuitProperty, value); }
        }

        public bool HasGravitySuit
        {
            get { return (bool)GetValue(HasGravitySuitProperty); }
            set { SetValue(HasGravitySuitProperty, value); }
        }

        public uint TotalMetroids
        {
            get { return (uint)GetValue(TotalMetroidsProperty); }
            set { SetValue(TotalMetroidsProperty, value); }
        }

        public uint MetroidsKilled
        {
            get { return (uint)GetValue(MetroidsKilledProperty); }
            set { SetValue(MetroidsKilledProperty, value); }
        }

        public uint CurrentMetroidDNA
        {
            get { return (uint)GetValue(CurrentMetroidDNAProperty); }
            set { SetValue(CurrentMetroidDNAProperty, value); }
        }

        public bool HasBabyMetroid
        {
            get { return (bool)GetValue(HasBabyMetroidProperty); }
            set { SetValue(HasBabyMetroidProperty, value); }
        }



        #endregion Properties

        #region Events

        public delegate void SuitChangedHandler(bool hasVariaSuit, bool hasGravitySuit);
        public event SuitChangedHandler OnSuitChanged;

        #endregion Events

        #region Ctor

        public InventoryDataModel(BMSSVFile bmssvFile) : base(bmssvFile)
        {

        }

        #endregion Ctor

        #region Dependency Property Callbacks

        private static void OnMaxEnergyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is InventoryDataModel idm && idm.MaxEnergy < idm.CurrentEnergy)
                idm.CurrentEnergy = idm.MaxEnergy;

            OnDataPropertyChanged(d, e);
        }

        private static void OnCurrentEnergyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is InventoryDataModel idm && idm.CurrentEnergy > idm.MaxEnergy)
                idm.CurrentEnergy = idm.MaxEnergy;

            OnDataPropertyChanged(d, e);
        }

        private static void OnMaxAeionEnergyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is InventoryDataModel idm && idm.MaxAeionEnergy < idm.CurrentAeionEnergy)
                idm.CurrentAeionEnergy = idm.MaxAeionEnergy;

            OnDataPropertyChanged(d, e);
        }

        private static void OnCurrentAeionEnergyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is InventoryDataModel idm && idm.CurrentAeionEnergy > idm.MaxAeionEnergy)
                idm.CurrentAeionEnergy = idm.MaxAeionEnergy;

            OnDataPropertyChanged(d, e);
        }

        private static void OnMaxMissilesPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is InventoryDataModel idm)
            {
                if (idm.MaxMissiles < idm.CurrentMissiles)
                    idm.CurrentMissiles = idm.MaxMissiles;

                idm.HasMissiles = idm.MaxMissiles > 0;
            }

            OnDataPropertyChanged(d, e);
        }

        private static void OnCurrentMissilesPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is InventoryDataModel idm && idm.CurrentMissiles > idm.MaxMissiles)
                idm.CurrentMissiles = idm.MaxMissiles;

            OnDataPropertyChanged(d, e);
        }

        private static void OnMaxSuperMissilesPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is InventoryDataModel idm)
            {
                if (idm.MaxSuperMissiles < idm.CurrentSuperMissiles)
                    idm.CurrentSuperMissiles = idm.MaxSuperMissiles;

                idm.HasSuperMissiles = idm.MaxSuperMissiles > 0;
            }

            OnDataPropertyChanged(d, e);
        }

        private static void OnCurrentSuperMissilesPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is InventoryDataModel idm && idm.CurrentSuperMissiles > idm.MaxSuperMissiles)
                idm.CurrentSuperMissiles = idm.MaxSuperMissiles;

            OnDataPropertyChanged(d, e);
        }

        private static void OnMaxPowerBombsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is InventoryDataModel idm)
            {
                if (idm.MaxPowerBombs < idm.CurrentPowerBombs)
                    idm.CurrentPowerBombs = idm.MaxPowerBombs;

                idm.HasPowerBombs = idm.MaxPowerBombs > 0;
            }

            OnDataPropertyChanged(d, e);
        }

        private static void OnCurrentPowerBombsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is InventoryDataModel idm && idm.CurrentPowerBombs > idm.MaxPowerBombs)
                idm.CurrentPowerBombs = idm.MaxPowerBombs;

            OnDataPropertyChanged(d, e);
        }

        private static void OnSuitPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is InventoryDataModel idm)
            {
                idm.OnSuitChanged?.Invoke(idm.HasVariaSuit, idm.HasGravitySuit);
            }

            OnDataPropertyChanged(d, e);
        }

        #endregion Dependency Property Callbacks

        #region Methods

        protected override void LoadData(BMSSVFile bmssvFile)
        {
            MaxEnergy = (uint)bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.MaxEnergy)?.Value;
            CurrentEnergy = (uint)bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.CurrentEnergy)?.Value;
            MaxAeionEnergy = (uint)bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.MaxAeionEnergy)?.Value;
            CurrentAeionEnergy = (uint)bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.CurrentAeionEnergy).Value;
            MaxMissiles = (uint)bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.MaxMissiles)?.Value;
            CurrentMissiles = (uint)bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.CurrentMissiles)?.Value;
            MaxSuperMissiles = (uint)bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.MaxSuperMissiles)?.Value;
            CurrentSuperMissiles = (uint)bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.CurrentSuperMissiles)?.Value;
            MaxPowerBombs = (uint)bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.MaxPowerBombs)?.Value;
            CurrentPowerBombs = (uint)bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.CurrentPowerBombs)?.Value;
            HasScanPulse = Convert.ToBoolean(bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.ScanPulse)?.Value);
            HasLightningArmor = Convert.ToBoolean(bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.LightningArmor)?.Value);
            HasBeamBurst = Convert.ToBoolean(bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.BeamBurst)?.Value);
            HasPhaseDrift = Convert.ToBoolean(bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.PhaseDrift)?.Value);
            HasChargeBeam = Convert.ToBoolean(bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.ChargeBeam)?.Value);
            HasWaveBeam = Convert.ToBoolean(bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.WaveBeam)?.Value);
            HasSpazerBeam = Convert.ToBoolean(bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.SpazerBeam)?.Value);
            HasPlasmaBeam = Convert.ToBoolean(bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.PlasmaBeam)?.Value);
            HasIceBeam = Convert.ToBoolean(bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.IceBeam)?.Value);
            HasGrappleBeam = Convert.ToBoolean(bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.GrappleBeam)?.Value);
            HasMorphBall = Convert.ToBoolean(bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.MorphBall)?.Value);
            HasMorphBallBomb = Convert.ToBoolean(bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.MorphBallBomb)?.Value);
            HasSpringBall = Convert.ToBoolean(bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.SpringBall)?.Value);
            HasSpiderBall = Convert.ToBoolean(bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.SpiderBall)?.Value);
            HasHighJumpBoots = Convert.ToBoolean(bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.HighJumpBoots)?.Value);
            HasSpaceJump = Convert.ToBoolean(bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.SpaceJump)?.Value);
            HasScrewAttack = Convert.ToBoolean(bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.ScrewAttack)?.Value);
            HasVariaSuit = Convert.ToBoolean(bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.VariaSuit)?.Value);
            HasGravitySuit = Convert.ToBoolean(bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.GravitySuit)?.Value);
            TotalMetroids = (uint)bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.TotalMetroids)?.Value;
            MetroidsKilled = (uint)bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.MetroidsKilled)?.Value;
            CurrentMetroidDNA = (uint)bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.CurrentMetroidDNA)?.Value;
            HasBabyMetroid = Convert.ToBoolean(bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.BabyMetroid)?.Value);
        }

        public override void CommitChanges(BMSSVFile bmssvFile)
        {
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.MaxEnergy).SetValue(MaxEnergy);
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.CurrentEnergy).SetValue(CurrentEnergy);
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.MaxAeionEnergy).SetValue(MaxAeionEnergy);
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.CurrentAeionEnergy).SetValue(CurrentAeionEnergy);
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.MaxMissiles).SetValue(MaxMissiles);
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.CurrentMissiles).SetValue(CurrentMissiles);
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.MaxSuperMissiles).SetValue(MaxSuperMissiles);
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.CurrentSuperMissiles).SetValue(CurrentSuperMissiles);
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.MaxPowerBombs).SetValue(MaxPowerBombs);
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.CurrentPowerBombs).SetValue(CurrentPowerBombs);
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.ScanPulse).SetValue(Convert.ToSingle(HasScanPulse));
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.LightningArmor).SetValue(Convert.ToSingle(HasLightningArmor));
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.BeamBurst).SetValue(Convert.ToSingle(HasBeamBurst));
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.PhaseDrift).SetValue(Convert.ToSingle(HasPhaseDrift));
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.ChargeBeam).SetValue(Convert.ToSingle(HasChargeBeam));
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.WaveBeam).SetValue(Convert.ToSingle(HasWaveBeam));
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.SpazerBeam).SetValue(Convert.ToSingle(HasSpazerBeam));
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.PlasmaBeam).SetValue(Convert.ToSingle(HasPlasmaBeam));
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.IceBeam).SetValue(Convert.ToSingle(HasIceBeam));
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.GrappleBeam).SetValue(Convert.ToSingle(HasGrappleBeam));
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.MorphBall).SetValue(Convert.ToSingle(HasMorphBall));
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.MorphBallBomb).SetValue(Convert.ToSingle(HasMorphBallBomb));
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.SpringBall).SetValue(Convert.ToSingle(HasSpringBall));
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.SpiderBall).SetValue(Convert.ToSingle(HasSpiderBall));
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.HighJumpBoots).SetValue(Convert.ToSingle(HasHighJumpBoots));
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.SpaceJump).SetValue(Convert.ToSingle(HasSpaceJump));
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.ScrewAttack).SetValue(Convert.ToSingle(HasScrewAttack));
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.VariaSuit).SetValue(Convert.ToSingle(HasVariaSuit));
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.GravitySuit).SetValue(Convert.ToSingle(HasGravitySuit));
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.TotalMetroids).SetValue(TotalMetroids);
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.MetroidsKilled).SetValue(MetroidsKilled);
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.CurrentMetroidDNA).SetValue(CurrentMetroidDNA);
            bmssvFile.GetChunk<Float32Chunk>(BlockIDs.Inventory, ChunkIDs.BabyMetroid).SetValue(Convert.ToSingle(HasBabyMetroid));
        }

        #endregion Methods
    }
}
